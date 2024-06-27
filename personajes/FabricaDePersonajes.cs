using System;
using System.Collections.Generic;
using Personajes;

namespace FabricaDePersonajes
{
    public class Fabrica
    {
        // Listas para evitar duplicados
        private static List<string> nombresUsados = new List<string>();
        private static List<string> apodosUsados = new List<string>();

        public static void ReiniciarListasUsadas()
        {
            nombresUsados.Clear();
            apodosUsados.Clear();
        }

        public static Personaje CrearPersonajeAleatorio()
        {
            Random random = new Random();
            string[] tipos = { "Guerrero", "Berserker", "Explorador", "Jarl" };
            string[] nombres = { "Ragnar", "Lagertha", "Bjorn", "Floki", "Rollo", "Ivar", "Ubbe", "Hvitserk", "Aslaug", "Sigurd", "Kjetill" };
            string[] apodos = { "El Valiente", "El Despiadado", "El Explorador", "El Conquistador", "El Sabio", "El Temible", "El Astuto", "El Fuerte", "El Justo", "El Terrible" };

            DateTime fechaDeNacimiento = GenerarFechaDeNacimiento(random);

            Personaje personaje = new Personaje
            {
                Tipo = tipos[random.Next(tipos.Length)],
                Nombre = GenerarNombreUnico(random, nombres),
                Apodo = GenerarApodoUnico(random, apodos),
                FechaDeNacimiento = fechaDeNacimiento,
                Edad = CalcularEdad(fechaDeNacimiento),
                Velocidad = random.Next(1, 11),
                Destreza = random.Next(1, 6),
                Fuerza = random.Next(1, 11),
                Nivel = random.Next(1, 11),
                Armadura = random.Next(1, 11),
                Salud = 100,
                SaludInicial = 100,
                Habilidades = random.Next(1, 11)
            };

            return personaje;
        }

        private static DateTime GenerarFechaDeNacimiento(Random random)
        {
            int anio = random.Next(DateTime.Now.Year - 60, DateTime.Now.Year - 18);
            int mes = random.Next(1, 13);
            int dia = random.Next(1, DateTime.DaysInMonth(anio, mes) + 1);

            return new DateTime(anio, mes, dia);
        }

        private static int CalcularEdad(DateTime fechaDeNacimiento)
        {
            int edad = DateTime.Now.Year - fechaDeNacimiento.Year;
            return edad;
        }

        private static string GenerarNombreUnico(Random random, string[] nombres)
        {
            string nombre;
            do
            {
                nombre = nombres[random.Next(nombres.Length)];
            } while (nombresUsados.Contains(nombre));

            nombresUsados.Add(nombre);
            return nombre;
        }

        private static string GenerarApodoUnico(Random random, string[] apodos)
        {
            string apodo;
            do
            {
                apodo = apodos[random.Next(apodos.Length)];
            } while (apodosUsados.Contains(apodo));

            apodosUsados.Add(apodo);
            return apodo;
        }
    }
}
