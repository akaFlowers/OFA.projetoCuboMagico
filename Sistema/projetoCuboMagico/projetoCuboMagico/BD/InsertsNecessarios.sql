USE bdCuboMagico;

INSERT INTO Usuario(usuario, senha, nivelAcesso) VALUES(
'nemA',
'123',
'Administrador'
);

INSERT INTO Cliente(nome, sobrenome, dataNascimento, sexo, tamCamiseta, cpf, email, telefone, celular, cep, estado, cidade, bairro, rua, numero, complemento, pais, idUsuario) VALUES(
'João',
'Lima',
'05/10/2000',
'Masculino',
'G',
'478.926.788.160',
'joao.vitor9524@gmail.com',
'(11)3719-3418',
'(11)99281-6711',
'05347-010',
'São Paulo',
'São Paulo',
'Jaguaré',
'Av. Kenkit Simomoto',
'27',
'Bloco 1 Apto 16',
'Brazuca',
1
);

INSERT INTO Funcionario(nomeCompleto, dataNascimento, sexo, cpf, email, telefone, celular, endereco, idUsuario) VALUES(
'João Vitor Lima de Brito',
'05/10/2000',
'Masculino',
'478.926.78.16',
'joao.vitor9964@outlook.com.br',
'(11)3719-3418',
'(11)99281-6711',
'Av. Kenkit Simomoto, 27, Jaguaré, Bloco 1 apto 16',
1
);

INSERT INTO Gerente(nomeCompleto, dataNascimento, sexo, cpf, email, telefone, celular, endereco, idUsuario) VALUES(
'João Vitor Lima de Brito',
'05/10/2000',
'Masculino',
'478.926.78.16',
'joao.vitor9964@outlook.com.br',
'(11)3719-3418',
'(11)99281-6711',
'Av. Kenkit Simomoto, 27, Jaguaré, Bloco 1 apto 16',
1
);

INSERT INTO GeneroLivro(generoLivro, subGenero) VALUES(
'Terror',
'Terror Piscológico'
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'O ilumidado',
'Stephen King',
'1',
'25/12/1980',
'Saraiva'
);

INSERT INTO brinde(nome, tipo, design) VALUES(
'Caixinha de Som',
'Som',
'Interiores'
);

/*INSERT INTO LivrosSorteadosCliente VAlues(
1,
1
);




/*
SELECT @i:=@i+1 AS ID, Cliente.nome, Livro.id , Livro.NOME, Genero.genero, Genero.subGenero FROM Cliente, Livro, Genero, (SELECT @i:=0)A
WHERE Livro.id NOT IN (SELECT idLivro FROM (((LivrosSorteadosCliente
INNER JOIN Livro ON idLivro = Livro.id)
INNER JOIN Genero ON Livro.idGenero = Genero.id)
INNER JOIN Cliente ON idCliente = Cliente.id)
WHERE Cliente.id = 1) AND Cliente.id = 1 AND Genero.genero IN ('Terror')
ORDER BY Cliente.nome;
*/