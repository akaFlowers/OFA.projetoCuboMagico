/*PROCEDURES CLIENTES*/
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
CREATE PROCEDURE SP_alterarUsuario(IN usuario VARCHAR(100), IN senha VARCHAR(100), IN nivelAcesso VARCHAR(30))
BEGIN
UPDATE Usuario SET
	Usuario.usuario = usuario,
	Usuario.senha = senha,
    Usuario.nivelAcesso = nivelAcesso;
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
CREATE PROCEDURE SP_consultUsuarioPorEmail(IN email VARCHAR(100))
BEGIN
SELECT Cliente.email, Usuario.usuario, Usuario.senha, Usuario.nivelAcesso FROM Usuario JOIN Cliente ON Cliente.idUsuario = Usuario.id
WHERE cliente.email = email;
END $$
DELIMITER ;
