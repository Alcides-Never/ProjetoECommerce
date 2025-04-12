using ECommerceAPI.Context;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IPagamentoRepository _pagamentoRepository;

        //public PagamentoController(EcommerceContext context, IPagamentoRepository pagamentoRepository)
            public PagamentoController(EcommerceContext context)
        {
            _context = context;
            _pagamentoRepository =  new PagamentoRepository(_context);
        }

        // 1 - Definir o VERBO
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_pagamentoRepository.ListarTodos());
        }
    }
}
