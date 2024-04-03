USE [master]
GO
/****** Object:  Database [WinFormsContacts]    Script Date: 2/04/2024 22:22:03 ******/
CREATE DATABASE [WinFormsContacts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WinFormsContacts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\WinFormsContacts.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WinFormsContacts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\WinFormsContacts_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [WinFormsContacts] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WinFormsContacts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WinFormsContacts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WinFormsContacts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WinFormsContacts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WinFormsContacts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WinFormsContacts] SET ARITHABORT OFF 
GO
ALTER DATABASE [WinFormsContacts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WinFormsContacts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WinFormsContacts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WinFormsContacts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WinFormsContacts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WinFormsContacts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WinFormsContacts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WinFormsContacts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WinFormsContacts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WinFormsContacts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WinFormsContacts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WinFormsContacts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WinFormsContacts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WinFormsContacts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WinFormsContacts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WinFormsContacts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WinFormsContacts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WinFormsContacts] SET RECOVERY FULL 
GO
ALTER DATABASE [WinFormsContacts] SET  MULTI_USER 
GO
ALTER DATABASE [WinFormsContacts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WinFormsContacts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WinFormsContacts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WinFormsContacts] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WinFormsContacts] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WinFormsContacts] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WinFormsContacts', N'ON'
GO
ALTER DATABASE [WinFormsContacts] SET QUERY_STORE = ON
GO
ALTER DATABASE [WinFormsContacts] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [WinFormsContacts]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NULL,
	[razon_social] [varchar](50) NULL,
	[IDtipo_documento] [int] NULL,
	[numero_documento] [int] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_documento]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_documento](
	[IDtipo_documento] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NULL,
	[descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_tipo_documento] PRIMARY KEY CLUSTERED 
(
	[IDtipo_documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_tipo_documento] FOREIGN KEY([IDtipo_documento])
REFERENCES [dbo].[tipo_documento] ([IDtipo_documento])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_tipo_documento]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarCliente]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarCliente]
    @nuevo_id INT,
    @codigo VARCHAR(50),
	@razon_social VARCHAR(50)

AS
BEGIN
    UPDATE cliente 
    SET codigo=@codigo,razon_social=@razon_social
    WHERE id = @nuevo_id;
END
GO
/****** Object:  StoredProcedure [dbo].[GuardarTipoDocumento]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarTipoDocumento]
    @ID INT,
    @TipoDocumento NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Insertar o actualizar el tipo de documento en la tabla correspondiente
        -- En este ejemplo, asumimos que tienes una tabla llamada 'Cliente' con una columna llamada 'TipoDocumento'
        -- Puedes modificar esto según la estructura real de tu base de datos

        -- Si el registro ya existe (suponiendo que cada cliente tiene una fila en la tabla)
        IF EXISTS (SELECT 1 FROM Cliente WHERE id = @ID)
        BEGIN
            UPDATE Cliente
            SET IDtipo_documento = @TipoDocumento
            WHERE id = @ID;
        END
        ELSE
        BEGIN
            -- Si el registro no existe, puedes insertarlo
            -- Esto puede variar según tu estructura de base de datos
            -- Aquí se muestra un ejemplo básico
            INSERT INTO Cliente (id, IDtipo_documento)
            VALUES (@ID, @TipoDocumento);
        END

        -- Indicar que la operación se completó correctamente
        SELECT 1 AS Resultado;
    END TRY
    BEGIN CATCH
        -- En caso de error, se devuelve un mensaje de error
        -- Esto puede personalizarse según tus necesidades
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarCliente]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarCliente]
    @id INT,
    @codigo VARCHAR(50),
    @razon_social VARCHAR(50)
AS
BEGIN
    INSERT INTO cliente (id, codigo, razon_social) 
    VALUES (@id, @codigo, @razon_social);
END
GO
/****** Object:  StoredProcedure [dbo].[ObtenerTiposDocumento]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerTiposDocumento]
AS
BEGIN
    -- Simplemente seleccionamos las opciones que deseamos mostrar en el ComboBox
    -- Asumimos que el IDtipo_documento de "ruc" es 1, "pasaporte" es 2 y "dni" es 3
    -- Puedes ajustar estos valores según la estructura real de tu base de datos

    SELECT IDtipo_documento AS idTipDoc,descripcion AS descrip from tipo_documento
    
END
GO
/****** Object:  StoredProcedure [dbo].[Pa_ActualizarCliente]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pa_ActualizarCliente]
    @nuevo_id INT,
    @codigo VARCHAR(50),
	@razon_social VARCHAR(50),
	@IDtipo_documento INT,
	@numero_documento INT


AS
BEGIN
    UPDATE cliente 
    SET codigo=@codigo,razon_social=@razon_social, IDtipo_documento =@IDtipo_documento,numero_documento=@numero_documento  
    WHERE id = @nuevo_id;
END
GO
/****** Object:  StoredProcedure [dbo].[Pa_cbxInsertarIDtipoDocumento]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pa_cbxInsertarIDtipoDocumento]
    @IDtipoDocumento VARCHAR(50) -- Parámetro para recibir el tipo de documento seleccionado
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TipoDocumentoz INT

    -- Determinar el ID del tipo de documento basado en la selección del usuario
    IF @IDtipoDocumento = 'RUC'
        SET @TipoDocumentoz = 3;
    ELSE IF @IDtipoDocumento = 'Pasaporte'
        SET @TipoDocumentoz = 4;
    ELSE IF @IDtipoDocumento = 'DNI'
        SET @TipoDocumentoz = 5;
    ELSE
        SET @TipoDocumentoz = NULL; -- Manejo de error si el tipo de documento no coincide con ninguna opción

    -- Insertar el ID del tipo de documento en la tabla de clientes
    INSERT INTO WinFormsContacts.dbo.Cliente (IDtipo_documento) -- Ajusta el nombre de la tabla y la base de datos según tu estructura
    VALUES (@TipoDocumentoz);
END
GO
/****** Object:  StoredProcedure [dbo].[Pa_EliminarCliente]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pa_EliminarCliente]
    @ID INT
AS
BEGIN
    
  
        -- Eliminar el cliente de la tabla Clientes
        DELETE FROM cliente WHERE id = @ID;
       

       
END
GO
/****** Object:  StoredProcedure [dbo].[Pa_InsertarCliente]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pa_InsertarCliente]
    
    @codigo VARCHAR(50),
    @razon_social VARCHAR(50),
	@IDtipoDocumento INT,
	@numero_documento INT

AS
BEGIN
    INSERT INTO cliente (codigo, razon_social, IDtipo_documento, numero_documento) 
    VALUES (@codigo, @razon_social ,@IDtipoDocumento, @numero_documento);
END
GO
/****** Object:  StoredProcedure [dbo].[Pa_ObtenerIDTipoDocumentoPorDescripcion]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pa_ObtenerIDTipoDocumentoPorDescripcion]
    @DescripcionTipoDocumento NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Declarar una variable para almacenar el IDtipo_documento
    DECLARE @IDtipo_documento INT;

    -- Buscar el IDtipo_documento basado en la descripción proporcionada
    SELECT @IDtipo_documento = IDtipo_documento
    FROM tipo_documento
    WHERE descripcion = @DescripcionTipoDocumento;

    -- Devolver el IDtipo_documento encontrado
    SELECT @IDtipo_documento AS IDtipo_documento;
END;
GO
/****** Object:  StoredProcedure [dbo].[Pa_ObtenerIDTipoDocumentoPorNombre]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pa_ObtenerIDTipoDocumentoPorNombre]
    @NombreTipoDocumento VARCHAR(50) -- Parámetro para el nombre del tipo de documento
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IDTipoDocumento INT;

    -- Buscar el ID del tipo de documento basado en su nombre
    SELECT @IDTipoDocumento = IDtipo_documento
    FROM tipo_documento
    WHERE descripcion = @NombreTipoDocumento;

    -- Devolver el ID del tipo de documento
    SELECT @IDTipoDocumento AS IDTipoDocumento;
END
GO
/****** Object:  StoredProcedure [dbo].[Pa_ObtenerTiposDocumento]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pa_ObtenerTiposDocumento]
AS
BEGIN
    -- Simplemente seleccionamos las opciones que deseamos mostrar en el ComboBox
    -- Asumimos que el IDtipo_documento de "ruc" es 1, "pasaporte" es 2 y "dni" es 3
    -- Puedes ajustar estos valores según la estructura real de tu base de datos

    SELECT IDtipo_documento AS idTipDoc,descripcion AS descrip from tipo_documento
    
END
GO
/****** Object:  StoredProcedure [dbo].[Pa_SeleccionarClientePorID]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pa_SeleccionarClientePorID]
    @ID INT
AS
BEGIN
    SELECT codigo, razon_social, IDtipo_documento , numero_documento   
    FROM cliente
    WHERE id = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[Pa_SeleccionarClientes]    Script Date: 2/04/2024 22:22:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pa_SeleccionarClientes]
AS
BEGIN
    SELECT * FROM cliente;
END
GO
USE [master]
GO
ALTER DATABASE [WinFormsContacts] SET  READ_WRITE 
GO
