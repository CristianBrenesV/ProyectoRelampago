using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;  
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace ProyectoRelampago
{
    public partial class Inicio : System.Web.UI.Page
    {
        // Obtener el connectionString desde web.config
        private string connectionString = ConfigurationManager.ConnectionStrings["Relampago"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarFiltros();
                ActualizarConteos(); 
                CargarGrid();      
            }
        }

        private void CargarFiltros()
        {
            // Cargar filtro Eje Estratégico
            ddlEje.DataSource = ObtenerDatosFiltro("SELECT idEje, nombreEjeEstrategico FROM Relampago.eje_estrategico");
            ddlEje.DataTextField = "nombreEjeEstrategico";
            ddlEje.DataValueField = "idEje";
            ddlEje.DataBind();
            ddlEje.Items.Insert(0, new ListItem("Seleccionar Eje", ""));

            // Cargar filtro Area
            ddlArea.DataSource = ObtenerDatosFiltro("SELECT idArea, nombreArea FROM Relampago.area");
            ddlArea.DataTextField = "nombreArea";
            ddlArea.DataValueField = "idArea";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("Seleccionar Área", ""));

            // Cargar filtro Dependencia
            ddlDependencia.DataSource = ObtenerDatosFiltro("SELECT idDependencia, nombreDependencia FROM Relampago.dependencia");
            ddlDependencia.DataTextField = "nombreDependencia";
            ddlDependencia.DataValueField = "idDependencia";
            ddlDependencia.DataBind();
            ddlDependencia.Items.Insert(0, new ListItem("Seleccionar Dependencia", ""));

            // Cargar filtro Macroproceso
            ddlMacroproceso.DataSource = ObtenerDatosFiltro("SELECT idMacroproceso, nombreMacroproceso FROM Relampago.macroproceso");
            ddlMacroproceso.DataTextField = "nombreMacroproceso";
            ddlMacroproceso.DataValueField = "idMacroproceso";
            ddlMacroproceso.DataBind();
            ddlMacroproceso.Items.Insert(0, new ListItem("Seleccionar Macroproceso", ""));

            // Cargar filtro Tipo Procedimiento
            ddlTipoProcedimiento.DataSource = ObtenerDatosFiltro("SELECT DISTINCT tipoProcedimiento FROM Relampago.Procedimientos");
            ddlTipoProcedimiento.DataTextField = "tipoProcedimiento";
            ddlTipoProcedimiento.DataValueField = "tipoProcedimiento";
            ddlTipoProcedimiento.DataBind();
            ddlTipoProcedimiento.Items.Insert(0, new ListItem("Seleccionar Tipo Procedimiento", ""));

            // Cargar filtro Estado
            ddlEstado.DataSource = ObtenerDatosFiltro("SELECT DISTINCT estado FROM Relampago.Procedimientos");
            ddlEstado.DataTextField = "estado";
            ddlEstado.DataValueField = "estado";
            ddlEstado.DataBind();
            ddlEstado.Items.Insert(0, new ListItem("Seleccionar Estado", ""));

            // Cargar filtro Teletrabajado
            ddlTeletrabajado.DataSource = ObtenerDatosFiltro("SELECT DISTINCT teletrabajado FROM Relampago.Procedimientos");
            ddlTeletrabajado.DataTextField = "teletrabajado";
            ddlTeletrabajado.DataValueField = "teletrabajado";
            ddlTeletrabajado.DataBind();
            ddlTeletrabajado.Items.Insert(0, new ListItem("Seleccionar Teletrabajado", ""));

            // Cargar filtro Año Actualización
            ddlAñoActualizacion.DataSource = ObtenerDatosFiltro("SELECT DISTINCT anioActualizacion FROM Relampago.Procedimientos");
            ddlAñoActualizacion.DataTextField = "anioActualizacion";
            ddlAñoActualizacion.DataValueField = "anioActualizacion";
            ddlAñoActualizacion.DataBind();
            ddlAñoActualizacion.Items.Insert(0, new ListItem("Seleccionar Año", ""));

            // Cargar filtro Eje Estratégico (nuevo)
            ddlEjeEstrategico.DataSource = ObtenerDatosFiltro("SELECT DISTINCT nombreEjeEstrategico FROM Relampago.eje_estrategico");
            ddlEjeEstrategico.DataTextField = "nombreEjeEstrategico";
            ddlEjeEstrategico.DataValueField = "nombreEjeEstrategico";
            ddlEjeEstrategico.DataBind();
            ddlEjeEstrategico.Items.Insert(0, new ListItem("Seleccionar Eje Estratégico", ""));

            // Cargar filtro Apoyo Tecnológico (nuevo)
            ddlApoyoTecnologico.DataSource = ObtenerDatosFiltro("SELECT DISTINCT apoyoTecnologico FROM Relampago.Procedimientos");
            ddlApoyoTecnologico.DataTextField = "apoyoTecnologico";
            ddlApoyoTecnologico.DataValueField = "apoyoTecnologico";
            ddlApoyoTecnologico.DataBind();
            ddlApoyoTecnologico.Items.Insert(0, new ListItem("Seleccionar Apoyo Tecnológico", ""));
        }


        private void ActualizarConteos()
        {
            lblConteoEje.Text = ObtenerConteo("eje_estrategico", ddlEje.SelectedValue).ToString();
            lblConteoArea.Text = ObtenerConteo("area", ddlArea.SelectedValue).ToString();
            lblConteoDependencia.Text = ObtenerConteo("dependencia", ddlDependencia.SelectedValue).ToString();
            lblConteoTipoProcedimiento.Text = ObtenerConteo("tipoProcedimiento", ddlTipoProcedimiento.SelectedValue).ToString();
            lblConteoEstado.Text = ObtenerConteo("estado", ddlEstado.SelectedValue).ToString();
            lblConteoTeletrabajado.Text = ObtenerConteo("teletrabajado", ddlTeletrabajado.SelectedValue).ToString();
            lblConteoMacroproceso.Text = ObtenerConteo("macroproceso", ddlMacroproceso.SelectedValue).ToString();
            lblConteoEjeEstrategico.Text = ObtenerConteo("eje_estrategico", ddlEjeEstrategico.SelectedValue).ToString();
            lblConteoApoyoTecnologico.Text = ObtenerConteo("apoyoTecnologico", ddlApoyoTecnologico.SelectedValue).ToString();
            lblConteoAño.Text = ObtenerConteo("anio", ddlAñoActualizacion.SelectedValue).ToString();
        }


        private int ObtenerConteo(string categoria, string valorSeleccionado)
        {
            int conteo = 0;
            string query = "";

            // Aquí generamos una consulta dinámica basada en la categoría seleccionada
            switch (categoria)
            {
                case "estado":
                    query = "SELECT COUNT(*) FROM Relampago.Procedimientos WHERE estado = @Estado";
                    break;

                case "eje_estrategico":
                    query = "SELECT COUNT(*) FROM Relampago.Procedimientos WHERE idEje = @Eje";
                    break;

                case "area":
                    query = "SELECT COUNT(*) FROM Relampago.Procedimientos WHERE idArea = @Area";
                    break;

                case "dependencia":
                    query = "SELECT COUNT(*) FROM Relampago.Procedimientos WHERE idDependencia = @Dependencia";
                    break;

                case "tipoProcedimiento":
                    query = "SELECT COUNT(*) FROM Relampago.Procedimientos WHERE tipoProcedimiento = @TipoProcedimiento";
                    break;

                case "teletrabajado":
                    query = "SELECT COUNT(*) FROM Relampago.Procedimientos WHERE teletrabajado = @Teletrabajado";
                    break;

                case "macroproceso":
                    query = "SELECT COUNT(*) FROM Relampago.Procedimientos WHERE idMacroproceso = @Macroproceso";
                    break;

                case "apoyoTecnologico":
                    query = "SELECT COUNT(*) FROM Relampago.Procedimientos WHERE apoyoTecnologico = @ApoyoTecnologico";
                    break;

                case "anio":
                    query = "SELECT COUNT(*) FROM Relampago.Procedimientos WHERE anioActualizacion = @AnioActualizacion";
                    break;

                default:
                    return 0;
            }

            // Ejecutar la consulta y devolver el conteo
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                // Agregar solo el parámetro correspondiente según la categoría seleccionada
                switch (categoria)
                {
                    case "estado":
                        cmd.Parameters.AddWithValue("@Estado", valorSeleccionado);
                        break;

                    case "eje_estrategico":
                        cmd.Parameters.AddWithValue("@Eje", valorSeleccionado);
                        break;

                    case "area":
                        cmd.Parameters.AddWithValue("@Area", valorSeleccionado);
                        break;

                    case "dependencia":
                        cmd.Parameters.AddWithValue("@Dependencia", valorSeleccionado);
                        break;

                    case "tipoProcedimiento":
                        cmd.Parameters.AddWithValue("@TipoProcedimiento", valorSeleccionado);
                        break;

                    case "teletrabajado":
                        cmd.Parameters.AddWithValue("@Teletrabajado", valorSeleccionado);
                        break;

                    case "macroproceso":
                        cmd.Parameters.AddWithValue("@Macroproceso", valorSeleccionado);
                        break;

                    case "apoyoTecnologico":
                        cmd.Parameters.AddWithValue("@ApoyoTecnologico", valorSeleccionado);
                        break;

                    case "anio":
                        cmd.Parameters.AddWithValue("@AnioActualizacion", valorSeleccionado);
                        break;
                }

                conn.Open();
                conteo = (int)cmd.ExecuteScalar(); // Ejecuta el query y obtiene el conteo
                conn.Close();
            }

            return conteo;
        }



        // Método que se llama cuando cambia el filtro (puedes agregar esta lógica en los eventos de selección de cada DropDown)
        protected void Filtro_Cambiado(object sender, EventArgs e)
        {
            ActualizarConteos();
            CargarGrid(); // Recargar el GridView con los nuevos filtros
        }

        private DataTable ObtenerDatosFiltro(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        private void CargarGrid()
        {
            // Construir la consulta SQL
            string query = "SELECT Procedimientos.idEje, area.nombreArea, dependencia.nombreDependencia, " +
                           "Procedimientos.tipoProcedimiento, Procedimientos.estado, Procedimientos.teletrabajado, " +
                           "macroproceso.nombreMacroproceso, eje_estrategico.nombreEjeEstrategico, Procedimientos.tipoDocumento, " +
                           "Procedimientos.nombreProcedimiento, Procedimientos.apoyoTecnologico, Procedimientos.anioActualizacion " +
                           "FROM Relampago.Procedimientos " +
                           "INNER JOIN Relampago.area ON area.idArea = Procedimientos.idArea " +
                           "INNER JOIN Relampago.dependencia ON dependencia.idDependencia = Procedimientos.idDependencia " +
                           "INNER JOIN Relampago.eje_estrategico ON eje_estrategico.idEje = Procedimientos.idEje " +
                           "INNER JOIN Relampago.macroproceso ON macroproceso.idMacroproceso = Procedimientos.idMacroproceso";

            // Filtros adicionales según lo que el usuario seleccione
            if (!string.IsNullOrEmpty(ddlEje.SelectedValue))
                query += " AND Procedimientos.idEje = @Eje";

            if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
                query += " AND Procedimientos.idArea = @Area";

            if (!string.IsNullOrEmpty(ddlDependencia.SelectedValue))
                query += " AND Procedimientos.idDependencia = @Dependencia";

            if (!string.IsNullOrEmpty(ddlMacroproceso.SelectedValue))
                query += " AND Procedimientos.idMacroproceso = @Macroproceso";

            if (!string.IsNullOrEmpty(ddlTipoProcedimiento.SelectedValue))
                query += " AND Procedimientos.tipoProcedimiento = @TipoProcedimiento";

            if (!string.IsNullOrEmpty(ddlEstado.SelectedValue))
                query += " AND Procedimientos.estado = @Estado";

            if (!string.IsNullOrEmpty(ddlTeletrabajado.SelectedValue))
                query += " AND Procedimientos.teletrabajado = @Teletrabajado";

            if (!string.IsNullOrEmpty(ddlAñoActualizacion.SelectedValue))
                query += " AND Procedimientos.anioActualizacion = @AñoActualizacion";

            // Ejecutar la consulta y llenar el GridView
            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            da.SelectCommand.Parameters.AddWithValue("@Eje", ddlEje.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@Area", ddlArea.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@Dependencia", ddlDependencia.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@Macroproceso", ddlMacroproceso.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@TipoProcedimiento", ddlTipoProcedimiento.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@Estado", ddlEstado.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@Teletrabajado", ddlTeletrabajado.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@AñoActualizacion", ddlAñoActualizacion.SelectedValue);

            DataTable dt = new DataTable();
            da.Fill(dt);

            // Enlazar el GridView con los datos
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // Manejadores de eventos
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Cambiar la página
            GridView1.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = (DataTable)GridView1.DataSource;
            if (dt != null)
            {
                // Ordenar los datos
                DataView dv = dt.DefaultView;
                dv.Sort = e.SortExpression + " " + (e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC");
                GridView1.DataSource = dv;
                GridView1.DataBind();
            }
        }
    }
}
