using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributos
{
    public class Producto
    {
        public int ID_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Descripcion { get; set; }
        public int ID_TipoProducto { get; set; }
        public DateTime? Fecha_Caducidad { get; set; }
        public int ID_Proveedor { get; set; }
        public int CostoUnitario { get; set; }

    }
}
