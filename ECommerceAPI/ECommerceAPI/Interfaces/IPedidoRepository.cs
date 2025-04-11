using ECommerceAPI.Models;

namespace ECommerceAPI.Interfaces
{
    public interface IPedidoRepository
    {

        List<Pedido> ListarTodos();

        // Read
        Pedido BuscarPorId(int id);

        // Create
        void Cadastrar(Pedido pedido);

        // Update
        void Atualizar(int id, Pedido pedido);

        // Delete
        void Deletar(int id);

    }
}
