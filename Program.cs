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
            Console.Clear();
            Texto.Texto.MostrarMenu();

            string opcion = Console.ReadLine().ToUpper();

            switch (opcion)
            {
                case "1":
                    await Jugar();
                    break;
                case "2":
                    VerHistorial();
                    break;
                case "S":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Presiona Enter para volver al menú.");
                    Console.ReadLine();
                    break;
            }
        } while (true);
    }

    static async Task Jugar()
    {
        Console.Clear();
        Texto.Texto.Presentacion();
        Console.Clear();
        Texto.Texto.Dificultad();

        int numeroRivales;
        while (true)
        {
            string seleccionDificultad = Console.ReadLine();
            if (seleccionDificultad == "1")
            {
                numeroRivales = 3;
                break;
            }
            else if (seleccionDificultad == "2")
            {
                numeroRivales = 6;
                break;
            }
            else if (seleccionDificultad == "3")
            {
                numeroRivales = 10;
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, selecciona una dificultad válida (1, 2 o 3):");
            }
        }

        Fabrica.ReiniciarListasUsadas();

        string nombreArchivoPersonajes = "personajes/personajes.json";
        string nombreArchivoGanadores = "ganadores/ganadores.json";
        List<Personaje> personajes;

        bool archivoExiste = PersonajesJson.PersonajesJson.Existe(nombreArchivoPersonajes);

        if (archivoExiste)
        {
            personajes = PersonajesJson.PersonajesJson.LeerPersonajes(nombreArchivoPersonajes);
        }
        else
        {
            personajes = new List<Personaje>();
            for (int i = 0; i < numeroRivales + 1; i++)
            {
                personajes.Add(Fabrica.CrearPersonajeAleatorio());
            }
            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
        }

        Personaje elegido = null;
        Random random = new Random();

        Console.Clear();

        Console.WriteLine("\nPersonajes disponibles:");
        for (int i = 0; i < personajes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
        }

        Console.Write("\nElija el número de su personaje: ");
        int indicePersonaje1 = int.Parse(Console.ReadLine()) - 1;
        elegido = personajes[indicePersonaje1];

        int rondasGanadas = 0;

        while (rondasGanadas < numeroRivales && personajes.Count > 1)
        {
            Console.Clear();

            List<Personaje> posiblesOponentes = new List<Personaje>(personajes);
            posiblesOponentes.Remove(elegido);

            Console.WriteLine("\nGuerreros en batalla:");
            for (int i = 0; i < posiblesOponentes.Count; i++)
            {
                Console.WriteLine($"{posiblesOponentes[i].Nombre} ({posiblesOponentes[i].Tipo})");
            }
            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();

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
            await Texto.Texto.Chiste();

            Console.WriteLine($"\nJAJA! Ahora si, comienza la batalla entre {elegido.Nombre} y {oponente.Nombre}:");

            Console.WriteLine("\nPresiona Enter para comenzar la batalla...");
            Console.ReadLine();

            Combate.Combate.Combatir(elegido, oponente, personajes);

            if (elegido.Salud <= 0)
            {
                Console.Clear();
                Texto.Texto.Perdiste();
                elegido = null;
                personajes.Clear();
                PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
                break;
            }
            else if (oponente.Salud <= 0)
            {
                personajes.Remove(oponente);
                rondasGanadas++;
                if (rondasGanadas < numeroRivales)
                {
                    Console.WriteLine("\nPresiona Enter para la siguiente ronda...");
                    Console.ReadLine();
                }
            }

            if (rondasGanadas == numeroRivales || personajes.Count == 1)
            {
                Console.Clear();
                Texto.Texto.Ganaste();
                Console.WriteLine("Ingresa tu nombre para el historial de ganadores: ");
                string usado = elegido.Nombre;
                string nombre = Console.ReadLine();
                elegido.Nombre = nombre + " con el guerrero " + usado;
                HistorialJson.HistorialJson.GuardarGanador(elegido, nombreArchivoGanadores);
                personajes.Clear();
                Console.WriteLine("\nPresiona Enter para volver al inicio...");
                Console.ReadLine();
            }

            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
        }
    }

    static void VerHistorial()
    {
        Console.Clear();
        string nombreArchivoGanadores = "ganadores/ganadores.json";

        bool archivoExiste = HistorialJson.HistorialJson.Existe(nombreArchivoGanadores);

        if (archivoExiste)
        {
            List<Personaje> ganadores = HistorialJson.HistorialJson.LeerGanadores(nombreArchivoGanadores);

            Console.WriteLine("\nHistorial de ganadores:");
            foreach (var ganador in ganadores)
            {
                Console.WriteLine($"{ganador.Nombre}");
            }
        }
        else
        {
            Console.WriteLine("No hay historial de ganadores.");
        }

        Console.WriteLine("\nPresiona Enter para volver al menú...");
        Console.ReadLine();
    }
}
