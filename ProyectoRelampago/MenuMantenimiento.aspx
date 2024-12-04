<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuMantenimiento.aspx.cs" Inherits="ProyectoRelampago.MenuMantenimiento" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Menú Principal de Mantenimiento</title>
         <link href="Content/Menu.css" rel="stylesheet" type="text/css" />
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
    <form id="formMenu" runat="server">
        <div class="menu-container">
            <h1>Menú Principal - Mantenimiento</h1>
            
            <!-- Menú de navegación -->
            <nav>
                <ul class="menu-list">
                    <li><a href="Procedimiento.aspx">Mantenimiento de Procedimientos</a></li>
                    <li><a href="Dependencia.aspx">Mantenimiento de Dependencias</a></li>
                    <li><a href="Area.aspx">Mantenimiento de Areas</a></li>
                    <li><a href="Macroproceso.aspx">Mantenimiento de Macroprocesos</a></li>
                    <li><a href="EjeEstrategico.aspx">Mantenimiento de Ejes Estratégicos</a></li>
                </ul>
            </nav>
        </div>
    </form>
</body>
</html>
