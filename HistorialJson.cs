using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FabricaDePersonajes;


namespace HistorialJson{
    public class HistorialJson{
        public static void GuardarGanador(List<Personaje> personajes, string nombreArchivo)
        {
            string json = JsonSerializer.Serialize(personajes);
            File.WriteAllText(nombreArchivo, json);
            Console.WriteLine($"Se han guardado {personajes.Count} personajes en '{nombreArchivo}'.");
        }

        // Método para leer una lista de personajes desde un archivo JSON
        public static List<Personaje> LeerPersonajes(string nombreArchivo)
        {
            List<Personaje> personajes = new List<Personaje>();
            if (File.Exists(nombreArchivo))
            {
                string json = File.ReadAllText(nombreArchivo);
                personajes = JsonSerializer.Deserialize<List<Personaje>>(json);
                Console.WriteLine($"Se han leído {personajes.Count} personajes desde '{nombreArchivo}'.");
            }
            else
            {
                Console.WriteLine($"El archivo '{nombreArchivo}' no existe.");
            }
            return personajes;
        }

        public static bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                string json = File.ReadAllText(nombreArchivo);
                return !string.IsNullOrWhiteSpace(json); // Devuelve true si hay contenido válido
            }
            else
            {
                return false; // Devuelve false si el archivo no existe
            }
        }
    }
}