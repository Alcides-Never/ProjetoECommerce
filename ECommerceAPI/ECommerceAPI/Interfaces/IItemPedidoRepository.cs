using ECommerceAPI.Models;

namespace ECommerceAPI.Interfaces
{
    public interface IItensPedidoRepository
    {
        List<ItensPedido> ListarTodos();

        // Read
        ItensPedido BuscarPorId(int id);

        // Create
        void Cadastrar(ItensPedido itemPedido);

        // Update
        void Atualizar(int id, ItensPedido itemPedido);

        // Delete
        void Deletar(int id);
    }
}
