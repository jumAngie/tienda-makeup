CREATE OR ALTER PROC UDP_Gral_tbClientes_UPDATE
	@cli_ID INT,
	@cli_Nombre				NVARCHAR(250),		
	@cli_Apellido			NVARCHAR(250),		
	@cli_DNI				VARCHAR(13)	,		
	@cli_FechaNacimiento	DATE	,			
	@cli_Sexo				CHAR(1)	,		
	@cli_Telefono			NVARCHAR(100),
	@cli_Municipio			INT		,			
	@cli_EstadoCivil		INT	,				
	@cli_UsuarioCrea		INT

AS
BEGIN
	UPDATE	Gral.tbClientes
	SET		cli_Nombre = @cli_Nombre,
			cli_Apellido = @cli_Apellido,
			cli_DNI = @cli_DNI,
			cli_FechaNacimiento = @cli_FechaNacimiento,
			cli_Sexo = @cli_Sexo,
			cli_Telefono = @cli_Telefono,
			cli_Municipio = @cli_Municipio,
			cli_EstadoCivil = @cli_EstadoCivil,
			cli_UsuarioCrea = @cli_UsuarioCrea
	WHERE	cli_ID = @cli_ID
			
END