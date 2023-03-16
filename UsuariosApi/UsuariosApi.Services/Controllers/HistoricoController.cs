using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Repositories;
using UsuariosApi.Services.Models;

namespace UsuariosApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();
                var historicoRepository = new HistoricoRepository();

                var email = User.Identity.Name;

                var usuario = usuarioRepository.GetByEmail(email);

                var historicos = historicoRepository.GetAllByUsuario(usuario.IdUsuario);

                var model = new List<HistoricoGetModel>();
                foreach (var item in historicos)
                {
                    model.Add(new HistoricoGetModel
                    {
                        DataHoraOperacao = item.DataHoraOperacao,
                        TipoOperacao = item.TipoOperacao
                    });
                }

                return StatusCode(200, model);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha ao consultar histórico: {e.Message}" });
            }
        }
    }
}