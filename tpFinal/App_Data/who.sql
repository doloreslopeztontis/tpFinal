USE [master]
GO
/****** Object:  Database [QUIEN ES QUIEN]    Script Date: 9/10/2018 12:13:48 p. m. ******/
CREATE DATABASE [QUIEN ES QUIEN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QUIEN ES QUIEN', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QUIEN ES QUIEN.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QUIEN ES QUIEN_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\QUIEN ES QUIEN_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QUIEN ES QUIEN] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QUIEN ES QUIEN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QUIEN ES QUIEN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET ARITHABORT OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET  MULTI_USER 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QUIEN ES QUIEN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QUIEN ES QUIEN] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [QUIEN ES QUIEN]
GO
/****** Object:  Table [dbo].[CARACTERISTICAS]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CARACTERISTICAS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Caracteristica] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CARACTERISTICAS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](100) NOT NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PERSONAJES]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PERSONAJES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Foto] [varchar](100) NOT NULL,
	[fkCategoria] [int] NOT NULL,
 CONSTRAINT [PK_PERSONAJES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PREGUNTAS]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PREGUNTAS](
	[fkPersonaje] [int] NOT NULL,
	[fkCaracteristica] [int] NOT NULL,
	[Tiene] [bit] NOT NULL
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PERSONAJES]  WITH CHECK ADD  CONSTRAINT [FK_PERSONAJES_CATEGORIAS] FOREIGN KEY([fkCategoria])
REFERENCES [dbo].[CATEGORIAS] ([id])
GO
ALTER TABLE [dbo].[PERSONAJES] CHECK CONSTRAINT [FK_PERSONAJES_CATEGORIAS]
GO
ALTER TABLE [dbo].[PREGUNTAS]  WITH CHECK ADD  CONSTRAINT [FK_CARACTERISTICASxPERSONAJES_CARACTERISTICAS] FOREIGN KEY([fkCaracteristica])
REFERENCES [dbo].[CARACTERISTICAS] ([id])
GO
ALTER TABLE [dbo].[PREGUNTAS] CHECK CONSTRAINT [FK_CARACTERISTICASxPERSONAJES_CARACTERISTICAS]
GO
ALTER TABLE [dbo].[PREGUNTAS]  WITH CHECK ADD  CONSTRAINT [FK_CARACTERISTICASxPERSONAJES_PERSONAJES] FOREIGN KEY([fkPersonaje])
REFERENCES [dbo].[PERSONAJES] ([id])
GO
ALTER TABLE [dbo].[PREGUNTAS] CHECK CONSTRAINT [FK_CARACTERISTICASxPERSONAJES_PERSONAJES]
GO
/****** Object:  StoredProcedure [dbo].[EliminarPersonaje]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarPersonaje]
	
	@idpersonaje int

AS
BEGIN
	
	SET NOCOUNT ON;

    DELETE FROM PERSONAJES
	WHERE id = @idpersonaje

END

GO
/****** Object:  StoredProcedure [dbo].[ListarCaracteristicas]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarCaracteristicas]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM CARACTERISTICAS
	  
END


GO
/****** Object:  StoredProcedure [dbo].[ListarCaracteristicasPersonaje]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarCaracteristicasPersonaje]
	
	@idpersonaje int

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT CARACTERISTICAS.Caracteristica 
	FROM PREGUNTAS
	INNER JOIN CARACTERISTICAS ON CARACTERISTICAS.id = PREGUNTAS.fkCaracteristica
	INNER JOIN PERSONAJES ON PERSONAJES.id = PREGUNTAS.fkPersonaje
	WHERE fkPersonaje = @idpersonaje

END

GO
/****** Object:  StoredProcedure [dbo].[ListarCategorias]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarCategorias]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM Categorias
  
END


GO
/****** Object:  StoredProcedure [dbo].[ListarPersonajes]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarPersonajes]
	
	@categoria varchar(100)

AS
BEGIN
	
	SET NOCOUNT ON;

	IF(@categoria != 'todos')
	BEGIN
		IF EXISTS (SELECT * FROM CATEGORIAS WHERE Categoria = @categoria)
		BEGIN
			DECLARE @idcategoria int
			SELECT @idcategoria = id FROM CATEGORIAS WHERE Categoria = @categoria

			SELECT PERSONAJES.id, Nombre, Foto, CATEGORIAS.id AS 'IdCategoria', CATEGORIAS.Categoria
			FROM PERSONAJES
			INNER JOIN CATEGORIAS ON CATEGORIAS.id = PERSONAJES.fkCategoria
			WHERE fkCategoria = @idcategoria
		END
	END
	ELSE
	BEGIN
		SELECT PERSONAJES.id, Nombre, Foto, CATEGORIAS.id AS 'IdCategoria', CATEGORIAS.Categoria
		FROM PERSONAJES
		INNER JOIN CATEGORIAS ON CATEGORIAS.id = PERSONAJES.fkCategoria
	END
	  
END


GO
/****** Object:  StoredProcedure [dbo].[TraerCaracteristica]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TraerCaracteristica]

	@idcaracteristica int
	
AS
BEGIN
	
	SELECT * FROM CARACTERISTICAS
	WHERE id = @idcaracteristica

END


GO
/****** Object:  StoredProcedure [dbo].[TraerPersonaje]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TraerPersonaje]
	
	@idpersonaje int

AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT * FROM PERSONAJES
	WHERE id = @idpersonaje	

END


GO
/****** Object:  StoredProcedure [dbo].[TraerPregunta]    Script Date: 9/10/2018 12:13:48 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TraerPregunta] 
	
	@idpersonaje int,
	@idcaracteristica int

AS
BEGIN
	
	IF EXISTS (SELECT * FROM PREGUNTAS WHERE fkPersonaje = @idpersonaje AND fkCaracteristica = @idcaracteristica)
	BEGIN
		SELECT * FROM PREGUNTAS
		WHERE fkPersonaje = @idpersonaje AND fkCaracteristica = @idcaracteristica
	END
	
END


GO
USE [master]
GO
ALTER DATABASE [QUIEN ES QUIEN] SET  READ_WRITE 
GO
