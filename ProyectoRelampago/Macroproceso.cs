using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoRelampago
{
    public class Macroproceso
    {
        public string IdMacroproceso { get; set; }
        public string NombreMacroproceso { get; set; }

        private string connectionString = ConfigurationManager.ConnectionStrings["Relampago"].ConnectionString;

        // Obtener todos los Macroprocesos
        public List<Macroproceso> GetAllMacroprocesos()
        {
            List<Macroproceso> macroprocesos = new List<Macroproceso>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Macroproceso", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Macroproceso macroproceso = new Macroproceso
                    {
                        IdMacroproceso = reader["IdMacroproceso"].ToString(),
                        NombreMacroproceso = reader["NombreMacroproceso"].ToString()
                    };
                    macroprocesos.Add(macroproceso);
                }
            }

            return macroprocesos;
        }

        // Agregar un nuevo Macroproceso
        public void AddMacroproceso(Macroproceso macroproceso)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Macroproceso (IdMacroproceso, NombreMacroproceso) VALUES (@IdMacroproceso, @NombreMacroproceso)", conn);

                cmd.Parameters.AddWithValue("@IdMacroproceso", macroproceso.IdMacroproceso);
                cmd.Parameters.AddWithValue("@NombreMacroproceso", macroproceso.NombreMacroproceso);

                cmd.ExecuteNonQuery();
            }
        }

        // Actualizar un Macroproceso existente
        public void UpdateMacroproceso(Macroproceso macroproceso)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Macroproceso SET NombreMacroproceso = @NombreMacroproceso WHERE IdMacroproceso = @IdMacroproceso";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdMacroproceso", macroproceso.IdMacroproceso);
                cmd.Parameters.AddWithValue("@NombreMacroproceso", macroproceso.NombreMacroproceso);

                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar un Macroproceso
        public void DeleteMacroproceso(string idMacroproceso)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Macroproceso WHERE IdMacroproceso = @IdMacroproceso", conn);
                cmd.Parameters.AddWithValue("@IdMacroproceso", idMacroproceso);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
