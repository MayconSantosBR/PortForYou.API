using AutoMapper;
using PortForYouProject.Data.Entities;

namespace PortForYouProject.Models.Profiles
{
    public class FunctionaryProfile : Profile
    {
        public FunctionaryProfile()
        {
            CreateMap<Functionary, FunctionaryModel>();
            CreateMap<FunctionaryModel, Functionary>();
            CreateMap<Functionary, Functionary>()
                .ForMember(src => src.IdFunctionary, c => c.Ignore());
        }
    }
}
