using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloCheckin.Commands;
using ControleDeEstacionamento.WebApi.Models.ModuloCheckin;

namespace ControleDeEstacionamento.WebApi.AutoMapper;
public class CheckinModelsMappingProfile : Profile
{
    public CheckinModelsMappingProfile()
    {
        CreateMap<RealizarCheckinRequest, RealizarCheckinCommand>();
        CreateMap<RealizarCheckinResult, RealizarCheckinResponse>();
    }
}
