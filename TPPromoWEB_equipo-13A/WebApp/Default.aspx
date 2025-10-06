<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Promo Verano 2026</h1>
    <p>¡Gracias por participar de la promoción!</p>
    <p>Para comenzar, clickee en el siguiente botón para ingresar el código de su voucher:</p>
    <a class="btn btn-primary" href='/IngresarCodigo.aspx'>
    ¡Comenzar!</a>
</asp:Content>
