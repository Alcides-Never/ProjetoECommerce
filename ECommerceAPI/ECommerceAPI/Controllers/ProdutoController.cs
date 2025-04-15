﻿using ECommerceAPI.Context;
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
        public IActionResult CadastrarProduto(Produto prod)
        {
            // 1 - Coloco o Produto no Banco de Dados
            _produtoRepository.Cadastrar(prod);

            // 3 - Retorno o resultado
            // 201 - Created
            return Created();
        }

    }
}
