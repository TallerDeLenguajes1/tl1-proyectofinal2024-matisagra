using System;
using System.Collections.Generic;
using FabricaDePersonajes;

namespace Combate
{
    public class Combate
    {
        public static void Combatir(Personaje personaje1, Personaje personaje2, List<Personaje> personajes)
        {
            animaciones.AnimacionPelea animacion = new animaciones.AnimacionPelea(10, 9, 50, 9, personaje1.Nombre, personaje2.Nombre, personaje1.Salud, personaje2.Salud);
            Random random = new Random();
            bool sigueCombate = true;

            while (sigueCombate)
            {
                animacion.DibujarEscena();
                Thread.Sleep(500); // Pausa para la animación

                // Turno de personaje1 (ataque personaje1, defiende personaje2)
                int danioCausado = CalcularDanioCausado(personaje1, personaje2, random);
                personaje2.Salud -= danioCausado;
                animacion.ActualizarSaludVikingo2(personaje2.Salud);
                Console.WriteLine($"{personaje1.Nombre} ataca a {personaje2.Nombre} y le causa {danioCausado} puntos de daño.");

                // Mover vikingo1 hacia adelante y luego hacia atrás
                for (int i = 0; i < 5; i++) // Mover 5 pasos adelante
                {
                    animacion.MoverVikingo1(2, 0);
                    Thread.Sleep(100);
                }
                for (int i = 0; i < 5; i++) // Mover 5 pasos atrás
                {
                    animacion.MoverVikingo1(-2, 0);
                    Thread.Sleep(100);
                }

                animacion.DibujarEscena();
                Thread.Sleep(500); // Pausa para la animación

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
                for (int i = 0; i < 5; i++) // Mover 5 pasos adelante
                {
                    animacion.MoverVikingo2(-2, 0);
                    Thread.Sleep(100);
                }
                for (int i = 0; i < 5; i++) // Mover 5 pasos atrás
                {
                    animacion.MoverVikingo2(2, 0);
                    Thread.Sleep(100);
                }

                animacion.DibujarEscena();
                Thread.Sleep(500); // Pausa para la animación

                // Verificar si personaje1 ha sido derrotado
                if (personaje1.Salud <= 0)
                {
                    Console.WriteLine($"{personaje1.Nombre} ha sido derrotado.");
                    MejorarPersonaje(personaje2);
                    personajes.Clear();
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
            // Asumimos que el ganador recibe un aumento en la salud o defensa
            if (random.Next(0, 2) == 0) // 50% de probabilidad de elegir entre salud o defensa
            {
                ganador.Salud += 10; // Aumento de 10 en la salud
                Console.WriteLine($"{ganador.Nombre} ha mejorado su salud en +10.");
            }
            else
            {
                ganador.Armadura += 5; // Aumento de 5 en la armadura (defensa)
                Console.WriteLine($"{ganador.Nombre} ha mejorado su defensa en +5.");
            }
        }
    }
}
