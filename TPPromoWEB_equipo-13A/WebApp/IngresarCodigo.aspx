<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IngresarCodigo.aspx.cs" Inherits="WebApp.IngresarCodigo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-3">¡Ingresá el código del cupón!</h1>
    <div class="row">
        <div class="col-6">
            <asp:Label runat="server" CssClass="form-label">Código:</asp:Label>
            <asp:TextBox ID="CodigoVoucher" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Button runat="server" type="button" class="btn btn-primary" Text="Utilizar cupón" />
        </div>
    </div>
</asp:Content>
