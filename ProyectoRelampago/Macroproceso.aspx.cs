using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRelampago
{
    public partial class MacroprocesoPage : Page
    {
        private Macroproceso macroproceso = new Macroproceso();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMacroprocesosGrid();
            }
        }

        private void BindMacroprocesosGrid()
        {
            gvMacroprocesos.DataSource = macroproceso.GetAllMacroprocesos();
            gvMacroprocesos.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdMacroproceso.Text) || string.IsNullOrWhiteSpace(txtNombreMacroproceso.Text))
            {
                lblMessage.Text = "Por favor, complete todos los campos.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                macroproceso.AddMacroproceso(new Macroproceso
                {
                    IdMacroproceso = txtIdMacroproceso.Text.Trim(),
                    NombreMacroproceso = txtNombreMacroproceso.Text.Trim()
                });

                lblMessage.Text = "Macroproceso agregado correctamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                BindMacroprocesosGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvMacroprocesos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMacroprocesos.PageIndex = e.NewPageIndex;
            BindMacroprocesosGrid();
        }

        protected void gvMacroprocesos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMacroprocesos.EditIndex = e.NewEditIndex;
            BindMacroprocesosGrid();
        }

        protected void gvMacroprocesos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idMacroproceso = gvMacroprocesos.DataKeys[e.RowIndex].Value.ToString();
            TextBox txtNombreMacroproceso = (TextBox)gvMacroprocesos.Rows[e.RowIndex].FindControl("txtNombreMacroproceso");

            try
            {
                macroproceso.UpdateMacroproceso(new Macroproceso
                {
                    IdMacroproceso = idMacroproceso,
                    NombreMacroproceso = txtNombreMacroproceso.Text.Trim()
                });

                gvMacroprocesos.EditIndex = -1;
                BindMacroprocesosGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvMacroprocesos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMacroprocesos.EditIndex = -1;
            BindMacroprocesosGrid();
        }

        protected void gvMacroprocesos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idMacroproceso = gvMacroprocesos.DataKeys[e.RowIndex].Value.ToString();

            try
            {
                macroproceso.DeleteMacroproceso(idMacroproceso);
                BindMacroprocesosGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
