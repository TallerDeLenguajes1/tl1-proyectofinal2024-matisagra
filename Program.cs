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
            // Limpiar la pantalla y mostrar el menú principal.
            Console.Clear();
            Texto.Texto.MostrarMenu();

            // Leer la opción seleccionada por el usuario.
            string opcion = Console.ReadLine().ToUpper();

            switch (opcion)
            {
                case "1":
                    // Iniciar el juego.
                    await Jugar();
                    break;
                case "2":
                    // Ver historial de ganadores.
                    VerHistorial();
                    break;
                case "S":
                    // Salir del programa.
                    return;
                default:
                    // Manejar opción no válida.
                    Console.WriteLine("Opción no válida. Presiona Enter para volver al menú.");
                    Console.ReadLine();
                    break;
            }
        } while (true); // Repetir el menú hasta que se seleccione la opción de salir.
    }

    static async Task Jugar()
    {
        // Limpiar la pantalla y mostrar la presentación y selección de dificultad.
        Console.Clear();
        Texto.Texto.Presentacion();
        Console.Clear();
        Texto.Texto.Dificultad();

        int numeroRivales;
        while (true)
        {
            // Leer la selección de dificultad del usuario.
            string seleccionDificultad = Console.ReadLine();
            if (seleccionDificultad == "1")
            {
                numeroRivales = 3; // Fácil: 3 rivales.
                break;
            }
            else if (seleccionDificultad == "2")
            {
                numeroRivales = 6; // Medio: 6 rivales.
                break;
            }
            else if (seleccionDificultad == "3")
            {
                numeroRivales = 9; // Difícil: 9 rivales.
                break;
            }
            else
            {
                // Manejar selección no válida.
                Console.WriteLine("Opción no válida. Por favor, selecciona una dificultad válida (1, 2 o 3):");
            }
        }

        // Reiniciar listas usadas en la fábrica de personajes.
        Fabrica.ReiniciarListasUsadas();

        // Definir nombres de archivos para personajes y ganadores.
        string nombreArchivoPersonajes = "personajes/personajes.json";
        string nombreArchivoGanadores = "ganadores/ganadores.json";
        List<Personaje> personajes;

        // Verificar si el archivo de personajes existe.
        bool archivoExiste = PersonajesJson.PersonajesJson.Existe(nombreArchivoPersonajes);

        if (archivoExiste)
        {
            // Leer personajes desde el archivo.
            personajes = PersonajesJson.PersonajesJson.LeerPersonajes(nombreArchivoPersonajes);
        }
        else
        {
            // Crear nuevos personajes aleatorios y guardarlos en el archivo.
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

        // Mostrar lista de personajes para que el usuario seleccione uno.
        Console.WriteLine("\nSelecciona tu personaje:");
        for (int i = 0; i < personajes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
        }

        // Leer el número del personaje elegido por el usuario.
        Console.Write("\nElija el número de su personaje: ");
        int indicePersonaje1 = int.Parse(Console.ReadLine()) - 1;
        elegido = personajes[indicePersonaje1];

        int rondasGanadas = 0;

        while (rondasGanadas < numeroRivales && personajes.Count > 1)
        {
            Console.Clear();

            // Crear una lista de posibles oponentes excluyendo el personaje elegido.
            List<Personaje> posiblesOponentes = new List<Personaje>(personajes);
            posiblesOponentes.Remove(elegido);

            // Mostrar los posibles oponentes.
            Console.WriteLine("\nGuerreros en batalla:");
            for (int i = 0; i < posiblesOponentes.Count; i++)
            {
                Console.WriteLine($"{posiblesOponentes[i].Nombre} ({posiblesOponentes[i].Tipo})");
            }
            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();

            Personaje oponente = null;
            int menorDiferencia = int.MaxValue;

            // Seleccionar el oponente con la menor diferencia de habilidades.
            foreach (var posibleOponente in posiblesOponentes)
            {
                int diferencia = Fabrica.CalcularDiferenciaHabilidades(elegido, posibleOponente);
                if (diferencia < menorDiferencia)
                {
                    menorDiferencia = diferencia;
                    oponente = posibleOponente;
                }
            }

            // Anunciar el oponente y comenzar la pelea.
            Console.Clear();
            Console.WriteLine($"Ahora te vas a enfrentar a {oponente.Nombre}");
            Texto.Texto.Pelea(elegido.Nombre, oponente.Nombre);
            await Texto.Texto.Chiste(); // Mostrar un chiste antes de la pelea.

            Console.WriteLine($"\nJAJA! Ahora si, comienza la batalla entre {elegido.Nombre} y {oponente.Nombre}:");

            Console.WriteLine("\nPresiona Enter para comenzar la batalla...");
            Console.ReadLine();

            // Realizar la pelea entre el personaje elegido y el oponente.
            Combate.Combate.Combatir(elegido, oponente, personajes);

            // Verificar si el personaje elegido perdió.
            if (elegido.Salud <= 0)
            {
                Console.Clear();
                Texto.Texto.Perdiste();
                elegido = null;
                personajes.Clear();
                PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
                break;
            }
            // Verificar si el oponente perdió.
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

            // Si el jugador gana todas las rondas o no quedan más oponentes.
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

            // Guardar el estado actual de los personajes.
            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
        }
    }

    static void VerHistorial()
    {
        // Limpiar la pantalla y mostrar el historial de ganadores.
        Console.Clear();
        string nombreArchivoGanadores = "ganadores/ganadores.json";

        // Verificar si el archivo de historial de ganadores existe.
        bool archivoExiste = HistorialJson.HistorialJson.Existe(nombreArchivoGanadores);

        if (archivoExiste)
        {
            // Leer y mostrar los ganadores desde el archivo.
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
