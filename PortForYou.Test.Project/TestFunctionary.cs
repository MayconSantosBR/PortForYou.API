using Newtonsoft.Json;
using PortForYouProject.Data.Repositories.Interfaces;
using PortForYouProject.Models;
using PortForYouProject.Services;
using PortForYouProject.Services.Intefaces;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using PortForYouProject.Data.Repositories;
using PortForYouProject.Data.Contexts;
using PortForYou.Test.Project.Helpers;

namespace PortForYou.Test.Project
{
    public class TestFunctionary
    {
        [Fact]
        public async Task CreateFunctionaryTest()
        {
            //Arrange
            HttpClient client = new();

            FunctionaryModel model = new()
            {
                Name = $"Testador {Random.Shared.Next(1, 15000)}",
                Ocuppation = "Testador",
            };

            var body = ClientHelper.GenerateBody(model);

            //Act
            try
            {
                using var response = await client.PostAsync("https://localhost:44393/CreateFunctionary", body);
                Assert.Contains(model.Name, await response.Content.ReadAsStringAsync());
            }
            catch
            {
                throw;
            }
        }

        [Fact]
        public async Task UpdateFunctionaryTest()
        {
            //Arrange
            HttpClient client = new();
            FunctionaryRepository repository = new(new PortforyouContext());
            var test = await repository.GetList();

            FunctionaryModel model = new()
            {
                Name = $"Testador {Random.Shared.Next(1, 15000)}",
                Ocuppation = "Testador atualizado",
            };

            var body = ClientHelper.GenerateBody(model);

            //Act
            try
            {
                using var response = await client.PatchAsync($"https://localhost:44393/UpdateFunctionary?id={test.FirstOrDefault().IdFunctionary}", body);
                Assert.True(response.IsSuccessStatusCode);
            }
            catch
            {
                throw;
            }
        }

        [Fact]
        public async Task DeleteFunctionaryTest()
        {
            //Arrange
            HttpClient client = new();
            FunctionaryRepository repository = new(new PortforyouContext());
            var test = await repository.GetList();

            if (test == null)
                throw new Exception("Nenhum usuário para deletar");

            //Act
            try
            {
                using var response = await client.DeleteAsync($"https://localhost:44393/DeleteFunctionary?id={test.FirstOrDefault().IdFunctionary}");
                Assert.True(response.IsSuccessStatusCode);
            }
            catch
            {
                throw;
            }
        }
    }
}