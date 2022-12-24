using PortForYouProject.Data.Entities;

namespace PortForYouProject.Data.Repositories.Interfaces
{
    public interface IFunctionaryRepository
    {
        Task Save(Functionary functionary);
        Task<Functionary> GetSingle(int id);
        Task<List<Functionary>> GetList();
        Task<bool> Delete(int id);
        Task<bool> Update(Functionary model);
    }
}