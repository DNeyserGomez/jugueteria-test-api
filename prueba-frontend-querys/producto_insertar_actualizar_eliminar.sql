USE Prueba
Go

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.Producto_Insertar_Actualizar_Eliminar
	-- Add the parameters for the stored procedure here
	@pId int = null,
	@pNombre varchar(50) = null,
	@pDescripcion varchar(100) = null,
	@pEdadMinima int = null,
	@pCompania varchar(50) = null,
	@pPrecio decimal (18,2) = null,
	--@pFechaRegistro datetime = null,
	--@pFechaActualizacion datetime = null,
	--@pEstatus int = null,
	@pImgUrl varchar(500) = null,
	@pAccion int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if @pAccion not in(1,2,3)
		begin
			RAISERROR('La acción que intentas realizar no es válida',1,1)
		end

	--1  = Insertar
	--2 = Actualizar
	--3 = Eliminar (Cambio de estatus)

	if @pAccion = 1
		begin
			insert into dbo.Productos select @pNombre, @pDescripcion, @pEdadMinima, @pCompania, @pPrecio, getdate(), null, 1, @pImgUrl
		end
	else if @pAccion = 2
		begin
			update dbo.Productos set Nombre = @pNombre, Descripcion = @pDescripcion, EdadMinima = @pEdadMinima, Compania = @pCompania,
					Precio = @pPrecio, FechaActualizacion = getdate(), ImgUrl = @pImgUrl
			where Id = @pId
		end
	else
		begin
			update dbo.Productos set Estatus = 0 where Id = @pId 
		end
END
GO
