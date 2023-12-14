using System;
using System.Data.SqlClient;
using System.Text.Json;



namespace Entidades.BaseDeDatos
{


    public static class GestorDeBaseDeDatos
    {
        private static readonly string connectionString;

        // Constructor estático para inicializar la cadena de conexión
        static GestorDeBaseDeDatos()
        {
            connectionString = "14122023-rsp";
        }

        // Método estático para registrar un trabajo en la base de datos
        public static void RegistrarTrabajo(int pacientesAtendidos, string nombreAlumno)
        {
            // Verificar si los parámetros son válidos
            if (string.IsNullOrEmpty(nombreAlumno) || pacientesAtendidos < 0)
            {
                throw new ArgumentException("Los parámetros no son válidos para el registro de trabajo.");
            }

            // Crear la conexión utilizando la cadena de conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();

               
                string query = "INSERT INTO dbo.log (pacientes_atendidos, alumno) VALUES (@PacientesAtendidos, @NombreAlumno)";

                // Crear un comando con la consulta SQL y la conexión
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@PacientesAtendidos", pacientesAtendidos);
                    command.Parameters.AddWithValue("@NombreAlumno", nombreAlumno);

                   
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
