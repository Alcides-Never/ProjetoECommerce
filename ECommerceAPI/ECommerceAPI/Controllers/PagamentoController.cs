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
    public class PagamentoController : ControllerBase
    {
        private IPagamentoRepository _pagamentoRepository;

            public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }


        
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pagamentoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarPagamento(CadastrarPagamentoDTO pagamento)
        {
            _pagamentoRepository.Cadastrar(pagamento);
            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorID(int id)
        {
            Pagamento pagamento = _pagamentoRepository.BuscarPorId(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return Ok(pagamento);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPagamento(int id, Pagamento pagamento)
        {
            try
            {
                _pagamentoRepository.Atualizar(id, pagamento);
                return Ok(pagamento);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _pagamentoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound("Pagamento não enontrado");
            }
        }
    }
}
