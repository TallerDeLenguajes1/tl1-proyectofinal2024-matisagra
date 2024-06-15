using System;
using System.Collections.Generic;
using FabricaDePersonajes;
using PersonajesJson;
using HistorialJson;
using Combate;
using Texto;

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
                case "2":
                    VerHistorialGanadores();
                    break;
                case "3":
                    VerHistoriaPersonajes();
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

        string nombreArchivo = "personajes.json";
        string nombreArchivo2 = "ganadores.json";
        List<Personaje> personajes;

        bool archivoExiste = PersonajesJson.PersonajesJson.Existe(nombreArchivo);

        if (archivoExiste)
        {
            personajes = PersonajesJson.PersonajesJson.LeerPersonajes(nombreArchivo);
        }
        else
        {
            personajes = new List<Personaje>();
            for (int i = 0; i < 10; i++)
            {
                personajes.Add(Personaje.CrearPersonajeAleatorio());
            }
            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);
        }

        Personaje ganador = null;
        while (personajes.Count > 1)
        {
            Console.Clear();

            if (ganador == null)
            {
                Console.WriteLine("\nPersonajes disponibles:");
                for (int i = 0; i < personajes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
                }

                Console.Write("\nElija el número de su personaje: ");
                int indicePersonaje1 = int.Parse(Console.ReadLine()) - 1;
                ganador = personajes[indicePersonaje1];
            }

            Console.Clear();

            Console.WriteLine($"\nPersonajes disponibles para combatir contra {ganador.Nombre}:");
            for (int i = 0; i < personajes.Count; i++)
            {
                if (personajes[i] != ganador)
                {
                    Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
                }
            }

            Console.Write("\nElija el número del personaje oponente: ");
            int indicePersonaje2 = int.Parse(Console.ReadLine()) - 1;
            Personaje oponente = personajes[indicePersonaje2];

            Console.WriteLine($"\nComienza la competencia entre {ganador.Nombre} y {oponente.Nombre}:");

            Combate.Combate.Combatir(ganador, oponente, personajes);

            if (ganador.Salud <= 0)
            {
                HistorialJson.HistorialJson.GuardarGanador(oponente,nombreArchivo2);
                Texto.Texto.Perdiste();
            }

            if (personajes.Count == 1)
            {
                Texto.Texto.Ganaste();
                HistorialJson.HistorialJson.GuardarGanador(ganador, nombreArchivo2);
                personajes.Clear();
            }

            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);

            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();
        }

        Console.WriteLine("\n¿Deseas jugar de nuevo? (S/N)");
    }

    static void VerHistorialGanadores()
    {
        Console.Clear();
        Console.WriteLine("HISTORIAL DE GANADORES:");
        List<Personaje> ganadores = HistorialJson.HistorialJson.LeerGanadores("ganadores.json");
        
        foreach (Personaje ganador in ganadores)
        {
            ganador.MostrarPersonaje();
        }
        Console.WriteLine("\nPresiona Enter para volver al menú principal...");
        Console.ReadLine();
    }

    static void VerHistoriaPersonajes()
    {
        Console.Clear();
        Console.WriteLine("HISTORIA DE CADA PERSONAJE:");
        
        Console.WriteLine("\nPresiona Enter para volver al menú principal...");
        Console.ReadLine();
    }

    










