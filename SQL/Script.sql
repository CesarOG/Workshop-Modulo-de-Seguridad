/*
	CREACION DE BASE DE DATOS
*/
USE master
GO
DROP DATABASE DB_SECURITY
GO
CREATE DATABASE DB_SECURITY
GO
USE DB_SECURITY
GO

/*
	CREACION DE TABLAS PRINCIPALES
*/

CREATE TABLE Modulo(
IdModulo INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Nombre VARCHAR(30),
Ruta VARCHAR(100),
IdModuloPadre INT,
FechaRegistra DATETIME NOT NULL,
UsuarioRegistra INT NOT NULL,
FechaModifica DATETIME,
UsuarioModifica INT,
Activo BIT NOT NULL,
CONSTRAINT FK_Usuario_Recursivo FOREIGN KEY (IdModuloPadre) REFERENCES Modulo (IdModulo)
);

CREATE TABLE Perfil(
IdPerfil INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Nombre VARCHAR(30) NOT NULL,
FechaRegistra DATETIME NOT NULL,
UsuarioRegistra INT NOT NULL,
FechaModifica DATETIME,
UsuarioModifica INT,
Activo BIT NOT NULL
);

CREATE TABLE Usuario(
IdUsuario INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
NombreCompleto VARCHAR(150) NOT NULL,
Usuario VARCHAR(20) NOT NULL,
Contrasena VARCHAR(32) NOT NULL,
FechaRegistra DATETIME NOT NULL,
UsuarioRegistra INT,
FechaModifica DATETIME,
UsuarioModifica INT,
Activo BIT NOT NULL
);

/*
	CREACION DE TABLAS UNO A MUCHOS Y
	SU REALACIÓN CON LAS PRINCIPALES
*/

CREATE TABLE PerfilModulo(
IdPerfilModulo INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
IdPerfil INT NOT NULL,
IdModulo INT NOT NULL,
FechaRegistra DATETIME NOT NULL,
UsuarioRegistra INT,
FechaModifica DATETIME,
UsuarioModifica INT,
Activo BIT NOT NULL,
CONSTRAINT FK_Perfil_PerfilModulo FOREIGN KEY (IdPerfil) REFERENCES Perfil (IdPerfil),
CONSTRAINT FK_Modulo_PerfilModulo FOREIGN KEY (IdModulo) REFERENCES Modulo (IdModulo)
);

CREATE TABLE UsuarioPerfil(
IdUsuarioPerfil INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
IdUsuario INT NOT NULL,
IdPerfil INT NOT NULL,
FechaRegistra DATETIME NOT NULL,
UsuarioRegistra INT,
FechaModifica DATETIME,
UsuarioModifica INT,
Activo BIT NOT NULL,
CONSTRAINT FK_Usuario_UsuarioPerfil FOREIGN KEY (IdUsuario) REFERENCES Usuario (IdUsuario),
CONSTRAINT FK_Perfil_UsuarioPerfil FOREIGN KEY (IdPerfil) REFERENCES Perfil (IdPerfil)
);

/*
	INSERT DE DATA INICIAL
*/

INSERT INTO Usuario 
(NombreCompleto,Usuario,Contrasena,FechaRegistra,Activo)
VALUES
('Usuario Base','ROOT','123',GETDATE(),1);
GO

INSERT INTO Perfil
(Nombre,FechaRegistra,UsuarioRegistra,Activo)
VALUES
('ADMINISTRADOR',GETDATE(),1,1);
GO

INSERT INTo Modulo
(Nombre,Ruta,IdModuloPadre,FechaRegistra,UsuarioRegistra,Activo)
VALUES
('Seguridad','/',NULL,GETDATE(),1,1),
('Usuario','Seguridad/Usuario',1,GETDATE(),1,1),
('Perfil','Seguridad/Perfil',1,GETDATE(),1,1),
('Modulo','Seguridad/Modulo',1,GETDATE(),1,1);
GO

INSERT INTO PerfilModulo
(IdPerfil,IdModulo,FechaRegistra,UsuarioRegistra,Activo)
VALUES
(1,1,GETDATE(),1,1),
(1,2,GETDATE(),1,1),
(1,3,GETDATE(),1,1),
(1,4,GETDATE(),1,1);
GO

INSERT INTO UsuarioPerfil
(IdUsuario,IdPerfil,FechaRegistra,UsuarioRegistra,Activo)
VALUES
(1,1,GETDATE(),1,1);
GO

/*
	CREACION DE PROCEDIMIENTOS ALMACENADOS
*/

-- USUARIO
CREATE OR ALTER PROCEDURE SP_LISTAR_USUARIO
AS
BEGIN
	SELECT 
		IdUsuario,
		NombreCompleto,
		Usuario,
		Contrasena
	FROM Usuario
	WHERE
		Activo = 1
END
GO

CREATE OR ALTER PROCEDURE SP_OBTENER_USUARIO_PorID
@IDUSUARIO INT
AS
BEGIN
	SELECT 
		IdUsuario,
		NombreCompleto,
		Usuario,
		Contrasena
	FROM Usuario
	WHERE
		IdUsuario = @IDUSUARIO
END
GO

CREATE OR ALTER PROCEDURE SP_REGISTRA_USUARIO
@NOMBRECOMPLETO VARCHAR(150),
@USUARIO VARCHAR(20),
@CONTRASENA VARCHAR(32) ,
@USUARIO_REGISTRA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO Usuario
		(NombreCompleto,Usuario,Contrasena,FechaRegistra,UsuarioRegistra,Activo)
		VALUES
		(@NOMBRECOMPLETO,@USUARIO,@CONTRASENA,GETDATE(),@USUARIO_REGISTRA,1);
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_USUARIO
@IDUSUARIO INT,
@NOMBRECOMPLETO VARCHAR(150),
@USUARIO VARCHAR(20),
@CONTRASENA VARCHAR(32),
@USUARIO_MODIFICA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE Usuario
		SET
			NombreCompleto = @NOMBRECOMPLETO,
			Usuario = @USUARIO,
			Contrasena = @CONTRASENA,
			FechaModifica = GETDATE(),
			UsuarioModifica = @USUARIO_MODIFICA
		WHERE
			IdUsuario = @IDUSUARIO;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_USUARIO
@IDUSUARIO INT,
@USUARIO_MODIFICA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE Usuario
		SET
			Activo = 0,
			FechaModifica = GETDATE(),
			UsuarioModifica = @USUARIO_MODIFICA
		WHERE
			IdUsuario = @IDUSUARIO;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

-- PERFIL
CREATE OR ALTER PROCEDURE SP_LISTAR_PERFIL
AS
BEGIN
	SELECT 
		IdPerfil,
		Nombre
	FROM Perfil
	WHERE
		Activo = 1
END
GO

CREATE OR ALTER PROCEDURE SP_OBTENER_PERFIL_PorID
@IDPERFIL INT
AS
BEGIN
	SELECT 
		IdPerfil,
		Nombre
	FROM Perfil
	WHERE
		IdPerfil = @IDPERFIL
END
GO

CREATE OR ALTER PROCEDURE SP_REGISTRA_PERFIL
@NOMBRE VARCHAR(30),
@USUARIO_REGISTRA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO Perfil
		(Nombre,FechaRegistra,UsuarioRegistra,Activo)
		VALUES
		(@NOMBRE,GETDATE(),@USUARIO_REGISTRA,1);
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_PERFIL
@IDPERFIL INT,
@NOMBRE VARCHAR(150),
@USUARIO_MODIFICA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE Perfil
		SET
			Nombre = @NOMBRE,
			FechaModifica = GETDATE(),
			UsuarioModifica = @USUARIO_MODIFICA
		WHERE
			IdPerfil = @IDPERFIL;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_PERFIL
@IDPERFIL INT,
@USUARIO_MODIFICA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE Perfil
		SET
			Activo = 0,
			FechaModifica = GETDATE(),
			UsuarioModifica = @USUARIO_MODIFICA
		WHERE
			IdPerfil = @IDPERFIL;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

-- MODULO
CREATE OR ALTER PROCEDURE SP_LISTAR_MODULO
AS
BEGIN
	SELECT 
		M.IdModulo,
		M.Nombre,
		M.Ruta,
		ISNULL(MP.Nombre,'') AS 'ModuloPadre'
	FROM Modulo M
	LEFT JOIN Modulo MP ON M.IdModuloPadre = MP.IdModulo
	WHERE
		M.Activo = 1
END
GO

CREATE OR ALTER PROCEDURE SP_OBTENER_MODULO_PorID
@IDMODULO INT
AS
BEGIN
	SELECT 
		IdModulo,
		Nombre,
		Ruta,
		IdModuloPadre
	FROM Modulo
	WHERE
		IdModulo = @IDMODULO
END
GO

CREATE OR ALTER PROCEDURE SP_REGISTRA_MODULO
@NOMBRE VARCHAR(30),
@RUTA VARCHAR(150),
@IDMODULOPADRE INT = NULL,
@USUARIO_REGISTRA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO Modulo
		(Nombre,Ruta,IdModuloPadre,FechaRegistra,UsuarioRegistra,Activo)
		VALUES
		(@NOMBRE,@RUTA,@IDMODULOPADRE,GETDATE(),@USUARIO_REGISTRA,1);
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_MODULO
@IDMODULO INT,
@NOMBRE VARCHAR(150),
@RUTA VARCHAR(150),
@IDMODULOPADRE INT = NULL,
@USUARIO_MODIFICA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE Modulo
		SET
			Nombre = @NOMBRE,
			Ruta = @RUTA,
			IdModuloPadre = @IDMODULOPADRE,
			FechaModifica = GETDATE(),
			UsuarioModifica = @USUARIO_MODIFICA
		WHERE
			IdModulo = @IDMODULO;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

CREATE OR ALTER PROCEDURE SP_ELIMINA_MODULO
@IDMODULO INT,
@USUARIO_MODIFICA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE Modulo
		SET
			Activo = 0,
			FechaModifica = GETDATE(),
			UsuarioModifica = @USUARIO_MODIFICA
		WHERE
			IdModulo = @IDMODULO;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

-- PERFIL MODULO 
CREATE OR ALTER PROCEDURE SP_OBTENER_PERFILMODULO_PorIDS
@IDPERFIL INT
AS
BEGIN
	SELECT 
		M.IdModulo,
		M.Nombre,
		M.Ruta,
		M.IdModuloPadre,
		MP.Nombre AS 'ModuloPadre',
		PM.Activo
	FROM Modulo M	
	LEFT JOIN Modulo MP ON MP.IdModuloPadre = M.IdModulo
	LEFT JOIN PerfilModulo PM ON PM.IdModulo = PM.IdModulo AND M.Activo = 1
	WHERE
		PM.IdPerfil = @IDPERFIL
END
GO

CREATE OR ALTER PROCEDURE SP_REGISTRA_PERFIL_MODULO
@IDPERFIL INT,
@IDMODULO INT,
@USUARIO_REGISTRA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO PerfilModulo
		(IdPerfil,IdModulo,FechaRegistra,UsuarioRegistra,Activo)
		VALUES
		(@IDPERFIL,@IDMODULO,GETDATE(),@USUARIO_REGISTRA,1);
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_PERFIL_MODULO
@IDPERFIL INT,
@IDMODULO INT,
@ACTIVO BIT,
@USUARIO_MODIFICA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE PerfilModulo
		SET
			IdPerfil = @IDPERFIL,
			IdModulo = @IDMODULO,
			Activo = @ACTIVO,
			FechaModifica = GETDATE(),
			UsuarioModifica = @USUARIO_MODIFICA
		WHERE
			IdPerfil = @IDPERFIL AND IdModulo = @IDMODULO;
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

-- USUARIO PERFIL 
CREATE OR ALTER PROCEDURE SP_OBTENER_USUARIOPERFIL_PorIDS
@IDUSUARIO INT
AS
BEGIN
	SELECT 
		P.IdPerfil,
		P.Nombre,
		UP.Activo
	FROM Perfil P
	LEFT JOIN UsuarioPerfil UP ON UP.IdPerfil = P.IdPerfil AND P.Activo = 1
	WHERE
		UP.IdUsuario = @IDUSUARIO 
END
GO

CREATE OR ALTER PROCEDURE SP_REGISTRA_USUARIO_PERFIL
@IDUSUARIO INT,
@IDPERFIL INT,
@USUARIO_REGISTRA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO UsuarioPerfil
		(IdUsuario,IdPerfil,FechaRegistra,UsuarioRegistra,Activo)
		VALUES
		(@IDUSUARIO,@IDPERFIL,GETDATE(),@USUARIO_REGISTRA,1);
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

CREATE OR ALTER PROCEDURE SP_ACTUALIZA_USUARIO_PERFIL
@IDUSUARIO INT,
@IDPERFIL INT,
@ACTIVO BIT,
@USUARIO_MODIFICA INT
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE UsuarioPerfil
		SET
			IdUsuario = @IDUSUARIO,
			IdPerfil = @IDPERFIL,
			Activo = @ACTIVO,
			FechaModifica = GETDATE(),
			UsuarioModifica = @USUARIO_MODIFICA
		WHERE
			IdUsuario = @IDUSUARIO AND IdPerfil = @IDPERFIL
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
 PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
 PRINT 'Error Message: ' + ERROR_MESSAGE();  
 PRINT 'Error Severity: ' + CAST(ERROR_SEVERITY() AS VARCHAR(10));
 PRINT 'Error State: ' + CAST(ERROR_STATE() AS VARCHAR(10));
 PRINT 'Error Line: ' + CAST(ERROR_LINE() AS VARCHAR(10));
 PRINT 'Error Proc: ' + COALESCE(ERROR_PROCEDURE(), 'Not within procedure');
 ROLLBACK TRANSACTION;
END CATCH;
GO

SELECT * FROM Usuario