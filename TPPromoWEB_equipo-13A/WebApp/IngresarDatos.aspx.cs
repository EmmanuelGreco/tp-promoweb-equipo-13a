using Dominio;
using negocio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApp
{
    public partial class IngresarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Validar que llega idArticulo por Query String.
                if (Request.QueryString["idArticulo"] == null)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                Session["IdArticuloSeleccionado"] = int.Parse(Request.QueryString["idArticulo"]);
            }
        }

        protected void EnviarFormulario(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                string documento = txtClienteDocumento.Text;

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente clienteExistente = negocio.buscarPorDocumento(documento);

                Cliente cliente = new Cliente();

                cliente.Documento = txtClienteDocumento.Text;
                cliente.Nombre = txtClienteNombre.Text;
                cliente.Apellido = txtClienteApellido.Text;
                cliente.Email = txtClienteEmail.Text;
                cliente.Direccion = txtClienteDireccion.Text;
                cliente.Ciudad = txtClienteCiudad.Text;
                cliente.CP = int.Parse(txtClienteCP.Text);

                int idCliente;

                if (clienteExistente == null)
                {
                    negocio.agregar(cliente);

                    Cliente clienteRecienAgregado = negocio.buscarPorDocumento(documento);
                    idCliente = clienteRecienAgregado.Id;
                }
                else
                {
                    negocio.modificar(cliente);

                    idCliente = clienteExistente.Id;
                }

                string voucher = Session["voucher"] as string;
                if (Session["voucher"] == null)
                    Response.Redirect("Default.aspx");
                int idArticulo = (int)Session["IdArticuloSeleccionado"];

                VoucherNegocio voucherNegocio = new VoucherNegocio();

                bool exito = voucherNegocio.asignarVoucher(idCliente, idArticulo, voucher);

                if (!exito)
                {
                    lblError.Text = "Error al asignar el voucher. Intente nuevamente.";
                    return;
                }


                EmailService emailService = new EmailService();
                // TUVE QUE VOLVER A LLAMAR A LA DB XQ PASAR EL NOMBRE DEL PRODUCTO DESDE "ELEGIRPRODUCTOS" ERA MUY DIFCIL, CON COSAS QUE NO VIMOS. 
                //NO QUISE METER UN MONTON DE GPT QUE NO ENTENDÍ BIEN, Y ASI FUNCIONA.
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = articuloNegocio.listar();
                string nombreArticulo = "";
                foreach (Articulo art in listaArticulos)
                {
                    if (art.Id == idArticulo)
                        nombreArticulo = art.Nombre;
                }
                string email = cliente.Email;

                emailService.armarCorreo(email, "¡Voucher canjeado exitosamente!", "Utilizaste el código \"" + voucher + "\" para participar por el siguiente producto: \"" + nombreArticulo + "\". ¡Muchas gracias por tu apoyo!");
                try
                {
                    emailService.enviarEmail();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                Response.Redirect("CanjeExitoso.aspx");

            }
            catch (FormatException)
            {
                lblError.Text = "El Código Postal debe ser un número válido!";
            }
            catch (Exception ex)
            {
                conexionDB.Attributes["style"] = "display: block";
            }
        }

        protected void ClienteDocumento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string documento = txtClienteDocumento.Text;

                errorDNI.IsValid = true;

                if (string.IsNullOrWhiteSpace(documento))
                {
                    errorDNI.IsValid = false;
                    errorDNI.ForeColor = Color.FromName("Red");
                    errorDNI.ErrorMessage = "¡Debe ingresar un Documento válido!";
                    return;
                }

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente clienteExistente = negocio.buscarPorDocumento(documento);

                if (clienteExistente != null)
                {
                    txtClienteEmail.Text = clienteExistente.Email;
                    txtClienteNombre.Text = clienteExistente.Nombre;
                    txtClienteApellido.Text = clienteExistente.Apellido;
                    txtClienteDireccion.Text = clienteExistente.Direccion;
                    txtClienteCiudad.Text = clienteExistente.Ciudad;
                    txtClienteCP.Text = clienteExistente.CP.ToString();

                    errorDNI.IsValid = false;
                    errorDNI.ForeColor = Color.FromName("Green");
                    errorDNI.ErrorMessage = "¡Cliente encontrado! Verifique sus datos.";

                    txtClienteEmail.ReadOnly = false;
                    txtClienteNombre.ReadOnly = false;
                    txtClienteApellido.ReadOnly = false;
                    txtClienteDireccion.ReadOnly = false;
                    txtClienteCiudad.ReadOnly = false;
                    txtClienteCP.ReadOnly = false;
                }
                else
                {
                    errorDNI.IsValid = false;
                    errorDNI.ForeColor = Color.FromName("Red");
                    errorDNI.ErrorMessage = "No existe un cliente con ese DNI. Complete el formulario para registrarse.";
                }
            }
            catch (Exception ex)
            {
                conexionDB.Attributes["style"] = "display: block";
            }
        }
    }
}