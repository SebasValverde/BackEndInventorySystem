using Atributos;
using Negocio;
using Negocio.Reporteria;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIProyecto.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiSucursalesController : ApiController
    {
        [Route("api/ApiSucursal/InsertarSucursal")]
        [HttpPost]
        public IHttpActionResult InsertarSucursal([FromBody] Sucursal ParametroSucursal)
        {
            NegSucursal Sucursal = new NegSucursal();
            return Ok(Sucursal.Insertar(ParametroSucursal));
        }

        [Route("api/ApiSucursal/ConsultaSucursalxID")]
        [HttpGet]
        public IHttpActionResult ConsultaSucursalxID(string ID_Sucursal)
        {
            NegSucursal Sucursal = new NegSucursal();
            return Ok(Sucursal.ConsultaSucursal(ID_Sucursal));
        }

        [Route("api/ApiSucursal/ConsultaSucursalesNombreDescripcion")]
        [HttpGet]
        public IHttpActionResult ConsultaSucursalesNombreDescripcion(string Nombre_Sucursal = null, string Descripcion = null)
        {
            Nombre_Sucursal = Nombre_Sucursal ?? "";
            Descripcion = Descripcion ?? "";

            NegSucursal Sucursal = new NegSucursal();
            return Ok(Sucursal.ConsultaSucursalesNombreDescripcion(Nombre_Sucursal, Descripcion));
        }

        [Route("api/ApiSucursal/ModificarSucursal")]
        [HttpPatch]
        public IHttpActionResult ModificarSucursal([FromBody] Sucursal ParametroSucursal)
        {
            NegSucursal Sucursal = new NegSucursal();
            return Ok(Sucursal.ModificarSucursal(ParametroSucursal));
        }

        [Route("api/ApiSucursal/EliminarSucursal")]
        [HttpDelete]
        public IHttpActionResult EliminarSucursal(string ID_Sucursal)
        {
            NegSucursal Sucursal = new NegSucursal();
            return Ok(Sucursal.Eliminar(ID_Sucursal));
        }

        [Route("api/ApiSucursal/ReporteSucursales")]
        [HttpGet]
        public IHttpActionResult ReporteSucursales(string Nombre_Sucursal = null, string Descripcion = null)
        {
            Nombre_Sucursal = Nombre_Sucursal ?? "";
            Descripcion = Descripcion ?? "";

            Impresiones P = new Impresiones();
            return Ok(P.ImprimirReporteSucursales(Nombre_Sucursal, Descripcion));
        }
    }
}
