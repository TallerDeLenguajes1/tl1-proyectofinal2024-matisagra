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

            Personaje personaje = new Personaje();

            personaje.Tipo = tipos[random.Next(tipos.Length)];
            personaje.Nombre = GenerarNombreUnico(random, nombres);
            personaje.Apodo = GenerarApodoUnico(random, apodos);
            personaje.FechaDeNacimiento = fechaDeNacimiento;
            personaje.Edad = CalcularEdad(fechaDeNacimiento);
            personaje.Velocidad = random.Next(1, 11);
            personaje.Destreza = random.Next(1, 6);
            personaje.Fuerza = random.Next(1, 11);
            personaje.Nivel = random.Next(1, 11);
            personaje.Armadura = random.Next(1, 11);
            personaje.Salud = 100;

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
