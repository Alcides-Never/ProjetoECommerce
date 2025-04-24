namespace ECommerceAPI.DTO
{
    public class CadastrarPagamentoDTO
    {
        public string FormaPagamento { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime Data { get; set; }
        
        public int IdPedido { get; set; }

    }
}
