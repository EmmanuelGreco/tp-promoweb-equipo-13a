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
            //Chequeo masivo de no null, no empty, y no pasado de cantidad de char maximo -- osea, valido
            if (string.IsNullOrEmpty(nuevo.Documento) ||
                string.IsNullOrEmpty(nuevo.Email) ||
                string.IsNullOrEmpty(nuevo.Nombre) ||
                string.IsNullOrEmpty(nuevo.Apellido) ||
                string.IsNullOrEmpty(nuevo.Direccion) ||
                string.IsNullOrEmpty(nuevo.Ciudad) ||
                string.IsNullOrEmpty(nuevo.CP.ToString()) ||
                nuevo.Documento.Length > 8 ||
                nuevo.Email.Length > 50 ||
                nuevo.Nombre.Length > 50 ||
                nuevo.Apellido.Length > 50 ||
                nuevo.Direccion.Length > 50 ||
                nuevo.Ciudad.Length > 50 ||
                nuevo.CP.ToString().Length > 50)
                return;

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
                datos.setearParametro("@cp", nuevo.CP);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Cliente buscarPorDocumento(string documento)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT * FROM Clientes WHERE Documento = @documento");
                datos.setearParametro("@documento", documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = (int)datos.Lector["Id"];
                    cliente.Documento = datos.Lector["Documento"].ToString();
                    cliente.Nombre = datos.Lector["Nombre"].ToString();
                    cliente.Apellido = datos.Lector["Apellido"].ToString();
                    cliente.Email = datos.Lector["Email"].ToString();
                    cliente.Direccion = datos.Lector["Direccion"].ToString();
                    cliente.Ciudad = datos.Lector["Ciudad"].ToString();
                    cliente.CP = (int)datos.Lector["CP"];

                    return cliente;
                }

                return null; // No existe
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            if (string.IsNullOrEmpty(cliente.Documento) ||
                string.IsNullOrEmpty(cliente.Email) ||
                string.IsNullOrEmpty(cliente.Nombre) ||
                string.IsNullOrEmpty(cliente.Apellido) ||
                string.IsNullOrEmpty(cliente.Direccion) ||
                string.IsNullOrEmpty(cliente.Ciudad) ||
                string.IsNullOrEmpty(cliente.CP.ToString()) ||
                cliente.Documento.Length > 8 || 
                cliente.Email.Length > 50 ||
                cliente.Nombre.Length > 50||
                cliente.Apellido.Length > 50 ||
                cliente.Direccion.Length > 50||
                cliente.Ciudad.Length  > 50 || 
                cliente.CP.ToString().Length > 50)
                return;

            try
            {
                datos.setearConsulta(@"UPDATE Clientes
                                        SET Nombre = @nombre,
                                            Apellido = @apellido,
                                            Email = @email,
                                            Direccion = @direccion,
                                            Ciudad = @ciudad,
                                            CP = @cp
                                        WHERE Documento = @documento");

                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@direccion", cliente.Direccion);
                datos.setearParametro("@ciudad", cliente.Ciudad);
                datos.setearParametro("@cp", cliente.CP);
                datos.setearParametro("@documento", cliente.Documento);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
