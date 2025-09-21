using ControleDeEstacionamento.Core.Aplicacao.Compartilhado;
using ControleDeEstacionamento.Core.Aplicacao.ModuloCheckin.Commands;
using ControleDeEstacionamento.Core.Dominio.Compartilhado;
using ControleDeEstacionamento.Core.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Core.Dominio.ModuloHospede;
using ControleDeEstacionamento.Core.Dominio.ModuloTicket;
using ControleDeEstacionamento.Core.Dominio.ModuloVaga;
using ControleDeEstacionamento.Core.Dominio.ModuloVeiculo;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using ControleDeEstacionamento.Dominio.ModuloTicket;
using FluentResults;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ControleDeEstacionamento.Core.Aplicacao.ModuloCheckin.Cadastrar
{
    public class RealizarCheckinCommandHandler(
        IValidator<RealizarCheckinCommand> validator,
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
                return Result.Fail(ResultadosErro.RequisicaoInvalidaErro(erros));
            }

            try
            {
                var vaga = await repositorioVaga.SelecionarRegistroPorIdAsync(command.vagaId);
                if (vaga == null)
                    return Result.Fail(ResultadosErro.VagaNaoEncontradaErro(command.vagaId));

                if (vaga.Veiculo != null)
                    return Result.Fail(ResultadosErro.VagaOcupadaErro(vaga.Id));

                var veiculo = await repositorioVeiculo.SelecionarRegistroPorIdAsync(command.veiculoId);
                if (veiculo == null)
                {
                }

                Hospede hospede = null;
                if (command.hospedeId.HasValue)
                {
                    hospede = await repositorioHospede.SelecionarRegistroPorIdAsync(command.hospedeId.Value);
                    if (hospede == null)
                    {
                    }
                }

                vaga.Veiculo = veiculo;
                await repositorioVaga.EditarAsync(vaga.Id, vaga);

                var tickets = await repositorioTicket.SelecionarRegistrosAsync();
                var ultimoId = tickets.Select(t => t.IdentificadorUnicoSequencial).DefaultIfEmpty(0).Max();

                var ticket = new Ticket
                {
                    Id = Guid.NewGuid(),
                    Vaga = vaga,
                    Veiculo = veiculo,
                    Hospede = hospede,
                    DataEntrada = DateTime.UtcNow
                };
                ticket.GerarIdentificadorUnicoSequencial(ultimoId);

                var checkin = new Checkin
                {
                    Id = Guid.NewGuid(),
                    Vaga = vaga,
                    Veiculo = veiculo,
                    Hospede = hospede,
                    Ticket = ticket,
                    Status = StatusCheckin.Ativo,
                    DataEntrada = DateTime.UtcNow
                };

                await repositorioCheckin.CadastrarAsync(checkin);
                await unitOfWork.CommitAsync();

                var result = new RealizarCheckinResult(checkin.Id);
          

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
}
