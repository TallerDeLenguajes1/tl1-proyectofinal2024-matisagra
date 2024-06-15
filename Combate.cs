using FabricaDePersonajes;

namespace Combate
{

    public class Combate
    {
        public static void Combatir(Personaje personaje1, Personaje personaje2, List<Personaje> personajes)
        {
            Random random = new Random();
            bool sigueCombate = true;

           while (sigueCombate)
        {
            // Turno de personaje1 (ataque personaje1, defiende personaje2)
            int danioCausado = CalcularDanioCausado(personaje1, personaje2, random);
            personaje2.Salud -= danioCausado;
            Console.WriteLine($"{personaje1.Nombre} ataca a {personaje2.Nombre} y le causa {danioCausado} puntos de daño.");

            // Verificar si personaje2 ha sido derrotado
            if (personaje2.Salud <= 0)
            {
                Console.WriteLine($"{personaje2.Nombre} ha sido derrotado.");
                // Aplicar mejora al personaje1
                MejorarPersonaje(personaje1);
                // Eliminar personaje2 de la lista
                personajes.Remove(personaje2);
                sigueCombate = false;
                break;
            }

            // Turno de personaje2 (ataque personaje2, defiende personaje1)
            danioCausado = CalcularDanioCausado(personaje2, personaje1, random);
            personaje1.Salud -= danioCausado;
            Console.WriteLine($"{personaje2.Nombre} ataca a {personaje1.Nombre} y le causa {danioCausado} puntos de daño.");

            // Verificar si personaje1 ha sido derrotado
            if (personaje1.Salud <= 0)
            {
                Console.WriteLine($"{personaje1.Nombre} ha sido derrotado.");
                // Aplicar mejora al personaje2
                MejorarPersonaje(personaje2);
                // Eliminar personaje1 de la lista
                personajes.Remove(personaje1);
                sigueCombate = false;
            }
        }
        }

        static int CalcularDanioCausado(Personaje atacante, Personaje defensor, Random random)
        {
            // Calcular componentes del daño
            int ataque = atacante.Destreza * atacante.Fuerza * atacante.Nivel;
            int efectividad = random.Next(1, 101);
            int defensa = defensor.Armadura * defensor.Velocidad;
            const int constanteAjuste = 500;

            // Calcular daño
            int danio = ((ataque * efectividad) - defensa) / constanteAjuste;

            // Asegurarse de que el daño no sea negativo
            return Math.Max(danio, 0);
        }

        static void MejorarPersonaje(Personaje ganador)
        {
            Random random = new Random();
            // Asumimos que el ganador recibe un aumento en la salud o defensa
            if (random.Next(0, 2) == 0) // 50% de probabilidad de elegir entre salud o defensa
            {
                ganador.Salud += 10; // Aumento de 10 en la salud
                Console.WriteLine($"{ganador.Nombre} ha mejorado su salud en +10.");
            }
            else
            {
                ganador.Armadura += 5; // Aumento de 5 en la armadura (defensa)
                Console.WriteLine($"{ganador.Nombre} ha mejorado su defensa en +5.");
            }
        }




    }
}