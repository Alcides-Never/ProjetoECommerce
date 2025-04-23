using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ECommerceAPI.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateOnly DataPedido { get; set; }

    public string Status { get; set; } = null!;

    public decimal? ValorTotal { get; set; }

    public int IdCliente { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();

    // Aqui comentamos para evitar um erro de loop por Json ou adicionamos o Json
    [JsonIgnore]
    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
