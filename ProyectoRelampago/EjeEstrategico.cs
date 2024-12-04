using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoRelampago
{
    public class EjeEstrategico
    {
        public string IdEje { get; set; }
        public string NombreEjeEstrategico { get; set; }

        private string connectionString = ConfigurationManager.ConnectionStrings["Relampago"].ConnectionString;

        public List<EjeEstrategico> GetAllEjesEstrategicos()
        {
            List<EjeEstrategico> ejesEstrategicos = new List<EjeEstrategico>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Eje_Estrategico", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ejesEstrategicos.Add(new EjeEstrategico
                        {
                            IdEje = reader["IdEje"].ToString(),
                            NombreEjeEstrategico = reader["NombreEjeEstrategico"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los Ejes Estratégicos: " + ex.Message);
            }

            return ejesEstrategicos;
        }

        public void AddEjeEstrategico(EjeEstrategico ejeEstrategico)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Eje_Estrategico (IdEje, NombreEjeEstrategico) VALUES (@IdEje, @NombreEjeEstrategico)", conn);
                    cmd.Parameters.AddWithValue("@IdEje", ejeEstrategico.IdEje);
                    cmd.Parameters.AddWithValue("@NombreEjeEstrategico", ejeEstrategico.NombreEjeEstrategico);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el Eje Estratégico: " + ex.Message);
            }
        }

        public void UpdateEjeEstrategico(EjeEstrategico ejeEstrategico)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Eje_Estrategico SET NombreEjeEstrategico = @NombreEjeEstrategico WHERE IdEje = @IdEje", conn);
                    cmd.Parameters.AddWithValue("@IdEje", ejeEstrategico.IdEje);
                    cmd.Parameters.AddWithValue("@NombreEjeEstrategico", ejeEstrategico.NombreEjeEstrategico);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Eje Estratégico: " + ex.Message);
            }
        }

        public void DeleteEjeEstrategico(string idEje)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Eje_Estrategico WHERE IdEje = @IdEje", conn);
                    cmd.Parameters.AddWithValue("@IdEje", idEje);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Eje Estratégico: " + ex.Message);
            }
        }
    }
}
