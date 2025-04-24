namespace ECommerceAPI.DTO
{
    public class CadastrarProdutoDTO
    {
        public string NomeProduto { get; set; } = null!;

        public string? Descricao { get; set; }

        public decimal Preco { get; set; }

        public int EstoqueDisponivel { get; set; }

        public string Categoria { get; set; } = null!;

        public string? Imagem { get; set; }
    }
}
