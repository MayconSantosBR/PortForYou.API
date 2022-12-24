using AutoMapper;
using PortForYouProject.Models.Profiles;

namespace PortForYouProject.Models
{
    public class MapperService
    {
        public MapperService()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FunctionaryProfile>();
                cfg.AddProfile<ProjectProfile>();
            });

            configuration.CreateMapper();
        }
    }
}
