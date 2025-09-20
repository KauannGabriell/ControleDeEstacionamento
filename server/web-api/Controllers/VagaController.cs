using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloContato.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using ControleDeEstacionamento.Models.ModuloVeiculo;
using ControleDeEstacionamento.WebApi.Models.ModuloVaga;
using ControleDeEstacionamento.WebApi.Models.ModuloVeiculo;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstacionamento.Controllers;

[ApiController]
[Route("[controller]")]
public class VagaController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<CadastrarVagaResponse>> CadastrarContato(CadastrarVagaRequest request)
    {
        var command = mapper.Map<CadastrarVagaCommand>(request);

        var result = await mediator.Send(command);

        if (result.IsFailed)
        {
            if (result.HasError(e => e.HasMetadata("TipoErro", m => m.Equals("RequisicaoInvalida"))))
            {
                var errosDeValidacao = result.Errors
                    .SelectMany(e => e.Reasons.OfType<IError>())
                    .Select(e => e.Message);

                return BadRequest(errosDeValidacao);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        var response = mapper.Map<CadastrarVagaResponse>(result.Value);

        return Created(string.Empty, response);
    }

}




