using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Repositories;
using UsuariosApi.Messages.Services;
using UsuariosApi.Services.Models;

namespace UsuariosApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoverController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(PasswordRecoverPostModel model)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();
                var usuario = usuarioRepository.GetByEmail(model.Email);

                if (usuario != null)
                {
                    #region Gerando uma nova senha para o usuário

                    var faker = new Faker();
                    var novaSenha = $"{faker.Internet.Password()}";

                    #endregion

                    #region Enviando um email para o usuário contendo a nova senha

                    var subject = "Recuperação de Senha - API de Usuários";
                    var body = @$"
                            <h3>Olá {usuario.Nome}</h3>
                            <p>Uma nova senha foi gerada com sucesso para o seu usuário.</p>
                            <p>Acesse a aplicação com a senha: <strong>{novaSenha}</strong></p>
                            <p>Após acessar a aplicação, você poderá alterar a senha para outra de sua preferência.</p>
                            <br/>
                            <p>Att, <br/>Equipe API</p>
                        ";

                    var emailMessageService = new EmailMessageService();
                    emailMessageService.SendMessage(usuario.Email, subject, body);

                    #endregion

                    #region Atualizando a senha no banco de dados

                    usuario.Senha = novaSenha;
                    usuarioRepository.Update(usuario);

                    #endregion

                    #region Gravando um histório para o usuário

                    var historico = new Historico
                    {
                        IdHistorico = Guid.NewGuid(),
                        DataHoraOperacao = DateTime.Now,
                        TipoOperacao = "Recuperação de Senha",
                        IdUsuario = usuario.IdUsuario
                    };

                    var historicoRepository = new HistoricoRepository();
                    historicoRepository.Create(historico);

                    #endregion

                    return StatusCode(200, new { mensagem = "Recuperação de senha realizada com sucesso." });
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Usuário não encontrado. Verifique o email informado." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}