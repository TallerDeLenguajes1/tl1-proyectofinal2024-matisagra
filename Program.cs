using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FabricaDePersonajes;
using Personajes;

class Program
{
    static async Task Main()
    {
        do
        {
            // Limpia la consola al inicio de cada ciclo de juego
            Console.Clear();
            // Muestra el menú de opciones
            Texto.Texto.MostrarMenu();

            // Lee la opción seleccionada por el usuario y la convierte a mayúsculas
            string opcion = Console.ReadLine().ToUpper();

            switch (opcion)
            {
                case "1":
                    // Llama a la función Jugar si se selecciona la opción 1
                    await Jugar();
                    break;
                case "2":
                    // Llama a la función VerHistorial si se selecciona la opción 2
                    VerHistorial();
                    break;
                case "S":
                    // Sale del juego si se ingresa "S"
                    return;
                default:
                    // Muestra un mensaje de error y espera a que el usuario presione Enter
                    Console.WriteLine("Opción no válida. Presiona Enter para volver al menú.");
                    Console.ReadLine();
                    break;
            }
        } while (true); // Repite el ciclo mientras la condición sea verdadera (bucle infinito)
    }

    static async Task Jugar()
    {
        Console.Clear();
        // Muestra la presentación del juego
        Texto.Texto.Presentacion();

        Console.WriteLine("\nPresiona Enter para comenzar...");
        Console.ReadLine();
        // Reinicia las listas usadas en la fábrica de personajes
        Fabrica.ReiniciarListasUsadas();

        // Define las rutas de los archivos JSON para personajes y ganadores
        string nombreArchivoPersonajes = "personajes/personajes.json";
        string nombreArchivoGanadores = "ganadores/ganadores.json";
        List<Personaje> personajes;

        // Verifica si el archivo de personajes existe
        bool archivoExiste = PersonajesJson.PersonajesJson.Existe(nombreArchivoPersonajes);

        if (archivoExiste)
        {
            // Lee los personajes del archivo JSON si este existe
            personajes = PersonajesJson.PersonajesJson.LeerPersonajes(nombreArchivoPersonajes);
        }
        else
        {
            // Crea una lista nueva de personajes si el archivo no existe
            personajes = new List<Personaje>();
            for (int i = 0; i < 10; i++)
            {
                personajes.Add(Fabrica.CrearPersonajeAleatorio());
            }
            // Guarda los personajes creados en el archivo JSON
            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
        }

        Personaje elegido = null;
        Random random = new Random();

        Console.Clear();

        // Muestra los personajes disponibles
        Console.WriteLine("\nPersonajes disponibles:");
        for (int i = 0; i < personajes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
        }

        // Pide al usuario que elija un personaje
        Console.Write("\nElija el número de su personaje: ");
        int indicePersonaje1 = int.Parse(Console.ReadLine()) - 1;
        elegido = personajes[indicePersonaje1];

        while (personajes.Count > 1)
        {
            Console.Clear();

            // Crea una lista de posibles oponentes excluyendo al ganador actual
            List<Personaje> posiblesOponentes = new List<Personaje>(personajes);
            posiblesOponentes.Remove(elegido);

            Console.WriteLine("\nTus oponentes seran:");
            for (int i = 0; i < posiblesOponentes.Count; i++)
            {
                Console.WriteLine($"{posiblesOponentes[i].Nombre} ({posiblesOponentes[i].Tipo})");
            }
            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();

            // Ordena los opnonentes para enfrentarme al mejor al final
            Personaje oponente = null;
            int menorDiferencia = int.MaxValue;

            foreach (var posibleOponente in posiblesOponentes)
            {
                int diferencia = Fabrica.CalcularDiferenciaHabilidades(elegido, posibleOponente);
                if (diferencia < menorDiferencia)
                {
                    menorDiferencia = diferencia;
                    oponente = posibleOponente;
                }
            }
            
            Console.Clear();
            Console.WriteLine($"Ahora te vas a enfrentar a {oponente.Nombre}");
            Texto.Texto.Pelea(elegido.Nombre, oponente.Nombre);
            // API
            await Texto.Texto.Chiste();


            // Muestra el inicio de la batalla
            Console.WriteLine($"\nJAJA! Ahora si, comienza la batalla entre {elegido.Nombre} y {oponente.Nombre}:");

            Console.WriteLine("\nPresiona Enter para comenzar la batalla...");
            Console.ReadLine();


            // Realiza el combate entre el ganador y el oponente
            Combate.Combate.Combatir(elegido, oponente, personajes);

            // Verifica el resultado del combate
            if (elegido.Salud <= 0)
            {
                Console.Clear();
                Texto.Texto.Perdiste();
                elegido = null;
                personajes.Clear(); // Limpia la lista de personajes al perder
                PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
                break;
            }
            else if (oponente.Salud <= 0)
            {
                // Si el oponente pierde, lo elimina de la lista y continúa
                personajes.Remove(oponente);
                Console.WriteLine($"\n{elegido.Nombre} ha ganado la batalla.");
                if (personajes.Count > 1)
                {
                    Console.WriteLine("\nPresiona Enter para la siguiente ronda...");
                    Console.ReadLine();
                }
            }

            // Verifica si solo queda un personaje en la lista
            if (personajes.Count == 1)
            {
                Console.Clear();
                Texto.Texto.Ganaste();
                Console.WriteLine("Ingresa tu nombre para el historial de ganadores: ");
                string usado = elegido.Nombre;
                string nombre = Console.ReadLine();
                elegido.Nombre = nombre + " con el guerrero " + usado;
                HistorialJson.HistorialJson.GuardarGanador(elegido, nombreArchivoGanadores);
                personajes.Clear(); // Limpia la lista de personajes al ganar
            }

            // Guarda el estado actual de los personajes en el archivo JSON
            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
        }
    }

    static void VerHistorial()
    {
        Console.Clear();
        // Define la ruta del archivo JSON de ganadores
        string nombreArchivoGanadores = "ganadores/ganadores.json";

        // Verifica si el archivo de ganadores existe
        bool archivoExiste = HistorialJson.HistorialJson.Existe(nombreArchivoGanadores);

        if (archivoExiste)
        {
            // Lee los ganadores del archivo JSON si este existe
            List<Personaje> ganadores = HistorialJson.HistorialJson.LeerGanadores(nombreArchivoGanadores);

            // Muestra la lista de ganadores
            Console.WriteLine("\nHistorial de ganadores:");
            foreach (var ganador in ganadores)
            {
                Console.WriteLine($"{ganador.Nombre}");
            }
        }
        else
        {
            // Muestra un mensaje si no hay historial de ganadores
            Console.WriteLine("No hay historial de ganadores.");
        }

        // Espera a que el usuario presione Enter para volver al menú
        Console.WriteLine("\nPresiona Enter para volver al menú...");
        Console.ReadLine();
    }
}
