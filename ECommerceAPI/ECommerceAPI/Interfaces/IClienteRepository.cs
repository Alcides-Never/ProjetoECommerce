using ECommerceAPI.Models;

namespace ECommerceAPI.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();

        // Read
        Cliente BuscarPorId(int id);
        Cliente BuscarPorEmailSenha(string email, string senha);

        // Create
        void Cadastrar(Cliente cliente);

        // Update
        void Atualizar(int id, Cliente cliente);

        // Delete
        void Deletar(int id);
    }
}
