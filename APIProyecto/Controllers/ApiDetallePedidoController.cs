using Atributos;
using Negocio;
using Negocio.Reporteria;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIProyecto.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiDetallePedidoController : ApiController
    {
        [Route("api/ApiDetallePedido/InsertarDetallePedido")]
        [HttpPost]
        public IHttpActionResult InsertarDetallePedido([FromBody] DetallePedido ParametroDetallePedido)
        {
            NegDetallePedido DetallePedido = new NegDetallePedido();
            return Ok(DetallePedido.Insertar(ParametroDetallePedido));
        }

        [Route("api/ApiDetallePedido/ConsultaDetallesPedidoxPedido")]
        [HttpGet]
        public IHttpActionResult ConsultaDetallesPedidoxPedido(string ID_Pedido)
        {
            NegDetallePedido DetallePedido = new NegDetallePedido();
            return Ok(DetallePedido.ConsultaDetallesPedidoxPedido(ID_Pedido));
        }

        [Route("api/ApiDetallePedido/ConsultaDetallePedidoxID")]
        [HttpGet]
        public IHttpActionResult ConsultaDetallePedidoxID(string ID_Detalle)
        {
            NegDetallePedido DetallePedido = new NegDetallePedido();
            return Ok(DetallePedido.ConsultaDetallePedidoxID(ID_Detalle));
        }

        [Route("api/ApiDetallePedido/ConsultaDetallesPedidoProductoSucursal")]
        [HttpGet]
        public IHttpActionResult ConsultaDetallesPedidoProductoSucursal(string ID_Pedido = null, string Nombre_Producto = null, string Nombre_Sucursal = null)
        {
            ID_Pedido = ID_Pedido ?? "";
            Nombre_Producto = Nombre_Producto ?? "";
            Nombre_Sucursal = Nombre_Sucursal ?? "";

            NegDetallePedido DetallePedido = new NegDetallePedido();
            return Ok(DetallePedido.ConsultaDetallesPedidoProductoSucursal(ID_Pedido, Nombre_Producto, Nombre_Sucursal));
        }

        [Route("api/ApiDetallePedido/ModificarDetallePedido")]
        [HttpPatch]
        public IHttpActionResult ModificarDetallePedido(string ID_Detalle, string Cantidad, string Monto)
        {
            NegDetallePedido DetallePedido = new NegDetallePedido();
            return Ok(DetallePedido.ModificarDetallePedido(ID_Detalle, Cantidad, Monto));
        }

        [Route("api/ApiDetallePedido/EliminarDetallePedido")]
        [HttpDelete]
        public IHttpActionResult EliminarDetallePedido(string ID_Detalle)
        {
            NegDetallePedido DetallePedido = new NegDetallePedido();
            return Ok(DetallePedido.Eliminar(ID_Detalle));
        }

        [Route("api/ApiDetallePedido/ReporteDetallePedido")]
        [HttpGet]
        public IHttpActionResult ReporteDetallePedido(string ID_Pedido = null, string Nombre_Producto = null, string Nombre_Sucursal = null)
        {
            ID_Pedido = ID_Pedido ?? "";
            Nombre_Producto = Nombre_Producto ?? "";
            Nombre_Sucursal = Nombre_Sucursal ?? "";

            Impresiones P = new Impresiones();
            return Ok(P.ImprimirReporteDetallePedido(ID_Pedido, Nombre_Producto, Nombre_Sucursal));
        }
    }
}
