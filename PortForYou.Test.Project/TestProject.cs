using PortForYou.Test.Project.Helpers;
using PortForYouProject.Data.Repositories;
using PortForYouProject.Models;
using PortForYouProject.Models.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortForYou.Test.Project
{
    public class TestProject
    {
        [Fact]
        public async Task CreateProjectTest()
        {
            //Arrange
            HttpClient client = new();

            ProjectModel model = new()
            {
                Name = $"Projeto teste {Random.Shared.Next(1, 10000)}",
                Description = "Description",
                Manager = "Manager",
                Status = Status.Iniciado,
                Risk = Risk.Low,
                StartDate = DateTime.UtcNow,
                EstimatedDate = DateTime.UtcNow.AddDays(14),
                FinishDate= DateTime.UtcNow.AddDays(13),
                TotalBudget = Random.Shared.NextDouble(),
            };

            var body = ClientHelper.GenerateBody(model);

            //Act
            try
            {
                using var response = await client.PostAsync("https://localhost:44393/CreateProject", body);
                Assert.Contains(model.Name, await response.Content.ReadAsStringAsync());
            }
            catch
            {
                throw;
            }
        }

        [Fact]
        public async Task UpdateProjectTestWithFunctionaryAddiction()
        {
            //Arrange
            HttpClient client = new();
            ProjectRepository repository = new(new PortForYouProject.Data.Contexts.PortforyouContext());
            FunctionaryRepository functionaryRepository = new(new PortForYouProject.Data.Contexts.PortforyouContext());

            var test = await repository.GetList();
            var user = await functionaryRepository.GetList();
            List<int> list = new();

            list.Add(user.FirstOrDefault().IdFunctionary);

            ProjectUpdateModel model = new()
            {
                Name = $"Projeto teste {Random.Shared.Next(1, 10000)} atualizado",
                Description = "Description atualizada",
                Manager = "Manager",
                Status = Status.Iniciado,
                Risk = Risk.Low,
                StartDate = DateTime.UtcNow,
                EstimatedDate = DateTime.UtcNow,
                FinishDate = DateTime.UtcNow,
                TotalBudget = Random.Shared.NextDouble(),
                IdFuncionaries = list,
            };

            var body = ClientHelper.GenerateBody(model);

            //Act
            try
            {
                using var response = await client.PatchAsync($"https://localhost:44393/UpdateProject?id={test.FirstOrDefault().IdProject}", body);
                Assert.True(response.IsSuccessStatusCode);
            }
            catch
            {
                throw;
            }
        }

        [Fact]
        public async Task DeleteProjectTest()
        {
            //Arrange
            HttpClient client = new();
            ProjectRepository repository = new(new PortForYouProject.Data.Contexts.PortforyouContext());

            var projects = await repository.GetList();
            PortForYouProject.Data.Entities.Project test = new();

            foreach(var project in projects)
            {
                if (project.Status != 4)
                    test = project;
                else if (project.Status != 6 && project.Status != 4)
                    test = project;
                else if (project.Status != 7 && project.Status != 4 && project.Status != 6)
                    test = project;

            }

            if(test.IdProject == 0)
            {
                ProjectModel model = new()
                {
                    Name = $"Projeto teste {Random.Shared.Next(1, 10000)} atualizado",
                    Description = "Description atualizada",
                    Manager = "Manager",
                    Status = Status.Analise,
                    Risk = Risk.Low,
                    StartDate = DateTime.UtcNow,
                    EstimatedDate = DateTime.UtcNow,
                    FinishDate = DateTime.UtcNow,
                    TotalBudget = Random.Shared.NextDouble(),
                };

                var body = ClientHelper.GenerateBody(model);

                using var response = await client.PostAsync("https://localhost:44393/CreateProject", body);
                Assert.Contains(model.Name, await response.Content.ReadAsStringAsync());
            }

            //Act
            try
            {
                using var response = await client.DeleteAsync($"https://localhost:44393/DeleteProject?id={test.IdProject}");
                Assert.True(response.IsSuccessStatusCode);
            }
            catch
            {
                throw;
            }
        }

        [Fact]
        public async Task DeleteProjectTestWithTheRules()
        {
            //Arrange
            HttpClient client = new();
            ProjectRepository repository = new(new PortForYouProject.Data.Contexts.PortforyouContext());

            var projects = await repository.GetList();
            PortForYouProject.Data.Entities.Project test = new();

            foreach (var project in projects)
            {
                if (project.Status == 4)
                    test = project;
                else if (project.Status == 6 && project.Status == 4)
                    test = project;
                else if (project.Status == 7 && project.Status == 4 && project.Status == 6)
                    test = project;
            }

            //Act
            try
            {
                using var response = await client.DeleteAsync($"https://localhost:44393/DeleteProject?id={test.IdProject}");
                Assert.False(response.IsSuccessStatusCode);
            }
            catch
            {
                throw;
            }
        }
    }
}
