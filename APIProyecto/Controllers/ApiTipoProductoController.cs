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
    public class ApiTipoProductoController : ApiController
    {
        [Route("api/ApiTipoProducto/InsertarTipoProducto")]
        [HttpPost]
        public IHttpActionResult InsertarTipoProducto([FromBody] TipoProducto pTipoProducto)
        {
            NegTipoProducto TipoProducto = new NegTipoProducto();
            return Ok(TipoProducto.InsertarTipoProducto(pTipoProducto));
        }

        [Route("api/ApiTipoProducto/ConsultaTipoProductoxID")]
        [HttpGet]
        public IHttpActionResult ConsultaTipoProductoxID(int ID_TipoProducto)
        {
            NegTipoProducto TipoProducto = new NegTipoProducto();
            return Ok(TipoProducto.ConsultaTipoProductoxID(ID_TipoProducto));
        }

        [Route("api/ApiTipoProducto/ConsultaTipoPNombre")]
        [HttpGet]
        public IHttpActionResult ConsultaTipoPNombre(string Categoria)
        {
            NegTipoProducto TipoProducto = new NegTipoProducto();
            return Ok(TipoProducto.ConsultaTipoPNombre(string.IsNullOrEmpty(Categoria) ? "" : Categoria));
        }

        [Route("api/ApiTipoProducto/ModificarTipoProducto")]
        [HttpPatch]
        public IHttpActionResult ModificarTipoProducto([FromBody] TipoProducto pTipoProducto)
        {
            NegTipoProducto TipoProducto = new NegTipoProducto();
            return Ok(TipoProducto.ModificarTipoProducto(pTipoProducto));
        }

        [Route("api/ApiTipoProducto/EliminarTipoProducto")]
        [HttpDelete]
        public IHttpActionResult EliminarTipoProducto(int ID_TipoProducto)
        {
            NegTipoProducto TipoProducto = new NegTipoProducto();
            return Ok(TipoProducto.EliminarTipoProducto(ID_TipoProducto));
        }

        [Route("api/ApiTipoProducto/ReporteCategoria")]
        [HttpGet]
        public IHttpActionResult ReporteCategoria(string Categoria)
        {
            Impresiones P = new Impresiones();
            return Ok(P.ImprimirReporteCategoria(Categoria));
        }
    }
}
