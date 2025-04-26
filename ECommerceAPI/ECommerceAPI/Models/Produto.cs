using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ECommerceAPI.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string NomeProduto { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public int EstoqueDisponivel { get; set; }

    public string Categoria { get; set; } = null!;

    public string? Imagem { get; set; }

    [JsonIgnore]
    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}
