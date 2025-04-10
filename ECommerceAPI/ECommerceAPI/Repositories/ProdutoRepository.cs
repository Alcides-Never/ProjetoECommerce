using ECommerceAPI.Context;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Models;

namespace ECommerceAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        // Métodos que acessam o Banco de Dados

        // Injetar o Context
        // Injeção de Dependência
        private readonly EcommerceContext _context;

        // ctor
        // Método construtor - Toda classe pode ter um  
        // Quando criar um objeto o que eu preciso ter?
        public ProdutoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
