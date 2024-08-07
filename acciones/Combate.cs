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
            int efectividad = random.Next(85, 116); // Modificar el rango de efectividad para variar más el daño
            int defensa = defensor.Armadura * defensor.Velocidad;
            const int constanteAjuste = 500; // Ajustar la constante para un daño más significativo

            // Calcular daño
            int danioBase = ((ataque * efectividad) - defensa) / constanteAjuste;
            
            // Introducir un rango de variabilidad en el daño
            int danioConVariabilidad = danioBase + random.Next(-10, 11); // Daño puede variar entre -10 y +10

            // Asegurarse de que el daño no sea menor que 1
            int danioFinal = Math.Max(danioConVariabilidad, 1);

            // Introducir posibilidad de golpe crítico
            bool golpeCritico = random.Next(1, 101) <= 10; // 10% de probabilidad de golpe crítico
            if (golpeCritico)
            {
                danioFinal *= 2; // Doble daño en caso de golpe crítico
                Console.WriteLine("\n¡Golpe Crítico!"); // Imprimir mensaje en caso de golpe crítico
            }

            return danioFinal;
        }


        static void MejorarPersonaje(Personaje ganador)
        {
            int puntosDeMejora = 10;
            int puntosAsignadosASalud = 0;
            int puntosAsignadosADefensa = 0;

            Console.WriteLine($"{ganador.Nombre} ha ganado y tiene {puntosDeMejora} puntos de mejora para asignar.");
            
            // Asignar puntos a la salud
            Console.WriteLine("¿Cuántos puntos quieres asignar a la salud?");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out puntosAsignadosASalud) &&
                    puntosAsignadosASalud >= 0 &&
                    puntosAsignadosASalud <= puntosDeMejora)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingresa un número entre 0 y 10.");
                }
            }

            // Calcular los puntos restantes para la defensa
            puntosAsignadosADefensa = puntosDeMejora - puntosAsignadosASalud;

            // Mejorar las estadísticas del personaje
            ganador.Salud += puntosAsignadosASalud;
            ganador.SaludInicial += puntosAsignadosASalud;
            ganador.Armadura += puntosAsignadosADefensa;

            Console.WriteLine($"{ganador.Nombre} ha mejorado su salud en +{puntosAsignadosASalud}.");
            Console.WriteLine($"{ganador.Nombre} ha mejorado su defensa en +{puntosAsignadosADefensa}.");
        }

    }
}
