using System;

namespace animaciones
{
    public class AnimacionPelea
    {
        private int posicion1X;
        private int posicion1Y;
        private int posicion2X;
        private int posicion2Y;

        private string nombre1;
        private string nombre2;
        private int salud1;
        private int salud2;

        // Constructor de la clase que inicializa las posiciones, nombres y salud de los personajes
        public AnimacionPelea(int posicion1X, int posicion1Y, int posicion2X, int posicion2Y, string nombre1, string nombre2, int salud1, int salud2)
        {
            this.posicion1X = posicion1X;
            this.posicion1Y = posicion1Y;
            this.posicion2X = posicion2X;
            this.posicion2Y = posicion2Y;
            this.nombre1 = nombre1;
            this.nombre2 = nombre2;
            this.salud1 = salud1;
            this.salud2 = salud2;
        }

        // Actualiza la salud del primer vikingo y redibuja la información de los personajes
        public void ActualizarSaludVikingo1(int nuevaSalud)
        {
            salud1 = nuevaSalud;
            DibujarInfoPersonajes();
        }

        // Actualiza la salud del segundo vikingo y redibuja la información de los personajes
        public void ActualizarSaludVikingo2(int nuevaSalud)
        {
            salud2 = nuevaSalud;
            DibujarInfoPersonajes();
        }

        // Dibuja el primer vikingo en la posición asignada
        public void DibujarVikingo1()
        {
            // Guardar el color original
            ConsoleColor colorOriginal = Console.ForegroundColor;

            // Cambiar el color a rojo
            Console.ForegroundColor = ConsoleColor.Red;

            // Dibujar el primer vikingo en la posición asignada
            Console.SetCursorPosition(posicion1X, posicion1Y);
            Console.WriteLine(" ( •_•) ");
            Console.SetCursorPosition(posicion1X, posicion1Y + 1);
            Console.WriteLine(" ( ง )ง ");
            Console.SetCursorPosition(posicion1X, posicion1Y + 2);
            Console.WriteLine(" /︶\\ ");

            // Restaurar el color original
            Console.ForegroundColor = colorOriginal;
        }

        // Dibuja el segundo vikingo en la posición asignada
        public void DibujarVikingo2()
        {
            // Guardar el color original
            ConsoleColor colorOriginal = Console.ForegroundColor;

            // Cambiar el color a rojo
            Console.ForegroundColor = ConsoleColor.Red;

            // Dibujar el segundo vikingo en la posición asignada
            Console.SetCursorPosition(posicion2X, posicion2Y);
            Console.WriteLine(" (•_• ) ");
            Console.SetCursorPosition(posicion2X, posicion2Y + 1);
            Console.WriteLine(" ୧( ୧ ) ");
            Console.SetCursorPosition(posicion2X, posicion2Y + 2);
            Console.WriteLine("   /︶\\ ");

            // Restaurar el color original
            Console.ForegroundColor = colorOriginal;
        }



        // Dibuja la información de los personajes en la parte superior de la consola
        public void DibujarInfoPersonajes()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(new string(' ', Console.WindowWidth)); // Limpiar la línea completa
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"{nombre1}: ♥ {salud1}");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine(new string(' ', Console.WindowWidth - 30)); // Limpiar la línea completa
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"{nombre2}: ♥ {salud2}");
        }

        // Limpia la representación del primer vikingo en la consola
        public void LimpiarVikingo1()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(posicion1X, posicion1Y + i);
                Console.WriteLine("       ");
            }
        }

        // Limpia la representación del segundo vikingo en la consola
        public void LimpiarVikingo2()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(posicion2X, posicion2Y + i);
                Console.WriteLine("       ");
            }
        }

        // Mueve el primer vikingo a una nueva posición y lo redibuja
        public void MoverVikingo1(int deltaX, int deltaY)
        {
            LimpiarVikingo1();
            posicion1X += deltaX;
            posicion1Y += deltaY;
            DibujarVikingo1();
        }

        // Mueve el segundo vikingo a una nueva posición y lo redibuja
        public void MoverVikingo2(int deltaX, int deltaY)
        {
            LimpiarVikingo2();
            posicion2X += deltaX;
            posicion2Y += deltaY;
            DibujarVikingo2();
        }

        // Dibuja la escena completa, incluyendo la información de los personajes y los dos vikingos
        public void DibujarEscena()
        {
            Console.Clear();
            DibujarInfoPersonajes();
            DibujarVikingo1();
            DibujarVikingo2();
        }

        // Mueve el primer vikingo hacia adelante y luego hacia atrás, simulando un ataque
        public void MoverVikingo1Secuencia()
        {
            for (int i = 0; i < 5; i++) // Mover 5 pasos adelante
            {
                MoverVikingo1(2, 0);
                Thread.Sleep(100);
            }
            for (int i = 0; i < 5; i++) // Mover 5 pasos atrás
            {
                MoverVikingo1(-2, 0);
                Thread.Sleep(100);
            }

            DibujarEscena();
            Thread.Sleep(500); // Pausa para la animación
        }

        // Mueve el segundo vikingo hacia adelante y luego hacia atrás, simulando un ataque
        public void MoverVikingo2Secuencia()
        {
            for (int i = 0; i < 5; i++) // Mover 5 pasos adelante
            {
                MoverVikingo2(-2, 0);
                Thread.Sleep(100);
            }
            for (int i = 0; i < 5; i++) // Mover 5 pasos atrás
            {
                MoverVikingo2(2, 0);
                Thread.Sleep(100);
            }

            DibujarEscena();
            Thread.Sleep(500); // Pausa para la animación
        }
    }
}
