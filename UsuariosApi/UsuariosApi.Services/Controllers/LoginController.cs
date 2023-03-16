using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Repositories;
using UsuariosApi.Services.Models;
using UsuariosApi.Services.Security;

namespace UsuariosApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LoginPostModel model)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();
                var historicoRepository = new HistoricoRepository();

                var usuario = usuarioRepository.GetByEmailAndSenha(model.Email, model.Senha);

                if (usuario == null)
                    return StatusCode(401, new { mensagem = "Acesso negado, usuário inválido." });

                var accessToken = JwtTokenSecurity.GenerateToken(usuario);

                var historico = new Historico
                {
                    IdHistorico = Guid.NewGuid(),
                    DataHoraOperacao = DateTime.Now,
                    TipoOperacao = "Autenticação de usuário",
                    IdUsuario = usuario.IdUsuario
                };

                historicoRepository.Create(historico);

                return StatusCode(200, new
                {
                    mensagem = "Usuário autenticado com sucesso",
                    nome = usuario.Nome,
                    email = usuario.Email,
                    token = accessToken,
                    dataHora = DateTime.Now
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha ao autenticar: {e.Message}" });
            }
        }
    }
}