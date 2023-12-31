USE inlock_games_manha;

SELECT * FROM TiposUsuario;

SELECT * FROM Usuario;

SELECT * FROM Estudio;

SELECT * FROM Jogo;

SELECT Jogo.Nome AS Jogo,Estudio.Nome AS Estudio From Jogo
INNER JOIN Estudio
ON Jogo.IdEstudio = Estudio.IdEstudio;

SELECT Estudio.Nome AS Estudio,Jogo.Nome AS Jogo FROM Estudio
LEFT JOIN Jogo
ON Estudio.IdEstudio = Jogo.IdEstudio;

SELECT * FROM Usuario WHERE Email = 'cliente@cliente.com' AND Senha = 'cliente';

SELECT * FROM Jogo WHERE IdJogo = 4;

SELECT * FROM Estudio WHERE IdEstudio = 2;

SELECT Estudio.IdEstudio,Estudio.Nome,Jogo.Nome FROM Estudio
LEFT JOIN Jogo
ON Estudio.IdEstudio = Jogo.IdEstudio;

SELECT IdJogo, Jogo.IdEstudio, Jogo.Nome, Descricao, DataLancamento, Valor, Estudio.Nome AS Estudio FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio

SELECT IdUsuario, Usuario.IdTipoUsuario, Email, Senha, CASE WHEN Usuario.IdTipoUsuario = 1 THEN 'Comum' ELSE 'Admin' END AS TipoUsuario FROM Usuario;

SELECT IdUsuario, Usuario.IdTipoUsuario, Email, Senha, TiposUsuario.Titulo FROM Usuario INNER JOIN TiposUsuario ON Usuario.IdTipoUsuario = TiposUsuario.IdTipoUsuario

SELECT IdUsuario, Usuario.IdTipoUsuario, Email, Titulo FROM Usuario LEFT JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuario.IdTipoUsuario

SELECT IdEstudio, Nome FROM Estudio 

DELETE FROM Jogo WHERE IdJogo = 4

SELECT Estudio.IdEstudio, Estudio.Nome AS Estudio, IdJogo, Jogo.Nome AS Jogo, Descricao, DataLancamento, Valor FROM Estudio LEFT JOIN Jogo ON Jogo.IdEstudio = Estudio.IdEstudio
