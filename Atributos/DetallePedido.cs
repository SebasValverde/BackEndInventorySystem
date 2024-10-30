
namespace Atributos
{
    public class DetallePedido
    {
        public int ID_Detalle { get; set; }
        public int ID_Pedido { get; set; }
        public int Cantidad { get; set; }
        public int ID_Producto { get; set; }
        public int ID_Sucursal { get; set; }
        public int Monto { get; set; }
    }
}
