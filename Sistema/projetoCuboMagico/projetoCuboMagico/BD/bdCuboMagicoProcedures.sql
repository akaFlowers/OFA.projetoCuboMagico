DELIMITER $$
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
CREATE PROCEDURE SP_alterarCliente(IN nome VARCHAR(100), IN sobrenome VARCHAR(100), IN dataNascimento VARCHAR(10), IN sexo VARCHAR(10), IN tamCamiseta VARCHAR(5), IN cpf VARCHAR(15), IN email VARCHAR(100), IN telefone VARCHAR(14), IN celular VARCHAR(15), IN cep VARCHAR(9), IN estado VARCHAR(50), IN cidade VARCHAR(65), IN bairro VARCHAR(65), IN rua VARCHAR(65), IN numero VARCHAR(10), IN complemento VARCHAR(100), IN pais VARCHAR(70), IN idUsuario INT)
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
Cliente.idUsuario = idUsuario;
END $$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE SP_deletarCliente(IN ID INT)
BEGIN    
DELETE FROM Cliente WHERE id = ID;
END $$
DELIMITER ;