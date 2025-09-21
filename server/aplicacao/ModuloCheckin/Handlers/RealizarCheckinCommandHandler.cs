using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.Compartilhado;
using ControleDeEstacionamento.Core.Aplicacao.ModuloCheckin.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Core.Dominio.ModuloHospede;
using ControleDeEstacionamento.Core.Dominio.ModuloTicket;
using ControleDeEstacionamento.Core.Dominio.ModuloVaga;
using ControleDeEstacionamento.Core.Dominio.ModuloVeiculo;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloCheckin.Cadastrar;

public class RealizarCheckinCommandHandler(
    IValidator<RealizarCheckinCommand> validator,
    IMapper mapper,
    IRepositorioCheckin repositorioCheckin,
    IRepositorioTicket repositorioTicket,
    IRepositorioVeiculo repositorioVeiculo,
    IRepositorioHospede repositorioHospede,
    IRepositorioVaga repositorioVaga,
    ILogger<RealizarCheckinCommandHandler> logger,
    IUnitOfWork unitOfWork
) : IRequestHandler<RealizarCheckinCommand, Result<RealizarCheckinResult>>

{
    public async Task<Result<RealizarCheckinResult>> Handle(RealizarCheckinCommand command, CancellationToken cancellationToken)
    {
        var resultadoValidacao = await validator.ValidateAsync(command);

        if (!resultadoValidacao.IsValid)
        {
            var erros = resultadoValidacao.Errors.Select(e => e.ErrorMessage);
            var erroFormatado = ResultadosErro.RequisicaoInvalidaErro(erros);

            return Result.Fail(erroFormatado);
        }
        var registros = await repositorioCheckin.SelecionarRegistrosAsync();

        var checkin = mapper.Map<Checkin>(command);

        var vaga = await repositorioVaga.SelecionarRegistroPorIdAsync(command.vagaId);

        if (vaga is null)
        {
            return Result.Fail(ResultadosErro.VagaNaoEncontradaErro(command.vagaId));
        }

        Hospede? hospede = null;

        if (command.hospedeId.HasValue)
        {
            hospede = await repositorioHospede.SelecionarRegistroPorIdAsync(command.hospedeId.Value);
        }

        if (vaga.Veiculo is null)
        {
            var veiculo = await repositorioVeiculo.SelecionarRegistroPorIdAsync(command.veiculoId);
            vaga.Veiculo = veiculo;

            await repositorioVaga.EditarAsync(vaga.Id, vaga);

            var tickets = await repositorioTicket.SelecionarRegistrosAsync();
            var ultimoId = tickets.Max(t => t.IdentificadorUnicoSequencial);

            Ticket ticket = null;

            if (hospede != null)
            {
                 ticket  = checkin.GerarTicket(vaga, DateTime.Now, hospede, veiculo, ultimoId);
            }

            else
            {
                 ticket = checkin.GerarTicket(vaga, DateTime.Now, null, veiculo, ultimoId);
            }

            checkin.Ticket = ticket;
            checkin.Vaga = vaga;
            checkin.Status = StatusCheckin.Ativo;
            checkin.Veiculo = veiculo;
            checkin.DataEntrada = DateTime.Now;

            if(hospede is not null)
            checkin.Hospede = hospede;
        }

        else
        {
            return Result.Fail(ResultadosErro.VagaOcupadaErro(vaga.Id));
        }

        try
        {
                await repositorioCheckin.CadastrarAsync(checkin);

                await unitOfWork.CommitAsync();

                var result = mapper.Map<RealizarCheckinResult>(checkin);
                return Result.Ok(result);


            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();

                logger.LogError(ex, "Erro ao cadastrar checkin {Checkin}", command);

                return Result.Fail(ResultadosErro.ExcecaoInternaErro(ex));
            }
    }
}
