using AutoMapper;
using PortForYouProject.Data.Entities;
using PortForYouProject.Data.Repositories.Interfaces;
using PortForYouProject.Models;
using PortForYouProject.Services.Intefaces;

namespace PortForYouProject.Services
{
    public class FunctionaryService : IFunctionaryService
    {
        private readonly IFunctionaryRepository repository;
        private readonly IMapper msvc;
        public FunctionaryService(IFunctionaryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.msvc = mapper;
        }

        public async Task SaveModel(FunctionaryModel model)
        {
            try
            {
                var functionary = msvc.Map<Functionary>(model);
                await repository.Save(functionary);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Functionary> GetFunctionary(int id)
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
        public async Task<List<Functionary>> GetFunctionaryList()
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
        public async Task<bool> DeleteFunctionary(int id)
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
        public async Task<bool> UpdateFunctionary(int id, FunctionaryModel model)
        {
            try
            {
                var functionary = await repository.GetSingle(id);
                var newFunctionary = msvc.Map<Functionary>(model);
                newFunctionary.IdFunctionary = functionary.IdFunctionary;
                await repository.Update(newFunctionary);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
