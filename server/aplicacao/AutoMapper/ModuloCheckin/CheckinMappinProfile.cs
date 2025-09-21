using AutoMapper;
using ControleDeEstacionamento.Core.Aplicacao.ModuloCheckin.Commands;
using ControleDeEstacionamento.Dominio.ModuloCheckin;
namespace ControleDeEstacionamento.Core.Aplicacao.AutoMapper;
public class CheckinMappingProfile : Profile
{

    public CheckinMappingProfile()
    {
        CreateMap<RealizarCheckinCommand, Checkin>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())              
            .ForMember(dest => dest.Veiculo, opt => opt.Ignore())         
            .ForMember(dest => dest.Vaga, opt => opt.Ignore())            
            .ForMember(dest => dest.Hospede, opt => opt.Ignore())          
            .ForMember(dest => dest.Ticket, opt => opt.Ignore())           
            .ForMember(dest => dest.DataEntrada, opt => opt.Ignore())      
            .ForMember(dest => dest.Status, opt => opt.Ignore());        

        CreateMap<Checkin, RealizarCheckinResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }

}
