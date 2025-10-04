<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IngresarCodigo.aspx.cs" Inherits="WebApp.IngresarCodigo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-3">¡Ingresá el código del cupón!</h1>
    <div class="row">
        <div class="col-6">
            <asp:Label runat="server" CssClass="form-label">Código:</asp:Label>
            <asp:TextBox ID="txtCodigoVoucher" CssClass="form-control mt-3" runat="server" Placeholder="Ingrese su código del Voucher..."></asp:TextBox>
            <div style="min-height: 1.5em;">
                <asp:CustomValidator ID="errorVoucher" ControlToValidate="txtCodigoVoucher" ErrorMessage="¡Voucher inválido!" ForeColor="Red" Display="Dynamic" EnableClientScript="false" runat="server" />
            </div>
            <asp:Button ID="btnUtilizarCupon" type="button" class="btn btn-primary mt-3" Text="Utilizar cupón" OnClick="btnUtilizarCupon_Click" runat="server"/>
        </div>
        <!--div class="row mb-3">
            <div class="col-sm-4">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger"/>
            </div>
        </div-->
    </div>
</asp:Content>
