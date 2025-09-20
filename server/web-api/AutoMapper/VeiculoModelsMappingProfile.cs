using AutoMapper;
using ControleDeEstacionamento.WebApi.Models.ModuloVeiculo;
using eAgenda.Core.Aplicacao.ModuloContato.Commands;
using eAgenda_WebApi.Models.Modulo_Contato;
using System.Collections.Immutable;

namespace ControleDeEstacionamento.WebApi.AutoMapper;
public class VeiculoModelsMappingProfile : Profile
{
    public VeiculoModelsMappingProfile()
    {
        CreateMap<CadastrarVeiculoRequest, CadastrarVeiculoCommand>();
        CreateMap<CadastrarVeiculoResult, CadastrarVeiculoResponse>();

        CreateMap<(Guid, EditarContatoRequest), EditarContatoCommand>()
            .ConvertUsing(src => new EditarContatoCommand(
                src.Item1,
                src.Item2.Nome,
                src.Item2.Telefone,
                src.Item2.Email,
                src.Item2.Empresa,
                src.Item2.Cargo
                ));


        CreateMap<EditarContatoResult, EditarContatoResponse>();

        CreateMap<SelecionarContatosRequest, SelecionarContatosQuery>();

        CreateMap<SelecionarContatosResult, SelecionarContatosResponse>()
            .ConvertUsing((src, dest, ctx) => new SelecionarContatosResponse(

                src.Contatos.Count, 
                src?.Contatos.Select(c => ctx.Mapper.Map<SelecionarContatosDto>(c)).ToImmutableList() ?? ImmutableList<SelecionarContatosDto>.Empty
                ));

        CreateMap<SelecionarContatoPorIdResult, SelecionarContatosPorIdResponse>();

        CreateMap<Guid, SelecionarContatoPorIdQuery>()
            .ConvertUsing(src =>  new SelecionarContatoPorIdQuery(src));

        CreateMap<Guid, ExcluirContatoCommand>()
           .ConstructUsing(src => new ExcluirContatoCommand(src));

        CreateMap<SelecionarContatoPorIdResult, SelecionarContatosPorIdResponse>()
              .ConvertUsing(src => new SelecionarContatosPorIdResponse(
                src.Id,
                src.Nome,
                src.Email,
                src.Telefone,
                src.Empresa,
                src.Cargo,
                (src.Compromissos ?? ImmutableList.Create<DetalhesCompromissoContatoDto>()) 
                .Select(c => new DetalhesCompromissoContatoDto(
                    c.Assunto,
                    c.Data,
                    c.HoraInicio,
                    c.HoraTermino
                    )).ToImmutableList()

            ));

    }
}
