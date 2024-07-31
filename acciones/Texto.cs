namespace Texto
{



    public class Texto
    {
        public static void MostrarMenu()
        {

            Console.WriteLine("\nMENU PRINCIPAL:");
            Animado(15, "1. Jugar\n");
            Animado(15, "2. Ver historial de ganadores\n");
            Animado(15, "S. Salir\n");
            Animado(15, "\nIngrese el número de la opción deseada: ");

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
            Console.WriteLine("\nPresiona Enter para volver al inicio...");
            Console.ReadLine();
        }

        public static void Pelea(string nombre1, string nombre2)
        {
           Console.WriteLine($@"
{nombre1}: {nombre2} te voy a derrotar!

   ( •_•)                (•_• ) 
   ( ง )ง                 ୧( ୧ )
   /︶\                     /︶\

");

        
            
        }


        public static void Animado(int vel, string texto)
        {

            for (int i = 0; i < texto.Length; i++)
            {
                Console.Write(texto[i]);
                Thread.Sleep(vel);
            }
        }

        public static async Task Chiste()
        {
            try
            {
                string joke = await Api.ChistesProgramadores.Chistes();
                Console.WriteLine("Antes de derrotarte te contare un chiste que me enseño mi creador:");
                Console.WriteLine(joke);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }



}

