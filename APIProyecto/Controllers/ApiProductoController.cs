using Atributos;
using Negocio;
using Negocio.Reporteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIProyecto.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiProductoController : ApiController
    {
        [Route("api/ApiProducto/InsertarProducto")]
        [HttpPost]
        public IHttpActionResult InsertarProducto([FromBody] Producto pProducto)
        {
            NegProducto Producto = new NegProducto();
            return Ok(Producto.InsertarProducto(pProducto));
        }

        [Route("api/ApiProducto/ConsultaProducto")]
        [HttpGet]
        public IHttpActionResult ConsultaProducto(int ID_Producto)
        {
            NegProducto Producto = new NegProducto();
            return Ok(Producto.ConsultaProducto(ID_Producto));
        }

        [Route("api/ApiProducto/ConsultaProductoNombreTipo")]
        [HttpGet]
        public IHttpActionResult ConsultaProductoNombreTipo(string NombreProducto, string Categoria)
        {
            NegProducto Producto = new NegProducto();
            return Ok(Producto.ConsultaProductoNombreTipo(NombreProducto, Categoria));
        }

        [Route("api/ApiProducto/ModificarProducto")]
        [HttpPatch]
        public IHttpActionResult ModificarProducto([FromBody] Producto pProducto)
        {
            NegProducto Producto = new NegProducto();
            return Ok(Producto.ModificarProducto(pProducto));
        }

        [Route("api/ApiProducto/EliminarProducto")]
        [HttpDelete]
        public IHttpActionResult EliminarProducto(int ID_Producto)
        {
            NegProducto Producto = new NegProducto();
            return Ok(Producto.EliminarProducto(ID_Producto));
        }

        [Route("api/ApiProducto/ReporteProducto")]
        [HttpGet]
        public IHttpActionResult ReporteProducto(string Nombre_Producto, string Categoria)
        {
            Impresiones P = new Impresiones();
            return Ok(P.ImprimirReporteProducto(Nombre_Producto, Categoria));
        }
    }
}
