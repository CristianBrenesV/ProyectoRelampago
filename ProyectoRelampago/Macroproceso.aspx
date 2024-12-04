<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Macroproceso.aspx.cs" Inherits="ProyectoRelampago.MacroprocesoPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Macroprocesos</title>
    <link href="Content/Macroprocesos.css" rel="stylesheet" type="text/css" />
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
        <div>
            <h3>Agregar Macroproceso</h3>
            <label>IdMacroproceso:</label>
            <asp:TextBox ID="txtIdMacroproceso" runat="server"></asp:TextBox>
            <br />
            <label>NombreMacroproceso:</label>
            <asp:TextBox ID="txtNombreMacroproceso" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Agregar Macroproceso" OnClick="btnAdd_Click" />
        </div>

        <h2>Macroprocesos</h2>
        <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="False"></asp:Label>
        <asp:GridView ID="gvMacroprocesos" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
            DataKeyNames="IdMacroproceso"
            OnPageIndexChanging="gvMacroprocesos_PageIndexChanging"
            OnRowEditing="gvMacroprocesos_RowEditing" OnRowDeleting="gvMacroprocesos_RowDeleting"
            OnRowUpdating="gvMacroprocesos_RowUpdating" OnRowCancelingEdit="gvMacroprocesos_RowCancelingEdit">
            <Columns>
                <asp:BoundField DataField="IdMacroproceso" HeaderText="IdMacroproceso" ReadOnly="True" />
                <asp:TemplateField HeaderText="NombreMacroproceso">
                    <ItemTemplate>
                        <asp:Label ID="lblNombreMacroproceso" runat="server" Text='<%# Eval("NombreMacroproceso") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNombreMacroproceso" runat="server" Text='<%# Bind("NombreMacroproceso") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
