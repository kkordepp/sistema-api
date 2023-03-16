using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Application.Models
{
    public class ProdutoPutModel
    {
        [Required(ErrorMessage = "Informe o id do produto.")]
        public Guid? IdProduto { get; set; }

        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o nome do produto.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage = "Informe a categoria do produto.")]
        public Guid? IdCategoria { get; set; }
    }
}