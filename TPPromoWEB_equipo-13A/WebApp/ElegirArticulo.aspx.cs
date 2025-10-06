using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
                Response.Redirect("Default.aspx");

            // Manejo de errores si el listado de Artículos está vacio.
            try
            {
                if (!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    listaArticulo = negocio.listar();

                    foreach (Articulo art in listaArticulo)
                    {
                        if (art.ListaImagen.Count < 1)
                        {
                            art.ListaImagen.Add(new Imagen());
                            art.ListaImagen[0].ImagenUrl = "https://www.svgrepo.com/show/508699/landscape-placeholder.svg";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return;
                lblError.Text = "Error! No se pudieron cargar los artículos! Intente nuevamente.";
            }
        }
    }
}