using AutoMapper;
using PortForYouProject.Data.Entities;
using PortForYouProject.Data.Repositories.Interfaces;
using PortForYouProject.Models;
using PortForYouProject.Services.Intefaces;

namespace PortForYouProject.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository repository;
        private readonly IFunctionaryRepository functionaryRepository;
        private readonly IMapper msvc;
        public ProjectService(IProjectRepository repository, IMapper mapper, IFunctionaryRepository functionaryRepository)
        {
            this.repository = repository;
            this.msvc = mapper;
            this.functionaryRepository = functionaryRepository;
        }

        public async Task SaveModel(ProjectModel model)
        {
            try
            {
                var project = msvc.Map<Project>(model);
                await repository.Save(project);
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Project>> GetProjectList()
        {
            try
            {
                return await repository.GetList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Project> GetProject(int id)
        {
            try
            {
                return await repository.GetSingle(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteProject(int id)
        {
            try
            {
                return await repository.Delete(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateProject(int id, ProjectUpdateModel model)
        {
            try
            {
                var project = await repository.GetSingle(id);

                var newProject = msvc.Map<Project>(model);

                foreach (var func in model.IdFuncionaries)
                    newProject.IdFunctionaries.Add(await functionaryRepository.GetSingle(func));

                newProject.IdProject = project.IdProject;
                await repository.Update(newProject);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
