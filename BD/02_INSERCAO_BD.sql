INSERT INTO USUARIOS (Email,Senha,TipoUsuario)
VALUES ('admin@admin.com','admin','ADMINISTRADOR')
	  ,('cliente@cliente.com','cliente','CLIENTE')

INSERT INTO ESTUDIOS
VALUES ('Blizzard')
	  ,('Rockstar Studios')
	  ,('Square Enix')

INSERT INTO JOGOS (NomeJogo,Descricao,DataLancamento,Valor,EstudioId)
VALUES ('Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','15-05-2012',99,1)
	  ,('Red Dead Redemption II','Jogo eletrônico de ação-aventura western','26-10-2018',120,2)