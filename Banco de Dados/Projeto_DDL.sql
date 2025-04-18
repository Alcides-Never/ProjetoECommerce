USE ECommerce;

-- Linguagem SQL
-- SQL - Structure Query Language
-- Linguagem de Consulta Estrutura

-- Variação do SQL que operam como linguagem de programação -> T-SQL (Microsoft), PL/SQL (Oracle) - 
-- Tem if else, funcoes

-- SQL - Comandos
-- DDL - Criar, Alterar ou Apagar Banco de Dados
-- E tabelas
-- DDL - Data Definition Language

-- DML - Criar, Alterar ou Apagar Dados
-- DML - Data Manipulation Language

-- DQL - Ver dados
-- DQL - Data Query Language

-- Create - 
-- Drop - Apaga Banco de Dados ou Tabela

CREATE DATABASE ECommerce;

DROP DATABASE ECommerce;

-- Criação de Tabela.
-- Singular, Começando com letra maiuscula
CREATE TABLE Cliente (
-- PRIMARY KEY - Coluna que identifica os clientes.
-- IDENTITY - Gerada automaticamente
	IdCliente INT PRIMARY KEY IDENTITY,
	NomeCompleto VARCHAR(150) NOT NULL,
	Email VARCHAR(100)NOT NULL UNIQUE,
	Telefone VARCHAR(20) ,
	Endereco VARCHAR(255),
	Senha VARCHAR(255) NOT NULL,
	DataCadastro DATE
);

CREATE TABLE Pedido (
	IdPedido INT PRIMARY KEY IDENTITY,
	DataPedido DATE NOT NULL,
	Status VARCHAR(20) NOT NULL,
	ValorTotal DECIMAL(18, 6),
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente) NOT NULL
);

CREATE TABLE Pagamento (
	IdPagamento INT PRIMARY KEY IDENTITY,
	FormaPagamento VARCHAR(30) NOT NULL,
	Status VARCHAR(20) NOT NULL,
	Data DATETIME NOT NULL,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido) NOT NULL
);

CREATE TABLE Produto (
	IdProduto INT PRIMARY KEY IDENTITY,
	NomeProduto VARCHAR(150) NOT NULL,
	Descricao VARCHAR(255),
	Preco DECIMAL(18, 6) NOT NULL,
	EstoqueDisponivel INT NOT NULL,
	Categoria VARCHAR(100) NOT NULL,
	Imagem VARCHAR(255)
);

CREATE TABLE ItensPedido (
	IdItem INT PRIMARY KEY IDENTITY,
	Quantidade INT NOT NULL,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido) NOT NULL,
	IdProduto INT FOREIGN KEY REFERENCES Produto(IdProduto) NOT NULL
);

DROP TABLE ItensPedido;
DROP TABLE Pagamento;
DROP TABLE Pedido;
DROP TABLE Produto;
DROP TABLE Cliente;

select * from Cliente;