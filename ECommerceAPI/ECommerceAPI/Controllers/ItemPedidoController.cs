using ECommerceAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private IItensPedidoRepository _itemPedidoRepository;

        public ItemPedidoController(IItensPedidoRepository itensPedidoRepository)
        {
            _itemPedidoRepository = itensPedidoRepository;
        }

        [HttpGet]
        public IActionResult ListarItemPedidos()
        {
            return Ok(_itemPedidoRepository.ListarTodos());
        }

        //[HttpPost]
        //public IActionResult CadastrarItemPedido(ItemPedido item)
        //{
        //    _itemPedidoRepository.Cadastrar(item);

        //    return Created();
        //}
    }
}
