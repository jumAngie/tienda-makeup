--****************************************************************************--
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
GO
--****************************************************************************--
CREATE OR ALTER PROC UDP_Gral_tbEmpleados_UPDATE
@emp_ID					INT,
@emp_Nombre				NVARCHAR(250),		
@emp_Apellido			NVARCHAR(250),		
@emp_DNI				VARCHAR(13)	,		
@emp_FechaNacimiento	DATE	,			
@emp_Sexo				CHAR(1)	,			
@emp_Municipio			INT		,	
@emp_Telefono			NVARCHAR(100),
@emp_Correo				NVARCHAR(100),
@emp_EstadoCivil		INT	,			
@emp_Sucursal			INT,
@emp_UsuarioCrea		INT
AS
BEGIN
	UPDATE Gral.tbEmpleados
	SET		emp_Nombre = @emp_Nombre,
			emp_Apellido = @emp_Apellido,
			emp_DNI = @emp_DNI,
			emp_FechaNacimiento = @emp_FechaNacimiento,
			emp_Sexo = @emp_Sexo,
			emp_Municipio = @emp_Municipio,
			emp_Telefono = @emp_Telefono,
			emp_Correo = @emp_Correo,
			emp_EstadoCivil = @emp_EstadoCivil,
			emp_Sucursal = @emp_Sucursal,
			emp_UsuarioCrea = @emp_UsuarioCrea
	WHERE	emp_ID = @emp_ID
END
GO
--****************************************************************************--
CREATE OR ALTER PROC UDP_Maqui_tbProductos_UPDATE
	@pro_Id				INT,
	@pro_Codigo			NVARCHAR(100),
	@pro_Nombre			NVARCHAR(100), 
	@pro_PrecioUnitario	DECIMAL(18,2), 
	@pro_Proveedor		INT, 
	@pro_usuCrea		INT,
	@pro_Categoria		INT
AS
BEGIN
	UPDATE Maqui.tbProductos
	SET		pro_Codigo = @pro_Codigo,
			pro_Nombre = @pro_Nombre,
			pro_PrecioUnitario = @pro_PrecioUnitario,
			pro_Proveedor = @pro_Proveedor,
			pro_usuCrea = @pro_usuCrea,
			pro_Categoria = @pro_Categoria
	WHERE   pro_ID = @pro_Id
END
GO
--****************************************************************************--
CREATE OR ALTER PROC UDP_Maqui_tbProveedores_UPDATE
	@prv_ID			INT,
	@prv_NombreCompa�ia		NVARCHAR(250),
	@prv_NombreContacto		NVARCHAR(250), 
	@prv_TelefonoContacto   NVARCHAR(100), 
	@prv_Municipio			INT, 
	@prv_DireccionEmpresa	NVARCHAR(200), 
	@prv_DireccionContacto	NVARCHAR(200),
	@prv_SexoContacto		CHAR(1),
	@prv_UsuarioCrea		INT
	
AS
BEGIN
	UPDATE Maqui.tbProveedores
	SET	   prv_NombreCompa�ia =  @prv_NombreCompa�ia,
		   prv_NombreContacto =  @prv_NombreContacto,
		   prv_TelefonoContacto = @prv_TelefonoContacto,
		   prv_Municipio = @prv_Municipio,
		   prv_DireccionEmpresa = @prv_DireccionEmpresa,
		   prv_DireccionContacto = @prv_DireccionContacto,
		   prv_SexoContacto = @prv_SexoContacto,
		   prv_UsuarioCrea = @prv_UsuarioCrea
	WHERE	prv_ID = @prv_ID
END