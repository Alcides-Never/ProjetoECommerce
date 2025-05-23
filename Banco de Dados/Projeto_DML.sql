USE ECommerce;
-- DML - Inserir, alterar ou apagar dados

-- INSERT INTO - Inserir dados

INSERT INTO Produto (NomeProduto, Descricao, Preco, EstoqueDisponivel, Categoria, Imagem)
VALUES
('Mouse', 'Mouse Logitech', 99.90, 50, 'Informatica', ''),
('Teclado', 'Teclado Dell', 209.50, 100, 'Informatica', '')

INSERT INTO Cliente (NomeCompleto, Email, Telefone, Endereco, DataCadastro, Senha)
VALUES
('Vinicio Santos', 'vinicio@senai.br', '(11) 999994444', 'Rua Niteroi, 180 - S�o Paulo/SP', '05/04/2022', '1234'),
('Saulo Santos', 'saulo@senai.br', '(11) 22223344', 'Rua Niteroi, 250 - S�o Paulo/SP', '20/11/2022', '123456')

INSERT INTO Pedido (IdCliente, DataPedido, Status, ValorTotal)
VALUES
(1, '06/05/2023', 'Processando', 3200.99),
(2, '10/05/2023', 'Conclu�do', 450.90)


INSERT INTO Pagamento (IdPedido, FormaPagamento, Status, Data)
VALUES
(1, 'Cart�o de Cr�dito', 'Aprovado', '08/05/2023 12:30:00'),
(2, 'Boleto', 'Aprovado', '18/05/2023 16:30:00')

INSERT INTO ItensPedido (IdPedido, IdProduto, Quantidade)
VALUES
(1, 1, 2),
(2, 2, 1),
(2, 1, 1)


DELETE FROM Cliente WHERE NomeCompleto = 'Vinicio Santos';

-- DQL - Visualizar os dados
-- Select

SELECT * FROM Cliente;
