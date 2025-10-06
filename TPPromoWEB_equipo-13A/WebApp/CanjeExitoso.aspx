<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CanjeExitoso.aspx.cs" Inherits="WebApp.CanjeExitoso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center">
        <div class="card text-center shadow p-3 mb-5 bg-body rounded" style="max-width: 400px;">
            <div class="card-body">
                <h5 class="card-title text-success">¡Éxito!</h5>
                <p class="card-text">La operación se completó correctamente.<br></p>
                <asp:Label ID="lblMensaje" runat="server" CssClass="card-text"></asp:Label>
            </div>
                <a href="IngresarCodigo.aspx" class="btn btn-primary mt-3">Ingresar otro código...</a>
        </div>
    </div>
</asp:Content>
