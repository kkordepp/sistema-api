using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Repositories;
using UsuariosApi.Services.Models;

namespace UsuariosApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ModifyPasswordController : ControllerBase
    {
        [HttpPut]
        public IActionResult Put(ModifyPasswordPutModel model)
        {
            try
            {
                var email = User.Identity.Name;

                var usuarioRepository = new UsuarioRepository();

                var usuario = usuarioRepository.GetByEmailAndSenha(email, model.SenhaAtual);

                if (usuario == null)

                    return StatusCode(400, new { mensagem = "Usuário não encontrado, verifique a senha atual informada." });

                usuario.Senha = model.NovaSenha;
                usuarioRepository.Update(usuario);

                var historico = new Historico
                {
                    IdHistorico = Guid.NewGuid(),
                    DataHoraOperacao = DateTime.Now,
                    TipoOperacao = "Alteração de senha de acesso",
                    IdUsuario = usuario.IdUsuario
                };

                var historicoRepository = new HistoricoRepository();
                historicoRepository.Create(historico);

                return StatusCode(200, new { mensagem = "Senha atualizada com sucesso." });
            }

            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha ao autenticar: {e.Message}" });
            }
        }
    }
}