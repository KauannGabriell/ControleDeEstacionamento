using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloContato.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using ControleDeEstacionamento.Models.ModuloVeiculo;
using ControleDeEstacionamento.WebApi.Models.ModuloVeiculo;
using System.Collections.Immutable;

namespace ControleDeEstacionamento.WebApi.AutoMapper;
public class VeiculoModelsMappingProfile : Profile
{
    public VeiculoModelsMappingProfile()
    {
        CreateMap<CadastrarVeiculoRequest, CadastrarVeiculoCommand>();
        CreateMap<CadastrarVeiculoResult, CadastrarVeiculoResponse>();
        CreateMap<SelecionarVeiculosRequest, SelecionarVeiculosQuery>();

        CreateMap<SelecionarVeiculosResult, SelecionarVeiculosResponse>()
            .ConvertUsing((src, dest, ctx) => new SelecionarVeiculosResponse(

                src.Veiculos.Count, 
                src?.Veiculos.Select(c => ctx.Mapper.Map<SelecionarVeiculosDto>(c)).ToImmutableList() ?? ImmutableList<SelecionarVeiculosDto>.Empty
                ));


        CreateMap<Guid, ExcluirVeiculoCommand>()
            .ConstructUsing(src => new ExcluirVeiculoCommand(src));

    }
}
