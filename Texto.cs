namespace Texto;

public class Texto
{
    public static void MostrarMenu()
    {
        Console.WriteLine("Bienvenido al juego de combate de personajes!");
        Console.WriteLine("\nMENU PRINCIPAL:");
        Console.WriteLine("1. Jugar");
        Console.WriteLine("2. Ver historial de ganadores");
        Console.WriteLine("3. Ver historia de cada personaje");
        Console.WriteLine("S. Salir");
        Console.Write("\nIngrese el número de la opción deseada: ");
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

        Console.WriteLine(@"           /|                                        |\");
        Console.WriteLine(@"         /  |                                        |  \");
        Console.WriteLine(@"       /   <              ,,''''|'''',,               >  \");
        Console.WriteLine(@"      |     \         ,,''      |      ``,,         /     |");
        Console.WriteLine(@"      |       \    ,''         | |         ``,     /       |");
        Console.WriteLine(@"       \        \,'            | |           `',/        /");
        Console.WriteLine(@"         \     ,'              | |              ',     /");
        Console.WriteLine(@"           \_,'                | |                ',_/");
        Console.WriteLine(@"            ;____             |   |             ____;");
        Console.WriteLine(@"            |____~~~---_______|   |_______---~~~____;");
        Console.WriteLine(@"            //   ~~~---_______|~-~|_______---~~~   ;\\");
        Console.WriteLine(@"          ///;    ,,=====,,,  ~~-~~  ,,,=====,,    ;|\|\");
        Console.WriteLine(@"         ||/`;   _--~~~~--__         __--~~~~--_   ;/|\|");
        Console.WriteLine(@"         /|||;  :  /       \~~-___-~~/       \  :  ;|\|\\");
        Console.WriteLine(@"         /\|;    -_\  (o)  / ,'; ;', \  (o)  /_-    ;||\\");
        Console.WriteLine(@"         |\|;      ~-____--~'  ; ;  '~--____-~      ;\||");
        Console.WriteLine(@"         /||;            ,`   ;   ;   ',            ;||\");
        Console.WriteLine(@"        |/|\ ;        ,'`    (  _  )    `',        ;/|\||");
        Console.WriteLine(@"        /|//|/;    ,'`        ~~ ~~        `',    ;|\\|\|\\");
        Console.WriteLine(@"       |/||\/||;  '                           '  ;\|/||\|\|\\");
        Console.WriteLine(@"       ///|||/||;         _--~~---~~--_         ;|\||/|\\|\\");
        Console.WriteLine(@"      |\||/\/|/||;      ,~-------------~,      ;\\|\||/|\\||");
        Console.WriteLine(@"     //||\|/|/||/;       ~~~~--------~~~       ;||\\|\|||\/|\\");
        Console.WriteLine(@"    ||/|/|||/||/;;`;,           -            ;';;\|\\|\\|/|\||\\");
        Console.WriteLine(@"   /|\|/||//|,,`    `;       -- _ --       ;'    `,,|\|\\|\||\\");
        Console.WriteLine(@"  ||/||//,,'`         `~--__         __--~`         `',,|\||\\||");
        Console.WriteLine(@" /|||,,'`                   ~~-----~~                   `',,|\|\|");
        Console.WriteLine(@"|,,'`                                                       `',,|");
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
}