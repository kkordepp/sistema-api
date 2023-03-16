namespace ProdutosApi.Application.Models
{
    public class ProdutoGetModel
    {
        public Guid IdProduto { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public CategoriaGetModel? Categoria { get; set; }
    }
}