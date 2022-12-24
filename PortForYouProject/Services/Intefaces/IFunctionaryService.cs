using PortForYouProject.Data.Entities;
using PortForYouProject.Models;

namespace PortForYouProject.Services.Intefaces
{
    public interface IFunctionaryService
    {
        Task SaveModel(FunctionaryModel model);
        Task<Functionary> GetFunctionary(int id);
        Task<List<Functionary>> GetFunctionaryList();
        Task<bool> DeleteFunctionary(int id);
        Task<bool> UpdateFunctionary(int id, FunctionaryModel model);
    }
}