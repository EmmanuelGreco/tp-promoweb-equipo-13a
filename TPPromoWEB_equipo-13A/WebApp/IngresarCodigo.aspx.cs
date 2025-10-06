using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class IngresarCodigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnUtilizarCupon_Click(object sender, EventArgs e)
        {
            string txtvoucher = txtCodigoVoucher.Text.Trim();

            errorVoucher.IsValid = true;

            if (string.IsNullOrWhiteSpace(txtvoucher))
            {
                errorVoucher.IsValid = false;
                errorVoucher.ErrorMessage = "¡Debe ingresar un código de voucher!";
                return;
            }

            VoucherNegocio voucherNegocio = new VoucherNegocio();
            Voucher voucher = new Voucher();
            try
            {
                voucher = voucherNegocio.buscarVoucher(txtvoucher);
            }
            catch (Exception ex)
            {
                conexionDB.Attributes["style"] = "display: block";

                return;
            }

            if (voucher == null)
            {
                errorVoucher.IsValid = false;
                errorVoucher.ErrorMessage = "¡Voucher inexistente! Regresando al inicio...";

                //Setear refresh a 3 segundos. 
                HtmlMeta meta = new HtmlMeta();
                meta.HttpEquiv = "refresh";
                meta.Content = "2;url=Default.aspx";
                Page.Header.Controls.Add(meta);
                txtCodigoVoucher.ReadOnly = true;
                return;
            }

            if (!voucherNegocio.voucherEsCanjeable(voucher))
            {
                errorVoucher.IsValid = false;
                errorVoucher.ErrorMessage = "¡El voucher ya fue canjeado!";
                return;
            }

            Session["voucher"] = voucher.CodigoVoucher.ToString();
            Response.Redirect("ElegirArticulo.aspx");
        }
    }
}