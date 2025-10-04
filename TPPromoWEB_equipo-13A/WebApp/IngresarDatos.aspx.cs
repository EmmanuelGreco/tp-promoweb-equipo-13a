using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                // Validar que llega idArticulo por Query String.
                if (Request.QueryString["idArticulo"] == null)
                {
                    Response.Redirect("ElegirArticulo.aspx");
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
                int idArticulo = (int)Session["IdArticuloSeleccionado"];

                VoucherNegocio voucherNegocio = new VoucherNegocio();

                bool exito = voucherNegocio.asignarVoucher(idCliente, idArticulo, voucher);

                if (!exito)
                {
                    lblError.Text = "Error al asignar el voucher. Intente nuevamente.";
                    return;
                }

                Response.Redirect("CanjeExitoso.aspx");

            }
            catch (FormatException)
            {
                lblError.Text = "El Código Postal debe ser un número válido!";
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al registrar el cliente: " + ex.Message;
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
                    errorDNI.ErrorMessage = "¡Debe ingresar un Documento válido!";
                    return;
                }

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente clienteExistente = negocio.buscarPorDocumento(documento);

                if (clienteExistente != null)
                {
                    txtClienteNombre.Text = clienteExistente.Nombre;
                    txtClienteApellido.Text = clienteExistente.Apellido;
                    txtClienteEmail.Text = clienteExistente.Email;
                    txtClienteDireccion.Text = clienteExistente.Direccion;
                    txtClienteCiudad.Text = clienteExistente.Ciudad;
                    txtClienteCP.Text = clienteExistente.CP.ToString();

                    errorDNI.IsValid = false;
                    errorDNI.ErrorMessage = "¡Cliente encontrado! Verifique sus datos.";
                }
                else
                {
                    errorDNI.IsValid = false;
                    errorDNI.ErrorMessage = "No existe un cliente con ese DNI. Complete el formulario para registrarse.";
                }
            }
            catch (Exception ex)
            {
                errorDNI.IsValid = false;
                errorDNI.ErrorMessage = "Error al buscar cliente: " + ex.Message;
            }
        }
    }
}