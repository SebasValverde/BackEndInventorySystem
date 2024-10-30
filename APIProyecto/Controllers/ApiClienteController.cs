using Atributos;
using Negocio;
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
    public class ApiClienteController : ApiController
    {
        [Route("api/ApiCliente/InsertarCliente")]
        [HttpPost]
        public IHttpActionResult InsertarCliente([FromBody] Cliente cCliente)
        {
            NegCliente Cliente = new NegCliente();
            return Ok(Cliente.InsertarCliente(cCliente));
        }

        [Route("api/ApiCliente/ConsultaCliente")]
        [HttpGet]
        public IHttpActionResult ConsultaCliente(string ID_Cliente)
        {
            NegCliente Cliente = new NegCliente();
            return Ok(Cliente.ConsultaCliente(ID_Cliente));
        }

        [Route("api/ApiCliente/ConsultaClientesNombreDireccion")]
        [HttpGet]
        public IHttpActionResult ConsultaClientesNombreDireccion(string Nombre_Cliente = null, string Direccion = null)
        {
            Nombre_Cliente = Nombre_Cliente ?? "";
            Direccion = Direccion ?? "";
            NegCliente Cliente = new NegCliente();
            return Ok(Cliente.ConsultaClientesNombreDireccion(Nombre_Cliente, Direccion));
        }

        [Route("api/ApiCliente/ModificarCliente")]
        [HttpPatch]
        public IHttpActionResult ModificarCliente([FromBody] Cliente cCliente)
        {
            NegCliente Cliente = new NegCliente();
            return Ok(Cliente.ModificarCliente(cCliente));
        }

        [Route("api/ApiCliente/EliminarCliente")]
        [HttpDelete]
        public IHttpActionResult EliminarCliente(int ID_Cliente)
        {
            NegCliente Cliente = new NegCliente();
            return Ok(Cliente.EliminarCliente(ID_Cliente));
        }
    }
}
