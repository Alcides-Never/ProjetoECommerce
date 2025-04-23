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
            // Localizo o cliente
            Cliente clienteEncontrado = _context.Clientes.Find(id);
            
            // Caso náo localizado, lanço o erro
            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("CLiente não encontrado");
            }

            // No entity framework opera de forma diferente, não irá funcionar se tentarmos o atualizar atribuindo o novo ao antigo, é preciso que seja feito campo a campo conforme abaixo
            clienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            clienteEncontrado.Email = cliente.Email;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Endereco = cliente.Endereco;
            clienteEncontrado.Senha = cliente.Senha;
            clienteEncontrado.DataCadastro = cliente.DataCadastro;

            _context.SaveChanges();
        }   


        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            // Encontrar o cliente que possui o email e senha fornecidos
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);

            return clienteEncontrado;
        }

        public Cliente BuscarPorId(int id)
        {
            // Qualquer método que vai me trazer apenas 1 cliente, usaremos o First or Default
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
            // FirstorDefault - Pesquisa por qualquer campo.
            // Find - Pesquisa SOMENTE pela chave primária (ID)
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            // 2 - Condicional caso não encontre o cliente, lanço um erro.
            if (clienteEncontrado == null)
            {
                throw new ArgumentNullException("Cliente não encontrado");
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
