USE [master]
GO
/****** Object:  Database [NilveraDb]    Script Date: 27.05.2025 23:40:56 ******/
CREATE DATABASE [NilveraDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NilveraDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NilveraDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NilveraDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\NilveraDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [NilveraDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NilveraDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NilveraDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NilveraDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NilveraDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NilveraDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NilveraDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [NilveraDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NilveraDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NilveraDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NilveraDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NilveraDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NilveraDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NilveraDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NilveraDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NilveraDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NilveraDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NilveraDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NilveraDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NilveraDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NilveraDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NilveraDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NilveraDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NilveraDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NilveraDb] SET RECOVERY FULL 
GO
ALTER DATABASE [NilveraDb] SET  MULTI_USER 
GO
ALTER DATABASE [NilveraDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NilveraDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NilveraDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NilveraDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NilveraDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NilveraDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NilveraDb', N'ON'
GO
ALTER DATABASE [NilveraDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [NilveraDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [NilveraDb]
GO
/****** Object:  Table [dbo].[Firma]    Script Date: 27.05.2025 23:40:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirmaAdi] [nvarchar](100) NULL,
	[VknTc] [nvarchar](20) NULL,
	[KullaniciAdi] [nvarchar](50) NULL,
	[AktifMi] [bit] NULL,
	[Adres] [nvarchar](250) NULL,
	[Ilce] [nvarchar](50) NULL,
	[Sehir] [nvarchar](50) NULL,
	[Ulke] [nvarchar](50) NULL,
	[PostaKodu] [nvarchar](20) NULL,
	[Telefon] [nvarchar](30) NULL,
	[Faks] [nvarchar](30) NULL,
	[WebSitesi] [nvarchar](100) NULL,
	[Eposta] [nvarchar](100) NULL,
	[VergiDairesi] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteFirma]    Script Date: 27.05.2025 23:40:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteFirma]
    @Id INT
AS
BEGIN
    DELETE FROM Firma WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllFirmas]    Script Date: 27.05.2025 23:40:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllFirmas]
AS
BEGIN
    SELECT * FROM Firma;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetFirmaById]    Script Date: 27.05.2025 23:40:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetFirmaById]
    @Id INT
AS
BEGIN
    SELECT * FROM Firma WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertFirma]    Script Date: 27.05.2025 23:40:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE PROCEDURE [dbo].[sp_InsertFirma]
    @FirmaAdi NVARCHAR(100),
    @VknTc NVARCHAR(20),
    @KullaniciAdi NVARCHAR(50),
    @AktifMi BIT,
    @Adres NVARCHAR(250),
    @Ilce NVARCHAR(50),
    @Sehir NVARCHAR(50),
    @Ulke NVARCHAR(50),
    @PostaKodu NVARCHAR(20),
    @Telefon NVARCHAR(30),
    @Faks NVARCHAR(30),
    @WebSitesi NVARCHAR(100),
    @Eposta NVARCHAR(100),
    @VergiDairesi NVARCHAR(100),
    @NewId INT OUTPUT
AS
BEGIN
    INSERT INTO Firma (FirmaAdi, VknTc, KullaniciAdi, AktifMi, Adres, Ilce, Sehir, Ulke, PostaKodu, Telefon, Faks, WebSitesi, Eposta, VergiDairesi)
    VALUES (@FirmaAdi, @VknTc, @KullaniciAdi, @AktifMi, @Adres, @Ilce, @Sehir, @Ulke, @PostaKodu, @Telefon, @Faks, @WebSitesi, @Eposta, @VergiDairesi);

    SET @NewId = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateFirma]    Script Date: 27.05.2025 23:40:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_UpdateFirma]
    @Id INT,
    @FirmaAdi NVARCHAR(100),
    @VknTc NVARCHAR(20),
    @KullaniciAdi NVARCHAR(50),
    @AktifMi BIT,
    @Adres NVARCHAR(250),
    @Ilce NVARCHAR(50),
    @Sehir NVARCHAR(50),
    @Ulke NVARCHAR(50),
    @PostaKodu NVARCHAR(20),
    @Telefon NVARCHAR(30),
    @Faks NVARCHAR(30),
    @WebSitesi NVARCHAR(100),
    @Eposta NVARCHAR(100),
    @VergiDairesi NVARCHAR(100)
AS
BEGIN
    UPDATE Firma
    SET
        FirmaAdi = @FirmaAdi,
        VknTc = @VknTc,
        KullaniciAdi = @KullaniciAdi,
        AktifMi = @AktifMi,
        Adres = @Adres,
        Ilce = @Ilce,
        Sehir = @Sehir,
        Ulke = @Ulke,
        PostaKodu = @PostaKodu,
        Telefon = @Telefon,
        Faks = @Faks,
        WebSitesi = @WebSitesi,
        Eposta = @Eposta,
        VergiDairesi = @VergiDairesi
    WHERE Id = @Id;
END
GO
USE [master]
GO
ALTER DATABASE [NilveraDb] SET  READ_WRITE 
GO
