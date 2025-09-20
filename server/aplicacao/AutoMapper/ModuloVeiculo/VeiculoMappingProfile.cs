using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloContato.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Win32;
using System.Collections.Immutable;
namespace ControleDeEstacionamento.Core.Aplicacao.AutoMapper;
public class VeiculoMappingProfile : Profile
{

    public VeiculoMappingProfile()
    {
        //Commands / Results de Cadastro
        CreateMap<CadastrarVeiculoCommand, Veiculo >();
        CreateMap<Veiculo, CadastrarVeiculoResult>();

        //Commands / Results de Edição

        //Queries / Results de Seleção por Id



        // Queries / Results de Selecionar Contatos
        CreateMap<Veiculo, SelecionarVeiculosDto>();

        CreateMap<IEnumerable<Veiculo>, SelecionarVeiculosResult>()
            .ConvertUsing((src, dest, ctx) =>
            new SelecionarVeiculosResult(
                src.Select(c => ctx.Mapper.Map<SelecionarVeiculosDto>(c)).ToImmutableList()
                ?? ImmutableList<SelecionarVeiculosDto>.Empty
            ));

      
    }

}
