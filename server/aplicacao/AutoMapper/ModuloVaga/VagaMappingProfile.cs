using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloContato.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVaga.Commands;
using ControleDeEstacionamento.Core.Aplicacao.ModuloVeiculo.Commands;
using ControleDeEstacionamento.Dominio.ModuloVaga;
using ControleDeEstacionamento.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Win32;
using System.Collections.Immutable;
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
