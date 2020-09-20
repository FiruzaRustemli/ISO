using AutoMapper;
using ISOCertificate.Models;
using ISOCertificate.ViewModels.RequestInputModels;
namespace ISOCertificate.Profiles
{
    public class InvestigateProfile : Profile
    {
        public InvestigateProfile()
        {
            CreateMap<InvestigateCreateViewModel, Investigate>()
                .ForMember(x => x.Materials, opt => opt.Ignore())
                .ForMember(x => x.InvestigateLines, opt => opt.Ignore())
                .ForMember(x => x.Images, opt => opt.Ignore()).ReverseMap();

            CreateMap<InvestigateCreateIncidentViewModel, Investigate>()
                 .ForMember(x => x.Images, opt => opt.Ignore())
               .ForMember(x => x.NominateLine, opt => opt.Ignore())
               .ForMember(x => x.EventLines, opt => opt.Ignore())
               .ForMember(x => x.EvaluationLines, opt => opt.Ignore())
               .ForMember(x => x.PreventLines, opt => opt.Ignore()).ReverseMap();

            CreateMap<InvestigateLineCreateViewModel, InvestigateLine>().ReverseMap();
            CreateMap<ImageCreateViewModel, Image>().ReverseMap();
            CreateMap<MaterialCreateViewModel, Material>().ReverseMap();
            CreateMap<PreventLineCreateViewModel, PreventLine>().ReverseMap();
            CreateMap<EvaluationLineCreateViewModel, EvaluationLine>().ReverseMap();
            CreateMap<EventLineCreateViewModel, EventLine>().ReverseMap();
            CreateMap<NominateLineCreateViewModel, NominateLine>().ReverseMap();



        }
    }
}
