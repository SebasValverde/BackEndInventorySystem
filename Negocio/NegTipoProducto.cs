using Atributos;
using DataAccess.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegTipoProducto
    {
        public MensajeRespuesta InsertarTipoProducto(TipoProducto pTipoProducto)
        {
            try
            {              
                if (String.IsNullOrEmpty(pTipoProducto.Descripcion))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Descripcion Incorrecta" };
                }

                TipoProductoDB TipoProductoRespuesta = new TipoProductoDB();
                return TipoProductoRespuesta.InsertarTipoProducto(pTipoProducto);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al ingresar nuevo Tipo Producto" };
            }
        }

        public MensajeRespuesta ConsultaTipoProductoxID(int ID_TipoProducto)
        {
            try
            {
                if (ID_TipoProducto < 0)
                {
                    return new MensajeRespuesta { Codigo = -2, Mensaje = "El Id de Tipo Producto debe ser mayor a 0" };
                }
                TipoProductoDB TipoProductoRespuesta = new TipoProductoDB();
                return TipoProductoRespuesta.ConsultaTipoProductoxID(ID_TipoProducto);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Tipo Producto por ID" };
            }
        }

        public MensajeRespuesta ConsultaTipoPNombre(string Categoria)
        {
            try
            {
                TipoProductoDB TipoProductoRespuesta = new TipoProductoDB();
                return TipoProductoRespuesta.ConsultaTipoPNombre(Categoria);
            }
            catch (Exception)
            {

                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al consultar Tipo Producto por ID" };
            }
        }

        public MensajeRespuesta ModificarTipoProducto(TipoProducto pTipoProducto)
        {
            try
            {
                if (String.IsNullOrEmpty(pTipoProducto.ID_TipoProducto.ToString()) || pTipoProducto.ID_TipoProducto == 0)
                {
                    return new MensajeRespuesta { Codigo = -3, Mensaje = "ID Tipo Producto Incorrecto" };
                }
                if (String.IsNullOrEmpty(pTipoProducto.Descripcion))
                {
                    return new MensajeRespuesta { Codigo = -14, Mensaje = "Descripcion Incorrecta" };
                }

                TipoProductoDB TipoProductoRespuesta = new TipoProductoDB();
                return TipoProductoRespuesta.ModificarTipoProducto(pTipoProducto);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al modificar Tipo Producto" };
            }
        }

        public MensajeRespuesta EliminarTipoProducto(int ID_TipoProducto)
        {
            try
            {
                if (ID_TipoProducto < 0)
                {
                    return new MensajeRespuesta { Codigo = -12, Mensaje = "El Id de Tipo Producto debe ser mayor a 0" };
                }
                TipoProductoDB TipoProductoRespuesta = new TipoProductoDB();
                return TipoProductoRespuesta.EliminarTipoProducto(ID_TipoProducto);
            }
            catch (Exception)
            {
                return new MensajeRespuesta { Codigo = -13, Mensaje = "Error desconocido al eliminar TipoProducto" };
            }
        }

    }
}
