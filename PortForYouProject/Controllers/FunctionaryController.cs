using Microsoft.AspNetCore.Mvc;
using PortForYouProject.Models;
using PortForYouProject.Services;
using PortForYouProject.Services.Intefaces;

namespace PortForYouProject.Controllers
{
    public class FunctionaryController : Controller
    {
        private readonly ILogger<FunctionaryController> _logger;
        private readonly IFunctionaryService functionaryService;

        public FunctionaryController(ILogger<FunctionaryController> logger, IFunctionaryService functionaryService)
        {
            _logger = logger;
            this.functionaryService = functionaryService;
        }

        [HttpPost("CreateFunctionary")]
        public async Task<IActionResult> Create([FromBody] FunctionaryModel model)
        {
            try
            {
                await functionaryService.SaveModel(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
        [HttpGet("GetFunctionaryById")]
        public async Task<IActionResult> GetFunctionary(int id)
        {
            try
            {
                return Ok(await functionaryService.GetFunctionary(id));
            }
            catch (NullReferenceException e)
            {
                return NotFound("Usuário não encontrado");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
        [HttpGet("GetFunctionaryList")]
        public async Task<IActionResult> GetFunctionaryList()
        {
            try
            {
                return Ok(await functionaryService.GetFunctionaryList());
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
        [HttpDelete("DeleteFunctionary")]
        public async Task<IActionResult> DeleteFunctionary([FromQuery] int id)
        {
            try
            {
                if (await functionaryService.DeleteFunctionary(id))
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
        [HttpPatch("UpdateFunctionary")]
        public async Task<IActionResult> UpdateFunctionary([FromQuery] int id, [FromBody] FunctionaryModel model)
        {
            try
            {
                if (await functionaryService.UpdateFunctionary(id, model))
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
