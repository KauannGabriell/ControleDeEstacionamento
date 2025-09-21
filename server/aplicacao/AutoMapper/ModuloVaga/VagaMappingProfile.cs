using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using ControleDeEstacionamento.Dominio.ModuloVaga;
namespace ControleDeEstacionamento.Aplicacao.AutoMapper.ModuloVaga;
public class VagaMappingProfile : Profile
{

    public VagaMappingProfile()
    {
        //Commands / Results de Cadastro
        CreateMap<CadastrarVagaCommand, Vaga>();
 



        //Commands / Results de Edição

        //Queries / Results de Seleção por Id

        // Queries / Results de Selecionar Vagas

    }

}
