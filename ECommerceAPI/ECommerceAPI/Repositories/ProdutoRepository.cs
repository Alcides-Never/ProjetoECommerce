    using ECommerceAPI.Context;
using ECommerceAPI.DTO;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

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
            // Encontro o produto que desejo
            Produto produtoEncontrado = _context.Produtos.Find(id);

            // Caso não encontre o produto, lanço um erro
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            produtoEncontrado.NomeProduto = produto.NomeProduto;
            produtoEncontrado.Descricao = produto.Descricao;
            produtoEncontrado.Preco = produto.Preco;
            produtoEncontrado.Categoria = produto.Categoria;
            produtoEncontrado.Imagem = produto.Imagem;
            produtoEncontrado.EstoqueDisponivel = produto.EstoqueDisponivel;

            _context.SaveChanges();
        }

        public Produto BuscarPorId(int id)
        {
            // ToList() - Pegar Varios
            // FirstorDefault - Tra o primeiro que encontrar ou NULL

            // Expressão Lambda, considerado como função sem corpo.
            // _context.Produtos - Acesse a tabela Produtos do Contexto
            // FirstorDefault - Pegue o primeiro que encontrar 
            // p => p.IdProduto == id
            // Para cada prodto P, me retorne aquele que tem o IdProduto igual ao id.
            return _context.Produtos.FirstOrDefault(p => p.IdProduto == id);
        }

        public void Cadastrar(CadastrarProdutoDTO produto)
        {

            Produto produtoCadastro = new Produto
            {
                NomeProduto = produto.NomeProduto,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                EstoqueDisponivel = produto.EstoqueDisponivel,
                Categoria = produto.Categoria,
                Imagem = produto.Imagem
            };

            _context.Produtos.Add(produtoCadastro);
            // 2 - Salvo a Alteração
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // 1 - Encontrar o que eu quero Excluir
            // Find - Procura pela chave primaria
            Produto produtoEncontrado = _context.Produtos.Find(id);

            // Caso não encontre o produto, lanço um erro
            if(produtoEncontrado == null)
            {
                throw new Exception();
            }
            // Caso eu encontre o produto, removo ele
            _context.Produtos.Remove(produtoEncontrado);

            // Salvo as alterações
            _context.SaveChanges();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
