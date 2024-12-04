<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Area.aspx.cs" Inherits="ProyectoRelampago.AreaPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Áreas</title>
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
            <h2>Áreas</h2>
            <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="False"></asp:Label>
            <asp:GridView ID="gvAreas" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                DataKeyNames="IdArea"
                OnPageIndexChanging="gvAreas_PageIndexChanging"
                OnRowEditing="gvAreas_RowEditing" OnRowDeleting="gvAreas_RowDeleting"
                OnRowUpdating="gvAreas_RowUpdating" OnRowCancelingEdit="gvAreas_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="IdArea" HeaderText="IdArea" ReadOnly="True" />
                    <asp:TemplateField HeaderText="NombreArea">
                        <ItemTemplate>
                            <asp:Label ID="lblNombreArea" runat="server" Text='<%# Eval("NombreArea") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreArea" runat="server" Text='<%# Bind("NombreArea") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <div>
                <h3>Agregar Área</h3>
                <label>IdArea:</label>
                <asp:TextBox ID="txtIdArea" runat="server"></asp:TextBox>
                <br />
                <label>NombreArea:</label>
                <asp:TextBox ID="txtNombreArea" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Agregar Área" OnClick="btnAdd_Click" />
            </div>
        </div>
    </form>
</body>
</html>
