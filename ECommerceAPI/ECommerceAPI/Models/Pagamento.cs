using System;
using System.Collections.Generic;

namespace ECommerceAPI.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public string FormaPagamento { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime Data { get; set; }

    public int IdPedido { get; set; }

    // O EF por padrao, ele entende<nome da tabela>Id. É preciso seguir o padrão, ID<nome da tabela>
    public virtual Pedido? IdPedidoNavigation { get; set; } = null!;
}
