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
                string documento = ClienteDocumento.Text;

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente clienteExistente = negocio.buscarPorDocumento(documento);

                Cliente cliente = new Cliente();

                cliente.Documento = ClienteDocumento.Text;
                cliente.Nombre = ClienteNombre.Text;
                cliente.Apellido = ClienteApellido.Text;
                cliente.Email = ClienteEmail.Text;
                cliente.Direccion = ClienteDireccion.Text;
                cliente.Ciudad = ClienteCiudad.Text;
                cliente.CP = int.Parse(ClienteCP.Text);

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
                lblError.Text = "Error al registrar cliente: " + ex.Message;
            }
        }

        protected void ClienteDNI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string documento = ClienteDocumento.Text;

                if (string.IsNullOrWhiteSpace(documento))
                {
                    lblError.Text = "Debe ingresar un Documento válido.";
                    return;
                }

                //int documento = int.Parse(ClienteDNI.Text); Cuando lo usabamos con tipo int.

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente clienteExistente = negocio.buscarPorDocumento(documento);

                if (clienteExistente != null)
                {
                    ClienteNombre.Text = clienteExistente.Nombre;
                    ClienteApellido.Text = clienteExistente.Apellido;
                    ClienteEmail.Text = clienteExistente.Email;
                    ClienteDireccion.Text = clienteExistente.Direccion;
                    ClienteCiudad.Text = clienteExistente.Ciudad;
                    ClienteCP.Text = clienteExistente.CP.ToString();

                    lblError.Text = "Cliente encontrado! Verifique sus datos.";
                }
                else
                {
                    ClienteNombre.Text = "";
                    ClienteApellido.Text = "";
                    ClienteEmail.Text = "";
                    ClienteDireccion.Text = "";
                    ClienteCiudad.Text = "";
                    ClienteCP.Text = "";

                    lblError.Text = "No existe cliente con ese DNI. Complete el formulario para registrarse.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al buscar cliente: " + ex.Message;
            }
        }
    }
}