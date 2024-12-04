<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjeEstrategico.aspx.cs" Inherits="ProyectoRelampago.EjeEstrategico1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Ejes Estratégicos</title>
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
            <h2>Ejes Estratégicos</h2>
            <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="False"></asp:Label>
            <asp:GridView ID="gvEjesEstrategicos" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                DataKeyNames="IdEje"
                OnPageIndexChanging="gvEjesEstrategicos_PageIndexChanging"
                OnRowEditing="gvEjesEstrategicos_RowEditing" OnRowDeleting="gvEjesEstrategicos_RowDeleting"
                OnRowUpdating="gvEjesEstrategicos_RowUpdating" OnRowCancelingEdit="gvEjesEstrategicos_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="IdEje" HeaderText="IdEje" ReadOnly="True" />
                    <asp:TemplateField HeaderText="NombreEjeEstrategico">
                        <ItemTemplate>
                            <asp:Label ID="lblNombreEjeEstrategico" runat="server" Text='<%# Eval("NombreEjeEstrategico") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreEjeEstrategico" runat="server" Text='<%# Bind("NombreEjeEstrategico") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <div>
                <h3>Agregar Eje Estratégico</h3>
                <label>IdEje:</label>
                <asp:TextBox ID="txtIdEje" runat="server"></asp:TextBox>
                <br />
                <label>NombreEjeEstrategico:</label>
                <asp:TextBox ID="txtNombreEjeEstrategico" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Agregar Eje Estratégico" OnClick="btnAdd_Click" />
            </div>
        </div>
    </form>
</body>
</html>
