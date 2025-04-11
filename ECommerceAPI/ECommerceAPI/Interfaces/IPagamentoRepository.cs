using ECommerceAPI.Models;

namespace ECommerceAPI.Interfaces
{
    public interface IPagamentoRepository
    {
        List<Pagamento> ListarTodos();

        // Read
        Pagamento BuscarPorId(int id);

        // Create
        void Cadastrar(Pagamento pagamento);

        // Update
        void Atualizar(int id, Pagamento pagamento);

        // Delete
        void Deletar(int id);

    }
}
