using ECommerceAPI.Models;

namespace ECommerceAPI.Interfaces
{
    // Fachada - Que métodos vou usar o repositório, o que ele pode fazer - Analogia, fachada do que uma pessoa pode fazer.
    public interface IProdutoRepository
    {
        // R- Read (Leitura)
        // Retorno
        List<Produto> ListarTodos();
        // Recebe um identificador, e retorna o produto correspondente
        Produto BuscarPorId(int id);

        // C - Create (Cadastro)
        void Cadastrar(Produto produto);

        // U - Update (Atualização)
        // Recebe um identificador para encontrar o produto, e recebe o Produto novo para substituir o Antigo
        void Atualizar(int id, Produto produto);

        // D - Delete (Deleção)
        // Recebo o identificador de quem quero excluir
        void Deletar(int id);
    }

}
