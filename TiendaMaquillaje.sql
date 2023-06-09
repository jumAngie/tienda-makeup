CREATE DATABASE TiendaMaquillaje
GO
USE TiendaMaquillaje

--//************************ TABLAS GENERALES ************************--//
GO
CREATE SCHEMA Gral
GO

CREATE TABLE Gral.tbUsuarios(
		usu_ID				INT IDENTITY(1,1) PRIMARY KEY,
		usu_Usuario			NVARCHAR(100)		NOT NULL,
		usu_empID			INT					NOT NULL,
		usu_Clave			NVARCHAR(MAX)		NOT NULL,
		usu_EsAdmin			BIT					NOT NULL,
		usu_UsuarioCrea		INT					NOT NULL,
		usu_FechaCrea		DATETIME			DEFAULT GETDATE(),
		usu_UsuarioModi		INT,
		usu_FechaModi		DATETIME,
		usu_Estado			BIT					DEFAULT 1

		CONSTRAINT	UQ_Gral_tbUsuarios_usu_Usuario	UNIQUE (usu_Usuario)
);

INSERT INTO Gral.tbUsuarios
VALUES  ('admin', 1, '123', 1, 1, GETDATE(), NULL, NULL, 1);


CREATE TABLE Gral.tbEstadosCiviles(
		est_ID				INT IDENTITY(1,1) PRIMARY KEY,
		est_Descripcion		NVARCHAR(250)			NOT NULL,

		est_UsuarioCrea		INT						NOT NULL,
		est_FechaCrea		DATETIME				DEFAULT GETDATE(),
		est_UsuarioModi		INT,
		est_FechaModi		DATETIME

		CONSTRAINT FK_Gral_tbEstadosCiviles_est_UsuarioCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(est_UsuarioCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Gral_tbEstadosCiviles_est_UsuarioModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(est_UsuarioModi) REFERENCES Gral.tbUsuarios(usu_ID)

);

INSERT INTO Gral.tbEstadosCiviles
VALUES  ('Amante',			1, GETDATE(), null, null),
		('Casado(a)',		1, GETDATE(), null, null),
		('Comprometido(a)', 1, GETDATE(), null, null),
		('Divorciado(a)',	1, GETDATE(), null, null),
		('Soltero(a)',		1, GETDATE(), null, null),
		('Uni�n Libre',		1, GETDATE(), null, null),
		('Viudo(a)',		1, GETDATE(), null, null);


CREATE TABLE Gral.tbDepartamentos(
		dep_ID					INT IDENTITY(1,1) PRIMARY KEY,
		dep_Descripcion			NVARCHAR(250)			NOT NULL,

		dep_UsuarioCrea			INT						NOT NULL,
		dep_FechaCrea			DATETIME				DEFAULT GETDATE(),
		dep_UsuarioModi			INT,
		dep_FechaModi			DATETIME

		CONSTRAINT FK_Gral_tbDepartamentos_dep_UsuarioCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(dep_UsuarioCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Gral_tbDepartamentos_dep_UsuarioModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(dep_UsuarioModi) REFERENCES Gral.tbUsuarios(usu_ID)

);

INSERT INTO Gral.tbDepartamentos
VALUES	('Atl�ntida',		    1, GETDATE(), NULL, NULL),
		('Col�n',			    1, GETDATE(), NULL, NULL),
		('Comayagua',		    1, GETDATE(), NULL, NULL),
		('Cop�n',			    1, GETDATE(), NULL, NULL),
		('Cort�s',			    1, GETDATE(), NULL, NULL),
		('Choluteca',		    1, GETDATE(), NULL, NULL),
		('El Para�so',		    1, GETDATE(), NULL, NULL),
		('Francisco Moraz�n',   1, GETDATE(), NULL, NULL),
		('Gracias a Dios',	    1, GETDATE(), NULL, NULL),
		('Intibuca',		    1, GETDATE(), NULL, NULL),
		('Islas de la Bah�a',   1, GETDATE(), NULL, NULL),
		('La Paz',			    1, GETDATE(), NULL, NULL),
		('Lempira',			    1, GETDATE(), NULL, NULL),
		('Ocotepeque',		    1, GETDATE(), NULL, NULL),
		('Olancho',			    1, GETDATE(), NULL, NULL),
		('Santa B�rbara',	    1, GETDATE(), NULL, NULL),
		('Valle',			    1, GETDATE(), NULL, NULL),
		('Yoro',			    1, GETDATE(), NULL, NULL);

		








CREATE TABLE Gral.tbMunicipios(
		mun_ID				INT IDENTITY(1,1) PRIMARY KEY,
		mun_depID			INT						NOT NULL,
		mun_Descripcion		NVARCHAR(250)			NOT NULL,
		mun_UsuarioCrea		INT						NOT NULL,
		mun_FechaCrea		DATETIME				DEFAULT GETDATE(),
		mun_UsuarioModi		INT,
		mun_FechaModi		DATETIME

		CONSTRAINT FK_Gral_tbMunicipios_mun_depID_Gral_tbDepartamentos_dep_ID	FOREIGN KEY (mun_depID) REFERENCES Gral.tbDepartamentos (dep_ID),
		CONSTRAINT FK_Gral_tbMunicipios_mun_UsuarioCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(mun_UsuarioCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Gral_tbMunicipios_mun_UsuarioModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(mun_UsuarioModi) REFERENCES Gral.tbUsuarios(usu_ID)
);

INSERT INTO Gral.tbMunicipios
VALUES   ( 1, 'La Ceiba',				   1, GETDATE(), NULL, NULL),
		 ( 1, 'Tela',					   1, GETDATE(), NULL, NULL),
	     ( 1, 'La Masica',				   1, GETDATE(), NULL, NULL),
		 ( 1, 'Arizona',				   1, GETDATE(), NULL, NULL),
		 ( 1, 'Jutiapa',				   1, GETDATE(), NULL, NULL),
		 ( 1, 'El Porvenir',			   1, GETDATE(), NULL, NULL),
		 ( 1, 'Esparta',				   1, GETDATE(), NULL, NULL),
	     ( 1, 'San Francisco',			   1, GETDATE(), NULL, NULL),
		 ( 2, 'Trujillo',				   1, GETDATE(), NULL, NULL),
		 ( 2, 'Balfate',				   1, GETDATE(), NULL, NULL),
		 ( 2, 'Iriona',					   1, GETDATE(), NULL, NULL),
		 ( 2, 'Lim�n',					   1, GETDATE(), NULL, NULL),
		 ( 2, 'Sab�',					   1, GETDATE(), NULL, NULL),
		 ( 2, 'Santa F�',				   1, GETDATE(), NULL, NULL),
		 ( 2, 'Santa Rosa de Agu�n',	   1, GETDATE(), NULL, NULL),
		 ( 2, 'Sonaguera',				   1, GETDATE(), NULL, NULL),
		 ( 2, 'Tocoa',					   1, GETDATE(), NULL, NULL),
		 ( 2, 'Bonito Oriental',		   1, GETDATE(), NULL, NULL),
		 ( 3, 'Comayagua',				   1, GETDATE(), NULL, NULL),
		 ( 3, 'Ajuterique',				   1, GETDATE(), NULL, NULL),
		 ( 3, 'El Rosario',				   1, GETDATE(), NULL, NULL),
		 ( 3, 'Esqu�as',				   1, GETDATE(), NULL, NULL),
		 ( 3, 'Humuya',					   1, GETDATE(), NULL, NULL),
		 ( 3, 'La Libertad',			   1, GETDATE(), NULL, NULL),
		 ( 3, 'Laman�',					   1, GETDATE(), NULL, NULL),
		 ( 3, 'La Trinidad',			   1, GETDATE(), NULL, NULL),
		 ( 3, 'Lejaman�',				   1, GETDATE(), NULL, NULL),
		 ( 3, 'Meamb�r',				   1, GETDATE(), NULL, NULL),
		 ( 3, 'Minas de Oro',			   1, GETDATE(), NULL, NULL),
		 ( 3, 'Ojos de Agua',			   1, GETDATE(), NULL, NULL),
		 ( 3, 'San Jer�nimo',			   1, GETDATE(), NULL, NULL),
		 ( 3, 'San Jos� de Comayagua',	   1, GETDATE(), NULL, NULL),
		 ( 3, 'San Jos� del Potrero',	   1, GETDATE(), NULL, NULL),
		 ( 3, 'San Luis',				   1, GETDATE(), NULL, NULL),
		 ( 3, 'San Sebasti�n',			   1, GETDATE(), NULL, NULL),
		 ( 3, 'Siguatepeque',			   1, GETDATE(), NULL, NULL),
		 ( 3, 'Villas de San Antonio',	   1, GETDATE(), NULL, NULL),
		 ( 3, 'Las Lajas',				   1, GETDATE(), NULL, NULL),
		 ( 3, 'Taulab�',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Santa Rosa de Cop�n',	   1, GETDATE(), NULL, NULL),
		 ( 4, 'Caba�as',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Concepci�n',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Cop�n Ruinas',			   1, GETDATE(), NULL, NULL),
		 ( 4, 'Corqu�n',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Cucuyagua',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Dolores',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Dulce Nombre',			   1, GETDATE(), NULL, NULL),
		 ( 4, 'El Para�so',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Florida',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Lajigua',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'La Uni�n',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Nueva Arcadia',			   1, GETDATE(), NULL, NULL),
		 ( 4, 'San Agust�n',			   1, GETDATE(), NULL, NULL),
		 ( 4, 'San Antonio',			   1, GETDATE(), NULL, NULL),
		 ( 4, 'San Jer�nimo',			   1, GETDATE(), NULL, NULL),
		 ( 4, 'San Jos�',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'San Juan de Ocoa',		   1, GETDATE(), NULL, NULL),
		 ( 4, 'San Nicol�s',			   1, GETDATE(), NULL, NULL),
		 ( 4, 'San Pedro',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Santa Rita',				   1, GETDATE(), NULL, NULL),
		 ( 4, 'Trinidad de Cop�n',		   1, GETDATE(), NULL, NULL),
		 ( 4, 'Veracr�z',				   1, GETDATE(), NULL, NULL),
		 ( 5, 'San Pedro Sula',			   1, GETDATE(), NULL, NULL),
		 ( 5, 'Choloma',				   1, GETDATE(), NULL, NULL),
		 ( 5, 'Omoa',					   1, GETDATE(), NULL, NULL),
		 ( 5, 'Pimienta',				   1, GETDATE(), NULL, NULL),
		 ( 5, 'Potrerillos',			   1, GETDATE(), NULL, NULL),
		 ( 5, 'Puerto Cort�s',			   1, GETDATE(), NULL, NULL),
		 ( 5, 'San Antonio de Cort�s',	   1, GETDATE(), NULL, NULL),
	     ( 5, 'San Francisco de Yojoa',    1, GETDATE(), NULL, NULL),
		 ( 5, 'San Manuel',				   1, GETDATE(), NULL, NULL),
		 ( 5, 'Santa Cruz de Yoja',		   1, GETDATE(), NULL, NULL),
		 ( 5, 'La Lima',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'Pascilagua',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'Comcepci�n de Mar�a',	   1, GETDATE(), NULL, NULL),
		 ( 6, 'Duyure',					   1, GETDATE(), NULL, NULL),
		 ( 6, 'El Corpues',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'El Triunfo',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'Marcovia',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'Morolica',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'Namasigue',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'Orocuina',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'Pespire',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'San Antonio de Flores',	   1, GETDATE(), NULL, NULL),
		 ( 6, 'San Isidrio',			   1, GETDATE(), NULL, NULL),
		 ( 6, 'San Jos�',				   1, GETDATE(), NULL, NULL),
		 ( 6, 'San Marcos de Col�n',	   1, GETDATE(), NULL, NULL),
		 ( 6, 'Santa Ana de Yuscuare',	   1, GETDATE(), NULL, NULL),
		 ( 7, 'Yuscar�n',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Alauca',					   1, GETDATE(), NULL, NULL),
		 ( 7, 'Danl�',					   1, GETDATE(), NULL, NULL),
		 ( 7, 'El Para�so',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Guinope',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Jacaleapa',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Liure',					   1, GETDATE(), NULL, NULL),
		 ( 7, 'Morocel�',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Oropol�',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Potrerillos',			   1, GETDATE(), NULL, NULL),
		 ( 7, 'San Antonio de Flores',	   1, GETDATE(), NULL, NULL),
		 ( 7, 'San Lucas',				   1, GETDATE(), NULL, NULL),		 
		 ( 7, 'San Mat�as',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Soledad',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Teupasenti',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Texiguat',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Vado Ancho',				   1, GETDATE(), NULL, NULL),		
		 ( 7, 'Yauyupe',				   1, GETDATE(), NULL, NULL),
		 ( 7, 'Trojes',					   1, GETDATE(), NULL, NULL),
		 ( 8, 'Distrito Central',		   1, GETDATE(), NULL, NULL),
		 ( 8, 'Alubar�n',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'Cedros',					   1, GETDATE(), NULL, NULL),
		 ( 8, 'Cucar�n',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'El Porvenir',			   1, GETDATE(), NULL, NULL),
		 ( 8, 'Guaimaca',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'La Libertad',			   1, GETDATE(), NULL, NULL),
		 ( 8, 'La Venta',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'Lepaterique',			   1, GETDATE(), NULL, NULL),
		 ( 8, 'Maraita',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'Maral�',					   1, GETDATE(), NULL, NULL),
		 ( 8, 'Nueva Armedia',			   1, GETDATE(), NULL, NULL),
		 ( 8, 'Ojojona',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'Orica',					   1, GETDATE(), NULL, NULL),
		 ( 8, 'Reitoca',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'Sabana Grande',			   1, GETDATE(), NULL, NULL),
		 ( 8, 'San Antonio de Oriente',    1, GETDATE(), NULL, NULL),
		 ( 8, 'San Buenaventura',		   1, GETDATE(), NULL, NULL),
		 ( 8, 'San Ignacio',			   1, GETDATE(), NULL, NULL),
		 ( 8, 'San Juan de Flores',		   1, GETDATE(), NULL, NULL),
		 ( 8, 'San Miguelito',			   1, GETDATE(), NULL, NULL),
		 ( 8, 'Santa Ana',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'Santa Luc�a',			   1, GETDATE(), NULL, NULL),
		 ( 8, 'Talanga',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'Tatumbla',				   1, GETDATE(), NULL, NULL),
		 ( 8, 'Valle de �ngeles',		   1, GETDATE(), NULL, NULL),
		 ( 8, 'Villas de San Fernando',    1, GETDATE(), NULL, NULL),
		 ( 8, 'Vallecillo',				   1, GETDATE(), NULL, NULL),
		 ( 9, 'Puerto Lempira',			   1, GETDATE(), NULL, NULL),
		 ( 9, 'Brus Laguna',			   1, GETDATE(), NULL, NULL),
		 ( 9, 'Hauas',					   1, GETDATE(), NULL, NULL),
		 ( 9, 'Juan Francisco Bulnes',	   1, GETDATE(), NULL, NULL),
		 ( 9, 'Villeda Morales',		   1, GETDATE(), NULL, NULL),
		 ( 9, 'Wanpucirpe',				   1, GETDATE(), NULL, NULL),
		 (10, 'La Esperanza',			   1, GETDATE(), NULL, NULL),
		 (10, 'Camasca',				   1, GETDATE(), NULL, NULL),
		 (10, 'Colomcagua',				   1, GETDATE(), NULL, NULL),
		 (10, 'Concepci�n',				   1, GETDATE(), NULL, NULL),
		 (10, 'Dolores',				   1, GETDATE(), NULL, NULL),
		 (10, 'Intibuca',				   1, GETDATE(), NULL, NULL),
		 (10, 'Jesus de Otoro',			   1, GETDATE(), NULL, NULL),
		 (10, 'Magadalena',				   1, GETDATE(), NULL, NULL),
		 (10, 'Masaguara',				   1, GETDATE(), NULL, NULL),
		 (10, 'San Antonio',			   1, GETDATE(), NULL, NULL),
		 (10, 'San Isidro',				   1, GETDATE(), NULL, NULL),
		 (10, 'San Juan',				   1, GETDATE(), NULL, NULL),
		 (10, 'San Marcos de la Sierra',   1, GETDATE(), NULL, NULL),
		 (10, 'San Miguelito',			   1, GETDATE(), NULL, NULL),
		 (10, 'Santa Luc�a',			   1, GETDATE(), NULL, NULL),
		 (10, 'Yamaranguila',			   1, GETDATE(), NULL, NULL),
		 (10, 'San Francisco de Opalaca',  1, GETDATE(), NULL, NULL),
		 (11, 'Roat�n',					   1, GETDATE(), NULL, NULL),
		 (11, 'Guanaja',				   1, GETDATE(), NULL, NULL),
		 (11, 'Jos� Santos Guardiola',	   1, GETDATE(), NULL, NULL),
		 (11, 'Utila',					   1, GETDATE(), NULL, NULL),
		 (12, 'Aguanqueterique',		   1, GETDATE(), NULL, NULL),
		 (12, 'Caba�as',				   1, GETDATE(), NULL, NULL),
		 (12, 'Cane',					   1, GETDATE(), NULL, NULL),
		 (12, 'Chinacla',				   1, GETDATE(), NULL, NULL),
		 (12, 'Guagiquiro',				   1, GETDATE(), NULL, NULL),
		 (12, 'Lauterique',				   1, GETDATE(), NULL, NULL),
		 (12, 'Marcala',				   1, GETDATE(), NULL, NULL),
		 (12, 'Mercedes de Oriente',	   1, GETDATE(), NULL, NULL),
		 (12, 'Opatoro',				   1, GETDATE(), NULL, NULL),
		 (12, 'San Antonio del Norte',	   1, GETDATE(), NULL, NULL),
		 (12, 'San Jos�',				   1, GETDATE(), NULL, NULL),
		 (12, 'San Juan',				   1, GETDATE(), NULL, NULL),
		 (12, 'San Pedro de Tutule',	   1, GETDATE(), NULL, NULL),
		 (12, 'Santa Ana',				   1, GETDATE(), NULL, NULL),
		 (12, 'San Elena',				   1, GETDATE(), NULL, NULL),
		 (12, 'Santa Mar�a',			   1, GETDATE(), NULL, NULL),
		 (12, 'Santiago de Puringla',	   1, GETDATE(), NULL, NULL),
		 (12, 'Yarula',					   1, GETDATE(), NULL, NULL),
		 (13, 'Gracias',				   1, GETDATE(), NULL, NULL),
		 (13, 'Bel�n',					   1, GETDATE(), NULL, NULL),
		 (13, 'Candelaria',				   1, GETDATE(), NULL, NULL),
		 (13, 'Cololaca',				   1, GETDATE(), NULL, NULL),
		 (13, 'Erandique',				   1, GETDATE(), NULL, NULL),
		 (13, 'Guascinse',				   1, GETDATE(), NULL, NULL),
		 (13, 'Guarita',				   1, GETDATE(), NULL, NULL),
		 (13, 'La Campa',				   1, GETDATE(), NULL, NULL),
		 (13, 'La Iguala',				   1, GETDATE(), NULL, NULL),
		 (13, 'Las Flores',				   1, GETDATE(), NULL, NULL),
		 (13, 'La Uni�n',				   1, GETDATE(), NULL, NULL),
		 (13, 'La Virtud',				   1, GETDATE(), NULL, NULL),
		 (13, 'Lepaera',				   1, GETDATE(), NULL, NULL),
		 (13, 'Mapulaca',				   1, GETDATE(), NULL, NULL),
		 (13, 'Piraera',				   1, GETDATE(), NULL, NULL),
		 (13, 'San Andr�s',				   1, GETDATE(), NULL, NULL),
		 (13, 'San Francisco',			   1, GETDATE(), NULL, NULL),
		 (13, 'San Juan Guarita',		   1, GETDATE(), NULL, NULL),
		 (13, 'San Manuel Colohete',	   1, GETDATE(), NULL, NULL),
		 (13, 'San Rafael',				   1, GETDATE(), NULL, NULL),
		 (13, 'San Sebasti�n',			   1, GETDATE(), NULL, NULL),
		 (13, 'Santa Cr�z',				   1, GETDATE(), NULL, NULL),
		 (13, 'Talgua',					   1, GETDATE(), NULL, NULL),
		 (13, 'Tambla',					   1, GETDATE(), NULL, NULL),
		 (13, 'Tomal�',					   1, GETDATE(), NULL, NULL),
		 (13, 'Valladolid',				   1, GETDATE(), NULL, NULL),
		 (13, 'Virginia',				   1, GETDATE(), NULL, NULL),
		 (13, 'San Marcos de Caiquin',	   1, GETDATE(), NULL, NULL),
		 (14, 'Ocotepeque',				   1, GETDATE(), NULL, NULL),
		 (14, 'Bel�n Gualcho',			   1, GETDATE(), NULL, NULL),
		 (14, 'Concepci�n',				   1, GETDATE(), NULL, NULL),
		 (14, 'Dolores Merend�n',		   1, GETDATE(), NULL, NULL),
		 (14, 'Fraternidad',			   1, GETDATE(), NULL, NULL),
		 (14, 'La Encarnaci�n',			   1, GETDATE(), NULL, NULL),
		 (14, 'La Labor',				   1, GETDATE(), NULL, NULL),
		 (14, 'Lucerna',				   1, GETDATE(), NULL, NULL),
		 (14, 'Mercedes',				   1, GETDATE(), NULL, NULL),
		 (14, 'San Fernando',			   1, GETDATE(), NULL, NULL),
		 (14, 'San Francisco del Valle',   1, GETDATE(), NULL, NULL),
		 (14, 'San Jorge',				   1, GETDATE(), NULL, NULL),
		 (14, 'San Marcos',				   1, GETDATE(), NULL, NULL),
		 (14, 'Santa F�',				   1, GETDATE(), NULL, NULL),
		 (14, 'Sesenti',				   1, GETDATE(), NULL, NULL),
		 (14, 'Sinuapa',				   1, GETDATE(), NULL, NULL),
		 (15, 'Juticalpa',				   1, GETDATE(), NULL, NULL),
		 (15, 'Campamento',				   1, GETDATE(), NULL, NULL),
		 (15, 'Catacamas',				   1, GETDATE(), NULL, NULL),
		 (15, 'Concordia',				   1, GETDATE(), NULL, NULL),
		 (15, 'Dulce Nombre de Culm�',	   1, GETDATE(), NULL, NULL),
		 (15, 'El Rosario',				   1, GETDATE(), NULL, NULL),
		 (15, 'Esqu�pulas del Norte',	   1, GETDATE(), NULL, NULL),
		 (15, 'Gualaco',				   1, GETDATE(), NULL, NULL),
		 (15, 'Guarizama',				   1, GETDATE(), NULL, NULL),
		 (15, 'Guata',					   1, GETDATE(), NULL, NULL),
		 (15, 'Guayape',				   1, GETDATE(), NULL, NULL),
		 (15, 'Jano',					   1, GETDATE(), NULL, NULL),
		 (15, 'La Uni�n',				   1, GETDATE(), NULL, NULL),
		 (15, 'Mangulile',				   1, GETDATE(), NULL, NULL),
		 (15, 'Manto',					   1, GETDATE(), NULL, NULL),
		 (15, 'Salam�',					   1, GETDATE(), NULL, NULL),
		 (15, 'San Esteban',			   1, GETDATE(), NULL, NULL),
		 (15, 'San Francisco de Becerra',  1, GETDATE(), NULL, NULL),
		 (15, 'San Francisco de La Paz',   1, GETDATE(), NULL, NULL),
		 (15, 'San Mar�a del Real',		   1, GETDATE(), NULL, NULL),
		 (15, 'Silca',					   1, GETDATE(), NULL, NULL),
		 (15, 'Yocon',					   1, GETDATE(), NULL, NULL),
		 (15, 'Patuca',					   1, GETDATE(), NULL, NULL),
		 (16, 'Santa B�rbara',			   1, GETDATE(), NULL, NULL),
		 (16, 'Arada',					   1, GETDATE(), NULL, NULL),
		 (16, 'Atima',					   1, GETDATE(), NULL, NULL),
		 (16, 'Azacualpa',				   1, GETDATE(), NULL, NULL),
		 (16, 'Ceguaca',				   1, GETDATE(), NULL, NULL),
		 (16, 'Concepci�n del Norte',	   1, GETDATE(), NULL, NULL),
		 (16, 'Concepci�n del Sur',		   1, GETDATE(), NULL, NULL),
		 (16, 'Chinda',					   1, GETDATE(), NULL, NULL),
		 (16, 'El N�spero',				   1, GETDATE(), NULL, NULL),
		 (16, 'Gualala',				   1, GETDATE(), NULL, NULL),
		 (16, 'Ilama',					   1, GETDATE(), NULL, NULL),
		 (16, 'Las Vegas',				   1, GETDATE(), NULL, NULL),
		 (16, 'Macuelizo',				   1, GETDATE(), NULL, NULL),
		 (16, 'Naranjito',				   1, GETDATE(), NULL, NULL),
		 (16, 'Nuevo Celilac',			   1, GETDATE(), NULL, NULL),
		 (16, 'Nueva Frontera',			   1, GETDATE(), NULL, NULL),
		 (16, 'Petoa',					   1, GETDATE(), NULL, NULL),
		 (16, 'Protecci�n',				   1, GETDATE(), NULL, NULL),
		 (16, 'Quimist�n',				   1, GETDATE(), NULL, NULL),
		 (16, 'San Francisco de Ojuera',   1, GETDATE(), NULL, NULL),
		 (16, 'San Jos� de Colinas',	   1, GETDATE(), NULL, NULL),
		 (16, 'San Luis',				   1, GETDATE(), NULL, NULL),
		 (16, 'San Marcos',				   1, GETDATE(), NULL, NULL),
		 (16, 'San Nicol�s',			   1, GETDATE(), NULL, NULL),
		 (16, 'San Pedro Zacapa',		   1, GETDATE(), NULL, NULL),
		 (16, 'San Vicente Centenario',    1, GETDATE(), NULL, NULL),
		 (16, 'Santa Rita',				   1, GETDATE(), NULL, NULL),
		 (16, 'Trinidad',				   1, GETDATE(), NULL, NULL),
		 (17, 'Nacome',					   1, GETDATE(), NULL, NULL),
		 (17, 'Alianza',				   1, GETDATE(), NULL, NULL),
		 (17, 'Amapala',				   1, GETDATE(), NULL, NULL),
		 (17, 'Aramecina',				   1, GETDATE(), NULL, NULL),
		 (17, 'Caridad',				   1, GETDATE(), NULL, NULL),
		 (17, 'Goascor�n',				   1, GETDATE(), NULL, NULL),
		 (17, 'Langue',					   1, GETDATE(), NULL, NULL),
		 (17, 'San Francisco de Coray',    1, GETDATE(), NULL, NULL),
		 (17, 'San Lorenzo',			   1, GETDATE(), NULL, NULL),
		 (18, 'Yoro',					   1, GETDATE(), NULL, NULL),
		 (18, 'Arenal',					   1, GETDATE(), NULL, NULL),
		 (18, 'El Negrito',				   1, GETDATE(), NULL, NULL),
		 (18, 'El Progreso',			   1, GETDATE(), NULL, NULL),
		 (18, 'Joc�n',					   1, GETDATE(), NULL, NULL),
		 (18, 'Moraz�n',				   1, GETDATE(), NULL, NULL),
		 (18, 'Olanchito',				   1, GETDATE(), NULL, NULL),
		 (18, 'Santa Rita',				   1, GETDATE(), NULL, NULL),
		 (18, 'Sulaco',					   1, GETDATE(), NULL, NULL),
		 (18, 'Victoria',				   1, GETDATE(), NULL, NULL),
		 (18, 'Yorito',					   1, GETDATE(), NULL, NULL);
		



CREATE TABLE Gral.tbSucursales (
		suc_Id				INT IDENTITY(1,1)	NOT NULL PRIMARY KEY,
		suc_Descripcion		NVARCHAR(100)		NOT NULL,
		suc_Municipio		INT					NOT NULL,

		suc_UsuCrea			INT,
		suc_FechaCrea		DATETIME			DEFAULT GETDATE(),
		suc_usuModi			INT,
		suc_FechaModi		DATETIME,
		suc_Estado			BIT DEFAULT 1,

		CONSTRAINT FK_Maqui_tbSucursales_Gral_tbMunicipios FOREIGN KEY (suc_Municipio) REFERENCES Gral.tbMunicipios(mun_Id),
		CONSTRAINT FK_Gral_tbSucursales_suc_UsuCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(suc_UsuCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Gral_tbSucursales_suc_usuModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(suc_usuModi) REFERENCES Gral.tbUsuarios(usu_ID)
);


INSERT INTO Gral.tbSucursales
VALUES  ('Beaty Face', 64,				 1, GETDATE(), NULL, NULL, 1),
		('Kriz Reales Studio', 64,		 1, GETDATE(), NULL, NULL, 1),
		('Beauty Supply Honduras', 111,  1, GETDATE(), NULL, NULL, 1),
		('Elf Cosmetics HN', 23,	     1, GETDATE(), NULL, NULL, 1),
		('Miami Beaty HN', 45,			 1, GETDATE(), NULL, NULL, 1),
		('Maquillajes Express', 230,	 1, GETDATE(), NULL, NULL, 1),
		('Cosmetics Depot', 67,			 1, GETDATE(), NULL, NULL, 1),
		('Makeup Studio', 98,			 1, GETDATE(), NULL, NULL, 1),
		('Tiendas Alisson', 88,			 1, GETDATE(), NULL, NULL, 1),
		('Tiendas Kelys', 29,			 1, GETDATE(), NULL, NULL, 1),
		('Og Beaty',61,					 1, GETDATE(), NULL, NULL, 1),
		('Sophis Beaty Studio', 130,	 1, GETDATE(), NULL, NULL, 1),
		('Xicero Makeup', 210,			 1, GETDATE(), NULL, NULL, 1),
	    ('Goc Makeup', 246,				 1, GETDATE(), NULL, NULL, 1),
		('Magic Makeup', 176,			 1, GETDATE(), NULL, NULL, 1),
		('Cosm�tica Mima', 132,			 1, GETDATE(), NULL, NULL, 1),
		('AR Makeup', 155,				 1, GETDATE(), NULL, NULL, 1),
		('Novedades Salom�', 110,		 1, GETDATE(), NULL, NULL, 1),
		('Pretty Rose MakeUp', 284,		 1, GETDATE(), NULL, NULL, 1),
		('Fedcp', 2,					 1, GETDATE(), NULL, NULL, 1);


CREATE TABLE Gral.tbEmpleados(
		emp_ID				INT IDENTITY(1,1) PRIMARY KEY,
		emp_Nombre			NVARCHAR(250)		NOT NULL,
		emp_Apellido		NVARCHAR(250)		NOT NULL,
		emp_DNI				VARCHAR(13)			NOT NULL,
		emp_FechaNacimiento DATE				NOT NULL,
		emp_Sexo			CHAR(1)				NOT NULL,
		emp_Telefono		NVARCHAR(100)		NOT NULL,
		emp_Municipio		INT					NOT NULL,
		emp_Correo			NVARCHAR(250)		NOT NULL,
		emp_EstadoCivil		INT					NOT NULL,
		emp_Sucursal		INT					NOT NULL,

		emp_UsuarioCrea		INT					NOT NULL,
		emp_FechaCrea		DATETIME			DEFAULT GETDATE(),
		emp_UsuarioModi		INT,
		emp_FechaModi		DATETIME,
		emp_Estado			BIT					DEFAULT 1

		CONSTRAINT UQ_Gral_tbEmpleados_emp_DNI		UNIQUE		(emp_DNI),
		CONSTRAINT CK_Gral_tbEmpleados_emp_Sexo		CHECK		(emp_Sexo IN ('F', 'M')),
		CONSTRAINT FK_Gral_tbEmpleados_emp_Sucursal_Gral_tbSucursales_emp_Sucursal_suc_Id	FOREIGN KEY (emp_Sucursal)		REFERENCES Gral.tbSucursales(suc_Id),
		CONSTRAINT FK_Gral_tbEmpleados_emp_Municipio_Gral_tbMunicipios_mun_ID				FOREIGN KEY (emp_Municipio)		REFERENCES Gral.tbMunicipios  (mun_ID),
		CONSTRAINT FK_Gral_tbEmpleados_emp_EstadoCivil_Gral_tbEstadoCivil_est_ID			FOREIGN KEY (emp_EstadoCivil)	REFERENCES Gral.tbEstadosCiviles (est_ID),
		CONSTRAINT FK_Gral_tbEmpleados_emp_UsuarioCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(emp_UsuarioCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Gral_tbEmpleados_emp_UsuarioModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(emp_UsuarioModi) REFERENCES Gral.tbUsuarios(usu_ID)
);

INSERT INTO Gral.tbEmpleados
VALUES  ('Hugo', 'Alcerro', '1615199009008', '1990-08-09', 'M', '+504 9009-6778', 200, 'hugalcerro@gmail.com', 2, 4,		1, GETDATE(), NULL, NULL, 1),
		('Mariela', 'Vega', '0910197600977', '1998-10-23', 'F', '+504 9878-3241', 111, 'marvega@gmail.com', 1, 6,			1, GETDATE(), NULL, NULL, 1),
		('Oliver', 'Membre�o', '0901199209034', '1992-12-09', 'M', '+504 8909-3343', 23, 'olimem@gmail.com', 3, 7,			1, GETDATE(), NULL, NULL, 1),
		('Ernestina', 'Mej�a', '0304199790567', '1997-02-10', 'F', '+504 9780-5463', 89, 'ernesmia@gmail.com', 6, 14,		1, GETDATE(), NULL, NULL, 1),
		('Sandro', 'Yanez', '0309199009890', '1990-10-26', 'M', '+504 9767-6657', 54, 'sandroyane@gmail.com', 7, 10,		1, GETDATE(), NULL, NULL, 1),
		('Juana', 'Juarez', '1002199062718', '1990-05-21', 'F', '+504 9231-6512', 90, 'juajua@gmail.com', 3, 11,			1, GETDATE(), NULL, NULL, 1),
		('Nelson', 'Uma�a', '1102198900090', '1989-02-10', 'M', '+504 9345-5161', 54, 'nelu�a@gmail.com', 1, 8,				1, GETDATE(), NULL, NULL, 1),
		('Carolina', 'Menjivar', '1109199908956', '1999-05-04', 'F', '+504 9789-5565', 87, 'caromen@gmail.com', 5, 19,		1, GETDATE(), NULL, NULL, 1),
		('Victor', 'Carcasa', '1210197600097', '1976-09-10', 'M', '+504 9451-5643', 23, 'viccarra@gmail.com', 6, 2,			1, GETDATE(), NULL, NULL, 1),
		('Tania', 'Lopez', '0912199090790', '1990-10-29', 'F', '+504 9134-5261', 180, 'tanlope@gmail.com', 1, 3,			1, GETDATE(), NULL, NULL, 1),
		('Betulio', 'Nu�ez', '1202199409890', '1997-12-18', 'M', '+504 8909-6473', 121, 'betunu@gmail.com', 2, 18,			1, GETDATE(), NULL, NULL, 1),
		('Yulissa', 'Sanchez', '1202197809001', '1978-12-23', 'F', '+504 9809-6657', 150, 'yulisan@gmail.com', 3, 12,		1, GETDATE(), NULL, NULL, 1),
		('Ilinois', 'Urqu�a', '1109198500909', '1985-06-25', 'M', '+504 8298-9089', 230, 'ilinourquia@gmail.com', 4, 15,	1, GETDATE(), NULL, NULL, 1),
		('Carla', 'Oliva', '0413198809067', '1988-04-20', 'F', '+504 9567-7789', 241, 'caroli@gmail.com', 5, 14,			1, GETDATE(), NULL, NULL, 1),
		('Rodrigo', 'Buena', '0412199089009', '1990-11-09', 'M', '+504 9587-4521', 143, 'rodribue@gmail.com', 6, 17,		1, GETDATE(), NULL, NULL, 1),
		('Nidia', 'Rodr�guez', '0911199809896', '1998-12-20', 'F', '+504 9954-7768', 25, 'nidirodri@gmail.com', 7, 5,		1, GETDATE(), NULL, NULL, 1),
		('Ulises', 'Villega', '1514199609890', '1996-09-02', 'M', '+504 9888-0909', 54, 'uliville@gmail.com', 1, 6,			1, GETDATE(), NULL, NULL, 1),
		('Tiana', 'Petoa', '0915199056281', '1990-10-15', 'F', '+504 9867-5546', 96, 'tuapetoa@gmail.com', 2, 7,			1, GETDATE(), NULL, NULL, 1),
		('Mario', 'Herrera', '0912199072819', '1990-04-21', 'M', '+504 9123-5434', 77, 'marioherre@gmail.com', 3, 8,		1, GETDATE(), NULL, NULL, 1),
		('Elia', 'Mej�a', '0917199072819', '1990-09-11', 'F', '+504 9678-4453', 87, 'eliameji@gmail.com', 4, 9,				1, GETDATE(), NULL, NULL, 1);

--*****************************************CONSTRAINT DE EMPLEADOS EN LA TABLA USUARIOS*****************************************--
ALTER TABLE Gral.tbUsuarios
ADD CONSTRAINT FK_Gral_tbUsuarios_usu_empID_Gral_tbEmpleados_emp_ID	FOREIGN KEY (usu_empID) REFERENCES Gral.tbEmpleados�(emp_ID)
--*****************************************CONSTRAINT DE EMPLEADOS EN LA TABLA USUARIOS*****************************************--

CREATE TABLE Gral.tbClientes(

		cli_ID				INT IDENTITY(1,1) PRIMARY KEY,
		cli_Nombre			NVARCHAR(250)		NOT NULL,
		cli_Apellido		NVARCHAR(250)		NOT NULL,
		cli_DNI				VARCHAR(13)			NOT NULL,
		cli_FechaNacimiento DATE				NOT NULL,
		cli_Sexo			CHAR(1)				NOT NULL,
		cli_Telefono		NVARCHAR(100)		NOT NULL,
		cli_Municipio		INT					NOT NULL,
		cli_EstadoCivil		INT					NOT NULL,
		

		cli_UsuarioCrea		INT					NOT NULL,
		cli_FechaCrea		DATETIME			DEFAULT GETDATE(),
		cli_UsuarioModi		INT,
		cli_FechaModi		DATETIME,
		cli_Estado			BIT					DEFAULT 1

		CONSTRAINT UQ_Gral_tbClientes_cli_DNI			UNIQUE		(cli_DNI),
		CONSTRAINT CK_Gral_tbClientes_cli_Sexo		CHECK		(cli_Sexo IN ('F', 'M')),
		CONSTRAINT FK_Gral_tbClientes_cli_Municipio_Gral_tbMunicipios_mun_ID	FOREIGN KEY (cli_Municipio)	    REFERENCES Gral.tbMunicipios  (mun_ID),
		CONSTRAINT FK_Gral_tbClientes_cli_EstadoCivil_Gral_tbEstadoCivil_est_ID	FOREIGN KEY (cli_EstadoCivil)	REFERENCES Gral.tbEstadosCiviles (est_ID),
		CONSTRAINT FK_Gral_tbClientes_cli_UsuarioCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(cli_UsuarioCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Gral_tbClientes_cli_UsuarioModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(cli_UsuarioModi) REFERENCES Gral.tbUsuarios(usu_ID)
);


INSERT INTO Gral.tbClientes
VALUES  ('Hugo', 'Mendoza', '1904425167251', '1990-12-15', 'M', '+504 9341-9097', 112, 1, 			1, GETDATE(), NULL, NULL, 1),
		('Sarai', 'Quintanilla', '1109199062781', '1990-12-15', 'F', '+504 9123-5543', 111, 1, 		1, GETDATE(), NULL, NULL, 1),
		('Marco', 'Torrez', '1109199828192', '1998-09-12', 'M', '+504 8908-5463', 23, 3, 			1, GETDATE(), NULL, NULL, 1),
		('Celina', 'Arias', '0912199064782', '1990-09-12', 'F', '+504 9657-7483', 89, 6, 			1, GETDATE(), NULL, NULL, 1),
		('Luis', 'Chicas', '0910199298128', '1992-09-27', 'M', '+504 9834-5621', 54, 7, 			1, GETDATE(), NULL, NULL, 1),
		('Angie', 'Andino', '0912199028739', '1990-05-21', 'F', '+504 9064-7869', 90, 3, 			1, GETDATE(), NULL, NULL, 1),
		('Nelson', 'Uma�a', '1102198900090', '1989-02-10', 'M', '+504 9345-5161', 54, 1, 			1, GETDATE(), NULL, NULL, 1),
		('Marbella', 'G�mez', '0815199789023', '1997-09-02', 'F', '+504 9809-5461', 87, 5, 			1, GETDATE(), NULL, NULL, 1),
		('Carlos', 'Amaya', '0914199567281', '1995-09-05', 'M', '+504 9109-6573', 23, 6, 			1, GETDATE(), NULL, NULL, 1),
		('Dayana', 'Erazo', '1805199678934', '1995-03-21', 'F', '+504 9563-7381', 180, 1, 			1, GETDATE(), NULL, NULL, 1),
		('Jasson', 'Zald�var', '0912199856271', '1998-09-21', 'M', '+504 9100-7584', 121, 2, 		1, GETDATE(), NULL, NULL, 1),
		('Marlin', 'Guzm�n', '0213199456721', '1994-10-07', 'F', '+504 9822-5216', 150, 3, 			1, GETDATE(), NULL, NULL, 1),
		('Yoner', 'Zald�var', '0913199245162', '1992-09-25', 'M', '+504 8145-6627', 230, 4, 		1, GETDATE(), NULL, NULL, 1),
		('Genesis', 'Sagastume', '0914199820192', '1988-09-07', 'F', '+504 9203-8749', 241, 5, 		1, GETDATE(), NULL, NULL, 1),
		('Anthony', 'Leiva', '0415198962592', '1989-11-03', 'M', '+504 9631-7521', 143, 6, 			1, GETDATE(), NULL, NULL, 1),
		('Paola', 'Decas', '0914199678291', '1996-09-23', 'F', '+504 9561-2331', 25, 7, 			1, GETDATE(), NULL, NULL, 1),
		('Caleb', 'Ben�tez', '1401199078676', '1990-03-27', 'M', '+504 9521-5547', 54, 1, 			1, GETDATE(), NULL, NULL, 1),
		('Exibia', 'Bueso', '0314199800989', '1998-02-15', 'F', '+504 9312-7584', 96, 2, 			1, GETDATE(), NULL, NULL, 1),
		('Carlos', 'Herrera', '0314199062712', '1990-04-22', 'M', '+504 9623-9956', 77, 3, 			1, GETDATE(), NULL, NULL, 1),
		('Ana', 'Fajardo', '0913199092738', '1998-09-23', 'F', '+504 9027-8867', 87, 4,				1, GETDATE(), NULL, NULL, 1);



		



--//************************ TABLAS TIENDA ************************--//
GO
CREATE SCHEMA Maqui
GO

CREATE TABLE Maqui.tbProveedores(
		prv_ID				    INT IDENTITY(1,1) PRIMARY KEY,
		prv_NombreCompa�ia		NVARCHAR(250)		NOT NULL,
		prv_NombreContacto		NVARCHAR(250)		NOT NULL,
		prv_TelefonoContacto	NVARCHAR(100)		NOT NULL,
		
		prv_DireccionEmpresa	NVARCHAR(200)		NOT NULL,
		prv_DireccionContacto	NVARCHAR(200)		NOT NULL,
		prv_SexoContacto		CHAR(1)				NOT NULL,

		prv_UsuarioCrea			INT					NOT NULL,
		prv_FechaCrea		    DATETIME			DEFAULT GETDATE(),
		prv_UsuarioModi			INT,
		prv_FechaModi		    DATETIME,
		prv_Estado			    BIT					DEFAULT 1,

		
		CONSTRAINT FK_Maqui_tbProveedores_prv_UsuarioCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(prv_UsuarioCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Maqui_tbProveedores_prv_UsuarioModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(prv_UsuarioModi) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT CK_Maqui_tbProveedores_prv_SexoContacto CHECK (prv_SexoContacto IN ('F','M'))

);
INSERT INTO Maqui.tbProveedores
VALUES  
		('Lubre Cosm�tica Natural', 'Francsico Mej�a', '+504 9878-4562',  'Calle hacia Armenta, atras de Mall Altara.','1ra Calle, Salida a La Lima','F',	1, GETDATE(), NULL, NULL, 1),
		('Ortrade', 'Blanca Wong', '+504 9809-4453',  '3ra Avenida, 2da Calle Prolonogaci�n Pasaje Valle','1ra Calle, Salida a La Lima','F',				1, GETDATE(), NULL, NULL, 1),
		('Yesensy', 'Marlon Lee', '+504 9856-6371',  '1ra Calle, Salida a La Lima',	'1ra Calle, Salida a La Lima','F',									1, GETDATE(), NULL, NULL, 1),
		('Bamboo Cosmetcis', 'Tristan Thompson', '+504 9801-3561',  '1ra Calle, 3ra Avenida, Frente al Parque Central','1ra Calle, Salida a La Lima','F',	1, GETDATE(), NULL, NULL, 1),
		('Laboratorios Anteii', 'Ulises Menjivar', '+504 8790-4352', '5ta Calle, 5ta Avenida, Barrio El Centro','1ra Calle, Salida a La Lima','F',		1, GETDATE(), NULL, NULL, 1),
		('Divasa Cosmetics', 'Pedro Urqu�a', '+504 8909-5564',  '4 y 5 Calle, 2da Avenida, Barrio El Centro','1ra Calle, Salida a La Lima','F',			1, GETDATE(), NULL, NULL, 1),
		('CosmetiChile', 'Maryuri Lee', '+504 8909-5563',  '2da Calle, Avenida Junior',	'1ra Calle, Salida a La Lima','F',								1, GETDATE(), NULL, NULL, 1),
		('Kylie Cosmetics', 'Angie Campos', '+504 9756-3311',  '1ra Calle, 4ta Avenida, Barrio Concepci�n',	'1ra Calle, Salida a La Lima','F',			1, GETDATE(), NULL, NULL, 1),
		('Guangzhou Xiran Cosmetics Co.', 'Sandra Xiang', '+504 9867-8954',  'Bo. del Norte', '1ra Calle, Salida a La Lima','F',						1, GETDATE(), NULL, NULL, 1),
		('Bause Cosmetcis', 'Julissa Liang', '+504 8756-3412',  '5ta Calle, 3ra Avenida, Atr�s de Tropigas','1ra Calle, Salida a La Lima','F',			1, GETDATE(), NULL, NULL, 1),
		('Frida Cosmetics', 'Karla Eraza', '+504 9756-3526',  '16 Avenida, Barrio Suyapa',	'1ra Calle, Salida a La Lima','F',							1, GETDATE(), NULL, NULL, 1),
		('Paulis MakeUp', 'Yana Rodr�guez', '+504 9786-4451',  'Calle Salida Vieja a La Lima',	'1ra Calle, Salida a La Lima','F',						1, GETDATE(), NULL, NULL, 1),
		('Maquillaje Stock', 'Oliver Memphis', '+504 8967-4251',  'Barrio El Calvario, Calle Principal',	'1ra Calle, Salida a La Lima','F',			1, GETDATE(), NULL, NULL, 1),
		('Seyt�', 'Ernesto Lopez', '+504 9878-3300',  'Col. El Carmen, Calle Principal',		'1ra Calle, Salida a La Lima','F',						1, GETDATE(), NULL, NULL, 1),
		('Ibella', 'Vanessa Banegas', '+504 9878-5536', 'Avenida Circunvalaci�n',	'1ra Calle, Salida a La Lima','F',									1, GETDATE(), NULL, NULL, 1),
		('Estudio Juvenil', 'Juana Jer�x', '+504 9299-5637',  'Avenida los Olivos, 6ta Calle, 1ra Avenida',	'1ra Calle, Salida a La Lima','F',			1, GETDATE(), NULL, NULL, 1),
		('Cosm�ticos al por Mayor', 'Paulina Guatusa', '+504 8900-6738',  'Avenida Francisco Olivos',	'1ra Calle, Salida a La Lima','F',				1, GETDATE(), NULL, NULL, 1),
		('DisDroper', 'Fanny Hungr�a', '+504 9877-5362',  'Col. Trinidad Yanez',	'1ra Calle, Salida a La Lima','F',									1, GETDATE(), NULL, NULL, 1),
		('Cosbelly Profesional', 'Deiby Guerra', '+504 9877-4412',  'Col. Villa Nuria',		'1ra Calle, Salida a La Lima','F',							1, GETDATE(), NULL, NULL, 1),
		('Fransua', 'Maicoll Hungaro', '+504 9677-3142', 'Col. Yanez',			'1ra Calle, Salida a La Lima','F',										1, GETDATE(), NULL, NULL, 1);



CREATE TABLE Maqui.tbCategorias(
		cat_Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		cat_Descripcion NVARCHAR(100) NOT NULL,

		cat_UsuCrea INT,
		cat_FechaCrea DATETIME DEFAULT GETDATE(),
		cat_UsuModi INT,
		cat_FechaModi DATETIME,
		cat_Estado BIT DEFAULT 1

		CONSTRAINT FK_Maqui_tbCategorias_cat_UsuCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(cat_UsuCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Maqui_tbCategorias_cat_UsuModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(cat_UsuModi) REFERENCES Gral.tbUsuarios(usu_ID)
);

INSERT INTO Maqui.tbCategorias
VALUES	('Labiales',				1, GETDATE(), NULL, NULL, 1),
		('Sombras',					1, GETDATE(), NULL, NULL, 1),
		('Rubores',					1, GETDATE(), NULL, NULL, 1),
		('Polvos',					1, GETDATE(), NULL, NULL, 1),
		('Bases',					1, GETDATE(), NULL, NULL, 1),
		('Cuidado para la Piel',	1, GETDATE(), NULL, NULL, 1),
		('Delineadores',			1, GETDATE(), NULL, NULL, 1),
		('R�meles',					1, GETDATE(), NULL, NULL, 1);





CREATE TABLE Maqui.tbMetodoPago (
		met_Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		met_Descripcion NVARCHAR(100) NOT NULL,

		met_UsuCrea INT,
		met_FechaCrea DATETIME DEFAULT GETDATE(),
		met_usuModi INT,
		met_FechaModi DATETIME,
		met_Estado BIT DEFAULT 1

		CONSTRAINT FK_Maqui_tbMetodoPago_met_UsuCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(met_UsuCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Maqui_tbMetodoPago_met_usuModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(met_usuModi) REFERENCES Gral.tbUsuarios(usu_ID)
);


INSERT INTO maqui.tbMetodoPago
VALUES  ('Efectivo',							 1, GETDATE(), NULL, NULL, 1),
		('Cheques',								 1, GETDATE(), NULL, NULL, 1),
		('Tarjeta de D�bito',					 1, GETDATE(), NULL, NULL, 1),
		('Tarjeta de Cr�dito',					 1, GETDATE(), NULL, NULL, 1),
		('Pagos M�viles',						 1, GETDATE(), NULL, NULL, 1),
		('Tranferencias Bancarias Electr�nicas', 1, GETDATE(), NULL, NULL, 1);


CREATE TABLE Maqui.tbProductos(
		pro_Id				INT IDENTITY(1,1) PRIMARY KEY	NOT NULL,
		pro_Codigo			NVARCHAR(100)					NOT NULL,
		pro_Nombre			NVARCHAR(100)					NOT NULL,
		pro_StockInicial	NVARCHAR(100)					NOT NULL,
		pro_PrecioUnitario	DECIMAL(18,2)					NOT NULL,
		pro_Proveedor		INT,
		pro_Categoria		INT,
		pro_usuCrea			INT,
		pro_FechaCrea		DATETIME						DEFAULT GETDATE(),
		pro_UsuModi			INT,
		pro_FechaModi		DATETIME,
		pro_Estado			BIT								DEFAULT 1

		CONSTRAINT UK_Maqui_tbProductos_pro_Codigo UNIQUE(pro_Codigo),
		CONSTRAINT FK_Maqui_tbProductos_Maqui_tbProveedores_pro_Proveedor FOREIGN KEY (pro_Proveedor) REFERENCES Maqui.tbProveedores(prv_Id),
		CONSTRAINT FK_Maqui_tbProductos_pro_usuCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(pro_usuCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Maqui_tbProductos_pro_UsuModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(pro_UsuModi) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Maqui_tbProductos_pro_Categoria_Maqui_tbCategorias_cat_ID FOREIGN KEY(pro_Categoria) REFERENCES Maqui.tbCategorias (cat_ID)
);

INSERT INTO Maqui.tbProductos
VALUES  ('LBLRM', 'Labial rojo l�quido de tinta mate.', '200', 50.00, 1,1,		1, GETDATE(), NULL, NULL, 1),
		('LBGLB', 'Labial gloss con brillantina.', '200', 60.00, 4,1,				1, GETDATE(), NULL, NULL, 1),
		('LBROM', 'Labial rosado de tinta mate.', '200', 70.00, 7,1	,			1, GETDATE(), NULL, NULL, 1),
		('LBNTM', 'Labial nude de tinta mate.', '200', 80.00, 9,1	,			1, GETDATE(), NULL, NULL, 1),
		('LBMTC', 'Labial morado de tinta cremosa.', '200', 45.00, 10,1,			1, GETDATE(), NULL, NULL, 1),
		('PTNNP', 'Paleta The New Nude Palette', '200', 200.00, 15,	2	,		1, GETDATE(), NULL, NULL, 1),
		('PNLEP', 'Paleta Natural Lust Eye Palette', '200',  400.00, 19,	2,	1, GETDATE(), NULL, NULL, 1),
		('PNHPA', 'Paleta Naked Heat Palette', '200',  560.00, 12,	2			,1, GETDATE(), NULL, NULL, 1),
		('PTBPA', 'Paleta The Burgundy Palette', '200',450.00, 11,		2		,1, GETDATE(), NULL, NULL, 1),
		('PTIBP', 'Paleta Tartelette in Bloom Palette', '200',  3400.00, 15,2	,1, GETDATE(), NULL, NULL, 1),
		('RBBBL', 'Rubor Baked Blush', '200', 2300.00, 3,	3					,1, GETDATE(), NULL, NULL, 1),
		('RBMON', 'Rubor Monochromatic', '200', 2350.00, 17,	3				,1, GETDATE(), NULL, NULL, 1),
		('RBFIT', 'Rubor FitMe', '200', 540.00, 18,				3				,1, GETDATE(), NULL, NULL, 1),
		('RBPPB', 'Rubor Pink Peach Bums', '200', 340.00, 20,	3				,1, GETDATE(), NULL, NULL, 1),
		('RBCHE', 'Rubor Cheekers', '200', 2300.00, 4,			3				,1, GETDATE(), NULL, NULL, 1),
		('POLPU', 'Polvo PUR', '200',  450.00, 17,				4				,1, GETDATE(), NULL, NULL, 1),
		('POLFM', 'Polvo FitMe Mate', '200',  340.00, 15,		4				,1, GETDATE(), NULL, NULL, 1),
		('POLHG', 'Polvo Halo Glow', '200', 570.00, 20,			4				,1, GETDATE(), NULL, NULL, 1),
		('POLSF', 'Polvo Soft Flex', '200',  230.00, 20,		4				,1, GETDATE(), NULL, NULL, 1),
		('POLTM', 'Polvo True Match', '200', 657.00, 19,		4				,1, GETDATE(), NULL, NULL, 1),
		('BASSA', 'Base Simply Ageless', '200',120.00, 12,		5				,1, GETDATE(), NULL, NULL, 1),
		('BASLI', 'Base Liquida', '200', 340.00, 15,			5				,1, GETDATE(), NULL, NULL, 1),
		('BASSM', 'Base StayMate', '200', 450.00, 9,			5				,1, GETDATE(), NULL, NULL, 1),
		('BASDM', 'Base Dermacol', '200', 100.00, 8,			5				,1, GETDATE(), NULL, NULL, 1),
		('BASCF', 'Base Clean Fresh', '200', 200.00, 7,			5				,1, GETDATE(), NULL, NULL, 1),
		('LIMAS', 'Limpiador de �cido salic�lico.', '200', 1200.00, 7, 6		,	1, GETDATE(), NULL, NULL, 1),
		('EXFLI', 'Exfoliante l�quido.', '200', 500.00, 7,				6		,1, GETDATE(), NULL, NULL, 1),
		('CRENO', 'Crema renovaci�n de noche', '200', 1980.00, 12,		6		,1, GETDATE(), NULL, NULL, 1),
		('SEVIC', 'Ser�m con vitamina ', '200', 870.00, 5,				6		,1, GETDATE(), NULL, NULL, 1),
		('MABAN', 'Mascarilla de�barro�del�mar.', '200', 560.00, 4,		6		,1, GETDATE(), NULL, NULL, 1),
		('DLIGR', 'Delineador Infallible Grip', '200',  460.00, 14,		7		,1, GETDATE(), NULL, NULL, 1),
		('DLNOB', 'Delineador No Budget', '200', 580.00, 12,			7		,1, GETDATE(), NULL, NULL, 1),
		('DLNYX', 'Delineador NYX Mec�nico', '200', 1000.00, 17,		7		,1, GETDATE(), NULL, NULL, 1),
		('DLSRE', 'Delineador Stila resistente al agua.', '200', 450.00, 4,7	,	1, GETDATE(), NULL, NULL, 1),
		('DLCOL', 'Delineador Colorstay', '200', 235.00, 7,				7		,1, GETDATE(), NULL, NULL, 1),
		('RIEXA', 'Rimel Exaggerete', '200', 230.00, 3,					8		,1, GETDATE(), NULL, NULL, 1),
		('RIDUF', 'Rimel Durable ', '200', 450.00, 16,					8		,1, GETDATE(), NULL, NULL, 1),
		('RIMAE', 'Rimel Magnific Eyes', '200', 600.00, 17,				8		,1, GETDATE(), NULL, NULL, 1),
		('RILSM', 'Rimel London Stay Matte', '200', 700.00, 12,			8		,1, GETDATE(), NULL, NULL, 1),
		('RISGL', 'Rimel�Stay�Gloss', '200',500.00, 2,					8		,1, GETDATE(), NULL, NULL, 1);


--CREATE TABLE Maqui.tbCategoriaProductos(
--		cpr_Id				INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
--		cpr_Categoria		INT NOT NULL,
--		cpr_Producto		INT NOT NULL,
		
--		cpr_UsuCrea			INT,
--		cpr_FechaCrea		DATETIME DEFAULT GETDATE(),
--		cpr_usuModi			INT,
--		cpr_FechaModi		DATETIME,
--		cpr_Estado			BIT DEFAULT 1

--		CONSTRAINT FK_Maqui_tbCategoriaProductos_Maqui_tbCategorias_cpr_Categoria	FOREIGN KEY (cpr_Categoria) REFERENCES Maqui.tbCategorias(cat_Id),
--		CONSTRAINT FK_Maqui_tbCategoriaProductos_Maqui_tbProductos_cpr_Producto		FOREIGN KEY (cpr_Producto)	REFERENCES Maqui.tbProductos(pro_Id),
--		CONSTRAINT FK_Maqui_tbCategoriaProductos_cpr_UsuCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(cpr_UsuCrea) REFERENCES Gral.tbUsuarios(usu_ID),
--		CONSTRAINT FK_Maqui_tbCategoriaProductos_cpr_usuModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(cpr_usuModi) REFERENCES Gral.tbUsuarios(usu_ID)
--);

--INSERT INTO Maqui.tbCategoriaProductos
--VALUES  (1,  1, 1, GETDATE(), NULL, NULL,1),
--		(1,  2, 1, GETDATE(), NULL, NULL, 1),
--		(1,  3, 1, GETDATE(), NULL, NULL,1),
--		(1,  4, 1, GETDATE(), NULL, NULL,1),
--		(1,  5, 1, GETDATE(), NULL, NULL,1),
--		(2,  6, 1, GETDATE(), NULL, NULL,1),
--		(2,  7, 1, GETDATE(), NULL, NULL,1),
--		(2,  8, 1, GETDATE(), NULL, NULL,1),
--		(2,  9, 1, GETDATE(), NULL, NULL,1),
--		(2, 10, 1, GETDATE(), NULL, NULL,1),
--		(3, 11, 1, GETDATE(), NULL, NULL,1),
--		(3, 12, 1, GETDATE(), NULL, NULL,1),
--		(3, 13, 1, GETDATE(), NULL, NULL,1),
--		(3, 14, 1, GETDATE(), NULL, NULL,1),
--		(3, 15, 1, GETDATE(), NULL, NULL,1),
--		(4, 16, 1, GETDATE(), NULL, NULL,1),
--		(4, 17, 1, GETDATE(), NULL, NULL,1),
--		(4, 18, 1, GETDATE(), NULL, NULL,1),
--		(4, 19, 1, GETDATE(), NULL, NULL,1),
--		(4, 20, 1, GETDATE(), NULL, NULL,1),
--		(5, 21, 1, GETDATE(), NULL, NULL,1),
--		(5, 22, 1, GETDATE(), NULL, NULL,1),
--		(5, 23, 1, GETDATE(), NULL, NULL,1),
--		(5, 24, 1, GETDATE(), NULL, NULL,1),
--		(5, 25, 1, GETDATE(), NULL, NULL,1),
--		(6, 26, 1, GETDATE(), NULL, NULL,1),
--		(6, 27, 1, GETDATE(), NULL, NULL,1),
--		(6, 28, 1, GETDATE(), NULL, NULL,1),
--		(6, 29, 1, GETDATE(), NULL, NULL,1),
--		(6, 30, 1, GETDATE(), NULL, NULL,1),
--		(7, 31, 1, GETDATE(), NULL, NULL,1),
--		(7, 32, 1, GETDATE(), NULL, NULL,1),
--		(7, 33, 1, GETDATE(), NULL, NULL,1),
--		(7, 34, 1, GETDATE(), NULL, NULL,1),
--		(7, 35, 1, GETDATE(), NULL, NULL,1),
--		(8, 36, 1, GETDATE(), NULL, NULL,1),
--		(8, 37, 1, GETDATE(), NULL, NULL,1),
--		(8, 38, 1, GETDATE(), NULL, NULL,1),
--		(8, 39, 1, GETDATE(), NULL, NULL,1),
--		(8, 40, 1, GETDATE(), NULL, NULL,1);



CREATE TABLE Maqui.tbInventario(
		inv_Id				INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		inv_Cantidad		INT NOT NULL,
		inv_Producto		INT NOT NULL,

		inv_UsuCrea			INT,
		inv_FechaCrea		DATETIME DEFAULT GETDATE(),
		inv_usuModi			INT,
		inv_FechaModi		DATETIME,
		inv_Estado			BIT DEFAULT 1

		CONSTRAINT FK_Maqui_tbInventario_Maqui_tbProducto FOREIGN KEY (inv_Producto) REFERENCES Maqui.tbProductos(pro_Id),
		CONSTRAINT FK_Maqui_tbInventario_inv_UsuCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(inv_UsuCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Maqui_tbInventario_inv_usuModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(inv_usuModi) REFERENCES Gral.tbUsuarios(usu_ID)
);

INSERT INTO Maqui.tbInventario
VALUES  (230,  1, 1, GETDATE(), NULL, NULL,1),
		(120,  2, 1, GETDATE(), NULL, NULL,1),
		(320,  3, 1, GETDATE(), NULL, NULL,1),
		(129,  4, 1, GETDATE(), NULL, NULL,1),
		( 78,  5, 1, GETDATE(), NULL, NULL,1),
		(435,  6, 1, GETDATE(), NULL, NULL,1),
		(122,  7, 1, GETDATE(), NULL, NULL,1),
		(133,  8, 1, GETDATE(), NULL, NULL,1),
		(181,  9, 1, GETDATE(), NULL, NULL,1),
		(174, 10, 1, GETDATE(), NULL, NULL,1),
		(165, 11, 1, GETDATE(), NULL, NULL,1),
		( 29, 12, 1, GETDATE(), NULL, NULL,1),
		(163, 13, 1, GETDATE(), NULL, NULL,1),
		(200, 14, 1, GETDATE(), NULL, NULL,1),
		(203, 15, 1, GETDATE(), NULL, NULL,1),
		(328, 16, 1, GETDATE(), NULL, NULL,1),
		(139, 17, 1, GETDATE(), NULL, NULL,1),
		(100, 18, 1, GETDATE(), NULL, NULL,1),
		(107, 19, 1, GETDATE(), NULL, NULL,1),
		(104, 20, 1, GETDATE(), NULL, NULL,1),
		( 10, 21, 1, GETDATE(), NULL, NULL,1),
		(109, 22, 1, GETDATE(), NULL, NULL,1),
		(205, 23, 1, GETDATE(), NULL, NULL,1),
		(258, 24, 1, GETDATE(), NULL, NULL,1),
		(176, 25, 1, GETDATE(), NULL, NULL,1),
		(189, 26, 1, GETDATE(), NULL, NULL,1),
		(293, 27, 1, GETDATE(), NULL, NULL,1),
		(301, 28, 1, GETDATE(), NULL, NULL,1),
		(230, 29, 1, GETDATE(), NULL, NULL,1),
		(231, 30, 1, GETDATE(), NULL, NULL,1),
		(439, 31, 1, GETDATE(), NULL, NULL,1),
		(126, 32, 1, GETDATE(), NULL, NULL,1),
		(132, 33, 1, GETDATE(), NULL, NULL,1),
		(231, 34, 1, GETDATE(), NULL, NULL,1),
		(161, 35, 1, GETDATE(), NULL, NULL,1),
		(182, 36, 1, GETDATE(), NULL, NULL,1),
		(172, 37, 1, GETDATE(), NULL, NULL,1),
		(281, 38, 1, GETDATE(), NULL, NULL,1),
		(190, 39, 1, GETDATE(), NULL, NULL,1),
		(192, 40, 1, GETDATE(), NULL, NULL,1);



CREATE TABLE Maqui.tbVentas(
		ven_Id				INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		ven_Cliente			INT NOT NULL,
		ven_Empleado		INT NOT NULL,
		ven_Fecha			DATETIME,
		ven_Sucursal		INT NOT NULL,
		ven_MetodoPago		INT NOT NULL,


		ven_UsuCrea			INT,
		ven_FechaCrea		DATETIME DEFAULT GETDATE(),
		ven_UsuModi			INT,
		ven_FechaModi		DATETIME,
		ven_Estado			BIT DEFAULT 1

		CONSTRAINT FK_Maqui_tbVentas_Gral_tbClientes_ven_Cliente		FOREIGN KEY (ven_Cliente)		REFERENCES Gral.tbClientes(cli_Id),
		CONSTRAINT FK_Maqui_tbVentas_Gral_tbClientes_ven_Empleado		FOREIGN KEY (ven_Empleado)		REFERENCES Gral.tbEmpleados(emp_Id),
		CONSTRAINT FK_Maqui_tbVentas_Maqui_tbSucursales_ven_Sucursal	FOREIGN KEY (ven_Sucursal)		REFERENCES  Gral.tbSucursales (suc_Id),
		CONSTRAINT FK_Maqui_tbVentas_Maqui_tbMetodoPago_ven_MetodoPago	FOREIGN KEY (ven_MetodoPago)	REFERENCES Maqui.tbMetodoPago (met_Id),
		CONSTRAINT FK_Maqui_tbVentas_ven_UsuCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(ven_UsuCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Maqui_tbVentas_ven_UsuModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(ven_UsuModi) REFERENCES Gral.tbUsuarios(usu_ID)
);

INSERT INTO Maqui.tbVentas
VALUES  (12, 10, '2023-09-10',  2, 1, 1, GETDATE(), NULL, NULL, 1),
		(11, 02, '2023-09-10', 11, 3, 1, GETDATE(), NULL, NULL, 1),
		(02, 08, '2023-09-10',  3, 2, 1, GETDATE(), NULL, NULL, 1),
		(15, 19, '2023-09-10', 20, 4, 1, GETDATE(), NULL, NULL, 1),
		(20, 14, '2023-09-10', 19, 5, 1, GETDATE(), NULL, NULL, 1),
		(19,  1, '2023-09-10', 18, 6, 1, GETDATE(), NULL, NULL, 1),
		(15,  2, '2023-09-10', 15, 1, 1, GETDATE(), NULL, NULL, 1),
		(05, 04, '2023-09-10', 03, 2, 1, GETDATE(), NULL, NULL, 1),
		(03, 09, '2023-09-10', 04, 3, 1, GETDATE(), NULL, NULL, 1),
		(02, 01, '2023-09-10', 09, 4, 1, GETDATE(), NULL, NULL, 1);




CREATE TABLE Maqui.tbVentasDetalle(
		vde_Id			INT IDENTITY(1,1)	NOT NULL PRIMARY KEY,
		vde_VentaId		INT					NOT NULL,
		vde_Producto	INT					NOT NULL,
		vde_Cantidad	INT					NOT NULL,
		
		vde_UsuCrea		INT,
		vde_FechaCrea	DATETIME			DEFAULT GETDATE(),
		vde_UsuModi		INT,
		vde_FechaModi	DATETIME,
		vde_Estado		BIT					DEFAULT 1

		CONSTRAINT FK_Maqui_tbVentas_MaquiDetalles_tbVentasDetalle_VD_VentaId	FOREIGN KEY (vde_VentaId)		REFERENCES Maqui.tbVentas(ven_Id),
		CONSTRAINT FK_Maqui_tbVentasDetalles_tbMaqui_Produtos_VD_Producto		FOREIGN KEY (vde_Producto)		REFERENCES Maqui.tbProductos(pro_Id),
		CONSTRAINT FK_Maqui_tbVentasDetalle_vde_UsuCrea_Gral_tbUsuarios_usu_ID FOREIGN KEY(vde_UsuCrea) REFERENCES Gral.tbUsuarios(usu_ID),
		CONSTRAINT FK_Maqui_tbVentasDetalle_vde_UsuModi_Gral_tbUsuarios_usu_ID FOREIGN KEY(vde_UsuModi) REFERENCES Gral.tbUsuarios(usu_ID)
);
GO

INSERT INTO Maqui.tbVentasDetalle
VALUES  (1,  03,  4, 1, GETDATE(), NULL, NULL, 1),
		(1,  23,  8, 1, GETDATE(), NULL, NULL, 1),
		(1,  21,  2, 1, GETDATE(), NULL, NULL, 1),
		(2,  34,  3, 1, GETDATE(), NULL, NULL, 1),
		(2,  09,  5, 1, GETDATE(), NULL, NULL, 1),
		(2,  32,  1, 1, GETDATE(), NULL, NULL, 1),
		(3,  09,  4, 1, GETDATE(), NULL, NULL, 1),
		(3,  19, 4, 1, GETDATE(), NULL, NULL, 1),
		(3,  15,  4, 1, GETDATE(), NULL, NULL, 1),
		(4,  32,  5, 1, GETDATE(), NULL, NULL, 1),
		(4,  11,  2, 1, GETDATE(), NULL, NULL, 1),
		(4,  06,  3, 1, GETDATE(), NULL, NULL, 1),
		(5,  08,  4, 1, GETDATE(), NULL, NULL, 1),
	    (5,  12,  6, 1, GETDATE(), NULL, NULL, 1),
		(5,  13,  7, 1, GETDATE(), NULL, NULL, 1),
		(6,  40,  3, 1, GETDATE(), NULL, NULL, 1),
		(6,  33, 4, 1, GETDATE(), NULL, NULL, 1),
		(6,  34,  2, 1, GETDATE(), NULL, NULL, 1),
		(7,  21,  1, 1, GETDATE(), NULL, NULL, 1),
		(7,  36, 6, 1, GETDATE(), NULL, NULL, 1),
		(7,  21,  9, 1, GETDATE(), NULL, NULL, 1),
		(8,  11,  3, 1, GETDATE(), NULL, NULL, 1),
		(8,  30, 8, 1, GETDATE(), NULL, NULL, 1),
		(8,  29,  4, 1, GETDATE(), NULL, NULL, 1),
		(9,  21,  8, 1, GETDATE(), NULL, NULL, 1),
		(9,  24,  6, 1, GETDATE(), NULL, NULL, 1),
        (9,  29,  3, 1, GETDATE(), NULL, NULL, 1),
		(10, 37,  9, 1, GETDATE(), NULL, NULL, 1),
		(10, 23,  9, 1, GETDATE(), NULL, NULL, 1),
		(10, 12,  9, 1, GETDATE(), NULL, NULL, 1);
GO


/************************UDPS VISTA************************/


CREATE OR ALTER VIEW Vw_Gral_tbClientes_LIST
AS

SELECT cli_ID, 
	   cli_Nombre + ' ' + cli_Apellido AS cli_Nombre, 
	   cli_DNI, 
	   cli_FechaNacimiento, 
	   CASE cli_Sexo
	   WHEN 'F' THEN 'Femenino'
	   WHEN 'M' THEN 'Masculino'
	   ELSE 'Otro' END AS cli_sexo, 
	   cli_Telefono, 
	   cli_Municipio = mun_Descripcion, 
	   cli_EstadoCivil = est_Descripcion
	   FROM Gral.tbClientes T1
	   INNER JOIN Gral.tbMunicipios T2
	   ON T1.cli_Municipio = T2.mun_ID
	   INNER JOIN Gral.tbEstadosCiviles T3
	   ON T1.cli_EstadoCivil = T3.est_ID
	   WHERE cli_Estado = 1;

GO





CREATE OR ALTER VIEW Vw_Gral_tbEmpleados_LIST
AS 

SELECT emp_ID, 
	   emp_Nombre + ' ' + emp_Apellido AS emp_Nombre, 
	   emp_DNI, 
	   emp_FechaNacimiento, 
	   CASE emp_Sexo
	   WHEN 'F' THEN 'Femenino'
	   WHEN 'M' THEN 'Masculino'
	   ELSE 'Otro' END AS emp_Sexo, 
	   emp_Telefono, 
	   emp_Municipio = mun_Descripcion, 
	   emp_Correo, 
	   emp_EstadoCivil = est_Descripcion, 
	   emp_Sucursal = suc_Descripcion
	   FROM Gral.tbEmpleados T1
	   INNER JOIN Gral.tbMunicipios T2
	   ON T1.emp_Municipio = T2.mun_ID
	   INNER JOIN Gral.tbEstadosCiviles T3
	   ON T1.emp_EstadoCivil = T3.est_ID
	   INNER JOIN Gral.tbSucursales T4
	   ON T1.emp_Sucursal = T4.suc_Id
	   WHERE emp_Estado = 1;

GO





CREATE OR ALTER VIEW Vw_Gral_tbDepartamentos_LIST
AS 

SELECT dep_ID, 
	   dep_Descripcion
	   FROM Gral.tbDepartamentos


GO



CREATE OR ALTER VIEW Vw_Gral_tbMunicipios_LIST
AS 

SELECT mun_ID, 
	   mun_depID = dep_Descripcion, 
	   mun_Descripcion 
	   FROM Gral.tbMunicipios T1
	   INNER JOIN Gral.tbDepartamentos T2
	   ON T1.mun_depID = T2.dep_ID

GO




CREATE OR ALTER VIEW Vw_Gral_tbSucursales_LIST
AS 

SELECT suc_Id, 
	   suc_Descripcion, 
	   suc_Municipio = mun_Descripcion
	   FROM Gral.tbSucursales T1
	   INNER JOIN Gral.tbMunicipios T2
	   ON T1.suc_Municipio = T2.mun_ID
	   WHERE suc_Estado = 1

GO




CREATE OR ALTER VIEW Vw_Gral_tbEstadosCiviles_LIST
AS 

SELECT est_ID, 
	   est_Descripcion
	   FROM Gral.tbEstadosCiviles


GO

CREATE OR ALTER VIEW Vw_Gral_tbUsuarios_LIST
AS

SELECT
		usu.usu_ID,
		usu.usu_Usuario,
		emple.emp_Nombre + ' ' + emple.emp_Apellido AS 'Empleado',
		usu_EsAdmin
		FROM Gral.tbUsuarios usu INNER JOIN Gral.tbEmpleados emple 
		ON	 usu.usu_empID = emple.emp_ID
		WHERE usu.usu_Estado = 1


GO



CREATE OR ALTER VIEW Vw_Maqui_tbCategorias_LIST
AS 

SELECT cat_Id, 
	   cat_Descripcion
	   FROM Maqui.tbCategorias
	   WHERE cat_Estado = 1;


GO





CREATE OR ALTER VIEW Vw_Maqui_tbInventario_LIST
AS 

SELECT  inv_Id,
		produc.pro_Nombre,	
		produc.pro_StockInicial,
	    inv_Cantidad
	    FROM Maqui.tbInventario inven INNER JOIN Maqui.tbProductos produc
		ON	 inven.inv_Producto = produc.pro_Id
		WHERE inven.inv_Estado = 1

GO




CREATE OR ALTER VIEW Vw_Maqui_tbMetodoPago_LIST
AS 

SELECT met_Id, 
	   met_Descripcion
	   FROM Maqui.tbMetodoPago
	   WHERE met_Estado = 1;

GO





CREATE OR ALTER VIEW Vw_Maqui_tbProductos_LIST
AS 

SELECT 
	   pro_Id,
	   pro_Codigo, 
	   pro_Nombre, 
	   pro_StockInicial, 
	   pro_PrecioUnitario,
	   cate.cat_Descripcion,
	   prv_NombreCompa�ia,
	   pro_Proveedor = prv_NombreContacto
	   FROM Maqui.tbProductos T1
	   INNER JOIN Maqui.tbProveedores T2
	   ON T1.pro_Proveedor = T2.prv_ID
	   INNER JOIN Maqui.tbCategorias cate
	   ON T1.pro_Categoria = cate.cat_Id
	   WHERE pro_Estado = 1;

GO





CREATE OR ALTER VIEW Vw_Maqui_tbProveedores_LIST
AS

SELECT prv_ID,
	   prv_NombreCompa�ia, 
	   prv_NombreContacto, 
	   prv_TelefonoContacto, 
	    
	   prv_DireccionEmpresa,
	   prv_DireccionContacto,
	   prv_SexoContacto
	   FROM Maqui.tbProveedores 
	   WHERE prv_Estado = 1;


GO






CREATE OR ALTER VIEW Vw_Maqui_tbVentas_LIST
AS 

SELECT ven_Id, 
	   ven_Cliente = cli_Nombre + ' ' + cli_Apellido, 
	   ven_Empleado = emp_Nombre + ' ' + emp_Apellido,
	   ven_Fecha, 
	   suc_Descripcion, 
	   met_Descripcion
	   FROM Maqui.tbVentas T1
	   INNER JOIN Gral.tbSucursales T2
	   ON T1.ven_Sucursal = T2.suc_Id
	   INNER JOIN Maqui.tbMetodoPago T3
	   ON T1.ven_MetodoPago = T3.met_Id
	   INNER JOIN Gral.tbClientes T4
	   ON T1.ven_Cliente = T4.cli_ID
	   INNER JOIN Gral.tbEmpleados T5
	   ON T1.ven_Empleado = T5.emp_ID
	   WHERE ven_Estado = 1;

GO





CREATE OR ALTER VIEW Vw_Maqui_tbVentasDetalle_LIST
AS 

SELECT vde_Id, 
	   vde_VentaId,
	   vde_Producto = pro_Nombre,
	   vde_Cantidad 
	   FROM Maqui.tbVentasDetalle T1
	   INNER JOIN Maqui.tbVentas T2
	   ON T1.vde_Id = T2.ven_Id
	   INNER JOIN Maqui.tbProductos T3
	   ON T1.vde_Producto = T3.pro_Id
	   WHERE vde_Estado = 1;
GO




/************************UDPS INSERT************************/

CREATE OR ALTER PROC UDP_Gral_tbEstadosCiviles_CREAR(
@est_Descripcion NVARCHAR(100),
@est_UsuCrea INT)
AS BEGIN

DECLARE @est_UsuModi INT = NULL;
DECLARE @est_FechaCrea DATETIME = GETDATE();
DECLARE @est_FechaModi DATETIME = NULL;

INSERT INTO Gral.tbEstadosCiviles
VALUES  (@est_Descripcion,
		 @est_UsuCrea,
		 @est_FechaCrea,
		 @est_UsuModi,
		 @est_FechaModi
		);
END
GO


CREATE OR ALTER PROC UDP_Gral_tbDepartamentos_CREAR(
@dep_Descripcion NVARCHAR(100),
@dep_UsuCrea INT)
AS BEGIN

DECLARE @dep_UsuModi INT = NULL;
DECLARE @dep_FechaCrea DATETIME = GETDATE();
DECLARE @dep_FechaModi DATETIME = NULL;

INSERT INTO Gral.tbDepartamentos
VALUES  (@dep_Descripcion,
		 @dep_UsuCrea,
		 @dep_FechaCrea,
		 @dep_UsuModi,
		 @dep_FechaModi
		);
END
GO

CREATE OR ALTER PROC UDP_Gral_tbSucursales_CREAR
	@suc_Descripcion	NVARCHAR(100),
	@suc_Municipio		INT, 
	@suc_UsuCrea		INT 	
AS
BEGIN
	DECLARE @suc_FechaCrea  DATETIME = GETDATE()
	DECLARE @suc_Estado		BIT = 1

		INSERT INTO Gral.tbSucursales
			(suc_Descripcion, suc_Municipio, suc_UsuCrea, suc_FechaCrea, suc_usuModi, 
			 suc_FechaModi, suc_Estado)
		VALUES
			(@suc_Descripcion, @suc_Municipio, @suc_UsuCrea, @suc_FechaCrea, NULL, 
			 NULL, @suc_Estado)
END
GO


CREATE OR ALTER PROC UDP_Gral_tbMunicipios_CREAR(
@mun_Descripcion NVARCHAR(100),
@mun_DepId INT,
@mun_UsuCrea INT)
AS BEGIN

DECLARE @mun_UsuModi INT = NULL;
DECLARE @mun_FechaCrea DATETIME = GETDATE();
DECLARE @mun_FechaModi DATETIME = NULL;

INSERT INTO Gral.tbMunicipios
VALUES  (@mun_DepId,
		 @mun_Descripcion, 
		 @mun_UsuCrea,
		 @mun_FechaCrea,
		 @mun_UsuModi,
		 @mun_FechaModi
		);
END
GO


CREATE OR ALTER PROC UDP_Gral_tbEmpleados_CREAR(
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
@emp_UsuarioCrea		INT	)
AS BEGIN

DECLARE @emp_UsuModi    INT = NULL;
DECLARE @emp_FechaCrea  DATETIME = GETDATE();
DECLARE @emp_Estado     BIT = 1;
DECLARE @emp_FechaModi  DATETIME = NULL;

INSERT INTO Gral.tbEmpleados
VALUES  (@emp_Nombre,				
		 @emp_Apellido,			
		 @emp_DNI	,			
		 @emp_FechaNacimiento,	
		 @emp_Sexo		,	
		 @emp_Telefono	,
		 @emp_Municipio	,		
		 @emp_Correo		,
		 @emp_EstadoCivil	,	
		 @emp_Sucursal,
		 @emp_UsuarioCrea,	
		 @emp_FechaCrea,
		 @emp_UsuModi,  
		 @emp_FechaModi,
		 @emp_Estado)
END
GO




CREATE OR ALTER PROC UDP_Gral_tbClientes_CREAR(
@cli_Nombre				NVARCHAR(250),		
@cli_Apellido			NVARCHAR(250),		
@cli_DNI				VARCHAR(13)	,		
@cli_FechaNacimiento	DATE	,			
@cli_Sexo				CHAR(1)	,		
@cli_Telefono			NVARCHAR(100),
@cli_Municipio			INT		,			
@cli_EstadoCivil		INT	,				
@cli_UsuarioCrea		INT	)
AS BEGIN

DECLARE @cli_UsuModi    INT = NULL;
DECLARE @cli_FechaCrea  DATETIME = GETDATE();
DECLARE @cli_FechaModi  DATETIME = NULL;
DECLARE @cli_Estado     BIT = 1;

INSERT INTO Gral.tbClientes
VALUES  (@cli_Nombre,				
		 @cli_Apellido,			
		 @cli_DNI	,			
		 @cli_FechaNacimiento,	
		 @cli_Sexo		,
		 @cli_Telefono,
		 @cli_Municipio	,		
		 @cli_EstadoCivil	,	
		 @cli_UsuarioCrea,		
		 @cli_FechaCrea,
		 @cli_UsuModi,  
		 @cli_FechaModi,
		 @cli_Estado)
END
GO




CREATE OR ALTER PROC UDP_Gral_tbUsuarios_CREAR(
@usu_Usuario			NVARCHAR(100)		,
@usu_empID			INT					,
@usu_Clave			NVARCHAR(MAX)		,
@usu_EsAdmin			BIT					,
@usu_UsuarioCrea		INT					)
AS BEGIN

DECLARE @usu_UsuModi    INT = NULL;
DECLARE @usu_FechaCrea  DATETIME = GETDATE();
DECLARE @usu_FechaModi  DATETIME = NULL;
DECLARE @usu_Estado     BIT = 1;

INSERT INTO Gral.tbUsuarios
VALUES  (@usu_Usuario,				
		 @usu_empID,			
		 @usu_Clave	,	
		 @usu_EsAdmin,
		 @usu_UsuarioCrea,		
		 @usu_FechaCrea,
		 @usu_UsuModi,  
		 @usu_FechaModi,
		 @usu_Estado)
END
GO
--CREATE OR ALTER PROC UDP_Maqui_tbCategoriasProducto_CREAR
--	@cpr_Categoria		INT,
--	@cpr_Producto		INT, 
--	@cpr_UsuCrea		INT
--AS
--BEGIN

--DECLARE @cpr_FechaCrea DATETIME = GETDATE()
--DECLARE @cpr_Estado	   BIT = 1

--INSERT INTO Maqui.tbCategoriaProductos
--		(cpr_Categoria, cpr_Producto, cpr_UsuCrea, cpr_FechaCrea, cpr_usuModi, cpr_FechaModi, cpr_Estado)
--VALUES	(@cpr_Categoria, @cpr_Producto,@cpr_UsuCrea,@cpr_FechaCrea, NULL,		NULL,		  @cpr_Estado)

--END
--GO

CREATE OR ALTER PROC UDP_Maqui_tbMetodoPago_CREAR
	@met_Descripcion	NVARCHAR(100), 
	@met_UsuCrea		INT
AS
BEGIN
	DECLARE @met_FechaCrea	DATETIME = GETDATE()
	DECLARE @met_Estado		BIT		 = 1
	
	INSERT INTO Maqui.tbMetodoPago
			(met_Descripcion, met_UsuCrea, met_FechaCrea, met_usuModi, met_FechaModi, met_Estado)
	VALUES	(@met_Descripcion,@met_UsuCrea,@met_FechaCrea, NULL,		NULL,		 @met_Estado)
END
GO

CREATE OR ALTER PROC UDP_Maqui_tbCategorias_CREAR
	@cat_Descripcion	NVARCHAR(100), 
	@cat_UsuCrea		INT
AS
BEGIN
	DECLARE @cat_FechaCrea DATETIME = GETDATE()
	DECLARE @cat_Estado	   BIT =		1

	INSERT INTO Maqui.tbCategorias
			(cat_Descripcion, cat_UsuCrea, cat_FechaCrea, cat_UsuModi, cat_FechaModi, cat_Estado)
	VALUES	(@cat_Descripcion,@cat_UsuCrea,@cat_FechaCrea,  NULL,		NULL,		  @cat_Estado)
END
GO

CREATE OR ALTER PROC UDP_Maqui_tbInventario_CREAR
	@inv_Cantidad	INT,
	@inv_Producto	INT, 
	@inv_UsuCrea	INT
AS
BEGIN
		DECLARE @inv_FechaCrea  DATETIME = GETDATE()
		DECLARE @inv_Estado		BIT		 =	1

		INSERT INTO Maqui.tbInventario
				(inv_Cantidad, inv_Producto, inv_UsuCrea, inv_FechaCrea, inv_usuModi, inv_FechaModi, inv_Estado)
		VALUES	(@inv_Cantidad,@inv_Producto,@inv_UsuCrea, @inv_FechaCrea, NULL,       NULL,		 @inv_Estado)

END
GO

CREATE OR ALTER PROC UDP_Maqui_tbProductos_CREAR
	@pro_Codigo			NVARCHAR(100),
	@pro_Nombre			NVARCHAR(100), 
	@pro_StockInicial	NVARCHAR(100), 
	@pro_PrecioUnitario	DECIMAL(18,2), 
	@pro_Proveedor		INT, 
	@pro_usuCrea		INT,
	@pro_Categoria		INT
AS
BEGIN
	DECLARE @pro_FechaCrea  DATETIME = GETDATE()
	DECLARE @pro_Estado		BIT		 = 1

	INSERT INTO Maqui.tbProductos
			(pro_Codigo, pro_Nombre, pro_StockInicial, pro_PrecioUnitario, pro_Proveedor, pro_Categoria, pro_usuCrea, 
			 pro_FechaCrea, pro_UsuModi, pro_FechaModi, pro_Estado)

	VALUES  (@pro_Codigo, @pro_Nombre, @pro_StockInicial, @pro_PrecioUnitario, @pro_Proveedor, @pro_Categoria, @pro_usuCrea,
			 @pro_FechaCrea, NULL, NULL, @pro_Estado)

END
GO

CREATE OR ALTER PROC UDP_Maqui_tbProveedores_CREAR
	@prv_NombreCompa�ia		NVARCHAR(250),
	@prv_NombreContacto		NVARCHAR(250), 
	@prv_TelefonoContacto   NVARCHAR(100), 
	@prv_DireccionEmpresa	NVARCHAR(200), 
	@prv_DireccionContacto	NVARCHAR(200),
	@prv_SexoContacto		CHAR(1),
	@prv_UsuarioCrea		INT 
AS
BEGIN
		DECLARE @prv_FechaCrea DATETIME = GETDATE() 
		DECLARE @prv_Estado	   BIT =	1	

		INSERT INTO Maqui.tbProveedores
				(prv_NombreCompa�ia, prv_NombreContacto, prv_TelefonoContacto, 
				 prv_DireccionEmpresa, prv_DireccionContacto, prv_SexoContacto, prv_UsuarioCrea, prv_FechaCrea, prv_UsuarioModi, 
				 prv_FechaModi, prv_Estado)

		VALUES	(@prv_NombreCompa�ia,@prv_NombreContacto, @prv_TelefonoContacto,
				 @prv_DireccionEmpresa, @prv_DireccionContacto, @prv_SexoContacto, @prv_UsuarioCrea, @prv_FechaCrea, NULL,
				 NULL, @prv_Estado)

END
GO

CREATE OR ALTER PROC UDP_Maqui_tbVentas_CREAR
	@ven_Cliente		INT, 
	@ven_Empleado		INT, 
	@ven_Fecha			DATETIME, 
	@ven_Sucursal		INT, 
	@ven_MetodoPago		INT, 
	@ven_UsuCrea		INT
AS
BEGIN
	DECLARE @ven_FechaCrea  DATETIME = GETDATE()
	DECLARE @ven_Estado		BIT		 = 1

	INSERT INTO Maqui.tbVentas
			(ven_Cliente, ven_Empleado, ven_Fecha, ven_Sucursal, ven_MetodoPago, ven_UsuCrea, 
			 ven_FechaCrea, ven_UsuModi, ven_FechaModi, ven_Estado)

	VALUES	 (@ven_Cliente,@ven_Empleado,@ven_Fecha,@ven_Sucursal,@ven_MetodoPago, @ven_UsuCrea,
			  @ven_FechaCrea, NULL,		  NULL,          @ven_Estado)

END
GO

CREATE OR ALTER PROC UDP_Maqui_tbVentasDetalle_CREAR
	@vde_VentaId			INT, 
	@vde_Producto			INT,
	@vde_Cantidad			INT, 
	@vde_UsuCrea			INT 
AS
BEGIN
		DECLARE @vde_FechaCrea DATETIME = GETDATE() 
		DECLARE @vde_Estado    BIT		= 1

		INSERT INTO Maqui.tbVentasDetalle
				(vde_VentaId, vde_Producto, vde_Cantidad, vde_UsuCrea, vde_FechaCrea, 
				 vde_UsuModi, vde_FechaModi, vde_Estado)

		VALUES	(@vde_VentaId, @vde_Producto, @vde_Cantidad,@vde_UsuCrea,@vde_FechaCrea,
				 NULL,         NULL,		@vde_Estado)
END
GO
--********************************************D D L s--***************************************************************
--********************************************************************************************************************
go
CREATE OR ALTER VIEW Vw_Maqui_tbProductos_DDL
AS

SELECT '0' AS 'pro_Id', ' ---Seleccione una opci�n---' AS 'pro_Nombre'
UNION ALL
SELECT pro_Id, pro_Nombre FROM Maqui.tbProductos
--************************************************************************************************************
GO
CREATE OR ALTER VIEW Vw_Maqui_tbProveedores_DDL
AS

SELECT '0' AS 'prv_ID', ' ---Seleccione una opci�n---' AS 'prv_NombreCompa�ia'
UNION ALL
SELECT prv_ID, prv_NombreCompa�ia FROM Maqui.tbProveedores


--************************************************************************************************************
GO
CREATE OR ALTER VIEW Vw_Maqui_tbCategorias_DDL
AS


SELECT '0' AS 'cat_Id', ' ---Seleccione una opci�n---' AS 'cat_Descripcion'
UNION ALL
SELECT cat_Id, cat_Descripcion FROM Maqui.tbCategorias


--************************************************************************************************************
GO
CREATE OR ALTER VIEW Vw_Gral_tbEstadosCiviles_DDL
AS


SELECT '0' AS 'est_ID', ' ---Seleccione una opci�n---' AS 'est_Descripcion'
UNION ALL
SELECT est_ID, est_Descripcion FROM Gral.tbEstadosCiviles


--************************************************************************************************************
GO
CREATE OR ALTER VIEW Vw_Gral_tbDepartamentos_DDL
AS


SELECT '0' AS 'depto', ' ---Seleccione una opci�n---' AS 'dep_Descripcion'
UNION ALL
SELECT dep_ID, dep_Descripcion FROM Gral.tbDepartamentos
GO
--************************************************************************************************************
CREATE OR ALTER VIEW Vw_Gral_tbClientes_DDL
AS


SELECT '0' AS 'cli_ID', ' ---Seleccione una opci�n---' AS 'cli_Nombre'
UNION ALL
SELECT cli_ID, cli_Nombre + ' ' + cli_Apellido FROM Gral.tbClientes
GO
--************************************************************************************************************
CREATE OR ALTER FUNCTION UDF_Gral_tbMunicipio_DDL(@depto INT)
RETURNS TABLE
AS
RETURN
(
SELECT mun_ID, mun_Descripcion FROM Gral.tbMunicipios
WHERE mun_depID = @depto
)
GO
--************************************************************************************************************

CREATE OR ALTER VIEW Vw_Gral_tbEmpleados_DDL
AS


SELECT '0' AS 'emp_ID', ' ---Seleccione una opci�n---' AS 'emp_Nombre'
UNION ALL

SELECT T2.emp_ID, emp_Nombre + ' '+ emp_Apellido AS per_Nombres FROM Gral.tbUsuarios T1
FULL JOIN Gral.tbEmpleados T2 ON T1.usu_empID = T2.emp_ID WHERE T1.usu_Usuario IS NULL AND T2.emp_Estado = 1
GO
--************************************************************************************************************
CREATE OR ALTER FUNCTION UDF_Gral_tbEmpleadoInfo_DDL(@id INT)
RETURNS TABLE
AS
RETURN
(
SELECT emp_Municipio, deptos.dep_ID FROM Gral.tbEmpleados emple
INNER JOIN Gral.tbMunicipios muni
ON emple.emp_Municipio = muni.mun_ID 
INNER JOIN Gral.tbDepartamentos deptos
ON muni.mun_depID = deptos.dep_ID
WHERE emp_ID = @id
)
GO

CREATE OR ALTER FUNCTION UDF_Gral_tbSucursalesInfo_DDL(@id INT)
RETURNS TABLE
AS
RETURN
(
SELECT suc_Id, suc_Descripcion, suc_Municipio,deptos.dep_ID  FROM Gral.tbSucursales sucu
INNER JOIN Gral.tbMunicipios muni
ON sucu.suc_Municipio = muni.mun_ID 
INNER JOIN Gral.tbDepartamentos deptos
ON muni.mun_depID = deptos.dep_ID
WHERE suc_Id = @id
)
GO





CREATE OR ALTER FUNCTION UDF_Gral_tbClienteInfo_DDL(@id INT)
RETURNS TABLE
AS
RETURN
(
SELECT cli_Municipio, deptos.dep_ID FROM Gral.tbClientes client
INNER JOIN Gral.tbMunicipios muni
ON client.cli_Municipio = muni.mun_ID 
INNER JOIN Gral.tbDepartamentos deptos
ON muni.mun_depID = deptos.dep_ID
WHERE cli_ID = @id
)
GO




select * from Gral.tbClientes
select * from Gral.tbMunicipios

SELECT * FROM dbo.UDF_Gral_tbMunicipio_DDL(5)

SELECT '0' AS 'cli_ID', ' ---Seleccione una opci�n---' AS 'cli_Nombre'
UNION ALL
SELECT cli_ID, cli_Nombre + ' ' + cli_Apellido FROM Gral.tbClientes

go







CREATE OR ALTER PROC UDP_Maqui_tbCategorias_EDITAR(
@cat_Id INT,
@cat_Descripcion NVARCHAR(100),
@cat_UsuModi INT)
AS BEGIN
DECLARE @cat_FechaModi DATETIME = GETDATE();
UPDATE Maqui.tbCategorias SET cat_Descripcion = @cat_Descripcion,
							  cat_UsuModi = @cat_UsuModi,
							  cat_FechaModi = @cat_FechaModi
							  WHERE cat_Id = @cat_Id

END
GO


CREATE OR ALTER PROC UDP_Maqui_tbCategorias_ELIMINAR
(@cat_Id INT, @cat_UsuModi INT)
AS BEGIN

DECLARE @cat_FechaModi DATETIME = GETDATE();
UPDATE Maqui.tbCategorias SET cat_Estado = 0, cat_UsuModi = @cat_UsuModi, cat_FechaModi = @cat_FechaModi
WHERE cat_Id = @cat_Id

END
GO


CREATE OR  ALTER PROC UDP_Maqui_tbMetodoPago_ELIMINAR
(@met_Id INT, @met_UsuModi INT)
AS BEGIN

DECLARE @met_FechaModi DATETIME = GETDATE();
UPDATE Maqui.tbMetodoPago SET met_Estado = 0, met_usuModi = @met_UsuModi, met_FechaModi = @met_FechaModi
WHERE met_Id = @met_Id

END
GO


CREATE OR ALTER PROC UDP_Maqui_tbMetodoPago_EDITAR(
@met_Id INT,
@met_Decripcion NVARCHAR(100),
@met_UsuModi INT)
AS BEGIN


DECLARE @met_FechaModi DATETIME = GETDATE();
UPDATE Maqui.tbMetodoPago SET met_Descripcion = @met_Decripcion,
							  met_usuModi = @met_UsuModi,
							  met_FechaModi = @met_FechaModi
							  WHERE met_Id = @met_Id
END
GO


CREATE OR ALTER PROC UDP_Gral_tbDepartamentos_EDITAR(
@dep_Id INT, 
@dep_Descripcion NVARCHAR(100), 
@dep_UsuModi INT)
AS BEGIN

DECLARE @dep_FechaModi DATETIME = GETDATE();
UPDATE Gral.tbDepartamentos SET dep_Descripcion = @dep_Descripcion,
								dep_UsuarioModi = @dep_UsuModi,
								dep_FechaModi = @dep_FechaModi
								WHERE dep_ID = @dep_Id
END
GO


CREATE OR ALTER PROC UDP_tbDeptos_CARGAR
AS BEGIN

SELECT '0' AS 'dep_ID', ' ---Seleccione una opci�n---' AS 'dep_Descripcion'
UNION ALL
SELECT  
		dep_ID,
		dep_Descripcion
		FROM  Gral.tbDepartamentos T2
END
GO


CREATE OR ALTER PROC UDP_Gral_tbMunicipios_CARGARPORDEPTO
(@dep_Id NVARCHAR(100))
AS BEGIN

SELECT  mun_ID, 
		mun_depID,
		dep_Descripcion,
		mun_Descripcion 
		FROM Gral.tbMunicipios T1 
		INNER JOIN Gral.tbDepartamentos T2
		ON T1.mun_depID = T2.dep_Id
		WHERE T1.mun_depID = @dep_Id

END
GO

CREATE OR ALTER PROC UDP_Gral_tbEstadosCiviles_EDITAR(
@est_Id INT,
@est_Descripcion NVARCHAR(100),
@est_UsuModi INT)
AS BEGIN
DECLARE @est_FechaModi DATETIME = GETDATE();
UPDATE Gral.tbEstadosCiviles SET est_Descripcion = @est_Descripcion,
								est_UsuarioModi = @est_UsuModi,
								est_FechaModi = @est_FechaModi
									WHERE est_ID = @est_Id
END
GO


CREATE OR ALTER PROC UDP_Gral_tbMunicipios_CARGAR(@mun_Id INT)
AS BEGIN
SELECT  mun_ID ,
		mun_depID,
		dep_Descripcion,
		mun_Descripcion
		FROM Gral.tbMunicipios T1
		INNER JOIN Gral.tbDepartamentos T2
		ON T1.mun_depID = T2.dep_ID
		WHERE mun_ID = @mun_Id
END
GO




CREATE OR ALTER FUNCTION UDF_Gral_tbMunicipios_CARGAR(@mun_Id INT)
RETURNS TABLE
AS
RETURN
(
SELECT  mun_ID ,
		mun_depID,
		dep_Descripcion,
		mun_Descripcion
		FROM Gral.tbMunicipios T1
		INNER JOIN Gral.tbDepartamentos T2
		ON T1.mun_depID = T2.dep_ID
		WHERE mun_ID = @mun_Id
)
GO





/*Proc que me acutualiza las ciudades*/
CREATE OR ALTER PROC UDP_Gral_tbMunicipios_EDITAR(
@mun_Descripcion NVARCHAR(100),
@mun_UsuModi INT,
@mun_Id INT,
@mun_DepId INT)
AS BEGIN

DECLARE @mun_FechaModi DATETIME = GETDATE();
UPDATE Gral.tbMunicipios SET mun_Descripcion = @mun_Descripcion,
					  mun_UsuarioModi = @mun_UsuModi,
					  mun_depID = @mun_DepId,
					  mun_FechaModi = @mun_FechaModi
					  WHERE mun_ID = @mun_Id
END
GO
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
			cli_UsuarioModi = @cli_UsuarioCrea,
			cli_FechaModi = GETDATE()
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
			emp_UsuarioModi = @emp_UsuarioCrea,
			emp_FechaModi = GETDATE()
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
			pro_UsuModi = @pro_usuCrea,
			pro_Categoria = @pro_Categoria,
			pro_FechaModi = GETDATE()
	WHERE   pro_ID = @pro_Id
END
GO
--****************************************************************************--
CREATE OR ALTER PROC UDP_Maqui_tbProveedores_UPDATE
	@prv_ID			INT,
	@prv_NombreCompa�ia		NVARCHAR(250),
	@prv_NombreContacto		NVARCHAR(250), 
	@prv_TelefonoContacto   NVARCHAR(100), 
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
		   prv_DireccionEmpresa = @prv_DireccionEmpresa,
		   prv_DireccionContacto = @prv_DireccionContacto,
		   prv_SexoContacto = @prv_SexoContacto,
		   prv_UsuarioModi = @prv_UsuarioCrea,
		   prv_FechaModi = GETDATE()
	WHERE	prv_ID = @prv_ID
END
GO


CREATE OR ALTER PROC UDP_Gral_tbSucurusales_EDITAR(
@suc_Id INT,
@suc_Descripcion NVARCHAR(100),
@suc_Municipio INT,
@suc_UsuModi INT)
AS BEGIN

DECLARE @suc_FechaModi DATETIME = GETDATE();
UPDATE Gral.tbSucursales SET suc_Municipio = @suc_Municipio,
							 suc_Descripcion = @suc_Descripcion,
							 suc_usuModi = @suc_UsuModi,
							 suc_FechaModi = @suc_FechaModi
							 WHERE suc_Id = @suc_Id

END
GO



CREATE OR ALTER PROC UDP_Gral_tbSucursales_ELIMINAR(@suc_Id INT, @suc_UsuModi INT)
AS BEGIN

DECLARE @suc_FechaModi DATETIME = GETDATE();
UPDATE Gral.tbSucursales SET suc_Estado = 0, suc_FechaModi = @suc_FechaModi, suc_usuModi = @suc_UsuModi WHERE suc_Id = @suc_Id;

END
GO


CREATE OR ALTER FUNCTION UDF_Gral_tbSucursales_DDL(@id INT)
RETURNS TABLE
AS
RETURN
(
SELECT suc_Municipio, deptos.dep_ID FROM Gral.tbSucursales suc
INNER JOIN Gral.tbMunicipios muni
ON suc.suc_Municipio = muni.mun_ID 
INNER JOIN Gral.tbDepartamentos deptos
ON muni.mun_depID = deptos.dep_ID
WHERE suc_Id = @id
)
GO



CREATE OR ALTER PROC UDP_Gral_tbUsuarios_ELIMINAR(@usu_Id INT,  @usu_UsuModi INT)
AS BEGIN

DECLARE @usu_FechaModi DATETIME = GETDATE();

UPDATE Gral.tbUsuarios SET usu_Estado = 0, usu_FechaModi = @usu_FechaModi, usu_UsuarioModi = @usu_UsuModi WHERE usu_Id = @usu_Id

END
GO

CREATE OR ALTER PROC UDP_Gral_tbUsuarios_EDITAR(
@usu_Id INT,
@usu_empID INT,
@usu_EsAdmin BIT,
@usu_UsuModi INT)
AS BEGIN

DECLARE @usu_FechaModi DATETIME = GETDATE();

UPDATE Gral.tbUsuarios SET 
						   usu_EsAdmin = @usu_EsAdmin,
						   usu_FechaModi = @usu_FechaModi, 
						   usu_UsuarioModi = @usu_UsuModi,
						   usu_empID = @usu_empID 
						   WHERE usu_Id = @usu_Id

END
GO

CREATE OR ALTER PROCEDURE UDP_tbSucursales_CargarMuni(
@dep_ID INT)
AS
BEGIN
SELECT	mun_ID, mun_Descripcion 
FROM	Gral.tbMunicipios
WHERE	mun_depID = @dep_ID
END
GO



GO
CREATE OR ALTER PROCEDURE UDP_tbSucursales_CargarDeptos
AS
BEGIN
SELECT	dep_ID, dep_Descripcion 
FROM	Gral.tbDepartamentos
END
GO












CREATE OR ALTER PROCEDURE UDP_tbSucursales_Cargar(
@sucu_ID INT)
AS
BEGIN
SELECT	suc_Id, 
		dep_ID, 
		dep_Descripcion, 
		mun_ID, 
		mun_Descripcion, 
		suc_Descripcion 
		FROM	Gral.tbSucursales sucu 
		INNER JOIN Gral.tbMunicipios ciu
		ON	sucu.suc_Municipio = ciu.mun_ID 
		INNER JOIN Gral.tbDepartamentos dep
		ON ciu.mun_depID = dep.dep_ID
WHERE	suc_Id = @sucu_ID
END
GO


exec UDP_tbSucursales_Cargar 2
select * from Gral.tbMunicipios



GO
CREATE OR ALTER PROC UDP_Gral_tbProveedores_ELIMINAR(@prv_Id INT, @prv_UsuModi INT)
AS BEGIN

UPDATE Maqui.tbProveedores SET prv_Estado = 0, prv_UsuarioModi = @prv_UsuModi, prv_FechaModi = GETDATE() WHERE prv_ID = @prv_Id

END
GO

CREATE OR ALTER PROC UDP_Gral_tbClientes_ELIMINAR(@cli_Id INT, @cli_UsuModi INT)
AS BEGIN

UPDATE Gral.tbClientes SET cli_Estado = 0, cli_UsuarioModi = @cli_UsuModi, cli_FechaModi = GETDATE() WHERE cli_ID = @cli_Id

END
GO


CREATE OR ALTER PROC UDP_Gral_tbEmpleados_ELIMINAR(@emp_Id INT, @emp_UsuModi INT)
AS BEGIN

UPDATE Gral.tbEmpleados SET emp_Estado = 0, emp_UsuarioModi = @emp_UsuModi, emp_FechaModi = GETDATE() WHERE emp_id = @emp_Id

END
GO

CREATE OR ALTER PROC UDP_Gral_tbProductos_ELIMINAR(@pro_Id INT, @pro_UsuModi INT)
AS BEGIN

UPDATE Maqui.tbProductos SET pro_Estado = 0, pro_UsuModi = @pro_UsuModi, pro_FechaModi = GETDATE() WHERE pro_Id = @pro_Id

END
GO


CREATE OR ALTER PROC UDP_Maqui_tbVentas_ELIMINAR(@ven_Id INT, @ven_UsuModi INT)
AS BEGIN

UPDATE Maqui.tbVentas SET ven_Estado = 0, ven_UsuModi = @ven_UsuModi, ven_FechaModi = GETDATE() WHERE ven_Id  = @ven_Id;

END
GO
--****************************************** VISTA PARA DDL SUCURSALES ****************************************************--
CREATE OR ALTER VIEW Vw_Gral_tbSucursales_DDL
AS

SELECT '0' AS 'suc_Id', ' ---Seleccione una opci�n---' AS 'suc_Descripcion'
UNION ALL
SELECT suc_Id, suc_Descripcion FROM Gral.tbSucursales

--****************************************** TG PARA ACTUALIZAR STOCK ****************************************************--
GO
CREATE OR ALTER TRIGGER Maqui.tg_ActualizarStock ON [Maqui].[tbVentasDetalle]
AFTER INSERT 
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE		tbInventario SET inv_Cantidad = inv_Cantidad - (SELECT vde_Cantidad from inserted)
	WHERE		inv_Producto = (Select vde_Producto from inserted)
END;
GO

--****************************************** TG PARA INSERTAR EN INVENTARIO ****************************************************--
GO
CREATE OR ALTER TRIGGER Maqui.tg_InsertInventario ON Maqui.tbProductos
AFTER INSERT
AS
BEGIN
		SET NOCOUNT ON;
		INSERT INTO  tbInventario(inv_Cantidad, inv_Producto, inv_UsuCrea, inv_FechaCrea, inv_Estado)
		SELECT pro_StockInicial, pro_Id, pro_usuCrea, pro_FechaCrea, pro_Estado FROM inserted
END
GO
---    TRIGGER PARA ELIMINAR PRODUCTOS POR CATE ----
go
CREATE OR ALTER TRIGGER tg_EliminarProductos
ON Maqui.tbCategorias
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	IF UPDATE(cat_Estado)
	BEGIN
		
		UPDATE	tbProductos
		SET		pro_Estado = 0, pro_UsuModi = (SELECT cat_UsuModi FROM inserted),  pro_FechaModi= GETDATE()
		WHERE	pro_Categoria IN (SELECT cat_Id FROM inserted WHERE cat_Estado = 0) 
	END
END

go

---    TRIGGER PARA ELIMINAR PRODUCTOS DEL INVENTARIO ----
go
CREATE OR ALTER TRIGGER tg_EliminarProductosInventario
ON Maqui.tbProductos
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	IF UPDATE(pro_Estado)
	BEGIN
		
		UPDATE	tbInventario
		SET		inv_Estado = 0, inv_usuModi = (SELECT pro_UsuModi FROM inserted),  inv_FechaModi= GETDATE()
		WHERE	inv_Producto IN (SELECT pro_Id FROM inserted WHERE pro_Estado = 0) 
	END
END

go

--****************************************** PANTALLA DETALLES ****************************************************--

--CREATE PROCEDURE 'UDP_tbVentas_IdVentaReciente'
CREATE OR ALTER PROCEDURE Maqui.UDP_tbVentas_IdVentaReciente
AS
BEGIN
	SELECT TOP 1 ven_Id
			FROM Maqui.tbVentas
		   WHERE ven_Estado = 1 
		ORDER BY ven_Id DESC 
END
GO

GO
CREATE OR ALTER FUNCTION Maqui.UDF_tbVentas_ListarDetallesPorIdVenta(@ven_Id INT)
RETURNS TABLE
RETURN
	SELECT detalles.vde_Id,
		   detalles.vde_VentaId,
		   productos.pro_Codigo,
		   productos.pro_Nombre,
		   detalles.vde_Cantidad,
		   productos.pro_PrecioUnitario,
		   MontoTotal = detalles.vde_Cantidad * productos.pro_PrecioUnitario
	  FROM Maqui.tbVentasDetalle detalles
INNER JOIN Maqui.tbProductos productos
	    ON detalles.vde_Producto = productos.pro_Id
	 WHERE detalles.vde_VentaId = @ven_Id
	   AND detalles.vde_Estado = 1
GO

CREATE OR ALTER PROCEDURE Maqui.UDP_tbVentas_IngresarNuevaVenta
(
	@ven_Cliente		INT,
	@ven_Empleado	INT,
	@ven_Sucursal	INT,
	@ven_MetodoPago INT,
	@ven_UsuCrea	INT
)
AS
BEGIN
	SET @ven_MetodoPago = 1
	INSERT INTO Maqui.tbVentas(ven_Cliente, ven_Empleado, ven_Fecha, ven_Sucursal, ven_MetodoPago, ven_UsuCrea, ven_FechaCrea, ven_UsuModi, ven_FechaModi, ven_Estado)
	VALUES					(@ven_Cliente,@ven_Empleado,GETDATE(), @ven_Sucursal, @ven_MetodoPago, @ven_UsuCrea,GETDATE(),null, null, 1)
END
GO

CREATE OR ALTER FUNCTION UDF_tbProductos_ListarProductoPorId(@pro_Id INT)
RETURNS TABLE
RETURN
	SELECT  pro_Id,
			pro_Codigo,
			pro_Nombre,
			pro_Categoria,
			pro_Proveedor,
			inv.inv_Cantidad,
			pro_PrecioUnitario
	  FROM  Maqui.tbProductos pro INNER JOIN Maqui.tbInventario inv
	  ON	pro.pro_Id = inv.inv_Producto
	 WHERE  pro_Id = @pro_Id
	   AND  pro_Estado= 1

GO

CREATE OR ALTER FUNCTION Maqui.UDF_tbProductos_CargarStockProductoPorId(@pro_Id INT)
RETURNS TABLE
RETURN
	SELECT  inv_Cantidad
	  FROM Maqui.tbInventario 
	 WHERE inv_Producto = @pro_Id
	   AND inv_Estado = 1
GO

CREATE OR ALTER FUNCTION UDF_tbDetallesVentas_CargarDetalleVentaPorId(@vde_Id INT)
RETURNS TABLE
RETURN
	SELECT	vde_Id,
			vde_VentaId, 
			vde_Producto, 
			vde_Cantidad, 
			pr.pro_PrecioUnitario
	  FROM  Maqui.tbVentasDetalle det INNER JOIN Maqui.tbProductos pr
	  ON	det.vde_Producto = pr.pro_Id
	 WHERE  vde_Id = @vde_Id
GO

CREATE OR ALTER PROCEDURE Maqui.UDP_tbVentas_IngresarNuevoDetalleVenta
(
	@vde_VentaId		INT,
	@vde_Producto		INT,
	@vde_Cantidad		INT,
	@vde_UsuCrea		INT
)
AS
BEGIN
	INSERT INTO Maqui.tbVentasDetalle(vde_VentaId, vde_Producto, vde_Cantidad, vde_UsuCrea, vde_FechaCrea, vde_UsuModi, vde_FechaModi, vde_Estado)
	VALUES(@vde_VentaId, @vde_Producto, @vde_Cantidad, @vde_UsuCrea, GETDATE(), null, null, 1);
END
GO

CREATE OR ALTER PROCEDURE Maqui.UDP_tbDetallesVentas_ActualizarDetalleVenta
(
	@vde_Id				INT,
	@vde_Producto			INT,
	@vde_Cantidad			INT,
	@vde_UsuModi			INT
)
AS
BEGIN
	 UPDATE Maqui.tbVentasDetalle
		SET vde_Producto = @vde_Producto,
			vde_Cantidad = @vde_Cantidad,
			vde_UsuModi = @vde_UsuModi,
			vde_FechaModi = GETDATE()
	  WHERE vde_Id = @vde_Id
END
GO

CREATE OR ALTER PROCEDURE Maqui.UDP_tbDetallesVentas_EliminarDetalleVenta (@vde_Id INT)
AS
BEGIN
 DELETE FROM Maqui.tbVentasDetalle WHERE vde_Id = @vde_Id
END
GO


CREATE OR ALTER PROCEDURE UDP_Login
(
@usu_Usuario NVARCHAR(100),
@usu_Clave	 NVARCHAR(100)
)
AS
BEGIN

SELECT  usu_ID, 
		emp_Nombre + ' ' + emp_Apellido AS usu_Nombre,
		usu_EsAdmin,
		emp_Sucursal,
		suc_Descripcion,
		suc_Id,
		usu_Usuario, 
		usu_Clave
		FROM Gral.[tbUsuarios] T1 
		INNER JOIN Gral.tbEmpleados T2
		ON T1.usu_empID = T2.emp_ID
		INNER JOIN Gral.tbSucursales T3
		ON T2.emp_Sucursal = T3.suc_Id
		WHERE [usu_Clave] = @usu_Clave
		AND	  usu_Usuario = @usu_Usuario



END
GO
CREATE OR ALTER FUNCTION Maqui.UDF_tbCategorias_BuscarCategorias(@ID INT)
RETURNS TABLE
RETURN
SELECT cat_Id, cat_Descripcion, cat_UsuCrea = usu.usu_Usuario, cat_UsuModi = usua.usu_Usuario, cat_FechaCrea, cat_FechaModi FROM Maqui.tbCategorias cate
INNER JOIN  [Gral].[tbUsuarios] usu
ON		cate.cat_UsuCrea = usu.usu_ID
LEFT JOIN  [Gral].[tbUsuarios] usua
ON		cate.cat_UsuModi = usua.usu_ID
WHERE	cate.cat_Id = @ID
GO
--�� VENTAS  ��--
GO

CREATE OR ALTER VIEW Maqui.VW_tbVentas_List
AS
SELECT ven_Id, client.cli_Nombre +' '+client.cli_Apellido AS cli_Nombres,
	   emple.emp_Nombre + ' '+ emple.emp_Apellido AS		emp_Nombres,
	   pago.met_Descripcion, ventas.ven_Fecha
FROM		Maqui.tbVentas ventas
INNER JOIN	Gral.tbClientes client
ON			ventas.ven_Cliente = client.cli_ID
INNER JOIN  Gral.tbEmpleados emple
ON			ventas.ven_Empleado = emple.emp_ID
INNER JOIN  Maqui.tbMetodoPago pago
ON			ventas.ven_MetodoPago = pago.met_Id
GO
--����� UDP  ������ --
CREATE OR ALTER PROCEDURE Maqui.UDP_tbVentas_Listado
AS
BEGIN
	SELECT * FROM Maqui.VW_tbVentas_List
END
GO

--��Listado de ventas con detalles ���--
CREATE OR ALTER VIEW Maqui.VW_tbVentasDetalles_List
AS
	SELECT t1.vde_Id,
		   T1.vde_VentaId, 
		   T2.pro_Id,
		   T2.pro_Nombre,
		   T2.pro_Categoria,
		   T1.vde_Cantidad,
		   T2.pro_PrecioUnitario,
		   (T1.vde_Cantidad*pro_PrecioUnitario) AS vde_PrecioTotal
	FROM	Maqui.tbVentasDetalle T1 INNER JOIN Maqui.tbProductos T2
	ON		T1.vde_Producto = T2.pro_Id
	WHERE	vde_Estado= 1
GO

CREATE OR ALTER PROCEDURE Maqui.UDP_maqu_tbVentasDetalles_Listado 
	@vde_VentaId INT
AS
BEGIN
	SELECT*FROM Maqui.VW_tbVentasDetalles_List 
	WHERE		vde_VentaId = @vde_VentaId
END

GO

---��� Listado de Clientes --��
GO
CREATE OR ALTER PROCEDURE Maqui.UDP_maqu_tbClientes_List
AS
BEGIN
    SELECT cli_ID,
		   cli_Nombre, 
           cli_Apellido, 
           cli_DNI,
           CASE cli_Sexo WHEN 'F' THEN 'Femenino'
                            ELSE 'Masculino'
           END AS cli_Sexo
    FROM   Gral.tbClientes
    WHERE  cli_Estado = 1
END
GO

CREATE OR ALTER PROC UDP_tbCategorias_Detalles(@ID INT)
AS BEGIN
SELECT cat_Id, cat_Descripcion, cat_UsuCrea = usu.usu_Usuario, cat_UsuModi = usua.usu_Usuario, cat_FechaCrea, cat_FechaModi FROM Maqui.tbCategorias cate
INNER JOIN  [Gral].[tbUsuarios] usu
ON		cate.cat_UsuCrea = usu.usu_ID
LEFT JOIN  [Gral].[tbUsuarios] usua
ON		cate.cat_UsuModi = usua.usu_ID
WHERE	cate.cat_Id = @ID
END
GO

CREATE OR ALTER PROC UDP_tbDepartamentos_Detalles(@ID INT)
AS BEGIN
SELECT dep_ID, dep_Descripcion, dep_UsuarioCrea = usu.usu_Usuario, dep_UsuarioModi = usua.usu_Usuario, dep_FechaCrea, dep_FechaModi FROM Gral.tbDepartamentos dep
INNER JOIN  [Gral].[tbUsuarios] usu
ON		dep.dep_UsuarioCrea = usu.usu_ID
LEFT JOIN  [Gral].[tbUsuarios] usua
ON		dep.dep_UsuarioModi = usua.usu_ID
WHERE	dep_ID = @ID
END
GO


CREATE OR ALTER PROC UDP_tbEstadosCiviles_Detalles(@ID INT)
AS BEGIN
SELECT est_ID, est_Descripcion, est_UsuarioCrea = usu.usu_Usuario, est_UsuarioModi = usua.usu_Usuario, est_FechaCrea, est_FechaModi FROM Gral.tbEstadosCiviles est
INNER JOIN  [Gral].[tbUsuarios] usu
ON		est.est_UsuarioCrea = usu.usu_ID
LEFT JOIN  [Gral].[tbUsuarios] usua
ON		est.est_UsuarioModi = usua.usu_ID
WHERE	est_ID = @ID
END
GO

CREATE OR ALTER PROC UDP_tbMetodoPago_Detalles(@ID INT)
AS BEGIN
SELECT met_Id, met_Descripcion, met_UsuCrea = usu.usu_Usuario, met_UsuModi = usua.usu_Usuario, met_FechaCrea, met_FechaModi FROM Maqui.tbMetodoPago met
INNER JOIN  [Gral].[tbUsuarios] usu
ON		met.met_UsuCrea = usu.usu_ID
LEFT JOIN  [Gral].[tbUsuarios] usua
ON		met.met_UsuModi = usua.usu_ID
WHERE	met_ID = @ID
END
GO


CREATE OR ALTER PROC UDP_tbMunicipios_Detalles(@ID INT)
AS BEGIN
SELECT mun_ID, mun_Descripcion, mun_depID = dep_Descripcion, mun_UsuarioCrea = usu.usu_Usuario, mun_UsuarioModi = usua.usu_Usuario, mun_FechaCrea, mun_FechaModi FROM Gral.tbMunicipios mun
INNER JOIN  [Gral].tbUsuarios usu
ON		mun.mun_UsuarioCrea = usu.usu_ID
LEFT JOIN  [Gral].[tbUsuarios] usua
ON		mun.mun_UsuarioModi = usua.usu_ID
INNER JOIN Gral.tbDepartamentos T3
ON mun.mun_depID = T3.dep_ID
WHERE	mun_ID = @ID
END
GO


CREATE OR ALTER PROC UDP_tbSucursales_Detalles(@ID INT)
AS BEGIN
SELECT suc_Id, suc_Descripcion, suc_Municipio = mun_Descripcion, suc_UsuCrea = usu.usu_Usuario, 
suc_UsuModi = usua.usu_Usuario, suc_FechaCrea, suc_FechaModi FROM Gral.tbSucursales suc
INNER JOIN  [Gral].tbUsuarios usu
ON		suc.suc_UsuCrea = usu.usu_ID
LEFT JOIN  [Gral].[tbUsuarios] usua
ON		suc.suc_UsuModi = usua.usu_ID
INNER JOIN Gral.tbMunicipios T3
ON suc.suc_Municipio = T3.mun_ID
WHERE	suc_Id = @ID
END
GO


CREATE OR ALTER PROC UDP_tbUsuarios_Detalles(@ID INT)
AS BEGIN
SELECT T1.usu_ID, T1.usu_Usuario, usu_empID = T4.emp_Nombre + ' ' + T4.emp_Apellido,
T1.usu_EsAdmin,T2.usu_Usuario AS usu_UsuarioCrea, T3.usu_Usuario AS usu_UsuarioModi, T1.usu_FechaCrea, T1.usu_FechaModi FROM Gral.tbUsuarios T1
JOIN Gral.tbUsuarios T2
ON T1.usu_UsuarioCrea = T2.usu_ID
LEFT JOIN Gral.tbUsuarios T3
ON T1.usu_UsuarioModi = T3.usu_ID
INNER JOIN Gral.tbEmpleados T4
ON T1.usu_empID = T4.emp_ID
WHERE T1.usu_ID = @ID
END
GO


CREATE OR ALTER PROC UDP_tbClientes_Detalles(@ID INT)
AS BEGIN
SELECT  cli_ID, 
		cli_Nombre,
		cli_Apellido, 
		cli_DNI, 
		cli_FechaNacimiento, 
		cli_Sexo,
		cli_Telefono,
		cli_Municipio = mun_Descripcion,
		cli_EstadoCivil = est_Descripcion,
		cli_UsuarioCrea = T2.usu_Usuario,
		cli_UsuarioModi = T3.usu_Usuario,
		cli_FechaCrea,
		cli_FechaModi
		FROM Gral.tbClientes T1
		INNER JOIN Gral.tbUsuarios T2
		ON T1.cli_UsuarioCrea = T2.usu_ID
		LEFT JOIN Gral.tbUsuarios T3
		ON T1.cli_UsuarioModi = T3.usu_ID
		INNER JOIN Gral.tbMunicipios T4
		ON T1.cli_Municipio = T4.mun_ID
		INNER JOIN Gral.tbEstadosCiviles T5
		ON T1.cli_EstadoCivil = T5.est_ID
		WHERE cli_ID = @ID

END
GO





CREATE OR ALTER PROC UDP_tbEmpleados_Detalles(@ID INT)
AS BEGIN
SELECT  emp_ID, 
		emp_Nombre, 
		emp_Apellido,
		emp_DNI,
		emp_FechaNacimiento, 
		emp_Sexo,
		emp_Telefono,
		emp_Municipio = mun_Descripcion,
		emp_Correo,
		emp_EstadoCivil = est_Descripcion,
		emp_Sucursal = suc_Descripcion,
		emp_UsuarioCrea = T3.usu_Usuario,
		emp_UsuarioModi = T4.usu_Usuario,
		emp_FechaCrea,
		emp_FechaModi

		FROM Gral.tbEmpleados T1
		INNER Join Gral.tbMunicipios T2
		ON T1.emp_Municipio = T2.mun_ID
		INNER JOIN Gral.tbUsuarios T3
		ON T1.emp_UsuarioCrea = T3.usu_ID
		LEFT JOIN Gral.tbUsuarios T4
		ON T1.emp_UsuarioModi = T4.usu_ID
		INNER JOIN Gral.tbEstadosCiviles T5
		ON T1.emp_EstadoCivil = T5.est_ID
		INNER JOIN Gral.tbSucursales T6
		ON T1.emp_Sucursal = T6.suc_Id
		WHERE emp_ID = @ID

END
GO




CREATE OR ALTER PROC UDP_tbProductos_Detalles(@ID INT)
AS BEGIN
SELECT  pro_Id,
		pro_Codigo,
		pro_Nombre,
		pro_StockInicial,
		pro_PrecioUnitario,
		pro_Proveedor = prv_NombreContacto,
		pro_Categoria = cat_Descripcion,
		pro_usuCrea = T2.usu_Usuario,
		pro_UsuModi = T3.usu_Usuario,
		pro_FechaCrea,
		pro_FechaModi
		FROM Maqui.tbProductos T1
		INNER JOIN Gral.tbUsuarios T2
		ON T1.pro_usuCrea = T2.usu_ID
		LEFT JOIN Gral.tbUsuarios T3
		ON T1.pro_UsuModi = T3.usu_ID
		INNER JOIN Maqui.tbProveedores T4
		ON T1.pro_Proveedor = T4.prv_ID
		INNER JOIN Maqui.tbCategorias T5
		ON T1.pro_Categoria = T5.cat_Id
		WHERE pro_Id = @ID
		
END
GO


CREATE OR ALTER PROC UDP_tbProveedores_Detalles(@ID INT)
AS BEGIN
SELECT  prv_ID,
		prv_NombreCompa�ia,
		prv_NombreContacto,
		prv_TelefonoContacto,
		prv_DireccionEmpresa,
		prv_DireccionContacto,
		CASE prv_SexoContacto
		WHEN 'F' THEN 'Femenino'
		WHEN 'M' THEN 'Masculino'
		END AS prv_SexoContacto,
		prv_UsuarioCrea = T2.usu_Usuario,
		prv_UsuarioModi = T3.usu_Usuario,
		prv_FechaCrea,
		prv_FechaModi
		
		FROM Maqui.tbProveedores T1
		INNER JOIN Gral.tbUsuarios T2
		ON T1.prv_UsuarioCrea = T2.usu_ID
		LEFT JOIN Gral.tbUsuarios T3
		ON T1.prv_UsuarioModi = T3.usu_ID
		WHERE prv_ID= @ID
		
END
GO
CREATE OR ALTER PROC UDP_tbVentas_Detalles(@ID INT)
AS BEGIN
SELECT ven_Id, client.cli_Nombre + ' ' + client.cli_Apellido as ven_Cliente, 
emple.emp_Nombre + ' ' + emple.emp_Apellido as ven_Empleado, met.met_Descripcion, ven_UsuCrea = usu.usu_Usuario, ven_UsuModi = usua.usu_Usuario, ven_Fecha, ven_FechaCrea, ven_FechaModi FROM Maqui.tbVentas vent
INNER JOIN  [Gral].[tbUsuarios] usu
ON			 ven_UsuCrea = usu.usu_ID
INNER JOIN  Maqui.tbMetodoPago met
ON			ven_MetodoPago = met_Id
INNER JOIN	Gral.tbClientes client
ON			ven_Cliente = client.cli_ID
INNER JOIN  Gral.tbEmpleados emple
ON			ven_Empleado = emple.emp_ID
LEFT JOIN  [Gral].[tbUsuarios] usua
ON			ven_UsuModi = usua.usu_ID
WHERE		ven_Id = @ID
END
GO

EXEC UDP_tbVentas_Detalles 2


select * from Maqui.tbProveedores
exec UDP_tbProveedores_Detalles 5


/*Vista metodos de pago*/
GO
CREATE OR ALTER VIEW Maqui.VW_maqu_tbMetodosPago_View
AS
SELECT meto.met_Id, meto.met_Descripcion
FROM Maqui.tbMetodoPago meto

/*Vista metodos de pago UDP*/
GO
CREATE OR ALTER PROCEDURE Maqui.UDP_tbMetodosPago_VW
AS
SELECT * FROM Maqui.VW_maqu_tbMetodosPago_View
GO
/*Listado de categorias*/
GO
CREATE OR ALTER PROCEDURE Maqui.UDP_tbCategorias_List
AS
BEGIN
	SELECT cat_Id, cat_Descripcion 
	FROM Maqui.tbCategorias
	WHERE cat_Estado = 1
END

/*Listado de categoria x Id*/
GO
CREATE OR ALTER PROCEDURE Maqui.UDP_tbCategorias_maqu_ListById
@cat_Id INT
AS
BEGIN
SELECT * FROM Maqui.tbCategorias WHERE cat_Id = @cat_Id AND cat_Estado = 1
END

-- *** �� STOCK *** �� --
GO
CREATE OR ALTER PROCEDURE Maqui.UDP_tbVentas_RevisarStock 
	@inv_Cantidad	INT,
	@inv_Producto	INT
AS
BEGIN
	DECLARE @stockRestante INT = (SELECT inv_Cantidad FROM Maqui.tbInventario WHERE inv_Producto = @inv_Producto) - @inv_Cantidad

	IF @stockRestante < 0
		SELECT 0
	ELSE
		SELECT 1
END


/*Precio de producto*/
GO
CREATE OR ALTER PROCEDURE Maqui.UDP_tbProductos_Precios 
	@pro_Id	INT
AS
BEGIN
	SELECT pro_Id, pro_Nombre, pro_PrecioUnitario
	FROM	Maqui.tbProductos
	WHERE	pro_Id = @pro_Id
END
-- ��Listado pro_Id POR pro_Categoria ��--
GO
CREATE OR ALTER PROCEDURE Maqui.UDP_tbProductos_ListDDL
	@pro_Categoria	INT
AS
BEGIN
	SELECT  pro_Id, pro_Nombre, pro_PrecioUnitario
	FROM	Maqui.tbProductos
	WHERE   pro_Categoria = @pro_Categoria
	AND		pro_Estado = 1
END

GO
CREATE OR ALTER PROCEDURE Maqui.UDP_tbFacturas_Insert
	@ven_Cliente INT,
	@ven_Empleado INT,
	@ven_Sucursal INT,
	@ven_MetodoPago INT,
	@ven_UsuCrea INT
AS
BEGIN
	BEGIN TRY
		INSERT INTO Maqui.tbVentas (ven_Cliente, ven_Empleado, ven_Fecha, ven_Sucursal, ven_MetodoPago, 
									ven_UsuCrea, ven_FechaCrea, ven_UsuModi, ven_FechaModi, ven_Estado)
		VALUES						(@ven_Cliente, @ven_Empleado, GETDATE(),@ven_Sucursal, @ven_MetodoPago,
									@ven_UsuCrea, GETDATE(), NULL, NULL, 1)

		SELECT SCOPE_IDENTITY()
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Insertar factura detalles*/
GO
CREATE OR ALTER PROCEDURE Maqui.UDP_maqu_tbFacturasDetalles_Insert 
	@vde_VentaId				INT,
	@vde_Producto				INT,
	@vde_Cantidad				INT,
	@vde_UsuCrea				INT
AS
BEGIN
	BEGIN TRY
		--DECLARE @factdeta_Precio DECIMAL(18,2) = (SELECT [prod_PrecioUni] FROM [maqu].[tbProductos] WHERE prod_Id = @prod_Id)

		INSERT INTO Maqui.tbVentasDetalle(vde_VentaId, 
										  vde_Producto, 
										  vde_Cantidad, 
										  vde_UsuCrea, 
										  vde_FechaCrea, 
										  vde_UsuModi, 
										  vde_FechaModi, 
										  vde_Estado)
		VALUES							(@vde_VentaId,
										@vde_Producto,
										@vde_Cantidad,
										@vde_UsuCrea,
										GETDATE(),
										null,
										null,
										1)
		SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END

/*Eliminar factura detalles*/
GO
CREATE OR ALTER PROCEDURE Maqui.UDP_tbVentasDetalles_Delete 
	@vde_Id	INT
AS
BEGIN
	BEGIN TRY
		DELETE 
		FROM  Maqui.tbVentasDetalle
		WHERE vde_Id = @vde_Id
		SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END
GO
-- ��� EDITAR EL DETALLE �� --
CREATE OR ALTER PROCEDURE Maqui.UDP_tbVentasDetalles_Update 
	@vde_Id						INT,
	@vde_Producto				INT,
	@vde_Cantidad				INT,
	@vde_UsuModi	INT
AS
BEGIN
	BEGIN TRY
		--DECLARE @factdeta_Precio DECIMAL(18,2) = (SELECT [prod_PrecioUni] FROM [maqu].[tbProductos] WHERE prod_Id = @prod_Id)

		UPDATE Maqui.tbVentasDetalle
		SET vde_Producto = @vde_Producto,
			vde_Cantidad= @vde_Cantidad,
			vde_UsuModi = @vde_UsuModi,
			vde_FechaModi = GETDATE()
		WHERE vde_Id = @vde_Id

		SELECT 1
	END TRY
	BEGIN CATCH
		SELECT 0
	END CATCH
END