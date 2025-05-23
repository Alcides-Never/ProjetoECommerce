﻿using ECommerceAPI.Context;
using ECommerceAPI.DTO;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Models;
using ECommerceAPI.Services;
using ECommerceAPI.ViewModels;

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

        public List<Cliente> BuscarClientePorNome(string nome)
        {

            // Where - Traz todos que atendem uma condição
            var listaClientes = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();

            return listaClientes;
        }

        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            // Encontrar o cliente que possui o email e senha fornecidos
            // Procuro por EMAIL
            var clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email);

            // Caso não encontre, retorno nulo
            if(clienteEncontrado == null)
                return null;

            var passwordService = new PasswordService();

            // Verifica se a senha do usuario gera o mesmo Hash
            var resultado = passwordService.VerificarSenha(clienteEncontrado, senha);

            if(resultado == true) return clienteEncontrado;

            return null;

        }

        public Cliente BuscarPorId(int id)
        {
            // Qualquer método que vai me trazer apenas 1 cliente, usaremos o First or Default
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(CadastrarClienteDTO cliente)
        {

            var passwordService = new PasswordService();

            
            Cliente clienteCadastrado = new Cliente
            {
                NomeCompleto = cliente.NomeCompleto,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                Senha = cliente.Senha,
                DataCadastro = cliente.DataCadastro,
            };

            clienteCadastrado.Senha = passwordService.HashPassword(clienteCadastrado);

            _context.Clientes.Add(clienteCadastrado);

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

        public List<ListarClienteViewModel> ListarTodos()
        {
            return _context.Clientes
                // Permite que eu selecione quais campos eu quero pegar
                .Select(
                    c => new ListarClienteViewModel
                    {
                        IdCliente = c.IdCliente,
                        NomeCompleto = c.NomeCompleto,
                        Email = c.Email,
                        Telefone = c.Telefone,
                        Endereco = c.Endereco
                    }
                )
                .OrderBy(c => c.NomeCompleto)
                .ToList();
        }
    }
}
