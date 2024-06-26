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
        public void ActualizarSaludVikingo1(int nuevaSalud)
        {
            salud1 = nuevaSalud;
            DibujarInfoPersonajes();
        }

        public void ActualizarSaludVikingo2(int nuevaSalud)
        {
            salud2 = nuevaSalud;
            DibujarInfoPersonajes();
        }


        public void DibujarVikingo1()
        {
            Console.SetCursorPosition(posicion1X, posicion1Y);
            Console.WriteLine("  O  ");
            Console.SetCursorPosition(posicion1X, posicion1Y + 1);
            Console.WriteLine(" /|\\ ");
            Console.SetCursorPosition(posicion1X, posicion1Y + 2);
            Console.WriteLine(" / \\ ");
            Console.SetCursorPosition(posicion1X, posicion1Y + 3);
            Console.WriteLine("/   \\");
        }

        public void DibujarVikingo2()
        {
            Console.SetCursorPosition(posicion2X, posicion2Y);
            Console.WriteLine("  O  ");
            Console.SetCursorPosition(posicion2X, posicion2Y + 1);
            Console.WriteLine(" \\|/ ");
            Console.SetCursorPosition(posicion2X, posicion2Y + 2);
            Console.WriteLine(" / \\ ");
            Console.SetCursorPosition(posicion2X, posicion2Y + 3);
            Console.WriteLine("/   \\");
        }

        public void DibujarInfoPersonajes()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"{nombre1}: ♥ {salud1}");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"{nombre2}: ♥ {salud2}");
        }
        public void LimpiarVikingo1()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(posicion1X, posicion1Y + i);
                Console.WriteLine("       ");
            }
        }

        public void LimpiarVikingo2()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(posicion2X, posicion2Y + i);
                Console.WriteLine("       ");
            }
        }

        public void MoverVikingo1(int deltaX, int deltaY)
        {
            LimpiarVikingo1();
            posicion1X += deltaX;
            posicion1Y += deltaY;
            DibujarVikingo1();
        }

        public void MoverVikingo2(int deltaX, int deltaY)
        {
            LimpiarVikingo2();
            posicion2X += deltaX;
            posicion2Y += deltaY;
            DibujarVikingo2();
        }

        public void DibujarEscena()
        {
            Console.Clear();
            DibujarInfoPersonajes();
            DibujarVikingo1();
            DibujarVikingo2();
        }
    }



}
