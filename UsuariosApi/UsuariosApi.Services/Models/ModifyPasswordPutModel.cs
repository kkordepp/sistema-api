using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Services.Models
{
    public class ModifyPasswordPutModel
    {
        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a senha atual.")]
        public string? SenhaAtual { get; set; }

        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a nova senha atual.")]
        public string? NovaSenha { get; set; }
    }
}