using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta(@"INSERT INTO Clientes (Documento, Nombre, Apellido, 
                                                              Email, Direccion, Ciudad, CP) 

                                       VALUES (@documento, @nombre, @apellido, 
                                               @email, @direccion, @ciudad, @cp);

                                       SELECT SCOPE_IDENTITY() AS NuevoID;");
                datos.setearParametro("@documento", nuevo.Documento);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@direccion", nuevo.Direccion);
                datos.setearParametro("@ciudad", nuevo.Ciudad);
                datos.setearParametro("@cp", nuevo.CodigoPostal);
                
                datos.ejecutarAccion();
            }
            catch (global::System.Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
