using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoRelampago
{
    public class Area
    {
        public string IdArea { get; set; }
        public string NombreArea { get; set; }

        private string connectionString = ConfigurationManager.ConnectionStrings["Relampago"].ConnectionString;

        // Obtener todas las Áreas
        public List<Area> GetAllAreas()
        {
            List<Area> areas = new List<Area>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Area", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Area area = new Area
                    {
                        IdArea = reader["IdArea"].ToString(),
                        NombreArea = reader["NombreArea"].ToString()
                    };
                    areas.Add(area);
                }
            }

            return areas;
        }

        // Agregar una nueva Área
        public void AddArea(Area area)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Area (IdArea, NombreArea) VALUES (@IdArea, @NombreArea)", conn);

                cmd.Parameters.AddWithValue("@IdArea", area.IdArea);
                cmd.Parameters.AddWithValue("@NombreArea", area.NombreArea);

                cmd.ExecuteNonQuery();
            }
        }

        // Actualizar una Área existente
        public void UpdateArea(Area area)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Area SET NombreArea = @NombreArea WHERE IdArea = @IdArea";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdArea", area.IdArea);
                cmd.Parameters.AddWithValue("@NombreArea", area.NombreArea);

                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar una Área
        public void DeleteArea(string idArea)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Area WHERE IdArea = @IdArea", conn);
                cmd.Parameters.AddWithValue("@IdArea", idArea);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
