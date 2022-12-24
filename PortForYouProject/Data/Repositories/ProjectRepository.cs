using Microsoft.EntityFrameworkCore;
using PortForYouProject.Data.Contexts;
using PortForYouProject.Data.Entities;
using PortForYouProject.Data.Repositories.Interfaces;
using System.Net;

namespace PortForYouProject.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PortforyouContext context;
        public ProjectRepository(PortforyouContext context)
        {
            this.context = context;
        }

        public async Task Save(Project project)
        {
            try
            {
                await context.AddAsync(project);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Project> GetSingle(int id)
        {
            try
            {
                var project = await context.Projects.AsNoTracking()
                    .Where(c => c.IdProject == id)
                    .FirstOrDefaultAsync();

                if (project == null)
                    throw new NullReferenceException();

                return project;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Project>> GetList()
        {
            try
            {
                return await context.Projects.ToListAsync();
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
                var project = await context.Projects.AsNoTracking().FirstOrDefaultAsync(c => c.IdProject == id);

                if (project == null)
                    throw new NullReferenceException();

                if (project.Status == 4 || project.Status == 6 || project.Status == 7)
                    throw new Exception("Projeto não pode ser mais removido no status atual");

                var associations = context.AssociatedProjects.FromSqlRaw($"delete from \"associatedProject\" ap where ap.\"idProject\" = (select ap.\"idProject\" from \"associatedProject\" ap where ap.\"idProject\" = {id})");

                context.Projects.Remove(project);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Update(Project model)
        {
            try
            {
                if(model.Status == 4)
                    model.StartDate = DateTime.UtcNow;

                if(model.Status == 7)
                    model.FinishDate = DateTime.UtcNow;

                context.Projects.Update(model);
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
