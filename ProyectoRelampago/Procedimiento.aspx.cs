using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRelampago
{
    public partial class ProcedimientoPage : Page
    {
        Procedimiento procedimientoService = new Procedimiento();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar procedimientos al iniciar la página
                LoadProcedimientos();
            }
        }

        // Método para cargar los procedimientos en el GridView
        private void LoadProcedimientos()
        {
            List<Procedimiento> procedimientos = procedimientoService.GetAllProcedimientos();
            gvProcedimientos.DataSource = procedimientos;
            gvProcedimientos.DataBind();
        }

        // Método para agregar un nuevo procedimiento
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Procedimiento nuevoProcedimiento = new Procedimiento
            {
                IdEje = txtIdEje.Text,
                IdArea = txtIdArea.Text,
                IdDependencia = txtIdDependencia.Text,
                TipoProcedimiento = txtTipoProcedimiento.Text,
                Estado = txtEstado.Text,
                Teletrabajado = txtTeletrabajado.Text,
                IdMacroproceso = txtIdMacroproceso.Text,
                IdEjeEstrategico = txtIdEjeEstrategico.Text,
                TipoDocumento = txtTipoDocumento.Text,
                NombreProcedimiento = txtNombreProcedimiento.Text,
                ApoyoTecnologico = txtApoyoTecnologico.Text,
                AnioActualizacion = txtAnioActualizacion.Text
            };

            try
            {
                procedimientoService.AddProcedimiento(nuevoProcedimiento);
                lblMessage.Text = "Procedimiento agregado con éxito.";
                lblMessage.CssClass = "message success";
                ClearForm();
                LoadProcedimientos();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al agregar el procedimiento: " + ex.Message;
                lblMessage.CssClass = "message error";
            }
        }

        // Método para limpiar el formulario
        private void ClearForm()
        {
            txtIdEje.Text = "";
            txtIdArea.Text = "";
            txtIdDependencia.Text = "";
            txtNombreProcedimiento.Text = "";
            txtTipoProcedimiento.Text = "";
            txtEstado.Text = "";
            txtTeletrabajado.Text = "";
            txtIdMacroproceso.Text = "";
            txtIdEjeEstrategico.Text = "";
            txtTipoDocumento.Text = "";
            txtApoyoTecnologico.Text = "";
            txtAnioActualizacion.Text = "";
        }

        // Método para manejar la edición de un procedimiento en el GridView
        protected void gvProcedimientos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProcedimientos.EditIndex = e.NewEditIndex;
            LoadProcedimientos();
        }

        // Método para cancelar la edición en el GridView
        protected void gvProcedimientos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProcedimientos.EditIndex = -1;
            LoadProcedimientos();
        }

        // Método para actualizar un procedimiento editado
        protected void gvProcedimientos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvProcedimientos.Rows[e.RowIndex];
            string idEje = gvProcedimientos.DataKeys[e.RowIndex].Value.ToString();

            Procedimiento procedimientoEditado = new Procedimiento
            {
                IdEje = idEje,
                IdArea = (row.FindControl("txtIdArea") as TextBox).Text,
                IdDependencia = (row.FindControl("txtIdDependencia") as TextBox).Text,
                TipoProcedimiento = (row.FindControl("txtTipoProcedimiento") as TextBox).Text,
                Estado = (row.FindControl("txtEstado") as TextBox).Text,
                Teletrabajado = (row.FindControl("txtTeletrabajado") as TextBox).Text,
                IdMacroproceso = (row.FindControl("txtIdMacroproceso") as TextBox).Text,
                IdEjeEstrategico = (row.FindControl("txtIdEjeEstrategico") as TextBox).Text,
                TipoDocumento = (row.FindControl("txtTipoDocumento") as TextBox).Text,
                NombreProcedimiento = (row.FindControl("txtNombreProcedimiento") as TextBox).Text,
                ApoyoTecnologico = (row.FindControl("txtApoyoTecnologico") as TextBox).Text,
                AnioActualizacion = (row.FindControl("txtAnioActualizacion") as TextBox).Text
            };

            try
            {
                procedimientoService.UpdateProcedimiento(procedimientoEditado);
                gvProcedimientos.EditIndex = -1;
                LoadProcedimientos();
                lblMessage.Text = "Procedimiento actualizado con éxito.";
                lblMessage.CssClass = "message success";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al actualizar el procedimiento: " + ex.Message;
                lblMessage.CssClass = "message error";
            }
        }

        // Método para eliminar un procedimiento
        protected void gvProcedimientos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idEje = gvProcedimientos.DataKeys[e.RowIndex].Value.ToString();

            try
            {
                procedimientoService.DeleteProcedimiento(idEje);
                LoadProcedimientos();
                lblMessage.Text = "Procedimiento eliminado con éxito.";
                lblMessage.CssClass = "message success";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error al eliminar el procedimiento: " + ex.Message;
                lblMessage.CssClass = "message error";
            }
        }

        // Método para manejar el cambio de página en el GridView
        protected void gvProcedimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProcedimientos.PageIndex = e.NewPageIndex;
            LoadProcedimientos();
        }
    }
}
