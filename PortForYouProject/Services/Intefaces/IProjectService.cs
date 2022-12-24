using PortForYouProject.Data.Entities;
using PortForYouProject.Models;

namespace PortForYouProject.Services.Intefaces
{
    public interface IProjectService
    {
        Task SaveModel(ProjectModel model);
        Task<List<Project>> GetProjectList();
        Task<Project> GetProject(int id);
        Task<bool> UpdateProject(int id, ProjectUpdateModel model);
        Task<bool> DeleteProject(int id);
    }
}