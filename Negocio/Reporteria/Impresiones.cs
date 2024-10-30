using Atributos;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Negocio.Reporteria
{
    public class Impresiones
    {
        public void conectar_reporte(ref ReportDocument Reporte)
        {
            // Leer la cadena de conexión desde web.config
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var builder = new SqlConnectionStringBuilder(connectionString);

            TableLogOnInfo conn = new TableLogOnInfo();
            foreach (Table table in Reporte.Database.Tables)
            {
                conn.ConnectionInfo.ServerName = builder.DataSource;
                conn.ConnectionInfo.DatabaseName = builder.InitialCatalog;
                conn.ConnectionInfo.UserID = builder.UserID;
                conn.ConnectionInfo.Password = builder.Password;

                table.ApplyLogOnInfo(conn);
            }
        }

        public MensajeRespuesta ImprimirReporteSucursales(string Nombre_Sucursal, string Descripcion)
        {
            MensajeRespuesta R = new MensajeRespuesta();
            ReportDocument Reporte = new ReportDocument();
            try
            {
                Reporte = new ReporteSucursales();
                Reporte.SetParameterValue(0, Nombre_Sucursal);
                Reporte.SetParameterValue(1, Descripcion);
                conectar_reporte(ref Reporte);
                Stream reportStream = Reporte.ExportToStream(ExportFormatType.PortableDocFormat);
                byte[] pdfbytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    reportStream.CopyTo(memoryStream);
                    pdfbytes = memoryStream.ToArray();
                }
                R.Contenido = Convert.ToBase64String(pdfbytes);
                R.Codigo = 0;
                R.Mensaje = "Reporte de Sucursales creado exitosamente";
            }
            catch (Exception ex)
            {
                R.Codigo = -23;
                R.Mensaje = $"Se generó un error al crear el Reporte de Sucursales: {ex.Message}";
            }
            finally
            {
                Reporte.Dispose();
                Reporte.Close();
            }
            return R;
        }

        public MensajeRespuesta ImprimirReporteCategoria(string Categoria)
        {
            MensajeRespuesta R = new MensajeRespuesta();
            ReportDocument Reporte = new ReportDocument();
            try
            {
                Reporte = new ReporteCategoria();
                Reporte.SetParameterValue(0, Categoria);
                conectar_reporte(ref Reporte);
                Stream reportStream = Reporte.ExportToStream(ExportFormatType.PortableDocFormat);
                byte[] pdfbytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    reportStream.CopyTo(memoryStream);
                    pdfbytes = memoryStream.ToArray();
                }
                R.Contenido = Convert.ToBase64String(pdfbytes);
                R.Codigo = 0;
                R.Mensaje = "Reporte de Categorias creado exitosamente";
            }
            catch (Exception ex)
            {
                R.Codigo = -23;
                R.Mensaje = $"Se generó un error al crear el Reporte de Categorias: {ex.Message}";
            }
            finally
            {
                Reporte.Dispose();
                Reporte.Close();
            }
            return R;
        }

        public MensajeRespuesta ImprimirReporteProveedor(string Nombre)
        {
            MensajeRespuesta R = new MensajeRespuesta();
            ReportDocument Reporte = new ReportDocument();
            try
            {
                Reporte = new ReporteProveedor();
                Reporte.SetParameterValue(0, Nombre);
                conectar_reporte(ref Reporte);
                Stream reportStream = Reporte.ExportToStream(ExportFormatType.PortableDocFormat);
                byte[] pdfbytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    reportStream.CopyTo(memoryStream);
                    pdfbytes = memoryStream.ToArray();
                }
                R.Contenido = Convert.ToBase64String(pdfbytes);
                R.Codigo = 0;
                R.Mensaje = "Reporte de Proveedores creado exitosamente";
            }
            catch (Exception ex)
            {
                R.Codigo = -23;
                R.Mensaje = $"Se generó un error al crear el Reporte de Proveedores: {ex.Message}";
            }
            finally
            {
                Reporte.Dispose();
                Reporte.Close();
            }
            return R;
        }

        public MensajeRespuesta ImprimirReporteProducto(string Nombre_Producto, string Categoria)
        {
            MensajeRespuesta R = new MensajeRespuesta();
            ReportDocument Reporte = new ReportDocument();
            try
            {
                Reporte = new ReporteProducto();
                Reporte.SetParameterValue(0, Nombre_Producto);
                Reporte.SetParameterValue(1, Categoria);
                conectar_reporte(ref Reporte);
                Stream reportStream = Reporte.ExportToStream(ExportFormatType.PortableDocFormat);
                byte[] pdfbytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    reportStream.CopyTo(memoryStream);
                    pdfbytes = memoryStream.ToArray();
                }
                R.Contenido = Convert.ToBase64String(pdfbytes);
                R.Codigo = 0;
                R.Mensaje = "Reporte de Producto creado exitosamente";
            }
            catch (Exception ex)
            {
                R.Codigo = -23;
                R.Mensaje = $"Se generó un error al crear el Reporte de Productos: {ex.Message}";
            }
            finally
            {
                Reporte.Dispose();
                Reporte.Close();
            }
            return R;
        }

        public MensajeRespuesta ImprimirReportePedidos(string Nombre_Cliente, string Nombre_Empleado)
        {
            MensajeRespuesta R = new MensajeRespuesta();
            ReportDocument Reporte = new ReportDocument();
            try
            {
                Reporte = new ReportePedido();
                Reporte.SetParameterValue(0, Nombre_Cliente);
                Reporte.SetParameterValue(1, Nombre_Empleado);
                conectar_reporte(ref Reporte);
                Stream reportStream = Reporte.ExportToStream(ExportFormatType.PortableDocFormat);
                byte[] pdfbytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    reportStream.CopyTo(memoryStream);
                    pdfbytes = memoryStream.ToArray();
                }
                R.Contenido = Convert.ToBase64String(pdfbytes);
                R.Codigo = 0;
                R.Mensaje = "Reporte de Pedidos creado exitosamente";
            }
            catch (Exception ex)
            {
                R.Codigo = -23;
                R.Mensaje = $"Se generó un error al crear el Reporte de Pedidos: {ex.Message}";
            }
            finally
            {
                Reporte.Dispose();
                Reporte.Close();
            }
            return R;
        }

        public MensajeRespuesta ImprimirReporteDetallePedido(string ID_Pedido, string Nombre_Producto, string Nombre_Sucursal)
        {
            MensajeRespuesta R = new MensajeRespuesta();
            ReportDocument Reporte = new ReportDocument();
            try
            {
                Reporte = new ReporteDetallePedido();
                Reporte.SetParameterValue(0, ID_Pedido);
                Reporte.SetParameterValue(1, Nombre_Producto);
                Reporte.SetParameterValue(2, Nombre_Sucursal);
                conectar_reporte(ref Reporte);
                Stream reportStream = Reporte.ExportToStream(ExportFormatType.PortableDocFormat);
                byte[] pdfbytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    reportStream.CopyTo(memoryStream);
                    pdfbytes = memoryStream.ToArray();
                }
                R.Contenido = Convert.ToBase64String(pdfbytes);
                R.Codigo = 0;
                R.Mensaje = "Reporte de Detalle Pedido creado exitosamente";
            }
            catch (Exception ex)
            {
                R.Codigo = -23;
                R.Mensaje = $"Se generó un error al crear el Reporte de Detalle Pedidos: {ex.Message}";
            }
            finally
            {
                Reporte.Dispose();
                Reporte.Close();
            }
            return R;
        }

        public MensajeRespuesta ImprimirReporteTiposEmpleado(string Descripcion)
        {
            MensajeRespuesta R = new MensajeRespuesta();
            ReportDocument Reporte = new ReportDocument();
            try
            {
                Reporte = new ReporteTipoEmpleado();
                Reporte.SetParameterValue(0, Descripcion);
                conectar_reporte(ref Reporte);
                Stream reportStream = Reporte.ExportToStream(ExportFormatType.PortableDocFormat);
                byte[] pdfbytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    reportStream.CopyTo(memoryStream);
                    pdfbytes = memoryStream.ToArray();
                }
                R.Contenido = Convert.ToBase64String(pdfbytes);
                R.Codigo = 0;
                R.Mensaje = "Reporte de Tipos de Empleado creado exitosamente";
            }
            catch (Exception ex)
            {
                R.Codigo = -23;
                R.Mensaje = $"Se generó un error al crear el Reporte de  Tipos de Empleado: {ex.Message}";
            }
            finally
            {
                Reporte.Dispose();
                Reporte.Close();
            }
            return R;
        }
    }
}
