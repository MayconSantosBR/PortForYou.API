using PortForYouProject.Data.Entities;
using AutoMapper;
using PortForYouProject.Services.Intefaces;

namespace PortForYouProject.Models.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectModel>();
            CreateMap<ProjectModel, Project>().ForMember(c => c.IdFunctionaries, c => c.Ignore());
            CreateMap<ProjectUpdateModel, Project>().ForMember(c => c.IdFunctionaries, c => c.Ignore());
            CreateMap<Project, Project>()
                .ForMember(src => src.IdProject, c => c.Ignore());
        }
    }
}
