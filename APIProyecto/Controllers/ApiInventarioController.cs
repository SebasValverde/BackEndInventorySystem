using Atributos;
using Negocio;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIProyecto.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiInventarioController : ApiController
    {
        [Route("api/ApiInventario/ConsultaInventarioxSucursalProducto")]
        [HttpGet]
        public IHttpActionResult ConsultaInventarioxSucursalProducto(string ID_Sucursal = null, string Nombre_Producto = null)
        {
            NegInventario Inventario = new NegInventario();
            return Ok(Inventario.ConsultaInventarioxSucursalProducto(ID_Sucursal, Nombre_Producto));
        }

        [Route("api/ApiInventario/ConsultaInventario")]
        [HttpGet]
        public IHttpActionResult ConsultaInventario(string ID_Inventario)
        {
            NegInventario Inventario = new NegInventario();

            // Convertir el ID_Inventario de string a int?
            int? idInventario = null;
            if (!string.IsNullOrEmpty(ID_Inventario) && int.TryParse(ID_Inventario, out int tempId))
            {
                idInventario = tempId;
            }

            // Pasar el ID_Inventario como string al método ConsultaInventario
            return Ok(Inventario.ConsultaInventario(ID_Inventario));
        }

        [Route("api/ApiInventario/ModificarInventarioAgregar")]
        [HttpPatch]
        public IHttpActionResult ModificarInventarioAgregar(string ID_Sucursal, string ID_Producto, string CantidadPorAgregar)
        {
            NegInventario Inventario = new NegInventario();
            return Ok(Inventario.ModificarInventarioAgregar(ID_Sucursal, ID_Producto, CantidadPorAgregar));
        }

        [Route("api/ApiInventario/ModificarInventarioRestar")]
        [HttpPatch]
        public IHttpActionResult ModificarInventarioRestar(string ID_Sucursal, string ID_Producto, string CantidadPorEliminar)
        {
            NegInventario Inventario = new NegInventario();
            return Ok(Inventario.ModificarInventarioRestar(ID_Sucursal, ID_Producto, CantidadPorEliminar));
        }

        [Route("api/ApiInventario/NuevoInventario")]
        [HttpPost]
        public IHttpActionResult NuevoInventario([FromBody] Inventario iInventario)
        {
            NegInventario Inventario = new NegInventario();
            return Ok(Inventario.InsertarInventario(iInventario));
        }

        [Route("api/ApiInventario/ConsultaInventarioxSucursal")]
        [HttpGet]
        public IHttpActionResult ConsultaInventarioxSucursal(string ID_Sucursal = null)
        {
            ID_Sucursal = ID_Sucursal ?? "";

            NegInventario Inventario = new NegInventario();
            return Ok(Inventario.ConsultaInventarioxSucursal(ID_Sucursal));
        }

        [Route("api/ApiInventario/EliminarInventario")]
        [HttpPatch]
        public IHttpActionResult EliminarInventario(string ID_Inventario)
        {
            NegInventario Inventario = new NegInventario();
            return Ok(Inventario.EliminarInventario(ID_Inventario));
        }

    }
}
