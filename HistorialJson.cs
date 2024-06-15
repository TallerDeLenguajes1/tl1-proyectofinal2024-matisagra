using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FabricaDePersonajes;


namespace HistorialJson
{
    public class HistorialJson
    {

         public static void GuardarGanador(Personaje personajes, string nombreArchivo)
        {
                string json = JsonSerializer.Serialize(personajes);
                File.WriteAllText(nombreArchivo, json);
            
        }

        // Método para leer una lista de personajes desde un archivo JSON
        public static List<Personaje> LeerGanadores(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                string json = File.ReadAllText(nombreArchivo);
                return JsonSerializer.Deserialize<List<Personaje>>(json);
            }
            return new List<Personaje>();
        }

        // Método para verificar si un archivo JSON existe y tiene datos
        public static bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                string json = File.ReadAllText(nombreArchivo);
                return json.Length > 0;
            }
            return false;
        }

    }
}