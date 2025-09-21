using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstacionamento.Controllers;

[ApiController]
[Route("[controller]")]
public class CheckinController(IMediator mediator, IMapper mapper) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<RealizarCheckinResponse>> RealizarCheckin(RealizarCheckinRequest request)
    {
        var command = mapper.Map<RealizarCheckinCommand>(request);

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


        var response = mapper.Map<RealizarCheckinResponse>(result.Value);

        return Created(string.Empty, response);
    }
}




