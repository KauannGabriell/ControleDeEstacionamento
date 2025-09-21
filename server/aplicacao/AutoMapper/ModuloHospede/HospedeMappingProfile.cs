using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloHospede.Commands;
using ControleDeEstacionamento.Dominio.ModuloHospede;
using System.Collections.Immutable;
namespace ControleDeEstacionamento.Core.Aplicacao.AutoMapper;
public class HospedeMappingProfile : Profile
{

    public HospedeMappingProfile()
    {
        //Commands / Results de Cadastro
        CreateMap<CadastrarHospedeCommand, Hospede>();
        CreateMap<Hospede, CadastrarHospedeResult>();

        // Queries / Results de Selecionar Contatos
        CreateMap<Hospede, SelecionarHospedesDto>();

        CreateMap<IEnumerable<Hospede>, SelecionarHospedesResult>()
            .ConvertUsing((src, dest, ctx) =>
            new SelecionarHospedesResult(
                src.Select(c => ctx.Mapper.Map<SelecionarHospedesDto>(c)).ToImmutableList()
                ?? ImmutableList<SelecionarHospedesDto>.Empty
            ));
    }

}
