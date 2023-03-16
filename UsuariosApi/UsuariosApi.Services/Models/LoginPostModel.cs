using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Services.Models
{
    public class LoginPostModel
    {
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe o email de acesso.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a senha de acesso.")]
        public string? Senha { get; set; }
    }
}