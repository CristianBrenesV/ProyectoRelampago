<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dependencia.aspx.cs" Inherits="ProyectoRelampago.Dependencia1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Dependencias</title>
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
            <h2>Dependencias</h2>
            <asp:Label ID="lblMessage" runat="server" Text="" EnableViewState="False"></asp:Label>
            <asp:GridView ID="gvDependencias" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                DataKeyNames="IdDependencia"
                OnPageIndexChanging="gvDependencias_PageIndexChanging"
                OnRowEditing="gvDependencias_RowEditing" OnRowDeleting="gvDependencias_RowDeleting"
                OnRowUpdating="gvDependencias_RowUpdating" OnRowCancelingEdit="gvDependencias_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="IdDependencia" HeaderText="IdDependencia" ReadOnly="True" />
                    <asp:TemplateField HeaderText="NombreDependencia">
                        <ItemTemplate>
                            <asp:Label ID="lblNombreDependencia" runat="server" Text='<%# Eval("NombreDependencia") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreDependencia" runat="server" Text='<%# Bind("NombreDependencia") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <div>
                <h3>Agregar Dependencia</h3>
                <label>IdDependencia:</label>
                <asp:TextBox ID="txtIdDependencia" runat="server"></asp:TextBox>
                <br />
                <label>NombreDependencia:</label>
                <asp:TextBox ID="txtNombreDependencia" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnAdd" runat="server" Text="Agregar Dependencia" OnClick="btnAdd_Click" />
            </div>
        </div>
    </form>
</body>
</html>
