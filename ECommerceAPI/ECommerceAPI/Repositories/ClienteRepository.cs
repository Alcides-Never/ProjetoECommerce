using ECommerceAPI.Context;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Models;

namespace ECommerceAPI.Repositories
{
    // 1 - Herdar da Interface
    // 2 - Implementar a Interface
    // 3 - Injetar o contexto
    public class ClienteRepository : IClienteRepository
    {

        private readonly EcommerceContext _context;

        public ClienteRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Cliente cliente)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);
            
            if (clienteEncontrado == null)
            {
                throw new Exception();
            }

            clienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            clienteEncontrado.Email = cliente.Email;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Endereco = cliente.Endereco;
            clienteEncontrado.DataCadastro = cliente.DataCadastro;

        }


        public Cliente BuscarPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // 1 - Encontrar o cliente por ID
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            // 2 - Condicional caso não encontre
            if (clienteEncontrado == null)
            {
                throw new Exception();
            }

            // 3 - Caso Ok
            _context.Clientes.Remove(clienteEncontrado);

            // 4 - Salva a alteração
            _context.SaveChanges();
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.ToList();
        }
    }
}
