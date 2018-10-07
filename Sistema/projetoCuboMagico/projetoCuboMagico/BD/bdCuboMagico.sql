DROP DATABASE IF EXISTS bdcubomagico;
CREATE DATABASE bdCuboMagico;

USE bdCuboMagico;

CREATE TABLE IF NOT EXISTS Usuario(
id INT AUTO_INCREMENT,
usuario VARCHAR(100) NOT NULL,
senha VARCHAR(110) NOT NULL,
nivelAcesso VARCHAR(30) NOT NULL,
PRIMARY KEY(id),
UNIQUE(usuario)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Cliente(
id INT AUTO_INCREMENT,
nome VARCHAR(100) NOT NULL,
sobrenome VARCHAR(100) NOT NULL,
dataNascimento VARCHAR(10) NOT NULL,
sexo VARCHAR(10) NOT NULL,
tamCamiseta VARCHAR(5) NOT NULL,
cpf VARCHAR(15) NOT NULL,
email VARCHAR(100) NOT NULL,
telefone VARCHAR(14),
celular VARCHAR(15) NOT NULL,
cep VARCHAR(9) NOT NULL,
estado VARCHAR(50) NOT NULL,
cidade VARCHAR(65) NOT NULL,
bairro VARCHAR(65) NOT NULL,
rua VARCHAR(100) NOT NULL,
numero VARCHAR(10) NOT NULL,
complemento VARCHAR(100),
pais VARCHAR(70),
idUsuario INT REFERENCES Usuario,
PRIMARY KEY(id),
UNIQUE(cpf)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Genero(
id INT AUTO_INCREMENT,
genero VARCHAR(50) NOT NULL,
subGenero VARCHAR(60) NOT NULL,
PRIMARY KEY(id)
)DEFAULT CHARSET = utf8;


CREATE TABLE IF NOT EXISTS Livro(
id INT AUTO_INCREMENT,
nome VARCHAR(100) NOT NULL,
autor VARCHAR(50) NOT NULL,
idGenero INT REFERENCES Genero,
dataPublicacao VARCHAR(10),
editora VARCHAR(80) NOT NULL,
PRIMARY KEY(ID)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Funcionario(
id INT AUTO_INCREMENT,
nomeCompleto VARCHAR(110) NOT NULL,
dataNascimento VARCHAR(10) NOT NULL,
sexo VARCHAR(10) NOT NULL,
cpf VARCHAR(15) NOT NULL,
email VARCHAR(100) NOT NULL,
telefone VARCHAR(14),
celular VARCHAR(15) NOT NULL,
endereco VARCHAR(120) NOT NULL,
idUsuario INT REFERENCES Usuario,
PRIMARY KEY(id),
UNIQUE(cpf)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Gerente(
id INT AUTO_INCREMENT,
nomeCompleto VARCHAR(110) NOT NULL,
dataNascimento VARCHAR(10) NOT NULL,
sexo VARCHAR(10) NOT NULL,
cpf VARCHAR(15) NOT NULL,
email VARCHAR(100) NOT NULL,
telefone VARCHAR(14),
celular VARCHAR(15) NOT NULL,
endereco VARCHAR(120) NOT NULL,
idUsuario INT REFERENCES Usuario,
PRIMARY KEY(id),
UNIQUE(cpf)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Fornecedor(
id INT AUTO_INCREMENT,
nome VARCHAR(100) NOT NULL,
email VARCHAR(100) NOT NULL,
telefone VARCHAR(14) NOT NULL,
cnpj VARCHAR(19) NOT NULL,
pais VARCHAR(100),
PRIMARY KEY(id),
UNIQUE(cnpj)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Produto(
id INT AUTO_INCREMENT,
nome VARCHAR(100) NOT NULL,
tipo VARCHAR(30) NOT NULL,
design VARCHAR(60) NOT NULL,
PRIMARY KEY(ID)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Caixa(
id INT AUTO_INCREMENT,
idCliente INT REFERENCES Cliente,
dataGerada DATETIME NOT NULL,
PRIMARY KEY(ID)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS CartaoCredito(
idCliente INT REFERENCES Cliente,
nomeImpresso VARCHAR(100) NOT NULL,
cpf VARCHAR(15) NOT NULL,
validade VARCHAR(6) NOT NULL,
cvv VARCHAR(5) NOT NULL,
UNIQUE(cpf)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS GeneroCliente(
idCliente INT REFERENCES Cliente,
idGenero INT REFERENCES Genero
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Assinatura(
id INT AUTO_INCREMENT,
idCliente INT REFERENCES Cliente,
nome Varchar(100) NOT NULL,
tipo VARCHAR(80) NOT NULL,
valor decimal(6,2) NOT NULL,
PRIMARY KEY(id)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS ProdutoCaixa(
idCaixa INT REFERENCES Caixa,
idProduto INT REFERENCES Produto
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS LivroCaixa(
idCaixa INT REFERENCES Caixa,
idLivro INT REFERENCES Livro
)DEFAULT CHARSET = utf8;



