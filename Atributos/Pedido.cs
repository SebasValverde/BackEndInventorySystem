using System;

namespace Atributos
{
    public class Pedido
    {
        public int ID_Pedido { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Empleado { get; set; }
        public bool Estado_Orden { get; set; }
        public DateTime Fecha_Envio { get; set; }
        public int MontoTotal { get; set; }

    }
}
