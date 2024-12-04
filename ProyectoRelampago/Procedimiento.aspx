<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Procedimiento.aspx.cs" Inherits="ProyectoRelampago.ProcedimientoPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Procedimientos</title>
        <link href="Content/Procedimiento.css" rel="stylesheet" type="text/css" />
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
        <div class="form-container">
            <h2>Gestión de Procedimientos</h2>

            <!-- Mensajes de éxito o error -->
            <asp:Label ID="lblMessage" runat="server" CssClass="message" Text="" EnableViewState="False"></asp:Label>

            <!-- Formulario para agregar un procedimiento -->
            <div>
                <label for="txtIdEje">IdEje:</label>
                <asp:TextBox ID="txtIdEje" runat="server"></asp:TextBox>

                <label for="txtIdArea">IdArea:</label>
                <asp:TextBox ID="txtIdArea" runat="server"></asp:TextBox>

                <label for="txtIdDependencia">IdDependencia:</label>
                <asp:TextBox ID="txtIdDependencia" runat="server"></asp:TextBox>

                <label for="txtTipoProcedimiento">Tipo Procedimiento:</label>
                <asp:TextBox ID="txtTipoProcedimiento" runat="server"></asp:TextBox>

                <label for="txtEstado">Estado:</label>
                <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>

                <label for="txtTeletrabajado">Teletrabajado:</label>
                <asp:TextBox ID="txtTeletrabajado" runat="server"></asp:TextBox>

                <label for="txtIdMacroproceso">Id Macroproceso:</label>
                <asp:TextBox ID="txtIdMacroproceso" runat="server"></asp:TextBox>

                <label for="txtIdEjeEstrategico">Id Eje Estratégico:</label>
                <asp:TextBox ID="txtIdEjeEstrategico" runat="server"></asp:TextBox>

                <label for="txtTipoDocumento">Tipo Documento:</label>
                <asp:TextBox ID="txtTipoDocumento" runat="server"></asp:TextBox>

                <label for="txtNombreProcedimiento">Nombre Procedimiento:</label>
                <asp:TextBox ID="txtNombreProcedimiento" runat="server"></asp:TextBox>

                <label for="txtApoyoTecnologico">Apoyo Tecnológico:</label>
                <asp:TextBox ID="txtApoyoTecnologico" runat="server"></asp:TextBox>

                <label for="txtAnioActualizacion">Año Actualización:</label>
                <asp:TextBox ID="txtAnioActualizacion" runat="server"></asp:TextBox>

                <asp:Button ID="btnAdd" runat="server" Text="Agregar Procedimiento" OnClick="btnAdd_Click" />
            </div>
        </div>

        <!-- GridView para mostrar, editar y eliminar procedimientos -->
        <div class="grid-container">
            <asp:GridView ID="gvProcedimientos" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                DataKeyNames="IdEje"
                OnPageIndexChanging="gvProcedimientos_PageIndexChanging"
                OnRowEditing="gvProcedimientos_RowEditing" OnRowDeleting="gvProcedimientos_RowDeleting"
                OnRowUpdating="gvProcedimientos_RowUpdating" OnRowCancelingEdit="gvProcedimientos_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="IdEje" HeaderText="IdEje" SortExpression="IdEje" ReadOnly="True" />
                   
                     <asp:TemplateField HeaderText="Id Area">
                        <ItemTemplate>
                            <asp:Label ID="lblIdArea" runat="server" Text='<%# Eval("IdArea") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdArea" runat="server" Text='<%# Bind("IdArea") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Id Dependencia">
                        <ItemTemplate>
                            <asp:Label ID="lblIdDependencia" runat="server" Text='<%# Eval("IdDependencia") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdDependencia" runat="server" Text='<%# Bind("IdDependencia") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tipo Procedimiento">
                        <ItemTemplate>
                            <asp:Label ID="lblTipoProcedimiento" runat="server" Text='<%# Eval("TipoProcedimiento") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTipoProcedimiento" runat="server" Text='<%# Bind("TipoProcedimiento") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEstado" runat="server" Text='<%# Bind("Estado") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Teletrabajado">
                        <ItemTemplate>
                            <asp:Label ID="lblTeletrabajado" runat="server" Text='<%# Eval("Teletrabajado") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTeletrabajado" runat="server" Text='<%# Bind("Teletrabajado") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Id Macroproceso">
                        <ItemTemplate>
                            <asp:Label ID="lblIdMacroproceso" runat="server" Text='<%# Eval("IdMacroproceso") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdMacroproceso" runat="server" Text='<%# Bind("IdMacroproceso") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Id Eje Estratégico">
                        <ItemTemplate>
                            <asp:Label ID="lblIdEjeEstrategico" runat="server" Text='<%# Eval("IdEjeEstrategico") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdEjeEstrategico" runat="server" Text='<%# Bind("IdEjeEstrategico") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tipo Documento">
                        <ItemTemplate>
                            <asp:Label ID="lblTipoDocumento" runat="server" Text='<%# Eval("TipoDocumento") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTipoDocumento" runat="server" Text='<%# Bind("TipoDocumento") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre Procedimiento">
                        <ItemTemplate>
                            <asp:Label ID="lblNombreProcedimiento" runat="server" Text='<%# Eval("NombreProcedimiento") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNombreProcedimiento" runat="server" Text='<%# Bind("NombreProcedimiento") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apoyo Tecnológico">
                        <ItemTemplate>
                            <asp:Label ID="lblApoyoTecnologico" runat="server" Text='<%# Eval("ApoyoTecnologico") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtApoyoTecnologico" runat="server" Text='<%# Bind("ApoyoTecnologico") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Año Actualización">
                        <ItemTemplate>
                            <asp:Label ID="lblAnioActualizacion" runat="server" Text='<%# Eval("AnioActualizacion") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAnioActualizacion" runat="server" Text='<%# Bind("AnioActualizacion") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
