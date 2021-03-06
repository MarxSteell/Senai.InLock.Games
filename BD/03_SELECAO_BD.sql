SELECT * FROM USUARIOS

SELECT * FROM ESTUDIOS

SELECT * FROM JOGOS

SELECT * FROM JOGOS LEFT JOIN ESTUDIOS ON JOGOS.EstudioId = ESTUDIOS.EstudioId

SELECT * FROM ESTUDIOS LEFT JOIN JOGOS ON ESTUDIOS.EstudioId = JOGOS.EstudioId

SELECT * FROM USUARIOS WHERE @EMAIL = Email AND @SENHA = Senha

SELECT * FROM JOGOS WHERE @ID = JogoId

SELECT * FROM ESTUDIOS WHERE @ID = EstudioId

-- PROCEDURES PARA AS 3 �LTIMAS SELE��ES, RESPECTIVAMENTE

CREATE PROCEDURE BuscaUsuario
	@EMAIL VARCHAR(200)
	,@SENHA VARCHAR(255)
AS
BEGIN
	SELECT * FROM USUARIOS WHERE @EMAIL = Email AND @SENHA = Senha
END

CREATE PROCEDURE BuscaJogoPorId
	@ID INT
AS
BEGIN
	SELECT * FROM JOGOS WHERE @ID = JogoId
END

CREATE PROCEDURE BuscaEstudioPorId
	@ID INT
AS
BEGIN
	SELECT * FROM ESTUDIOS WHERE @ID = EstudioId
END