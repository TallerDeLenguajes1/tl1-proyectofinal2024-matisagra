namespace Texto
{



    public class Texto
    {
        public static void MostrarMenu()
        {
            

            // Cambiar el color del texto a azul
            Console.ForegroundColor = ConsoleColor.Blue;

            // Mostrar el menú con animación
            Console.WriteLine("\nMENU PRINCIPAL:");
            Animado(15, "1. Jugar\n");
            Animado(15, "2. Ver historial de ganadores\n");
            Animado(15, "S. Salir\n");
            Animado(15, "\nIngrese el número de la opción deseada: ");

            
        }

        public static void Presentacion()
        {
            // Guardar los colores originales
            ConsoleColor colorOriginalTexto = Console.ForegroundColor;
            ConsoleColor colorOriginalFondo = Console.BackgroundColor;

            // Colores para el texto
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("##   ##   ######  ### ###   ######  ##   ##   #####    #####    #####");
            Console.WriteLine("##   ##     ##     ## ##      ##    ###  ##  ##   ##  ### ###  ##   ##");
            Console.WriteLine("##   ##     ##     ####       ##    #### ##  ##       ##   ##  ##");
            Console.WriteLine(" ## ##      ##     ###        ##    #######  ## ####  ##   ##   #####");
            Console.WriteLine(" ## ##      ##     ####       ##    ## ####  ##   ##  ##   ##       ##");
            Console.WriteLine("  ###       ##     ## ##      ##    ##  ###  ##   ##  ### ###  ##   ##");
            Console.WriteLine("  ###     ######  ### ###   ######  ##   ##   #####    #####    #####");
            
            // Restaurar el color original para el siguiente texto
            Console.ForegroundColor = colorOriginalTexto;
            Console.BackgroundColor = ConsoleColor.Black;  // Asegúrate de que el fondo sea negro o ajusta según tu preferencia

            Console.WriteLine();
            
            // Colores para el marco de bienvenida
            Console.ForegroundColor = ConsoleColor.Blue;
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

            // Restaurar el color original para el mensaje final
            Console.ForegroundColor = colorOriginalTexto;
            
            Console.WriteLine("Presione enter para continuar...");
            Console.ReadLine();
        }


        public static void Dificultad()
        {
            Console.WriteLine("\nSelecciona la dificultad:");
            Console.WriteLine("1. Fácil (3 rivales)");
            Console.WriteLine("2. Medio (6 rivales)");
            Console.WriteLine("3. Difícil (9 rivales)");
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

