DELIMITER $$
DROP PROCEDURE IF EXISTS SP_incluirCliente$$
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