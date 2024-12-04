using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoRelampago
{
    public class Dependencia
    {
        public string IdDependencia { get; set; }
        public string NombreDependencia { get; set; }

        private string connectionString = ConfigurationManager.ConnectionStrings["Relampago"].ConnectionString;

        // Obtener todas las dependencias
        public List<Dependencia> GetAllDependencias()
        {
            List<Dependencia> dependencias = new List<Dependencia>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Dependencia", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Dependencia dependencia = new Dependencia
                    {
                        IdDependencia = reader["IdDependencia"].ToString(),
                        NombreDependencia = reader["NombreDependencia"].ToString()
                    };
                    dependencias.Add(dependencia);
                }
            }

            return dependencias;
        }

        // Agregar una nueva dependencia
        public void AddDependencia(Dependencia dependencia)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Dependencia (IdDependencia, NombreDependencia) VALUES (@IdDependencia, @NombreDependencia)", conn);

                cmd.Parameters.AddWithValue("@IdDependencia", dependencia.IdDependencia);
                cmd.Parameters.AddWithValue("@NombreDependencia", dependencia.NombreDependencia);

                cmd.ExecuteNonQuery();
            }
        }

        // Actualizar una dependencia existente
        public void UpdateDependencia(Dependencia dependencia)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Dependencia SET NombreDependencia = @NombreDependencia WHERE IdDependencia = @IdDependencia";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdDependencia", dependencia.IdDependencia);
                cmd.Parameters.AddWithValue("@NombreDependencia", dependencia.NombreDependencia);

                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar una dependencia
        public void DeleteDependencia(string idDependencia)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Dependencia WHERE IdDependencia = @IdDependencia", conn);
                cmd.Parameters.AddWithValue("@IdDependencia", idDependencia);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
