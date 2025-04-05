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
	NomeCompleto VARCHAR(150),
	Email VARCHAR(100),
	Telefone VARCHAR(20),
	Endereco VARCHAR(255),
	DataCadastro DATE
);

CREATE TABLE Pedido (
	IdPedido INT PRIMARY KEY IDENTITY,
	DataPedido DATE,
	Status VARCHAR(20),
	ValorTotal DECIMAL(18, 6),
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente)
);

CREATE TABLE Pagamento (
	IdPagamento INT PRIMARY KEY IDENTITY,
	FormaPagamento VARCHAR(30),
	Status VARCHAR(20),
	Data DATETIME,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido)
);

CREATE TABLE Produto (
	IdProduto INT PRIMARY KEY IDENTITY,
	NomeProduto VARCHAR(150),
	Descricao VARCHAR(255),
	Preco DECIMAL(18, 6),
	EstoqueDisponivel INT,
	Categoria VARCHAR(100),
	Imagem VARCHAR(255)
);

CREATE TABLE ItensPedido (
	IdItem INT PRIMARY KEY IDENTITY,
	Quantidade INT,
	IdPedido INT FOREIGN KEY REFERENCES Pedido(IdPedido),
	IdProduto INT FOREIGN KEY REFERENCES Produto(IdProduto)
);

DROP TABLE ItensPedido;
DROP TABLE Pagamento;
DROP TABLE Pedido;
DROP TABLE Produto;
DROP TABLE Cliente;