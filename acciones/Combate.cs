using System;
using System.Collections.Generic;
using System.Threading;
using FabricaDePersonajes;
using Personajes;

namespace Combate
{
    public class Combate
    {
        public static void Combatir(Personaje personaje1, Personaje personaje2, List<Personaje> personajes)
        {
            // Restaurar la salud inicial antes de comenzar el combate
            personaje1.Salud = personaje1.SaludInicial;
            personaje2.Salud = personaje2.SaludInicial;

            // Inicializa la animación de la pelea con los datos iniciales
            animaciones.AnimacionPelea animacion = new animaciones.AnimacionPelea(10, 9, 50, 9, personaje1.Nombre, personaje2.Nombre, personaje1.Salud, personaje2.Salud);
            Random random = new Random();
            bool sigueCombate = true;

            while (sigueCombate)
            {

                // Dibuja la escena de la pelea
                animacion.DibujarEscena();
                Thread.Sleep(500); // Pausa para la animación

                // Turno de personaje1 (ataque personaje1, defiende personaje2)
                int danioCausado = CalcularDanioCausado(personaje1, personaje2, random);
                personaje2.Salud -= danioCausado;
                animacion.ActualizarSaludVikingo2(personaje2.Salud);

                Console.WriteLine($"{personaje1.Nombre} ataca a {personaje2.Nombre} y le causa {danioCausado} puntos de daño.");

                // Mover vikingo1 hacia adelante y luego hacia atrás
                animacion.MoverVikingo1Secuencia();

                // Verificar si personaje2 ha sido derrotado
                if (personaje2.Salud <= 0)
                {
                    Console.WriteLine($"{personaje2.Nombre} ha sido derrotado.");
                    MejorarPersonaje(personaje1);
                    personajes.Remove(personaje2);
                    sigueCombate = false;
                    break;
                }

                Thread.Sleep(500); // Pausa para la animación

                // Turno de personaje2 (ataque personaje2, defiende personaje1)
                danioCausado = CalcularDanioCausado(personaje2, personaje1, random);
                personaje1.Salud -= danioCausado;
                animacion.ActualizarSaludVikingo1(personaje1.Salud);
                Console.WriteLine($"{personaje2.Nombre} ataca a {personaje1.Nombre} y le causa {danioCausado} puntos de daño.");

                // Mover vikingo2 hacia adelante y luego hacia atrás
                animacion.MoverVikingo2Secuencia();

                // Verificar si personaje1 ha sido derrotado
                if (personaje1.Salud <= 0)
                {
                    Console.WriteLine($"{personaje1.Nombre} ha sido derrotado.");
                    sigueCombate = false;
                }

                Thread.Sleep(500); // Pausa para la animación
            }
        }

        static int CalcularDanioCausado(Personaje atacante, Personaje defensor, Random random)
        {
            // Calcular componentes del daño
            int ataque = atacante.Destreza * atacante.Fuerza * atacante.Nivel;
            int efectividad = random.Next(1, 101);
            int defensa = defensor.Armadura * defensor.Velocidad;
            const int constanteAjuste = 500;

            // Calcular daño
            int danio = ((ataque * efectividad) - defensa) / constanteAjuste;

            // Asegurarse de que el daño no sea menor que 10
            return Math.Max(danio, 10);
        }

        static void MejorarPersonaje(Personaje ganador)
        {
            Random random = new Random();
            int mejora = random.Next(0, 3); // Genera un número aleatorio entre 0 y 5 para decidir la mejora

            switch (mejora)
            {
                case 0:
                    ganador.Salud += 10;
                    ganador.SaludInicial += 10;
                    Console.WriteLine($"{ganador.Nombre} ha mejorado su salud en +10.");
                    ganador.Fuerza += 1;
                    Console.WriteLine($"{ganador.Nombre} ha mejorado su fuerza en +3.");
                    break;
                case 1:
                    ganador.Armadura += 5;
                    Console.WriteLine($"{ganador.Nombre} ha mejorado su defensa en +5.");
                    ganador.Velocidad += 3;
                    Console.WriteLine($"{ganador.Nombre} ha mejorado su velocidad en +1.");
                    break;
                case 2:
                    ganador.Destreza += 3;
                    Console.WriteLine($"{ganador.Nombre} ha mejorado su destreza en +1.");
                    ganador.Nivel += 1;
                    Console.WriteLine($"{ganador.Nombre} ha subido de nivel a {ganador.Nivel}.");
                    break;
            }
        }
    }
}
