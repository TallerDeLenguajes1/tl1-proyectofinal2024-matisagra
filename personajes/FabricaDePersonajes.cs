using System;
using System.Collections.Generic;
using Personajes;

namespace FabricaDePersonajes
{
    public class Fabrica
    {
        // Listas para evitar nombres y apodos duplicados
        private static List<string> nombresUsados = new List<string>();
        private static List<string> apodosUsados = new List<string>();

        // Método para reiniciar las listas de nombres y apodos usados
        public static void ReiniciarListasUsadas()
        {
            nombresUsados.Clear();
            apodosUsados.Clear();
        }

        // Método para crear un personaje aleatorio
        public static Personaje CrearPersonajeAleatorio()
        {
            Random random = new Random();
            // Arrays de tipos, nombres y apodos posibles
            string[] tipos = { "Guerrero", "Berserker", "Explorador", "Jarl" };
            string[] nombres = { "Ragnar", "Lagertha", "Bjorn", "Floki", "Rollo", "Ivar", "Ubbe", "Hvitserk", "Aslaug", "Sigurd", "Kjetill" };
            string[] apodos = { "El Valiente", "El Despiadado", "El Explorador", "El Conquistador", "El Sabio", "El Temible", "El Astuto", "El Fuerte", "El Justo", "El Terrible" };

            // Generar una fecha de nacimiento aleatoria
            DateTime fechaDeNacimiento = GenerarFechaDeNacimiento(random);

            // Crear y configurar el personaje con valores aleatorios
            Personaje personaje = new Personaje
            {
                Tipo = tipos[random.Next(tipos.Length)], // Tipo aleatorio
                Nombre = GenerarNombreUnico(random, nombres), // Nombre único aleatorio
                Apodo = GenerarApodoUnico(random, apodos), // Apodo único aleatorio
                FechaDeNacimiento = fechaDeNacimiento, // Fecha de nacimiento generada
                Edad = CalcularEdad(fechaDeNacimiento), // Calcular la edad basada en la fecha de nacimiento
                Velocidad = random.Next(1, 11), // Velocidad aleatoria entre 1 y 10
                Destreza = random.Next(1, 6), // Destreza aleatoria entre 1 y 5
                Fuerza = random.Next(1, 11), // Fuerza aleatoria entre 1 y 10
                Nivel = random.Next(1, 11), // Nivel aleatorio entre 1 y 10
                Armadura = random.Next(1, 11), // Armadura aleatoria entre 1 y 10
                Salud = 100, // Salud inicial de 100
                SaludInicial = 100, // Salud inicial de 100
                Habilidades = random.Next(1, 11) // Habilidades aleatorias entre 1 y 10
            };

            return personaje;
        }

        // Método para generar una fecha de nacimiento aleatoria
        private static DateTime GenerarFechaDeNacimiento(Random random)
        {
            int anio = random.Next(DateTime.Now.Year - 60, DateTime.Now.Year - 18); // Año aleatorio entre hace 60 y 18 años
            int mes = random.Next(1, 13); // Mes aleatorio entre 1 y 12
            int dia = random.Next(1, DateTime.DaysInMonth(anio, mes) + 1); // Día aleatorio válido para el mes y año

            return new DateTime(anio, mes, dia);
        }

        // Método para calcular la edad basada en la fecha de nacimiento
        private static int CalcularEdad(DateTime fechaDeNacimiento)
        {
            int edad = DateTime.Now.Year - fechaDeNacimiento.Year;
            return edad;
        }

        // Método para generar un nombre único aleatorio
        private static string GenerarNombreUnico(Random random, string[] nombres)
        {
            string nombre;
            do
            {
                nombre = nombres[random.Next(nombres.Length)]; // Seleccionar nombre aleatorio
            } while (nombresUsados.Contains(nombre)); // Repetir hasta encontrar un nombre no usado

            nombresUsados.Add(nombre); // Agregar el nombre a la lista de usados
            return nombre;
        }

        // Método para generar un apodo único aleatorio
        private static string GenerarApodoUnico(Random random, string[] apodos)
        {
            string apodo;
            do
            {
                apodo = apodos[random.Next(apodos.Length)]; // Seleccionar apodo aleatorio
            } while (apodosUsados.Contains(apodo)); // Repetir hasta encontrar un apodo no usado

            apodosUsados.Add(apodo); // Agregar el apodo a la lista de usados
            return apodo;
        }

        // Método para calcular la diferencia de habilidades entre dos personajes
        public static int CalcularDiferenciaHabilidades(Personaje p1, Personaje p2)
        {
            int diferencia = Math.Abs(p1.Velocidad - p2.Velocidad)
                            + Math.Abs(p1.Destreza - p2.Destreza)
                            + Math.Abs(p1.Fuerza - p2.Fuerza)
                            + Math.Abs(p1.Nivel - p2.Nivel)
                            + Math.Abs(p1.Armadura - p2.Armadura); // Sumar diferencias absolutas de habilidades
            return diferencia;
        }
    }
}
