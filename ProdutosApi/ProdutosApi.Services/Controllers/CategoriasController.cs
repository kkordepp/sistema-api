using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Models;

namespace ProdutosApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        [ProducesResponseType(200, Type = typeof(List<CategoriaGetModel>))]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = _categoriaAppService.GetAll();
                return StatusCode(200, lista);
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha: {e.Message}" });
            }
        }
    }
}