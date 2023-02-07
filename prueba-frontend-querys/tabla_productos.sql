CREATE DATABASE Prueba;
use Prueba
go
CREATE TABLE [dbo].[Productos](
[Id] [int] IDENTITY(1,1) NOT NULL,
[Nombre] [varchar](50) NOT NULL,
[Descripcion] [varchar](100) NULL,
[EdadMinima] [int] NULL,
[Compania] [varchar](50) NOT NULL,
[Precio] [Decimal](18, 2) NOT NULL,
[FechaRegistro] [datetime] NOT NULL,
[FechaActualizacion] [datetime] NULL,
[Estatus] [int] NOT NULL,
[ImgUrl][varchar](500) NULL
PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO