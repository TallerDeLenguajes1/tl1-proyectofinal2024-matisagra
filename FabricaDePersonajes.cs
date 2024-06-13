
namespace FabricaDePersonajes
{


    public class Personaje
    {

        // Caracteristicas
        public int Velocidad { get; set; }
        public int Destreza { get; set; }
        public int Fuerza { get; set; }
        public int Nivel { get; set; }
        public int Armadura { get; set; }
        public int Salud { get; set; }

        // Datos
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Apodo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public int Edad { get; set; }

        public static Personaje CrearPersonajeAleatorio()
        {

            Random random = new Random();
            string[] tipos = { "Guerrero", "Berserker", "Explorador", "Jarl" };
            string[] nombres = { "Ragnar", "Lagertha", "Bjorn", "Floki", "Rollo", "Ivar", "Ubbe", "Hvitserk" };
            string[] apodos = { "El Valiente", "El Despiadado", "El Explorador", "El Conquistador", "El Sabio", "El Temible", "El Astuto", "El Fuerte" };

            DateTime fechaDeNacimiento = GenerarFechaDeNacimiento(random);

            Personaje personaje = new Personaje();

            personaje.Tipo = tipos[random.Next(tipos.Length)];
            personaje.Nombre = nombres[random.Next(nombres.Length)];
            personaje.Apodo = apodos[random.Next(apodos.Length)];
            personaje.FechaDeNacimiento = fechaDeNacimiento;
            personaje.Edad = CalcularEdad(fechaDeNacimiento);
            personaje.Velocidad = random.Next(1, 11);
            personaje.Destreza = random.Next(1, 6);
            personaje.Fuerza = random.Next(1, 11);
            personaje.Nivel = random.Next(1, 11);
            personaje.Armadura = random.Next(1, 11);

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

        public void MostrarPersonaje()
        {
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Apodo: {Apodo}");
            Console.WriteLine($"Fecha de Nacimiento: {FechaDeNacimiento.ToShortDateString()}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Velocidad: {Velocidad}");
            Console.WriteLine($"Destreza: {Destreza}");
            Console.WriteLine($"Fuerza: {Fuerza}");
            Console.WriteLine($"Nivel: {Nivel}");
            Console.WriteLine($"Armadura: {Armadura}");
            Console.WriteLine($"Salud: {Salud}");

        }



    }




}