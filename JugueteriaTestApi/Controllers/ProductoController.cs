using JugueteriaTestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JugueteriaTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private string connectionString;
        public ProductoController(IConfiguration configuration)
        {
            connectionString =  configuration.GetConnectionString("PruebaDB");
        }
        // GET: ProductoController
        [HttpGet]
        [Route("obtener-producto")]

        public ActionResult<IEnumerable<Producto>> GetProducto()
        {
            var productos  = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ObtenerProductos", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        productos.Add(new Producto() { 
                            Id = int.Parse(reader["Id"].ToString()!),
                            Nombre = reader["Nombre"].ToString()!,
                            Descripcion =   String.IsNullOrEmpty(reader["Descripcion"].ToString()) ? null: reader["Descripcion"].ToString(),
                            EdadMinima = String.IsNullOrEmpty(reader["EdadMinima"].ToString()) ? null : int.Parse(reader["EdadMinima"].ToString()!),
                            Compania = reader["Compania"].ToString()!,
                            Precio = decimal.Parse(reader["Precio"].ToString()!),
                            FechaRegistro =  DateTime.Parse(reader["FechaRegistro"].ToString()!),
                            FechaActualizacion = String.IsNullOrEmpty(reader["FechaActualizacion"].ToString()) ? null : DateTime.Parse(reader["FechaActualizacion"].ToString()!),
                            Estatus = int.Parse(reader["Estatus"].ToString()!),
                            ImgUrl = reader["ImgUrl"].ToString()!
                        });
                    }
                }
            }
                return productos;
        }

        [HttpPost]
        [Route("guardar-producto")]
        public ActionResult<GuardarProductoResponse> SaveProducto(GuardarProducto producto)
        {
            var resp = new GuardarProductoResponse();
            try
            {
                if (String.IsNullOrEmpty(producto.Nombre)) throw new Exception("Nombre* es un campo requerido");
                if(producto.Nombre.Length > 50) throw new Exception("El nombre debe contener una longitud máxima de 50 caracteres");
                if (!String.IsNullOrEmpty(producto.Descripcion) && producto.Descripcion.Length > 100) throw new Exception("La descripción debe contener una longitud máxima de 100 caracteres");
                if (producto.EdadMinima < 0 || producto.EdadMinima > 18) throw new Exception("La edad debe estar en el rango de 0  a 18 años");
                if (String.IsNullOrEmpty(producto.Compania)) throw new Exception("Compañía* es un campo requerido");
                if (producto.Compania.Length > 50) throw new Exception("La Compañía debe contener una longitud máxima de 50 caracteres");
                if (producto.Precio < 1 && producto.Precio > 1000) throw new Exception("El precio debe estar en el rango de 0 a 1000");


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Producto_Insertar_Actualizar_Eliminar", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@pNombre", producto.Nombre);
                        command.Parameters.AddWithValue("@pDescripcion", producto.Descripcion);
                        command.Parameters.AddWithValue("@pEdadMinima", producto.EdadMinima);
                        command.Parameters.AddWithValue("@pCompania", producto.Compania);
                        command.Parameters.AddWithValue("@pPrecio", producto.Precio);
                        command.Parameters.AddWithValue("@pImgUrl", producto.ImgUrl);
                        command.Parameters.AddWithValue("@pAccion", 1);
                        command.ExecuteReader();
                    }
                }
                resp.Code = 200;
                resp.mensaje = "Producto guardado correctamente";
                return resp;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [HttpPost]
        [Route("actualizar-producto")]
        public ActionResult<GuardarProductoResponse> ActualizarProducto(ActualizarProducto producto)
        {
            var resp = new GuardarProductoResponse();
            try
            {
                if (producto.Id <= 0) throw new Exception("Id* es un campo requerido");
                if (String.IsNullOrEmpty(producto.Nombre)) throw new Exception("Nombre* es un campo requerido");
                if (producto.Nombre.Length > 50) throw new Exception("El nombre debe contener una longitud máxima de 50 caracteres");
                if (!String.IsNullOrEmpty(producto.Descripcion) && producto.Descripcion.Length > 100) throw new Exception("La descripción debe contener una longitud máxima de 100 caracteres");
                if (producto.EdadMinima < 0 || producto.EdadMinima > 18) throw new Exception("La edad debe estar en el rango de 0  a 18 años");
                if (String.IsNullOrEmpty(producto.Compania)) throw new Exception("Compañía* es un campo requerido");
                if (producto.Compania.Length > 50) throw new Exception("La Compañía debe contener una longitud máxima de 50 caracteres");
                if (producto.Precio < 1 || producto.Precio > 1000) throw new Exception("El precio debe estar en el rango de 0 a 1000");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Producto_Insertar_Actualizar_Eliminar", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@pId", producto.Id);
                        command.Parameters.AddWithValue("@pNombre", producto.Nombre);
                        command.Parameters.AddWithValue("@pDescripcion", producto.Descripcion);
                        command.Parameters.AddWithValue("@pEdadMinima", producto.EdadMinima);
                        command.Parameters.AddWithValue("@pCompania", producto.Compania);
                        command.Parameters.AddWithValue("@pPrecio", producto.Precio);
                        command.Parameters.AddWithValue("@pImgUrl", producto.ImgUrl);
                        command.Parameters.AddWithValue("@pAccion", 2);
                        command.ExecuteReader();
                    }
                }
                resp.Code = 200;
                resp.mensaje = "Producto actualizado correctamente";
                return resp;
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        [Route("eliminar-producto")]
        public ActionResult<GuardarProductoResponse> EliminarProducto(int idProducto)
        {
            var resp = new GuardarProductoResponse();
            try
            {
                if (idProducto <= 0) throw new Exception("Id* es un campo requerido");
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("Producto_Insertar_Actualizar_Eliminar", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@pId", idProducto);
                        command.Parameters.AddWithValue("@pAccion", 3);
                        command.ExecuteReader();
                    }
                }
                resp.Code = 200;
                resp.mensaje = "Producto eliminado correctamente";
                return resp;
            }
            catch (Exception)
            {

                throw;
            }

        }

        // GET: ProductoController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: ProductoController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: ProductoController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ProductoController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: ProductoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ProductoController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ProductoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
