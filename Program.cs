using System;
using System.Collections.Generic;
using FabricaDePersonajes;
using PersonajesJson;
using HistorialJson;
using Combate;

// Nombre del archivo JSON
string nombreArchivo = "personajes.json";
string nombreArchivo2 = "ganadores.json";
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

        // Ciclo para permitir múltiples combates
        Personaje ganador = null;
        while (personajes.Count > 1)
        {
            if (ganador == null)
            {
                // Mostrar los personajes cargados
                Console.WriteLine("\nPersonajes disponibles:");
                for (int i = 0; i < personajes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
                }

                // Elegir personajes para competir
                Console.Write("Elija el número de su personaje: ");
                int indicePersonaje1 = int.Parse(Console.ReadLine()) - 1;
                ganador = personajes[indicePersonaje1];
            }

            // Mostrar los personajes cargados excepto el ganador actual
            Console.WriteLine("\nPersonajes disponibles para combatir:");
            for (int i = 0; i < personajes.Count; i++)
            {
                if (personajes[i] != ganador)
                {
                    Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
                }
            }

            // Elegir el oponente para el ganador
            Console.Write("Elija el número del personaje oponente: ");
            int indicePersonaje2 = int.Parse(Console.ReadLine()) - 1;
            Personaje oponente = personajes[indicePersonaje2];

            Console.WriteLine($"\nComienza la competencia entre {ganador.Nombre} y {oponente.Nombre}:");

            // Iniciar el combate
            Combate.Combate.Combatir(ganador, oponente, personajes);

            // Guardar los personajes actualizados en el archivo
            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);

            // Mostrar resultado final
            //Console.WriteLine("\nLista de personajes después del combate:");
            //for (int i = 0; i < personajes.Count; i++)
            //{
            //    Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
            //}
        }

        Console.WriteLine("No hay suficientes personajes para continuar la competencia.");

        if (personajes.Count == 1)
        {
            HistorialJson.HistorialJson.GuardarGanador(personajes, nombreArchivo2);
        }
    

