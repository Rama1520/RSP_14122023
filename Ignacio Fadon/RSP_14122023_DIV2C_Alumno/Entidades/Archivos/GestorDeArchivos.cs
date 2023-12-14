using System;
using System.IO;
using System.Text.Json;

namespace Entidades.Archivos
{
    public static class GestorDeArchivos
    {
        private static readonly string basePath;

        // Constructor estático para inicializar basePath y llamar a ValidaExistenciaDeDirectorio
        static GestorDeArchivos()
        {
            basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "14122023_Alumno");
            ValidaExistenciaDeDirectorio();
        }

        // Método privado para validar y crear el directorio si no existe
        private static void ValidaExistenciaDeDirectorio()
        {
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
        }

        // Método privado para guardar archivos de texto
        private static void Guardar(string nombreArchivo, string contenido)
        {
            string filePath = Path.Combine(basePath, nombreArchivo);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(contenido);
            }
        }

        // Método genérico para serializar objetos en JSON
        private static void Serializar<T>(T objeto, string nombreArchivo) where T : class
        {
            string filePath = Path.Combine(basePath, nombreArchivo);
            string jsonString = JsonSerializer.Serialize(objeto);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(jsonString);
            }
        }
    }

}
