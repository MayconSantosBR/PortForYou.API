using Microsoft.EntityFrameworkCore;
using PortForYouProject.Data.Contexts;
using PortForYouProject.Data.Entities;
using PortForYouProject.Data.Repositories.Interfaces;
using System.Net;

namespace PortForYouProject.Data.Repositories
{
    public class FunctionaryRepository : IFunctionaryRepository
    {
        private readonly PortforyouContext context;
        public FunctionaryRepository(PortforyouContext context)
        {
            this.context = context;
        }

        public async Task Save(Functionary functionary)
        {
            try
            {
                await context.AddAsync(functionary);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Functionary> GetSingle(int id)
        {
            try
            {
                var owner = await context.Functionaries.AsNoTracking()
                    .Where(c => c.IdFunctionary == id)
                    .FirstOrDefaultAsync();

                if (owner == null)
                    throw new NullReferenceException();

                return owner;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Functionary>> GetList()
        {
            try
            {
                return await context.Functionaries.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var functionary = await context.Functionaries.AsNoTracking().FirstOrDefaultAsync(c => c.IdFunctionary == id);

                if (functionary == null)
                    throw new NullReferenceException();

                context.Functionaries.Remove(functionary);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Update(Functionary model)
        {
            try
            {
                context.Functionaries.Update(model);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
