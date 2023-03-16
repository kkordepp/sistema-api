using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Models;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ProdutosApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        public IActionResult Post(ProdutoPostModel model)
        {
            try
            {
                _produtoAppService.Create(model);

                return StatusCode(201, new { mensagem = "Produto cadastrado com sucesso." });
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

        [HttpPut]
        public IActionResult Put(ProdutoPutModel model)
        {
            try
            {
                _produtoAppService.Update(model);

                return StatusCode(200, new { mensagem = "Produto atualizado com sucesso." });
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

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoAppService.Delete(id);

                return StatusCode(200, new { mensagem = "Produto excluído com sucesso." });
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

        [ProducesResponseType(200, Type = typeof(List<ProdutoGetModel>))]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = _produtoAppService.GetAll();
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

        [ProducesResponseType(200, Type = typeof(ProdutoGetModel))]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var model = _produtoAppService.GetById(id);
                return StatusCode(200, model);
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