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

INSERT INTO Genero(genero, subGenero) VALUES(
'Terror',
'Terror Piscológico'
);

INSERT INTO Livro(nome, autor, idGenero, dataPublicacao, editora) VALUES(
'O ilumidado',
'Stephen King',
'1',
'25/12/1980',
'Saraiva'
);

