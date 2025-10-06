<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ElegirArticulo.aspx.cs" Inherits="WebApp.ElegirArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-3">Elija un artículo:</h1>

    <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-3"></asp:Label>


    <% 
        int idArticulo = 0;
        if (listaArticulo != null)
        { %>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%
            foreach (Dominio.Articulo art in listaArticulo)
            {
                string idCarousel = "carouselArt" + idArticulo; %>
        <div class="col">
            <div class="card h-100">
                <div id="<%: idCarousel %>" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-indicators">
                        <% 
                            int idImagen = 0;
                            if (art.ListaImagen.Count > 1)
                            {
                                foreach (Dominio.Imagen img in art.ListaImagen)
                                {
                        %>
                        <button type="button" style="filter: invert(1)" data-bs-target="#<%: idCarousel %>" data-bs-slide-to="<%: idImagen %>" aria-label="Slide <%: idImagen + 1 %>" <%:idImagen == 0 ? "class=active aria-current=true" : ""  %>></button>
                        <% idImagen++;
                                }
                            }%>
                    </div>
                    <div class="carousel-inner">
                        <%
                            idImagen = 0;
                            foreach (Dominio.Imagen img in art.ListaImagen)
                            {
                        %>
                        <div class="carousel-item <%: idImagen == 0 ? "active" : "" %>" style="height: 300px">
                            <img src="<%: img.ImagenUrl %>" class="d-block w-100" style="max-height: 300px; object-fit: contain;">
                        </div>
                        <% idImagen++;
                            }%>
                    </div>
                    <% if (art.ListaImagen.Count > 1)
                        {%>
                    <button class="carousel-control-prev" style="filter: invert(1)" type="button" data-bs-target="#<%: idCarousel %>" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" style="filter: invert(1)" type="button" data-bs-target="#<%: idCarousel %>" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                    <%} %>
                </div>
                <div class="card-body">
                    <p class="card-subtitle text-muted fst-italic"><%: art.Categoria %></p>
                    <h4 class="card-title"><%: art.Nombre %></h4>
                    <h5 class="card-subtitle mb-2 text-muted"><%: art.Marca %></h5>
                    <p class="card-text"><%: art.Descripcion %></p>
                    <h3><%:art.Precio.ToString("C") %></h3>
                    <!-- Paso el Artículo por Query String -->
                    <a class="btn btn-primary" href='IngresarDatos.aspx?idArticulo=<%: art.Id %>'>Elegir este artículo</a>
                </div>
                <div class="card-footer">
                    <small class="text-muted"><%: "Código de artículo: " + art.Codigo %></small>
                </div>
            </div>
        </div>
        <%
                idArticulo++;
            } %>
    </div>
    <%
        }
        else
        { %>
    <div class="alert alert-danger" role="alert">
        No se pudo establecer una conexión con la base de datos. Inténtelo nuevamente más tarde.
    </div>
    <% return;
        }%>
</asp:Content>
