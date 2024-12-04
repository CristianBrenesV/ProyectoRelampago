using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoRelampago
{
    public partial class EjeEstrategico1 : Page
    {
        private EjeEstrategico ejeEstrategico = new EjeEstrategico();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEjesEstrategicosGrid();
            }
        }

        private void BindEjesEstrategicosGrid()
        {
            gvEjesEstrategicos.DataSource = ejeEstrategico.GetAllEjesEstrategicos();
            gvEjesEstrategicos.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEje.Text) || string.IsNullOrWhiteSpace(txtNombreEjeEstrategico.Text))
            {
                lblMessage.Text = "Por favor, complete todos los campos.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                ejeEstrategico.AddEjeEstrategico(new EjeEstrategico
                {
                    IdEje = txtIdEje.Text.Trim(),
                    NombreEjeEstrategico = txtNombreEjeEstrategico.Text.Trim()
                });

                lblMessage.Text = "Eje Estratégico agregado correctamente.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                BindEjesEstrategicosGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvEjesEstrategicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEjesEstrategicos.PageIndex = e.NewPageIndex;
            BindEjesEstrategicosGrid();
        }

        protected void gvEjesEstrategicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEjesEstrategicos.EditIndex = e.NewEditIndex;
            BindEjesEstrategicosGrid();
        }

        protected void gvEjesEstrategicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idEje = gvEjesEstrategicos.DataKeys[e.RowIndex].Value.ToString();
            TextBox txtNombreEjeEstrategico = (TextBox)gvEjesEstrategicos.Rows[e.RowIndex].FindControl("txtNombreEjeEstrategico");

            try
            {
                ejeEstrategico.UpdateEjeEstrategico(new EjeEstrategico
                {
                    IdEje = idEje,
                    NombreEjeEstrategico = txtNombreEjeEstrategico.Text.Trim()
                });

                gvEjesEstrategicos.EditIndex = -1;
                BindEjesEstrategicosGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvEjesEstrategicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEjesEstrategicos.EditIndex = -1;
            BindEjesEstrategicosGrid();
        }

        protected void gvEjesEstrategicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idEje = gvEjesEstrategicos.DataKeys[e.RowIndex].Value.ToString();

            try
            {
                ejeEstrategico.DeleteEjeEstrategico(idEje);
                BindEjesEstrategicosGrid();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
