using Microsoft.AspNetCore.Mvc;
using PortForYouProject.Models;
using PortForYouProject.Services;
using PortForYouProject.Services.Intefaces;

namespace PortForYouProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService service)
        {
            _logger = logger;
            this.projectService = service;
        }

        [HttpPost("CreateProject")]
        public async Task<IActionResult> Create([FromBody] ProjectModel model)
        {
            try
            {
                await projectService.SaveModel(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
        [HttpGet("GetProjectList")]
        public async Task<IActionResult> GetProjectAsync()
        {
            try
            {
                return Ok(await projectService.GetProjectList());
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteProject([FromQuery] int id)
        {
            try
            {
                if (await projectService.DeleteProject(id))
                    return Ok();
                else
                    return BadRequest("Houve algum erro para deletar");
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
        [HttpPatch("UpdateProject")]
        public async Task<IActionResult> UpdateProject([FromQuery] int id, [FromBody] ProjectUpdateModel model)
        {
            try
            {
                if (await projectService.UpdateProject(id, model))
                    return Ok();
                else
                    return BadRequest("Houve algum erro para atualizar");
            }
            catch (NullReferenceException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
    }
}
