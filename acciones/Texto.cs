namespace Texto
{



    public class Texto
    {
        public static void MostrarMenu()
        {
            
            Console.WriteLine("\nMENU PRINCIPAL:");
            Animado(15,"1. Jugar\n");
            Animado(15,"S. Salir\n");
            Animado(15,"\nIngrese el número de la opción deseada: ");
        
        }
        public static void Presentacion()
        {
            Console.WriteLine("##   ##   ######  ### ###   ######  ##   ##   #####    #####    #####");
            Console.WriteLine("##   ##     ##     ## ##      ##    ###  ##  ##   ##  ### ###  ##   ##");
            Console.WriteLine("##   ##     ##     ####       ##    #### ##  ##       ##   ##  ##");
            Console.WriteLine(" ## ##      ##     ###        ##    #######  ## ####  ##   ##   #####");
            Console.WriteLine(" ## ##      ##     ####       ##    ## ####  ##   ##  ##   ##       ##");
            Console.WriteLine("  ###       ##     ## ##      ##    ##  ###  ##   ##  ### ###  ##   ##");
            Console.WriteLine("  ###     ######  ### ###   ######  ##   ##   #####    #####    #####");
            Console.WriteLine();
            Console.WriteLine("       ***************************************************");
            Console.WriteLine("       *                                                 *");
            Console.WriteLine("       *          Bienvenido al juego de Vikingos        *");
            Console.WriteLine("       *                                                 *");
            Console.WriteLine("       *    En este juego, te convertirás en un valiente *");
            Console.WriteLine("       *     guerrero vikingo y enfrentarás desafíos     *");
            Console.WriteLine("       *      épicos en busca de la gloria y el honor.   *");
            Console.WriteLine("       *                                                 *");
            Console.WriteLine("       *   Prepárate para combatir contra enemigos y     *");
            Console.WriteLine("       *        demostrar tu valía en la batalla.        *");
            Console.WriteLine("       *                                                 *");
            Console.WriteLine("       *        ¡Que los dioses te guíen, guerrero!      *");
            Console.WriteLine("       *                                                 *");
            Console.WriteLine("       ***************************************************");

        }

        public static void Ganaste()
        {
            Console.WriteLine(@"____    ____  ______    __    __     ____    __    ____  __  .__   __. 
\   \  /   / /  __  \  |  |  |  |    \   \  /  \  /   / |  | |  \ |  | 
 \   \/   / |  |  |  | |  |  |  |     \   \/    \/   /  |  | |   \|  | 
  \_    _/  |  |  |  | |  |  |  |      \            /   |  | |  . `  | 
    |  |    |  `--'  | |  `--'  |       \    /\    /    |  | |  |\   | 
    |__|     \______/   \______/         \__/  \__/     |__| |__| \__| 
                                                                        ");
        }

        public static void Perdiste()
        {
            Console.WriteLine(@"┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀
██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼
██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀
██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼
███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼
██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼
██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼
██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼
███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄
┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼
┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼");
        }

    public static void Animado(int vel, string texto)
    {

        for (int i = 0; i < texto.Length; i++)
        {
            Console.Write(texto[i]);
            Thread.Sleep(vel);
        }
    }

    public static void AnimacionPelea(string personaje1, string personaje2)
        {
            int anchoConsola = Console.WindowWidth;

            // Posiciones iniciales de los guerreros
            int posicionGuerrero1 = 0;
            int posicionGuerrero2 = anchoConsola - 10;

            // Bucle de animación
            while (Math.Abs(posicionGuerrero1 - posicionGuerrero2) > 10)
            {
                Console.Clear();
                DibujarGuerrero(posicionGuerrero1, personaje1);
                DibujarGuerrero(posicionGuerrero2, personaje2);

                // Simular la pelea
                if (posicionGuerrero1 < posicionGuerrero2 - 5)
                    posicionGuerrero1++;
                if (posicionGuerrero2 > posicionGuerrero1 + 5)
                    posicionGuerrero2--;

                Thread.Sleep(15); // Ajusta el tiempo para controlar la velocidad de la animación
            }
        }

         public static void DibujarGuerrero(int posicion, string nombre)
        {
            Console.SetCursorPosition(posicion, Console.WindowHeight / 2);
            Console.WriteLine($" {nombre}");
            Console.SetCursorPosition(posicion, Console.WindowHeight / 2 + 1);
            Console.WriteLine(@"   O");
            Console.SetCursorPosition(posicion, Console.WindowHeight / 2 + 2);
            Console.WriteLine(@" \_|_/");
            Console.SetCursorPosition(posicion, Console.WindowHeight / 2 + 3);
            Console.WriteLine(@"   |");
            Console.SetCursorPosition(posicion, Console.WindowHeight / 2 + 4);
            Console.WriteLine(@"  / \");
        }
    
}

    }

    