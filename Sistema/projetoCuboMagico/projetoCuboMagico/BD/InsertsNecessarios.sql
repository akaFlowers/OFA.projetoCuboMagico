USE bdCuboMagico;

INSERT INTO Usuario(usuario, senha, nivelAcesso) VALUES(
'nemA',
'123',
'Administrador'
);

INSERT INTO Cliente(nome, sobrenome, dataNascimento, sexo, tamCamiseta, cpf, email, telefone, celular, cep, estado, cidade, bairro, rua, numero, complemento, pais, idUsuario) VALUES(
'Joãoaa',
'Lima',
'05/10/2000',
'Masculino',
'G',
'478.926.789.060',
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

INSERT INTO Generolivro(generoLivro, subGenero) VALUES(
'Comédia',
'Comédia romantica'
);

INSERT INTO GeneroLivro(generoLivro, subGenero) VALUES(
'História',
'Pré-historia'
);

INSERT INTO GeneroLivro(generolivro, subGenero) VALUES(
'Infantil',
'Educativo'
);

INSERT INTO GeneroLivro(generoLivro, subGenero) VALUES(
'Biografia',
'Biografia'
);

INSERT INTO GeneroLivro(GeneroLivro, subGenero) VALUES(
'Informática',
'Logica de Programação'
);

INSERT INTO GeneroLivro(GeneroLivro, subGenero) VALUES(
'Economia',
'Economia analitica'
);

INSERT INTO GeneroLivroCliente(idCliente, idGeneroLivro) VALUES(
1,
1
);

INSERT INTO GeneroLivroCliente(idCliente, idGeneroLivro) VALUES(
1,
2
);

INSERT INTO GeneroLivroCliente(idCliente, idGeneroLivro) VALUES(
1,
4
);

INSERT INTO GeneroLivroCliente(idCliente, idGeneroLivro) VALUES(
1,
6
);

INSERT INTO GeneroLivroCliente(idCliente, idGeneroLivro) VALUES(
1,
7
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'O ilumidado',
'Stephen King',
1,
'25/12/1980',
'Saraiva'
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'Manual da Economia',
'Diva Benevides',
7,
'12/07/2017',
'Saraiva'
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'Logica de programação: a construção de algoritmos e estruturas de dados',
'André Luiz Villar',
6,
'25/05/2005',
'Saraiva'
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'Alice no País das Maravilhas',
'Lewis Carroll',
4,
'26/02/2010',
'Zahar'
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'Felipe Neto - A Vida Por Trás Das Câmeras',
'Felipe Neto',
5,
'20/04/2018',
'Pixel'
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'Fiquei com o seu número',
'Sophie Kinsella',
2,
'03/10/2011',
'Bantam Press'
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'Mas tem que ser mesmo para sempre?',
'Sophie Kinsella',
2,
'08/03/2018',
'Record'
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'Histórias da Pré-História',
'Alberto Moravia',
3,
'01/01/2003',
'Editora 34'
);

INSERT INTO Livro(nome, autor, idGeneroLivro, dataPublicacao, editora) VALUES(
'Misery',
'Stephen King',
1,
'08/06/1987',
'Suma'
);


INSERT INTO brinde(nome, tipo, design) VALUES(
'Caixinha de Som',
'Som',
'Interiores'
);

INSERT INTO LivrosSorteadosCliente VAlues(
1, 
1
);


SELECT * FROM Livro JOIN GeneroLivro ON GeneroLivro.id = Livro.idGeneroLivro
/

/*
SELECT @i:=@i+1 AS ID, Cliente.nome, Livro.id , Livro.NOME, GeneroLivro.generoLivro, GeneroLivro.subGenero FROM Cliente, Livro, GeneroLivro, (SELECT @i:=0)A
WHERE Livro.id NOT IN (SELECT idLivro FROM (((LivrosSorteadosCliente
INNER JOIN Livro ON idLivro = Livro.id)
INNER JOIN GeneroLivro ON Livro.idGeneroLivro = GeneroLivro.id)
INNER JOIN Cliente ON idCliente = Cliente.id)
WHERE Cliente.id = 1) AND Cliente.id = 1 AND GeneroLivro.generoLivro IN ('Terror', 'História') 
ORDER BY Cliente.nome;
*/