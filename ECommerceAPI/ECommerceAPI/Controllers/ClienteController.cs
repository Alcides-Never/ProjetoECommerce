using ECommerceAPI.Context;
using ECommerceAPI.DTO;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Models;
using ECommerceAPI.Repositories;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
        private IClienteRepository _clienteRepository;

        // Instanciar o PasswordService
        private PasswordService passwordService = new PasswordService();

        
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarCliente(CadastrarClienteDTO cliente)
        {
            //cliente.Senha = passwordService.HashPassword(cliente);

            _clienteRepository.Cadastrar(cliente);

            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Cliente cliente = _clienteRepository.BuscarPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, Cliente cliente)
        {
            try
            {
                _clienteRepository.Atualizar(id, cliente);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                _clienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound("Produto não encontrado!");
            }
        }

        [HttpGet("/buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(_clienteRepository.BuscarClientePorNome(nome));
        }

        //[HttpGet("{id}")]
        //public IActionResult BuscarPorId(int id)
        //{
        //    return Ok(_clienteRepository.BuscarPorId(id));
        //}


        // /api/cliente/vini@senai.br/senha123
        [HttpPost("login")]

        public IActionResult Login(LoginDTO login)
        {
            var cliente = _clienteRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if(cliente == null)
            {
                return Unauthorized("Email ou Senha inválidos!");
            }

            var tokenService = new TokenService();

            var token = tokenService.GenerateToken(cliente.Email);

            return Ok(token);
        }

    }
}
