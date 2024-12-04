using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRelampago
{
    public partial class Dependencia1 : Page
    {
        private Dependencia dependencia = new Dependencia();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDependenciasGrid();
            }
        }

        private void BindDependenciasGrid()
        {
            gvDependencias.DataSource = dependencia.GetAllDependencias();
            gvDependencias.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdDependencia.Text) || string.IsNullOrWhiteSpace(txtNombreDependencia.Text))
            {
                lblMessage.Text = "Por favor, complete todos los campos.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                dependencia.AddDependencia(new Dependencia
                {
                    IdDependencia = txtIdDependencia.Text.Trim(),
                    NombreDependencia = txtNombreDependencia.Text.Trim()
                });

                lblMessage.Text = "Dependencia agregada correctamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                BindDependenciasGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvDependencias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDependencias.PageIndex = e.NewPageIndex;
            BindDependenciasGrid();
        }

        protected void gvDependencias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDependencias.EditIndex = e.NewEditIndex;
            BindDependenciasGrid();
        }

        protected void gvDependencias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idDependencia = gvDependencias.DataKeys[e.RowIndex].Value.ToString();
            TextBox txtNombreDependencia = (TextBox)gvDependencias.Rows[e.RowIndex].FindControl("txtNombreDependencia");

            try
            {
                dependencia.UpdateDependencia(new Dependencia
                {
                    IdDependencia = idDependencia,
                    NombreDependencia = txtNombreDependencia.Text.Trim()
                });

                gvDependencias.EditIndex = -1;
                BindDependenciasGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvDependencias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDependencias.EditIndex = -1;
            BindDependenciasGrid();
        }

        protected void gvDependencias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idDependencia = gvDependencias.DataKeys[e.RowIndex].Value.ToString();

            try
            {
                dependencia.DeleteDependencia(idDependencia);
                BindDependenciasGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
