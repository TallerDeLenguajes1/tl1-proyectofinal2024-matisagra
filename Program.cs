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
                    Juego.Jugar();
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

        

    








