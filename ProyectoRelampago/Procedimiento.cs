using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoRelampago
{
    public class Procedimiento
    {
        public string IdEje { get; set; }
        public string IdArea { get; set; }
        public string IdDependencia { get; set; }
        public string TipoProcedimiento { get; set; }
        public string Estado { get; set; }
        public string Teletrabajado { get; set; }
        public string IdMacroproceso { get; set; }
        public string IdEjeEstrategico { get; set; }
        public string TipoDocumento { get; set; }
        public string NombreProcedimiento { get; set; }
        public string ApoyoTecnologico { get; set; }
        public string AnioActualizacion { get; set; }

        private string connectionString = ConfigurationManager.ConnectionStrings["Relampago"].ConnectionString;

        public List<Procedimiento> GetAllProcedimientos()
        {
            List<Procedimiento> procedimientos = new List<Procedimiento>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Procedimientos", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Procedimiento procedimiento = new Procedimiento
                    {
                        IdEje = reader["idEje"].ToString(),
                        IdArea = reader["idArea"].ToString(),
                        IdDependencia = reader["idDependencia"].ToString(),
                        TipoProcedimiento = reader["tipoProcedimiento"].ToString(),
                        Estado = reader["estado"].ToString(),
                        Teletrabajado = reader["teletrabajado"].ToString(),
                        IdMacroproceso = reader["idMacroproceso"].ToString(),
                        IdEjeEstrategico = reader["idEjeEstrategico"].ToString(),
                        TipoDocumento = reader["tipoDocumento"].ToString(),
                        NombreProcedimiento = reader["nombreProcedimiento"].ToString(),
                        ApoyoTecnologico = reader["apoyoTecnologico"].ToString(),
                        AnioActualizacion = reader["anioActualizacion"].ToString()
                    };
                    procedimientos.Add(procedimiento);
                }
            }

            return procedimientos;
        }



        public void AddProcedimiento(Procedimiento procedimiento)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Procedimientos (idEje, idArea, idDependencia, tipoProcedimiento, estado, teletrabajado, idMacroproceso, idEjeEstrategico, tipoDocumento, nombreProcedimiento, apoyoTecnologico, anioActualizacion) VALUES (@idEje, @idArea, @idDependencia, @tipoProcedimiento, @estado, @teletrabajado, @idMacroproceso, @idEjeEstrategico, @tipoDocumento, @nombreProcedimiento, @apoyoTecnologico, @anioActualizacion)", conn);

                cmd.Parameters.AddWithValue("@idEje", procedimiento.IdEje);
                cmd.Parameters.AddWithValue("@idArea", procedimiento.IdArea);
                cmd.Parameters.AddWithValue("@idDependencia", procedimiento.IdDependencia);
                cmd.Parameters.AddWithValue("@tipoProcedimiento", procedimiento.TipoProcedimiento);
                cmd.Parameters.AddWithValue("@estado", procedimiento.Estado);
                cmd.Parameters.AddWithValue("@teletrabajado", procedimiento.Teletrabajado);
                cmd.Parameters.AddWithValue("@idMacroproceso", procedimiento.IdMacroproceso);
                cmd.Parameters.AddWithValue("@idEjeEstrategico", procedimiento.IdEjeEstrategico);
                cmd.Parameters.AddWithValue("@tipoDocumento", procedimiento.TipoDocumento);
                cmd.Parameters.AddWithValue("@nombreProcedimiento", procedimiento.NombreProcedimiento);
                cmd.Parameters.AddWithValue("@apoyoTecnologico", procedimiento.ApoyoTecnologico);
                cmd.Parameters.AddWithValue("@anioActualizacion", procedimiento.AnioActualizacion);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProcedimiento(Procedimiento procedimiento)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Procedimientos SET IdArea = @IdArea, IdDependencia = @IdDependencia, TipoProcedimiento = @TipoProcedimiento, Estado = @Estado, Teletrabajado = @Teletrabajado, " +
                               "IdMacroproceso = @IdMacroproceso, IdEjeEstrategico = @IdEjeEstrategico, TipoDocumento = @TipoDocumento, NombreProcedimiento = @NombreProcedimiento, ApoyoTecnologico = @ApoyoTecnologico, " +
                               "AnioActualizacion = @AnioActualizacion WHERE IdEje = @IdEje";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdEje", procedimiento.IdEje);
                cmd.Parameters.AddWithValue("@IdArea", procedimiento.IdArea);
                cmd.Parameters.AddWithValue("@IdDependencia", procedimiento.IdDependencia);
                cmd.Parameters.AddWithValue("@TipoProcedimiento", procedimiento.TipoProcedimiento);
                cmd.Parameters.AddWithValue("@Estado", procedimiento.Estado);
                cmd.Parameters.AddWithValue("@Teletrabajado", procedimiento.Teletrabajado);
                cmd.Parameters.AddWithValue("@IdMacroproceso", procedimiento.IdMacroproceso);
                cmd.Parameters.AddWithValue("@IdEjeEstrategico", procedimiento.IdEjeEstrategico);
                cmd.Parameters.AddWithValue("@TipoDocumento", procedimiento.TipoDocumento);
                cmd.Parameters.AddWithValue("@NombreProcedimiento", procedimiento.NombreProcedimiento);
                cmd.Parameters.AddWithValue("@ApoyoTecnologico", procedimiento.ApoyoTecnologico);
                cmd.Parameters.AddWithValue("@AnioActualizacion", procedimiento.AnioActualizacion);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProcedimiento(string idEje)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Procedimientos WHERE idEje = @idEje", conn);
                cmd.Parameters.AddWithValue("@idEje", idEje);
                cmd.ExecuteNonQuery();
            }
        }
    }
}