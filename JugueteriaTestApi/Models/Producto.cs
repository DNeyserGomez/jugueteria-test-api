using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace JugueteriaTestApi.Models;

public partial class Producto
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("nombre")]
    public string Nombre { get; set; } = null!;
    [JsonProperty("descripcion")]

    public string? Descripcion { get; set; }
    [JsonProperty("edad_minima")]

    public int? EdadMinima { get; set; }
    [JsonProperty("compania")]

    public string Compania { get; set; } = null!;
    [JsonProperty("precio")]


    public decimal? Precio { get; set; }
    [JsonProperty("fecha_registro")]

    public DateTime FechaRegistro { get; set; }
    [JsonProperty("fecha_actualizacion")]


    public DateTime? FechaActualizacion { get; set; }
    [JsonProperty("estatus")]


    public int Estatus { get; set; }
    [JsonProperty("img_url")]

    public string? ImgUrl { get; set; }
}

public class GuardarProductoResponse
{
    [JsonProperty("code")]
    public int Code { get; set; }
    [JsonProperty("mensaje")]
    public string mensaje { get; set; }
}
public partial class GuardarProducto
{
    [JsonProperty("nombre")]
    public string Nombre { get; set; } = null!;
    [JsonProperty("descripcion")]
    public string? Descripcion { get; set; }
    [JsonProperty("edad_minima")]
    public int? EdadMinima { get; set; }
    [JsonProperty("compania")]
    public string Compania { get; set; } = null!;
    [JsonProperty("precio")]

    public decimal? Precio { get; set; }
    [JsonProperty("fecha_registro")]
    public string? ImgUrl { get; set; }

    public GuardarProducto()
    {
        Descripcion = string.Empty;
    }
}

public class ActualizarProducto: GuardarProducto
{
    [JsonProperty("id")]
    public int Id { get; set; }
}