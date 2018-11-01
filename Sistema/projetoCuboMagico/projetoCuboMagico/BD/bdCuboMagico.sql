DROP DATABASE IF EXISTS bdCuboMagico;

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

CREATE TABLE IF NOT EXISTS Brinde(
id INT AUTO_INCREMENT,
nome VARCHAR(100) NOT NULL,
tipo VARCHAR(30) NOT NULL,
design VARCHAR(60) NOT NULL,
PRIMARY KEY(ID)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS Unboxing(
id INT AUTO_INCREMENT,
idCliente INT REFERENCES Cliente,
dataGerada DATETIME NOT NULL,
PRIMARY KEY(ID)
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS CartaoCredito(
idCliente INT REFERENCES Cliente,
nomeImpresso VARCHAR(100) NOT NULL,
numero VARCHAR(50) NOT NULL,
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

CREATE TABLE IF NOT EXISTS BrindeUnboxing(
idUnboxing INT REFERENCES Caixa,
idBrinde INT REFERENCES Brinde
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS LivroUnboxing(
idUnboxing INT REFERENCES Caixa,
idLivro INT REFERENCES Livro
)DEFAULT CHARSET = utf8;

CREATE TABLE IF NOT EXISTS LivrosSorteadosCliente(
idCliente INT REFERENCES Cliente,
idLivro INT REFERENCES Livro
);

/*PROCEDURES CLIENTES*/
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_listarTodosClientes $$
CREATE PROCEDURE SP_listarTodosClientes()
BEGIN
SELECT * FROM Cliente;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirCliente $$
CREATE PROCEDURE SP_incluirCliente(IN nome VARCHAR(100), IN sobrenome VARCHAR(100), IN dataNascimento VARCHAR(10), IN sexo VARCHAR(10), IN tamCamiseta VARCHAR(5), IN cpf VARCHAR(15), IN email VARCHAR(100), IN telefone VARCHAR(14), IN celular VARCHAR(15), IN cep VARCHAR(9), IN estado VARCHAR(50), IN cidade VARCHAR(65), IN bairro VARCHAR(65), IN rua VARCHAR(65), IN numero VARCHAR(10), IN complemento VARCHAR(100), IN pais VARCHAR(70), IN idUsuario INT)
BEGIN
    INSERT INTO Cliente(nome, sobrenome, dataNascimento, sexo, tamCamiseta, cpf, email, telefone, celular, cep, estado, cidade, bairro, rua, numero, complemento, pais, idUsuario) VALUES(
    nome,
    sobrenome,
    dataNascimento,
    sexo,
    tamCamiseta,
    cpf,
    email,
    telefone,
    celular,
    cep,
    estado,
    cidade,
    bairro,
    rua,
    numero,
    complemento,
    pais,
    idUsuario
    );
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarCliente $$
CREATE PROCEDURE SP_alterarCliente(IN id INT, IN nome VARCHAR(100), IN sobrenome VARCHAR(100), IN dataNascimento VARCHAR(10), IN sexo VARCHAR(10), IN tamCamiseta VARCHAR(5), IN cpf VARCHAR(15), IN email VARCHAR(100), IN telefone VARCHAR(14), IN celular VARCHAR(15), IN cep VARCHAR(9), IN estado VARCHAR(50), IN cidade VARCHAR(65), IN bairro VARCHAR(65), IN rua VARCHAR(65), IN numero VARCHAR(10), IN complemento VARCHAR(100), IN pais VARCHAR(70), IN idUsuario INT)
BEGIN
UPDATE Cliente SET 
Cliente.nome = nome,
Cliente.sobrenome = sobrenome,
Cliente.dataNascimento = dataNascimento,
Cliente.sexo = sexo,
Cliente.tamCamiseta = tamCamiseta,
Cliente.cpf = cpf,
Cliente.email = email,
Cliente.telefone = telefone,
Cliente.celular = celular,
Cliente.cep = cep,
Cliente.estado = estado,
Cliente.cidade = cidade,
Cliente.bairro = bairro,
Cliente.rua = rua,
Cliente.numero = numero,
Cliente.complemento = complemento,
Cliente.pais = pais,
Cliente.idUsuario = idUsuario
WHERE Cliente.id = id;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_deletarCliente $$
CREATE PROCEDURE SP_deletarCliente(IN ID INT)
BEGIN    
DELETE FROM Cliente WHERE Cliente.id = ID;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_consultarClientePorID $$
CREATE PROCEDURE SP_consultarClientePorID(IN ID INT)
BEGIN
SELECT * FROM Cliente WHERE Cliente.id = ID;
END $$
DELIMITER ;


/*PROCEDURES USUARIOS*/
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_listarTodosUsuarios $$
CREATE PROCEDURE SP_listarTodosUsuarios()
BEGIN
SELECT * FROM Usuario;
END $$
DELIMITER ;


DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirUsuario $$
CREATE PROCEDURE SP_incluirUsuario(IN usuario VARCHAR(100), IN senha VARCHAR(100), IN nivelAcesso VARCHAR(30))
BEGIN
INSERT INTO Usuario(usuario, senha, nivelAcesso) VALUES(
	usuario,
    senha,
    nivelAcesso
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarUsuario $$
CREATE PROCEDURE SP_alterarUsuario(IN ID INT, IN usuario VARCHAR(100), IN senha VARCHAR(100), IN nivelAcesso VARCHAR(30))
BEGIN
UPDATE Usuario SET
	Usuario.usuario = usuario,
	Usuario.senha = senha,
    Usuario.nivelAcesso = nivelAcesso
WHERE Usuario.id = ID;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_deletarUsuario $$
CREATE PROCEDURE SP_deletarUsuario(IN ID INT)
BEGIN
DELETE FROM Usuario WHERE Usuario.id = ID;
END $$

DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_consultaPorUsuario $$
CREATE PROCEDURE SP_consultaPorUsuario(IN usuario VARCHAR(100))
BEGIN
SELECT * FROM Usuario WHERE Usuario.usuario = usuario;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_consultaUsuarioPorID $$
CREATE PROCEDURE SP_consultaUsuarioPorID(IN ID INT)
BEGIN
SELECT * FROM Usuario WHERE Usuario.id = ID;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_consultaUsuarioPorEmail $$
CREATE PROCEDURE SP_consultaUsuarioPorEmail(IN email VARCHAR(100))
BEGIN
SELECT Cliente.email, Usuario.usuario, Usuario.senha, Usuario.nivelAcesso FROM Usuario JOIN Cliente ON Cliente.idUsuario = Usuario.id
WHERE cliente.email = email;
END $$
DELIMITER ;

/*PROCEDURES LIVROS*/
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_listarTodosLivros $$
CREATE PROCEDURE SP_listarTodosLivros()
BEGIN
SELECT * FROM Livro;
END $$
DELIMITER ;



DELIMITER $$
DROP PROCEDURE IF EXISTS SP_IncluirLivro $$
CREATE PROCEDURE SP_incluirLivro(IN nome VARCHAR(100), IN autor VARCHAR(50), IN idGenero INT, IN dataPublicacao VARCHAR(10), IN editora VARCHAR(80))
BEGIN
INSERT INTO Livro(nome, autor, idGenero, dataPublicacao, editora) VALUES(
	nome,
	autor,
    idGenero,
    dataPublicacao,
    editora
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarLivro $$
CREATE PROCEDURE SP_alterarLivro(IN ID INT, IN nome VARCHAR(100), IN autor VARCHAR(50), IN idGenero INT, IN dataPublicacao VARCHAR(10), IN editora VARCHAR(80))
BEGIN
UPDATE Livro SET
Livro.nome = nome,
Livro.autor = autor,
Livro.idGenero = idGenero,
Livro.dataPublicacao = dataPublicacao,
Livro.editora = editora
WHERE Livro.id = ID;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_deletarLivro $$
CREATE PROCEDURE SP_deletarLivro(IN ID INT)
BEGIN
DELETE FROM Livro WHERE Livro.id = ID;
END $$
DELIMITER ;


/*PROCEDURES BRINDES*/
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_listarTodosBrindes $$
CREATE PROCEDURE SP_listarTodosBrindes()
BEGIN
SELECT * FROM Brinde;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirBrinde $$
CREATE PROCEDURE SP_incluirBrinde(IN nome VARCHAR(100), IN tipo VARCHAR(30), IN design VARCHAR(60))
BEGIN
INSERT INTO Brinde(nome, tipo, design) VALUES(
nome,
tipo,
design
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_deletarBrinde $$
CREATE PROCEDURE SP_deletarBrinde(IN ID INT)
BEGIN
DELETE FROM Brinde WHERE Brinde.id = ID;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarBrinde $$
CREATE PROCEDURE SP_alterarBrinde(IN ID INT, IN nome VARCHAR(100), IN tipo VARCHAR(30), IN design VARCHAR(60))
BEGIN
UPDATE Brinde SET
	Brinde.nome = nome,
    Brinde.tipo = tipo,
    Brinde.design = design
WHERE Brinde.id = ID;
END $$
DELIMITER ;


/* PROCEDURES FUNCIONARIOS*/
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_listarTodosFuncionarios $$
CREATE PROCEDURE SP_listarTodosFuncionarios()
BEGIN
SELECT * FROM Funcionario;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirFuncionario $$
CREATE PROCEDURE SP_incluirFuncionario(IN nomeCompleto VARCHAR(100), IN dataNascimento VARCHAR(10), IN sexo VARCHAR(10), IN cpf VARCHAR(15), IN email VARCHAR(100), IN telefone VARCHAR(14), IN celular VARCHAR(15), IN endereco VARCHAR(120), IN idUsuario INT)
BEGIN
INSERT INTO Funcionario(nomeCompleto, dataNascimento, sexo, cpf, email, telefone, celular, endereco, idUsuario) VALUES(
nomeCompleto,
dataNascimento,
sexo,
cpf,
email,
telefone,
celular,
endereco,
idUsuario
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_deletarFuncionario $$
CREATE PROCEDURE SP_deletarFuncionario(IN ID INT)
BEGIN
DELETE FROM Funcionario WHERE Funcionario.id = ID;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarFuncionario $$
CREATE PROCEDURE SP_alterarFuncionario(IN ID INT, IN nomeCompleto VARCHAR(100), IN dataNascimento VARCHAR(10), IN sexo VARCHAR(10), IN cpf VARCHAR(15), IN email VARCHAR(100), IN telefone VARCHAR(14), IN celular VARCHAR(15), IN endereco VARCHAR(120), IN idUsuario INT)
BEGIN
UPDATE Funcionario SET
	Funcionario.nomeCompleto = nomeCompleto,
	Funcionario.dataNascimento = dataNascimento,
	Funcionario.sexo = sexo,
	Funcionario.cpf = cpf,
	Funcionario.email = email,
	Funcionario.telefone = telefone,
	Funcionario.celular = celular,
	Funcionario.endereco = endereco,
	Funcionario.idUsuario = idUsuario
WHERE Funcionario.id = ID;
END $$
DELIMITER ;

/*PROCEDURES GERENTE*/
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_listarTodosGerentes $$
CREATE PROCEDURE SP_listarTodosGerentes()
BEGIN
SELECT * FROM Gerente;
END $$
DELIMITER ;



DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirGerente $$
CREATE PROCEDURE SP_incluirGerente(IN nomeCompleto VARCHAR(100), IN dataNascimento VARCHAR(10), IN sexo VARCHAR(10), IN cpf VARCHAR(15), IN email VARCHAR(100), IN telefone VARCHAR(14), IN celular VARCHAR(15), IN endereco VARCHAR(120), IN idUsuario INT)
BEGIN
INSERT INTO Gerente(nomeCompleto, dataNascimento, sexo, cpf, email, telefone, celular, endereco, idUsuario) VALUES(
nomeCompleto,
dataNascimento,
sexo,
cpf,
email,
telefone,
celular,
endereco,
idUsuario
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_deletarGerente $$
CREATE PROCEDURE SP_deletarGerente(IN ID INT)
BEGIN
DELETE FROM Gerente WHERE Gerente.id = ID;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarGerente $$
CREATE PROCEDURE SP_alterarGerente(IN ID INT, IN nomeCompleto VARCHAR(100), IN dataNascimento VARCHAR(10), IN sexo VARCHAR(10), IN cpf VARCHAR(15), IN email VARCHAR(100), IN telefone VARCHAR(14), IN celular VARCHAR(15), IN endereco VARCHAR(120), IN idUsuario INT)
BEGIN
UPDATE Gerente SET
	Gerente.nomeCompleto = nomeCompleto,
	Gerente.dataNascimento = dataNascimento,
	Gerente.sexo = sexo,
	Gerente.cpf = cpf,
	Gerente.email = email,
	Gerente.telefone = telefone,
	Gerente.celular = celular,
	Gerente.endereco = endereco,
	Gerente.idUsuario = idUsuario
WHERE Gerente.id = ID;
END $$
DELIMITER ;

/* PROCEDURES FORNECEDORES*/
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirFornecedor $$
CREATE PROCEDURE SP_incluirFornecedor(IN nome VARCHAR(100), IN email VARCHAR(100), IN telefone VARCHAR(14), IN cnpj VARCHAR(19), IN pais VARCHAR(100))
BEGIN
INSERT INTO Fornecedor(nome, email, telefone, cnpj, pais) VALUES(
nome,
email,
telefone,
cnpj,
pais
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarFornecedor $$
CREATE PROCEDURE SP_alterarFornecedor(IN ID INT, IN nome VARCHAR(100), IN email VARCHAR(100), IN telefone VARCHAR(14), IN cnpj VARCHAR(19), IN pais VARCHAR(100))
BEGIN
UPDATE Fornecedor SET
	Fornecedor.nome = nome,
    Fornecedor.email = email,
    Forncedor.telefone = telefone,
    Fornecedor.cnpj = cnpj,
    Fornecedor.pais = pais
WHERE Fornecedor.id = ID;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_deletarFornecedor $$
CREATE PROCEDURE SP_deletarFornecedor(IN ID INT)
BEGIN
DELETE FROM Fornecedor WHERE Fornecedor.id = ID;
END $$
DELIMITER ;

/*PROCEDURES GENEROS*/
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirGenero $$
CREATE PROCEDURE SP_incluirGenero(IN genero VARCHAR(50), IN subGenero VARCHAR(60))
BEGIN
INSERT INTO Genero(genero, subGenero) VALUES(
genero,
subGenero
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarGenero $$
CREATE PROCEDURE SP_alterarGenero(IN ID INT, IN genero VARCHAR(50), IN subGenero VARCHAR(60))
BEGIN
UPDATE Genero SET
Genero.genero = genero,
Genero.subGenero = subGenero
WHERE Generp.id = ID;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_deletarGenero $$
CREATE PROCEDURE SP_deletarGenero(IN ID INT)
BEGIN
DELETE FROM Genero WHERE Genero.id = ID;
END $$
DELIMITER ;

/* PROCEDURE CARTAO CREDITOS */
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirCartaoCredito $$
CREATE PROCEDURE SP_incluirCartaoCredito(IN nomeImpresso VARCHAR(100), IN numero VARCHAR(50), IN cpf VARCHAR(15), IN validade VARCHAR(6), IN cvv VARCHAR(5))
BEGIN
INSERT INTO CartaoCredito(nomeImpresso, cpf, validade, cvv) VALUES(
nomeImpresso,
numero,
cpf,
validade,
cvv
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarCartaoCredito $$
CREATE PROCEDURE SP_alterarCartaoCredito(IN ID INT, IN nomeImpresso VARCHAR(100), IN numero VARCHAR(50), IN cpf VARCHAR(15), IN validade VARCHAR(6), IN cvv VARCHAR(5))
BEGIN
UPDATE CartaoCredito SET
CartaoCredito.nomeImpresso = nomeImpresso,
CartaoCredtio.numero = numero,
CartaoCredito.cpf = cpf,
CartaoCredito.validade = validade,
CartaoCredito.cvv = cvv
WHERE CartaoCredito.numero = numero;
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_deletarCartaoCredito $$
CREATE PROCEDURE SP_deletarCartaoCredito(IN ID INT)
BEGIN
DELETE FROM CartaoCredito WHERE CartaoCredito.id = ID;
END $$
DELIMITER ;

/* PROCEDURES CAIXA */
DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirUnboxing $$
CREATE PROCEDURE SP_incluirUnboxing(IN idCliente INT, IN dataGerada DATETIME)
BEGIN
INSERT INTO Unboxing(idCliente, dataGerada) VALUES(
idCliente,
dataGerada
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirBrindeUnboxing $$
CREATE PROCEDURE SP_incluirBrindeUnboxing(IN idUnboxing INT, IN idBrinde INT)
BEGIN
INSERT INTO ProdutoUnboxing(idUnboxing, idBrinde) VALUES(
idUnboxing,
idBrinde
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirLivroUnboxing $$
CREATE PROCEDURE SP_incluirLivroUnboxing(IN idCaixa INT, IN idLivro INT)
BEGIN
INSERT INTO LivroUnboxing(idUnboxing, idLivro) VALUES(
idUnboxing,
idLivro
);
END $$
DELIMITER ;

DELIMITER $$
DROP PROCEDURE IF EXISTS SP_alterarUnboxing $$
CREATE PROCEDURE SP_alterarUnboxing(IN ID INT, IN idCliente INT)
BEGIN
UPDATE Unboxing SET
Unboxing.idCliente = idCliente
WHERE Unboxing.id = ID;
END $$
DELIMITER ;











