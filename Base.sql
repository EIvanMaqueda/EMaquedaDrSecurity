USE [EMaquedaDrSecurity]
GO
/****** Object:  StoredProcedure [dbo].[UsuarioAdd]    Script Date: 4/26/2023 3:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioAdd]
@nombre varchar(50),@apellidoPaterno varchar(50),@apellidoMaterno varchar(50),@fechaNacimiento varchar(50),@sexo char,@estadoCivil varchar(50),
@Curp varchar(20),@estado varchar(50),@municipio varchar(50),@colonia varchar(50),@calle varchar(50),@numero varchar(10)
AS
INSERT INTO [dbo].[Direccion]
           ([Estado]
           ,[Municipio]
           ,[Colonia]
           ,[Calle]
           ,[Numero])
     VALUES
           (@estado,@municipio,@colonia,@calle,@numero)

INSERT INTO [dbo].[Usuario]
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[FechaNacimiento]
           ,[Sexo]
           ,[EstadoCivil]
           ,[IdDireccion]
           ,[CURP])
     VALUES
           (@nombre,@apellidoPaterno,@apellidoMaterno,CONVERT(date,@fechaNacimiento,105),
		   @sexo,@estadoCivil,@@IDENTITY,@Curp)

GO
/****** Object:  StoredProcedure [dbo].[UsuarioDelete]    Script Date: 4/26/2023 3:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioDelete]
@idDireccion int,@idUsuario int
AS

DELETE FROM Usuario
      WHERE IdUsuario=@idUsuario
DELETE FROM [dbo].[Direccion]
      WHERE IdDireccion=@idDireccion

GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetAll]    Script Date: 4/26/2023 3:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioGetAll]
AS
SELECT [IdUsuario]
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,[FechaNacimiento]
      ,[Sexo]
      ,[EstadoCivil]
      ,Usuario.IdDireccion
      ,[CURP]
	  ,Estado
	  ,Municipio
	  ,Colonia
	  ,Calle
	  ,Numero
  FROM [dbo].[Usuario]
  INNER JOIN Direccion ON Usuario.IdDireccion=Direccion.IdDireccion 
GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetById]    Script Date: 4/26/2023 3:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioGetById]
@idUsuario int
AS
SELECT [IdUsuario]
      ,[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,[FechaNacimiento]
      ,[Sexo]
      ,[EstadoCivil]
      ,Usuario.IdDireccion
      ,[CURP]
	  ,Estado
	  ,Municipio
	  ,Colonia
	  ,Calle
	  ,Numero
  FROM [dbo].[Usuario]
  INNER JOIN Direccion ON Usuario.IdDireccion=Direccion.IdDireccion 
  WHERE IdUsuario=@idUsuario
GO
/****** Object:  StoredProcedure [dbo].[UsuarioUpdate]    Script Date: 4/26/2023 3:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioUpdate]
@nombre varchar(50),@apellidoPaterno varchar(50),@apellidoMaterno varchar(50),@fechaNacimiento varchar(50),@sexo char,@estadoCivil varchar(50),
@Curp varchar(20),@estado varchar(50),@municipio varchar(50),@colonia varchar(50),@calle varchar(50),@numero varchar(10),@idUsuario int,@idDireccion int
AS
UPDATE [dbo].[Direccion]
   SET [Estado] = @estado
      ,[Municipio] = @municipio
      ,[Colonia] = @colonia
      ,[Calle] = @calle
      ,[Numero] = @numero
 WHERE IdDireccion=@idDireccion

 UPDATE [dbo].[Usuario]
   SET [Nombre] = @nombre
      ,[ApellidoPaterno] = @apellidoPaterno
      ,[ApellidoMaterno] = @apellidoMaterno
      ,[FechaNacimiento] = CONVERT(date,@fechaNacimiento,105)
      ,[Sexo] = @sexo
      ,[EstadoCivil] = @estadoCivil
      ,[IdDireccion] = @idDireccion
      ,[CURP] = @Curp
 WHERE IdUsuario=@idUsuario



GO
/****** Object:  Table [dbo].[Direccion]    Script Date: 4/26/2023 3:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Direccion](
	[IdDireccion] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](50) NULL,
	[Municipio] [varchar](50) NULL,
	[Colonia] [varchar](50) NULL,
	[Calle] [varchar](50) NULL,
	[Numero] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDireccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/26/2023 3:24:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](50) NULL,
	[ApellidoMaterno] [varchar](50) NULL,
	[FechaNacimiento] [date] NULL,
	[Sexo] [char](1) NULL,
	[EstadoCivil] [varchar](50) NULL,
	[IdDireccion] [int] NULL,
	[CURP] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdDireccion])
REFERENCES [dbo].[Direccion] ([IdDireccion])
GO
