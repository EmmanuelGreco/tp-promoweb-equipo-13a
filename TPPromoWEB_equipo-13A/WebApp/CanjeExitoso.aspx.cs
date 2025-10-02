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
    public partial class CanjeExitoso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["voucher"] == null || Session["IdArticuloSeleccionado"] == null)
                {
                    Response.Redirect("IngresarCodigo.aspx");
                    return;
                }

                int idArticulo = (int)Session["IdArticuloSeleccionado"];
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo articuloSeleccionado = articuloNegocio.listar().FirstOrDefault(a => a.Id == idArticulo);

                lblMensaje.Text = $"El voucher &quot;<strong>{Session["voucher"]}</strong>&quot; fue canjeado correctamente. " +
                    $"Ya estás participando por el artículo &quot;<strong>{articuloSeleccionado.Nombre}</strong>&quot;.";

                Session.Remove("voucher");
                Session.Remove("IdArticuloSeleccionado");
            }
        }
    }
}