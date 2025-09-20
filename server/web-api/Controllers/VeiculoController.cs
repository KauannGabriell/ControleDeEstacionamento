using AutoMapper;
using ControleDeEstacionamento.Models.ModuloVeiculo;
using ControleDeEstacionamento.WebApi.Models.ModuloVeiculo;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstacionamento.Controllers;

[ApiController]
[Route("[controller]")]
public class VeiculoController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<SelecionarVeiculosResponse>> SelecionarRegistros(
        [FromQuery] SelecionarVeiculosRequest? request
    )
    {
        var query = mapper.Map<SelecionarVeiculosQuery>(request);

        var result = await mediator.Send(query);

        if (result.IsFailed)
            return BadRequest();

        var response = mapper.Map<SelecionarContatosResponse>(result.Value);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CadastrarVeiculoResponse>> CadastrarContato(CadastrarVeiculoRequest request)
    {
        var command = mapper.Map<CadastrarVeiculoCommand>(request);

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

            // Http 500 é o erro genérico do servidor
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        var response = mapper.Map<CadastrarVeiculoResponse>(result.Value);

        //Estado http 201
        return Created(string.Empty, response);
    }

}




