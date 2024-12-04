<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoRelampago.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proyecto Relampago</title>
    <link href="Content/Inicio.css" rel="stylesheet" type="text/css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
        <div class="container">
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Alternar navegación" aria-controls="navbarSupportedContent"
                aria-expanded="false" aria-label="Toggle navigation">
            </button>
            <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                <ul class="navbar-nav flex-grow-1">
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/Inicio">Inicio</a></li>
                    <li class="nav-item"><a class="nav-link" runat="server" href="~/MenuMantenimiento">Mantenimiento de tablas</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <form id="form1" runat="server">
        <div class="filters-container">
                <asp:DropDownList ID="ddlEje" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlArea" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlDependencia" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlTipoProcedimiento" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlEstado" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlTeletrabajado" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlMacroproceso" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlEjeEstrategico" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlApoyoTecnologico" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlAñoActualizacion" runat="server" OnSelectedIndexChanged="Filtro_Cambiado" AutoPostBack="true">
                </asp:DropDownList>

        </div>

<div class="contenedor">
            <div class="tarjeta">
                <div class="titulo">Eje</div>
                <asp:Label ID="lblConteoEje" runat="server" CssClass="conteo"></asp:Label>
            </div>

            <div class="tarjeta">
                <div class="titulo">Área</div>
                <asp:Label ID="lblConteoArea" runat="server" CssClass="conteo"></asp:Label>
            </div>

            <div class="tarjeta">
                <div class="titulo">Dependencia</div>
                <asp:Label ID="lblConteoDependencia" runat="server" CssClass="conteo"></asp:Label>
            </div>

            <div class="tarjeta">
                <div class="titulo">Tipo Procedimiento</div>
                <asp:Label ID="lblConteoTipoProcedimiento" runat="server" CssClass="conteo"></asp:Label>
            </div>

            <div class="tarjeta">
                <div class="titulo">Estado</div>
                <asp:Label ID="lblConteoEstado" runat="server" CssClass="conteo"></asp:Label>
            </div>

            <div class="tarjeta">
                <div class="titulo">Teletrabajado</div>
                <asp:Label ID="lblConteoTeletrabajado" runat="server" CssClass="conteo"></asp:Label>
            </div>

            <div class="tarjeta">
                <div class="titulo">Macroproceso</div>
                <asp:Label ID="lblConteoMacroproceso" runat="server" CssClass="conteo"></asp:Label>
            </div>

            <div class="tarjeta">
                <div class="titulo">Eje Estratégico</div>
                <asp:Label ID="lblConteoEjeEstrategico" runat="server" CssClass="conteo"></asp:Label>
            </div>

            <div class="tarjeta">
                <div class="titulo">Apoyo Tecnológico</div>
                <asp:Label ID="lblConteoApoyoTecnologico" runat="server" CssClass="conteo"></asp:Label>
            </div>

            <div class="tarjeta">
                <div class="titulo">Año</div>
                <asp:Label ID="lblConteoAño" runat="server" CssClass="conteo"></asp:Label>
            </div>
        </div>

        <div class="grid-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                          CssClass="table table-striped" OnPageIndexChanging="GridView1_PageIndexChanging" 
                          OnSorting="GridView1_Sorting">
                <Columns>
                    <asp:BoundField DataField="idEje" HeaderText="Eje Estratégico" SortExpression="idEje" />
                    <asp:BoundField DataField="nombreArea" HeaderText="Área" SortExpression="nombreArea" />
                    <asp:BoundField DataField="nombreDependencia" HeaderText="Dependencia" SortExpression="nombreDependencia" />
                    <asp:BoundField DataField="tipoProcedimiento" HeaderText="Tipo Procedimiento" SortExpression="tipoProcedimiento" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                    <asp:BoundField DataField="teletrabajado" HeaderText="Teletrabajado" SortExpression="teletrabajado" />
                    <asp:BoundField DataField="nombreMacroproceso" HeaderText="Macroproceso" SortExpression="nombreMacroproceso" />
                    <asp:BoundField DataField="nombreEjeEstrategico" HeaderText="Eje Estratégico" SortExpression="nombreEjeEstrategico" />
                    <asp:BoundField DataField="tipoDocumento" HeaderText="Tipo Documento" SortExpression="tipoDocumento" />
                    <asp:BoundField DataField="nombreProcedimiento" HeaderText="Nombre Procedimiento" SortExpression="nombreProcedimiento" />
                    <asp:BoundField DataField="apoyoTecnologico" HeaderText="Apoyo Tecnológico" SortExpression="apoyoTecnologico" />
                    <asp:BoundField DataField="anioActualizacion" HeaderText="Año Actualización" SortExpression="anioActualizacion" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
