using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using ControleDeEstacionamento.WebApi.Models.ModuloVaga;

namespace ControleDeEstacionamento.WebApi.AutoMapper;
public class VagaModelsMappingProfile : Profile
{
    public VagaModelsMappingProfile()
    {
        CreateMap<CadastrarVagaRequest, CadastrarVagaCommand>();
        CreateMap<CadastrarVagaResult, CadastrarVagaResponse>();
    }
}
