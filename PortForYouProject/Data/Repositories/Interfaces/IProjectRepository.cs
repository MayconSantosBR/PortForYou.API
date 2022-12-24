using PortForYouProject.Data.Entities;

namespace PortForYouProject.Data.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task Save(Project project);
        Task<Project> GetSingle(int id);
        Task<List<Project>> GetList();
        Task<bool> Delete(int id);
        Task<bool> Update(Project model);
    }
}