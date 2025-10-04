using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace WebApp
{
    public partial class IngresarCodigo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
                txtCodigoVoucher.Text = "Ingrese su código del Voucher...";
            */
        }

        protected void btnUtilizarCupon_Click(object sender, EventArgs e)
        {
            string txtvoucher = txtCodigoVoucher.Text.Trim();

            errorVoucher.IsValid = true;

            if (string.IsNullOrWhiteSpace(txtvoucher))
            {
                errorVoucher.IsValid = false;
                errorVoucher.ErrorMessage = "¡Debe ingresar un código de Voucher!";
                return;
            }

            VoucherNegocio voucherNegocio = new VoucherNegocio();
            Voucher voucher = voucherNegocio.buscarVoucher(txtvoucher);

            if (voucher == null)
            {
                errorVoucher.IsValid = false;
                errorVoucher.ErrorMessage = "¡Voucher inexistente!";
                return;
            }

            if (!voucherNegocio.voucherEsCanjeable(voucher))
            {
                errorVoucher.IsValid = false;
                errorVoucher.ErrorMessage = "¡El Voucher ya fue canjeado!";
                return;
            }

            Session["voucher"] = voucher.CodigoVoucher.ToString();
            Response.Redirect("ElegirArticulo.aspx");
        }
    }
}