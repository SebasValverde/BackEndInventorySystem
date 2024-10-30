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
    public class ApiEmpleadoController : ApiController
    {
        [Route("api/ApiEmpleado/InsertarEmpleado")]
        [HttpPost]
        public IHttpActionResult InsertarEmpleado([FromBody] Empleado eEmpleado)
        {
            NegEmpleado Empleado = new NegEmpleado();
            return Ok(Empleado.InsertarEmpleado(eEmpleado));
        }

        [Route("api/ApiEmpleado/ConsultaEmpleadosPorNombreCorreo")]
        [HttpGet]
        public IHttpActionResult ConsultaEmpleadosPorNombreCorreo(string Nombre_Empleado, string Correo_Empleado)
        {
            NegEmpleado Empleado = new NegEmpleado();
            return Ok(Empleado.ConsultaEmpleadosPorNombreCorreo(Nombre_Empleado, Correo_Empleado));
        }

        [Route("api/ApiEmpleado/ConsultaEmpleado")]
        [HttpGet]
        public IHttpActionResult ConsultaEmpleado(string ID_Empleado)
        {
            NegEmpleado Empleado = new NegEmpleado();
            return Ok(Empleado.ConsultaEmpleado(ID_Empleado));
        }

        [Route("api/ApiEmpleado/ModificarEmpleado")]
        [HttpPatch]
        public IHttpActionResult ModificarEmpleado([FromBody] Empleado eEmpleado)
        {
            NegEmpleado Empleado = new NegEmpleado();
            return Ok(Empleado.ModificarEmpleado(eEmpleado));
        }

        [Route("api/ApiEmpleado/EliminarEmpleado")]
        [HttpDelete]
        public IHttpActionResult EliminarEmpleado(int ID_Empleado)
        {
            NegEmpleado Empleado = new NegEmpleado();
            return Ok(Empleado.EliminarEmpleado(ID_Empleado));
        }


    }
}
