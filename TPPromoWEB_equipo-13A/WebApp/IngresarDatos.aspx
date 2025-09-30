<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IngresarDatos.aspx.cs" Inherits="WebApp.IngresarDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-3">Ingesá tus datos:</h1>
    <div class="container">
        <div class="row">
            <div class="col">
                <asp:Label runat="server" CssClass="form-label" for="ClienteDNI">DNI:</asp:Label>
                <asp:TextBox ID="ClienteDNI" CssClass="form-control mb-3" placeholder="12345678" runat="server" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label runat="server" CssClass="form-label" for="ClienteEmail">Correo:</asp:Label>
                <asp:TextBox ID="ClienteEmail" CssClass="form-control mb-3" placeholder="ejemplo@gmail.com" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:Label runat="server" CssClass="form-label" for="ClienteNombre">Nombre:</asp:Label>
                <asp:TextBox ID="ClienteNombre" CssClass="form-control mb-3" placeholder="Juan" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label runat="server" CssClass="form-label" for="ClienteApellido">Apellido:</asp:Label>
                <asp:TextBox ID="ClienteApellido" CssClass="form-control mb-3" placeholder="Pérez" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">

            <div class="col">
                <asp:Label runat="server" CssClass="form-label" for="ClienteDireccion">Dirección:</asp:Label>
                <asp:TextBox ID="ClienteDireccion" CssClass="form-control mb-3" placeholder="Gavilán 2151" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label runat="server" CssClass="form-label" for="ClienteCiudad">Ciudad:</asp:Label>
                <asp:TextBox ID="ClienteCiudad" CssClass="form-control mb-3" placeholder="CABA" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label runat="server" CssClass="form-label" for="ClienteCodigoP">Código Postal:</asp:Label>
                <asp:TextBox ID="ClienteCodigoP" CssClass="form-control mb-3" placeholder="1416" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button runat="server" type="button" class="btn btn-primary" Text="Ingresar Datos" OnClick="EnviarFormulario"/>
</asp:Content>
