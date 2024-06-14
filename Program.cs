using System;
using System.Collections.Generic;
using FabricaDePersonajes;
using PersonajesJson;


// Nombre del archivo JSON
string nombreArchivo = "personajes.json";
List<Personaje> personajes;

// Verificar si el archivo existe y tiene datos
bool archivoExiste = PersonajesJson.PersonajesJson.Existe(nombreArchivo);

if (archivoExiste)
{
    // Cargar personajes desde el archivo existente
    personajes = PersonajesJson.PersonajesJson.LeerPersonajes(nombreArchivo);
}
else
{
    // Generar 10 personajes aleatorios y guardarlos en el archivo
    personajes = new List<Personaje>();
    for (int i = 0; i < 10; i++)
    {
        personajes.Add(Personaje.CrearPersonajeAleatorio());
    }
    PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);
}

// Mostrar los personajes cargados
Console.WriteLine("Personajes cargados:");
int cont = 1;
foreach (var personaje in personajes)
{
    Console.WriteLine();
    Console.WriteLine($"Personajes {cont}:");
    personaje.MostrarPersonaje();
    cont++;
}
