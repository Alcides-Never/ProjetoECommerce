using ECommerceAPI.Context;
using ECommerceAPI.DTO;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Models;
using ECommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository _produtoRepository;

        // Injeção de Dependência
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        //GET
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }

        //Cadastrar Produto
        [HttpPost]
        public IActionResult CadastrarProduto(CadastrarProdutoDTO prod)
        {
            // 1 - Coloco o Produto no Banco de Dados
            _produtoRepository.Cadastrar(prod);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }

        // Buscar Produto por ID
        // /api/produtos -> padrao mas precisamos mudar
        // /api/produtos/1
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Produto produto = _produtoRepository.BuscarPorId(id);

            if(produto == null)
            {
                // 404 - Nao Encontrado
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Produto prod)
        {
            try
            {
                _produtoRepository.Atualizar(id, prod);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);

                // 204 - Deu certo!
                return NoContent();
            }
            // Caso dê erro 
            catch (Exception ex)
            {
                return NotFound("Produto não encontrado!");
            }
        }

    }
}
