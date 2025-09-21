using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;
using ControleDeEstacionamento.Models.ModuloHospede;
using ControleDeEstacionamento.WebApi.Models.ModuloHospede;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstacionamento.Controllers;

[ApiController]
[Route("[controller]")]
public class HospedeController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<SelecionarHospedesResponse>> SelecionarRegistros(
        [FromQuery] SelecionarHospedesRequest? request
    )
    {
        var query = mapper.Map<SelecionarHospedesQuery>(request);

        var result = await mediator.Send(query);

        if (result.IsFailed)
            return BadRequest();

        var response = mapper.Map<SelecionarHospedesResponse>(result.Value);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CadastrarHospedeResponse>> CadastrarRegistro(CadastrarHospedeRequest request)
    {
        var command = mapper.Map<CadastrarHospedeCommand>(request);

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


        var response = mapper.Map<CadastrarHospedeResponse>(result.Value);

        return Created(string.Empty, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<ExcluirHospedeResponse>> ExcluirRegistro(Guid id)
    {
        var command = mapper.Map<ExcluirHospedeCommand>(id);

        var result = await mediator.Send(command);

        if (result.IsFailed)
            return BadRequest();

        return NoContent();
    }
}




