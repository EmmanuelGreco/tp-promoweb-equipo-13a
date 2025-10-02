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
    public partial class ElegirArticulo : System.Web.UI.Page
    {
        public List<Articulo> listaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Una verificación, por si el Usuario llega a la página sin haber ingresado el Voucher.
            if (Session["voucher"] == null)
                Response.Redirect("IngresarCodigo.aspx");

            // Manejo de errores si el listado de Artículos está vacio.
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    listaArticulo = negocio.listar();
                }
            }
            catch (Exception)
            {
                lblError.Text = "Error! No se pudieron cargar los artículos! Intente nuevamente.";
            }
        }
    }
}