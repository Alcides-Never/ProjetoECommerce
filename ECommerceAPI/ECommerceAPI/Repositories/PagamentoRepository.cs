using ECommerceAPI.Context;
using ECommerceAPI.DTO;
using ECommerceAPI.Interfaces;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly EcommerceContext _context;

        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pagamento pagamento)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }
            
            pagamentoEncontrado.FormaPagamento = pagamento.FormaPagamento;
            pagamentoEncontrado.Status = pagamento.Status;
            pagamentoEncontrado.Data = pagamento.Data;
            
            _context.SaveChanges();
        }

        public Pagamento BuscarPorId(int id)
        {
            return _context.Pagamentos.FirstOrDefault(pag => pag.IdPagamento == id);
        }

        public void Cadastrar(CadastrarPagamentoDTO pagamento)
        {

            Pagamento pagamentoCadastrado = new Pagamento
            {
                FormaPagamento = pagamento.FormaPagamento,
                Status = pagamento.Status,
                Data = pagamento.Data,
                IdPedido = pagamento.IdPedido
            };

            _context.Pagamentos.Add(pagamentoCadastrado);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pagamentos.Remove(pagamentoEncontrado);

            _context.SaveChanges();

        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.Include(p => p.IdPedidoNavigation).ToList();
        }
    }
}

