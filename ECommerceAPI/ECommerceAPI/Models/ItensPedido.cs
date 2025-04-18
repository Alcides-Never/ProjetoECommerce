using System;
using System.Collections.Generic;

namespace ECommerceAPI.Models;

public partial class ItensPedido
{
    public int IdItem { get; set; }

    public int Quantidade { get; set; }

    public int IdPedido { get; set; }

    public int IdProduto { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;
}
