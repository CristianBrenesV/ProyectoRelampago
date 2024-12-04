using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRelampago
{
    public partial class AreaPage : Page
    {
        private Area area = new Area();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAreasGrid();
            }
        }

        private void BindAreasGrid()
        {
            gvAreas.DataSource = area.GetAllAreas();
            gvAreas.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdArea.Text) || string.IsNullOrWhiteSpace(txtNombreArea.Text))
            {
                lblMessage.Text = "Por favor, complete todos los campos.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                area.AddArea(new Area
                {
                    IdArea = txtIdArea.Text.Trim(),
                    NombreArea = txtNombreArea.Text.Trim()
                });

                lblMessage.Text = "Área agregada correctamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                BindAreasGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvAreas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAreas.PageIndex = e.NewPageIndex;
            BindAreasGrid();
        }

        protected void gvAreas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAreas.EditIndex = e.NewEditIndex;
            BindAreasGrid();
        }

        protected void gvAreas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idArea = gvAreas.DataKeys[e.RowIndex].Value.ToString();
            TextBox txtNombreArea = (TextBox)gvAreas.Rows[e.RowIndex].FindControl("txtNombreArea");

            try
            {
                area.UpdateArea(new Area
                {
                    IdArea = idArea,
                    NombreArea = txtNombreArea.Text.Trim()
                });

                gvAreas.EditIndex = -1;
                BindAreasGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvAreas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAreas.EditIndex = -1;
            BindAreasGrid();
        }

        protected void gvAreas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idArea = gvAreas.DataKeys[e.RowIndex].Value.ToString();

            try
            {
                area.DeleteArea(idArea);
                BindAreasGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
