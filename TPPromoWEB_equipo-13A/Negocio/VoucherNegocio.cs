using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VoucherNegocio
    {
        public Voucher buscarVoucher(string codigoVoucher)
        {
            AccesoDatos datos = null;
            try
            {
                datos = new AccesoDatos();
                // Lo hago Case Sensitive con COLLATE SQL_Latin1_General_CP1_CS_AS
                datos.setearConsulta("SELECT * FROM Vouchers WHERE codigoVoucher " +
                                     "COLLATE SQL_Latin1_General_CP1_CS_AS = @voucher");
                datos.limpiarParametros();
                datos.setearParametro("@voucher", codigoVoucher);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Voucher voucher = new Voucher();

                    if (datos.Lector["CodigoVoucher"] != DBNull.Value)
                        voucher.CodigoVoucher = datos.Lector["CodigoVoucher"].ToString();
                    if (datos.Lector["IdCliente"] != DBNull.Value)
                        voucher.IdCliente = (int) datos.Lector["IdCliente"];
                    if (datos.Lector["FechaCanje"] != DBNull.Value)
                        voucher.FechaCanje = (DateTime) datos.Lector["FechaCanje"];
                    if (datos.Lector["IdArticulo"] != DBNull.Value)
                        voucher.IdArticulo = (int) datos.Lector["IdArticulo"];

                    return voucher;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos?.cerrarConexion();
            }
        }

        public bool asignarVoucher(int idCliente, int idArticulo, string voucher)
        {
            AccesoDatos datos = null;
            if (string.IsNullOrEmpty(idCliente.ToString()) ||
                string.IsNullOrEmpty(idArticulo.ToString()) ||
                string.IsNullOrEmpty(voucher) ||
                voucher.Length > 50)
                return false;

            try
            {
                datos = new AccesoDatos();
                datos.setearConsulta("UPDATE Vouchers SET IdCliente = @idCliente, FechaCanje = GETDATE(), IdArticulo = @idArticulo WHERE CodigoVoucher = @voucher;");
                datos.setearParametro("@idCliente", idCliente);
                datos.setearParametro("@idArticulo", idArticulo);
                datos.setearParametro("@voucher", voucher);
                datos.ejecutarLectura();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (datos != null)
                {
                    try
                    {
                        if (datos.Lector != null && !datos.Lector.IsClosed)
                            datos.Lector.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public bool voucherEsCanjeable(Voucher voucher)
        {
            return voucher != null &&
                   voucher.IdCliente == 0 &&
                   voucher.FechaCanje == default(DateTime) &&
                   voucher.IdArticulo == 0;
        }
    }
}
