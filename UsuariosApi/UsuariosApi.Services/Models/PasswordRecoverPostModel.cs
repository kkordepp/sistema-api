using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Services.Models
{
    public class PasswordRecoverPostModel
    {
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o email de acesso.")]
        public string? Email { get; set; }
    }
}