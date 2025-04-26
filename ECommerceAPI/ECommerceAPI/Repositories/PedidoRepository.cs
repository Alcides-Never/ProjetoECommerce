using System.Runtime.Serialization.Formatters;
using ECommerceAPI.Context;
using ECommerceAPI.DTO;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        // base
        private readonly EcommerceContext _context;

        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }
        // trecho final
        public void Atualizar(int id, Pedido pedido)
        {
            Pedido pedidoEncontrado = _context.Pedidos.Find();
            
            if (pedidoEncontrado == null )
            {
                throw new Exception();
            }

            pedidoEncontrado.DataPedido = pedido.DataPedido;
            pedidoEncontrado.Status = pedido.Status;
            //pedidoEncontrado.

        }

        public Pedido BuscarPorId(int id)
        {
            return _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);
        }

        public void Cadastrar(CadastrarPedidoDTO pedidoDto)
        {
            // Cadastrar o Pedido
            // Crio uma variável pedido, para guardar as informações do pedido
            var pedido = new Pedido
            {
                DataPedido = pedidoDto.DataPedido,
                Status = pedidoDto.Status,
                IdCliente = pedidoDto.IdCliente,
                ValorTotal = pedidoDto.ValorTotal
            };

            _context.Pedidos.Add(pedido);

            _context.SaveChanges();

            // Cadastrar os ItensPedido
            // Para cada Produto, eu crio um ItemPedido

            for (int i = 0; i < pedidoDto.Produtos.Count; i++)
            {
                var produto = _context.Produtos.Find(pedidoDto.Produtos[i]);

                // TODO: Lançar erro se produto não existe

                // Crio uma variável ItemPedido
                var itemPedido = new ItensPedido
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0
                };

                // Jogo no banco de dados e salvo
                _context.ItensPedidos.Add(itemPedido);

                _context.SaveChanges();

            }
        }

        public void Deletar(int id)
        {
            Pedido pedidoEncontrado = _context.Pedidos.Find(id);

            if(pedidoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pedidos.Remove(pedidoEncontrado);

            _context.SaveChanges();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos
                .Include(p => p.ItensPedidos)
                .ThenInclude(p => p.IdProdutoNavigation)
                .ToList();
        }
    }
}
