
using FabricaDePersonajes;


do
{
    Console.Clear(); // Limpiar la consola al inicio de cada juego

    // Mostrar menú de opciones
    Texto.Texto.MostrarMenu();

    // Leer la opción seleccionada por el usuario
    string opcion = Console.ReadLine().ToUpper();

    switch (opcion)
    {
        case "1":
            Jugar();
            break;
        case "S":
            // Salir del juego si se ingresa "S"
            return;
        default:
            Console.WriteLine("Opción no válida. Presiona Enter para volver al menú.");
            Console.ReadLine();
            break;
    }
} while (true);

static void Jugar()
{
    Console.Clear();
    Texto.Texto.Presentacion();

    Console.WriteLine("\nPresiona Enter para comenzar...");
    Console.ReadLine();
    Personaje.ReiniciarListasUsadas();

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
        for (int i = 0; i < 10; i++)
        {
            personajes.Add(Personaje.CrearPersonajeAleatorio());
        }
        PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
    }

    Personaje ganador = null;
    Random random = new Random();

    Console.Clear();

    Console.WriteLine("\nPersonajes disponibles:");
    for (int i = 0; i < personajes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
    }

    Console.Write("\nElija el número de su personaje: ");
    int indicePersonaje1 = int.Parse(Console.ReadLine()) - 1;
    ganador = personajes[indicePersonaje1];

    while (personajes.Count > 1)
    {
        Console.Clear();

        List<Personaje> posiblesOponentes = new List<Personaje>(personajes);
        posiblesOponentes.Remove(ganador);

        int indiceOponente = random.Next(posiblesOponentes.Count);
        Personaje oponente = posiblesOponentes[indiceOponente];

        Console.WriteLine($"\nComienza la batalla entre {ganador.Nombre} y {oponente.Nombre}:");
        Texto.Texto.Pelea(ganador.Nombre, oponente.Nombre);
        Console.WriteLine("\nPresiona Enter para comenzar la batalla...");
        Console.ReadLine();

        Combate.Combate.Combatir(ganador, oponente, personajes);

        if (ganador.Salud <= 0)
        {
            HistorialJson.HistorialJson.GuardarGanador(oponente, nombreArchivoGanadores);
            Texto.Texto.Perdiste();
            ganador = null;
            personajes.Clear(); // Limpiar la lista de personajes al perder
            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
            break;
        }
        else if (oponente.Salud <= 0)
        {
            personajes.Remove(oponente);
            Console.WriteLine($"\n{ganador.Nombre} ha ganado la batalla.");
            if (personajes.Count > 1)
            {
                Console.WriteLine("\nPresiona Enter para la siguiente ronda...");
                Console.ReadLine();
            }
        }

        if (personajes.Count == 1)
        {
            Texto.Texto.Ganaste();
            HistorialJson.HistorialJson.GuardarGanador(ganador, nombreArchivoGanadores);
            personajes.Clear();
        }

        PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivoPersonajes);
    }
}


        

    








