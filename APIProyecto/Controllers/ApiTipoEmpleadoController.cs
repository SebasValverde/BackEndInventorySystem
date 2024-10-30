using Atributos;
using Negocio;
using Negocio.Reporteria;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIProyecto.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiTipoEmpleadoController : ApiController
    {
        [Route("api/ApiTipoEmpleado/InsertarTipoEmpleado")]
        [HttpPost]
        public IHttpActionResult InsertarTipoEmpleado([FromBody] TipoEmpleado ParametroTipoEmpleado)
        {
            NegTipoEmpleado TipoEmpleado = new NegTipoEmpleado();
            return Ok(TipoEmpleado.InsertarTipoEmpleado(ParametroTipoEmpleado));
        }

        [Route("api/ApiTipoEmpleado/ConsultaTipoEmpleado")]
        [HttpGet]
        public IHttpActionResult ConsultaTipoEmpleado(string ID_TipoEmpleado)
        {
            NegTipoEmpleado TipoEmpleado = new NegTipoEmpleado();
            return Ok(TipoEmpleado.ConsultaTipoEmpleado(ID_TipoEmpleado));
        }

        [Route("api/ApiTipoEmpleado/ConsultaTipoEmpleadoxDescripcion")]
        [HttpGet]
        public IHttpActionResult ConsultaTipoEmpleadoxDescripcion(string Descripcion = null)
        {
            Descripcion = Descripcion ?? "";

            NegTipoEmpleado TipoEmpleado = new NegTipoEmpleado();
            return Ok(TipoEmpleado.ConsultaTipoEmpleadoxDescripcion(Descripcion));
        }

        [Route("api/ApiTipoEmpleado/ModificarTipoEmpleado")]
        [HttpPatch]
        public IHttpActionResult ModificarTipoEmpleado([FromBody] TipoEmpleado ParametroTipoEmpleado)
        {
            NegTipoEmpleado TipoEmpleado = new NegTipoEmpleado();
            return Ok(TipoEmpleado.ModificarTipoEmpleado(ParametroTipoEmpleado));
        }

        [Route("api/ApiTipoEmpleado/EliminarTipoEmpleado")]
        [HttpDelete]
        public IHttpActionResult EliminarTipoEmpleado(string ID_TipoEmpleado)
        {
            NegTipoEmpleado TipoEmpleado = new NegTipoEmpleado();
            return Ok(TipoEmpleado.Eliminar(ID_TipoEmpleado));
        }

        [Route("api/ApiTipoEmpleado/ReporteTiposEmpleado")]
        [HttpGet]
        public IHttpActionResult ReporteTiposEmpleado(string Descripcion = null)
        {
            Descripcion = Descripcion ?? "";

            Impresiones P = new Impresiones();
            return Ok(P.ImprimirReporteTiposEmpleado(Descripcion));
        }
    }
}
