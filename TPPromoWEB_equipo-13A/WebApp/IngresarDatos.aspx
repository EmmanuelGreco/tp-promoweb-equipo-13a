<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IngresarDatos.aspx.cs" Inherits="WebApp.IngresarDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-3">Ingrese sus datos:</h1>

    <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-3"></asp:Label>

    <!--div class="container"-->
        <div class="row">
            <div class="col mb-2 d-flex flex-column">
                <asp:Label runat="server" CssClass="form-label" for="ClienteDocumento">Documento: (Presione TAB para autocompletar, en caso de estar registrado)</asp:Label>
                <asp:TextBox ID="txtClienteDocumento" CssClass="form-control" placeholder="12345678" runat="server" TextMode="SingleLine" MaxLength="8"
                    AutoPostBack="true" OnTextChanged="ClienteDocumento_TextChanged"></asp:TextBox>
                <div style="min-height: 1.5em;">
                    <asp:RequiredFieldValidator ErrorMessage="¡El Documento es requerido!" ForeColor="Red" Display="Dynamic" ControlToValidate="txtClienteDocumento" runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="¡El Documento debe ser numérico de 8 cifras! En caso de ser necesario, completar con 0 a la izquierda." ForeColor="Red" Display="Dynamic" 
                        ValidationExpression="^\d{8}$" ControlToValidate="txtClienteDocumento" runat="server" />
                    <asp:CustomValidator ID="errorDNI" ControlToValidate="txtClienteDocumento" ErrorMessage="Aca va el Error" ForeColor="Red" Display="Dynamic" EnableClientScript="false" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col mb-2 d-flex flex-column">
                <asp:Label runat="server" CssClass="form-label" for="ClienteEmail">Correo:</asp:Label>
                <asp:TextBox ID="txtClienteEmail" CssClass="form-control" placeholder="ejemplo@gmail.com" runat="server"></asp:TextBox>
                <div style="min-height: 1.5em;">
                    <asp:RequiredFieldValidator ErrorMessage="¡El Correo es requerido!" ForeColor="Red" Display="Dynamic" ControlToValidate="txtClienteEmail" runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="¡El Correo debe ser un email válido!" ForeColor="Red" Display="Dynamic" 
                        ValidationExpression="^([\w\.-]+)@((\[[0-9]{1,3}(\.[0-9]{1,3}){3}\])|(([\w-]+\.)+[a-zA-Z]{2,4}))$" ControlToValidate="txtClienteEmail" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col mb-2 d-flex flex-column">
                <asp:Label runat="server" CssClass="form-label" for="ClienteNombre">Nombre:</asp:Label>
                <asp:TextBox ID="txtClienteNombre" CssClass="form-control" placeholder="Juan" MaxLength="50" runat="server"></asp:TextBox>
                <div style="min-height: 1.5em;">
                    <asp:RequiredFieldValidator ErrorMessage="¡El Nombre es requerido!" ForeColor="Red" ControlToValidate="txtClienteNombre" runat="server" />
                </div>
            </div>
            <div class="col mb-2 d-flex flex-column">
                <asp:Label runat="server" CssClass="form-label" for="ClienteApellido">Apellido:</asp:Label>
                <asp:TextBox ID="txtClienteApellido" CssClass="form-control" placeholder="Pérez" MaxLength="50" runat="server"></asp:TextBox>
                <div style="min-height: 1.5em;">
                    <asp:RequiredFieldValidator ErrorMessage="¡El Apellido es requerido!" ForeColor="Red" ControlToValidate="txtClienteApellido" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col mb-2 d-flex flex-column">
                <asp:Label runat="server" CssClass="form-label" for="ClienteDireccion">Dirección:</asp:Label>
                <asp:TextBox ID="txtClienteDireccion" CssClass="form-control" placeholder="Gavilán 2151" MaxLength="50" runat="server"></asp:TextBox>
                <div style="min-height: 1.5em;">
                    <asp:RequiredFieldValidator ErrorMessage="¡La Dirección es requerida!" ForeColor="Red" ControlToValidate="txtClienteDireccion" runat="server" />
                </div>
            </div>
            <div class="col mb-2 d-flex flex-column">
                <asp:Label runat="server" CssClass="form-label" for="ClienteCiudad">Ciudad:</asp:Label>
                <asp:TextBox ID="txtClienteCiudad" CssClass="form-control" placeholder="CABA" MaxLength="50" runat="server"></asp:TextBox>
                <div style="min-height: 1.5em;">
                    <asp:RequiredFieldValidator ErrorMessage="¡La Ciudad es requerida!" ForeColor="Red" ControlToValidate="txtClienteCiudad" runat="server" />
                </div>
            </div>
            <div class="col mb-2 d-flex flex-column">
                <asp:Label runat="server" CssClass="form-label" for="ClienteCP">Código Postal:</asp:Label>
                <asp:TextBox ID="txtClienteCP" CssClass="form-control" placeholder="1416" MaxLength="4" runat="server"></asp:TextBox>
                <div style="min-height: 1.5em;">
                <asp:RequiredFieldValidator ErrorMessage="¡El Código Postal es requerido!" ForeColor="Red" Display="Dynamic" ControlToValidate="txtClienteCP" runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="¡El Código Postal debe ser numérico de 4 cifras! En caso de ser necesario, completar con 0 a la izquierda." ForeColor="Red" Display="Dynamic" 
                        ValidationExpression="^\d{4}$" ControlToValidate="txtClienteCP" runat="server" />
                </div>
            </div>
        </div>
    <!--/div-->
    <asp:Button runat="server" type="button" class="btn btn-primary mt-3" Text="Participar!" OnClick="EnviarFormulario"/>
</asp:Content>
