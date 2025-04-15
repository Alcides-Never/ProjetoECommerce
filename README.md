## Passo 1 - Criaçao da Interface para ItemPedido
- Dentro da Interface para ItemPedido, criaçào dos métodos
- Criado método: ListarTodos, BuscarPorId, Cadastrar, Atualizar, Deletar.
## Passo 2 - Criação do Repository para o ItemPedido
- Dentro do Repository, criamos a classe correspondente e herdamos da Interface Repository
- Depois efetuamos a implementação da interface, criado e injetado o contexto.
- Dentro do método de listagem de item e devolvemos o return com a listagem
- No método Cadastrar, geramos a ação para adição e para salvar o pedido.
## Passo 3 - Dentro da Program.cs
- Efetuamos a configuração da injeção de dependencia do Repositorio ItemPedido
## Passo 4 - Criamos a Controller do ItemPedido
- Dentro da controller, fazemos a injeção do Repository.
- Criamos os métodos do CRUD.
- Criamos o GET para trara o listarItemPedido
- Depois criado o POST  para acionar o método para cadastrarItemPedido
