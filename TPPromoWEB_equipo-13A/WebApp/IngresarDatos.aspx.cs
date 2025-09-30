using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class IngresarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EnviarFormulario(object sender, EventArgs e)
        {
            try
            {
            Cliente cliente = new Cliente();
            cliente.Documento = int.Parse(ClienteDNI.Text);
            cliente.Nombre = ClienteNombre.Text;
            cliente.Apellido = ClienteApellido.Text;
            cliente.Email = ClienteEmail.Text;
            cliente.Direccion = ClienteDireccion.Text;
            cliente.Ciudad = ClienteCiudad.Text;
            cliente.CodigoPostal = ClienteCodigoP.Text;
            
            ClienteNegocio negocio = new ClienteNegocio();
            negocio.agregar(cliente);
            }
            catch (Exception)
            {
                throw;
            } 
        }
    }
}