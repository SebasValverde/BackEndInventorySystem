using Atributos;
using Negocio;
using Negocio.Reporteria;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIProyecto.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiPedidoController : ApiController
    {
        [Route("api/ApiPedido/InsertarPedido")]
        [HttpPost]
        public IHttpActionResult InsertarPedido([FromBody] Pedido ParametroPedido)
        {
            NegPedido Pedido = new NegPedido();
            return Ok(Pedido.Insertar(ParametroPedido));
        }

        [Route("api/ApiPedido/ConsultaPedidoxID")]
        [HttpGet]
        public IHttpActionResult ConsultaPedidoxID(string ID_Pedido)
        {
            NegPedido Pedido = new NegPedido();
            return Ok(Pedido.ConsultaPedido(ID_Pedido));
        }

        [Route("api/ApiPedido/ConsultaPedidosClienteEmpleado")]
        [HttpGet]
        public IHttpActionResult ConsultaPedidosClienteEmpleado(string Nombre_Cliente = null, string Nombre_Empleado = null)
        {
            Nombre_Cliente = Nombre_Cliente ?? "";
            Nombre_Empleado = Nombre_Empleado ?? "";

            NegPedido Pedido = new NegPedido();
            return Ok(Pedido.ConsultaPedidosClienteEmpleado(Nombre_Cliente, Nombre_Empleado));
        }

        [Route("api/ApiPedido/ModificarPedido")]
        [HttpPatch]
        public IHttpActionResult ModificarPedido([FromBody] Pedido ParametroPedido)
        {
            NegPedido Pedido = new NegPedido();
            return Ok(Pedido.ModificarPedido(ParametroPedido));
        }

        [Route("api/ApiPedido/ModificarMontoTotalPedido")]
        [HttpPatch]
        public IHttpActionResult ModificarMontoTotalPedido(string ID_Pedido, string MontoTotal)
        {
            NegPedido Pedido = new NegPedido();
            return Ok(Pedido.ModificarMontoTotalPedido(ID_Pedido, MontoTotal));
        }

        [Route("api/ApiPedido/EliminarPedido")]
        [HttpDelete]
        public IHttpActionResult EliminarPedido(string ID_Pedido)
        {
            NegPedido Pedido = new NegPedido();
            return Ok(Pedido.Eliminar(ID_Pedido));
        }

        [Route("api/ApiPedido/ReporterPedidos")]
        [HttpGet]
        public IHttpActionResult ReporterPedidos(string Nombre_Cliente = null, string Nombre_Empleado = null)
        {
            Nombre_Cliente = Nombre_Cliente ?? "";
            Nombre_Empleado = Nombre_Empleado ?? "";

            Impresiones P = new Impresiones();
            return Ok(P.ImprimirReportePedidos(Nombre_Cliente, Nombre_Empleado));
        }
    }
}
