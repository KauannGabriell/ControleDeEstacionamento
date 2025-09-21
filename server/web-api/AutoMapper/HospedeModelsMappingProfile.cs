using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;
using ControleDeEstacionamento.Models.ModuloHospede;
using ControleDeEstacionamento.WebApi.Models.ModuloHospede;
using System.Collections.Immutable;

namespace ControleDeEstacionamento.WebApi.AutoMapper;
public class HospedeModelsMappingProfile : Profile
{
    public HospedeModelsMappingProfile()
    {
        CreateMap<CadastrarHospedeRequest, CadastrarHospedeCommand>();
        CreateMap<CadastrarHospedeResult, CadastrarHospedeResponse>();
        CreateMap<SelecionarHospedesRequest, SelecionarHospedesQuery>();

        CreateMap<SelecionarHospedesResult, SelecionarHospedesResponse>()
         .ConvertUsing((src, dest, ctx) => new SelecionarHospedesResponse(
             src.Veiculos.Count,
             src?.Veiculos.Select(c => ctx.Mapper.Map<SelecionarHospedesDto>(c)).ToImmutableList() ?? ImmutableList<SelecionarHospedesDto>.Empty
             ));

        CreateMap<Guid, ExcluirHospedeCommand>()
            .ConstructUsing(src => new ExcluirHospedeCommand(src));

    }
}
