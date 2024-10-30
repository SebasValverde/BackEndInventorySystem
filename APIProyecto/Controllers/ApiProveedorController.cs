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
    public class ApiProveedorController : ApiController
    {
        [Route("api/ApiProveedor/InsertarProveedor")]
        [HttpPost]
        public IHttpActionResult InsertarProveedor([FromBody] Proveedor pProveedor)
        {
            NegProveedor Proveedor = new NegProveedor();
            return Ok(Proveedor.InsertarProveedor(pProveedor));
        }

        [Route("api/ApiProveedor/ConsultaProveedor")]
        [HttpGet]
        public IHttpActionResult ConsultaProveedor(int ID_Proveedor)
        {
            NegProveedor Proveedor = new NegProveedor();
            return Ok(Proveedor.ConsultaProveedor(ID_Proveedor));
        }

        [Route("api/ApiProveedor/ConsultaProveedorNombre")]
        [HttpGet]
        public IHttpActionResult ConsultaProveedorNombre(string nombre)
        {
            NegProveedor Proveedor = new NegProveedor();
            return Ok(Proveedor.ConsultaProveedorNombre(nombre));
        }

        [Route("api/ApiProveedor/ModificarProveedor")]
        [HttpPatch]
        public IHttpActionResult ModificarProveedor([FromBody] Proveedor pProveedor)
        {
            NegProveedor Proveedor = new NegProveedor();
            return Ok(Proveedor.ModificarProveedor(pProveedor));
        }

        [Route("api/ApiProveedor/EliminarProveedor")]
        [HttpDelete]
        public IHttpActionResult EliminarProveedor(int ID_Proveedor)
        {
            NegProveedor Proveedor = new NegProveedor();
            return Ok(Proveedor.EliminarProveedor(ID_Proveedor));
        }

        [Route("api/ApiProveedor/ImprimirReporteProveedor")]
        [HttpGet]
        public IHttpActionResult ImprimirReporteProveedor(string Nombre)
        {
            Impresiones P = new Impresiones();
            return Ok(P.ImprimirReporteProveedor(Nombre));
        }
    }
}
