using FabricaDePersonajes;

public class Juego{
    public static void Jugar()
    {
        
        
        Console.Clear();
        Texto.Texto.Presentacion();

        Console.WriteLine("\nPresiona Enter para comenzar...");
        Console.ReadLine();
        Personaje.ReiniciarListasUsadas();

        string nombreArchivo = "personajes/personajes.json";
        string nombreArchivo2 = "ganadores/ganadores.json";
        List<Personaje> personajes;

        bool archivoExiste = PersonajesJson.PersonajesJson.Existe(nombreArchivo);

        if (archivoExiste)
        {
            personajes = PersonajesJson.PersonajesJson.LeerPersonajes(nombreArchivo);
        }
        else
        {
            personajes = new List<Personaje>();
            for (int i = 0; i < 10; i++)
            {
                personajes.Add(Personaje.CrearPersonajeAleatorio());
            }
            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);
        }

        Personaje ganador = null;
        while (personajes.Count > 1)
        {
           Console.Clear();

            if (ganador == null)
            {
                Console.WriteLine("\nPersonajes disponibles:");
                for (int i = 0; i < personajes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
                }

                Console.Write("\nElija el número de su personaje: ");
                int indicePersonaje1 = int.Parse(Console.ReadLine()) - 1;
                ganador = personajes[indicePersonaje1];
            }

           Console.Clear();

            Console.WriteLine($"\nPersonajes disponibles para combatir contra {ganador.Nombre}:");
            for (int i = 0; i < personajes.Count; i++)
            {
                if (personajes[i] != ganador)
                {
                    Console.WriteLine($"{i + 1}. {personajes[i].Nombre} ({personajes[i].Tipo})");
                }
            }

            Console.Write("\nElija el número del personaje oponente: ");
            int indicePersonaje2 = int.Parse(Console.ReadLine()) - 1;
            Personaje oponente = personajes[indicePersonaje2];

            Console.WriteLine($"\nComienza la competencia entre {ganador.Nombre} y {oponente.Nombre}:");
            Texto.Texto.AnimacionPelea(ganador.Nombre,oponente.Nombre);
            Combate.Combate.Combatir(ganador, oponente, personajes);

            if (ganador.Salud <= 0)
            {
                HistorialJson.HistorialJson.GuardarGanador(oponente,nombreArchivo2);
               Texto.Texto.Perdiste();
            }

            if (personajes.Count == 1)
            {
                Texto.Texto.Ganaste();
                HistorialJson.HistorialJson.GuardarGanador(ganador, nombreArchivo2);
                personajes.Clear();
            }

            PersonajesJson.PersonajesJson.GuardarPersonajes(personajes, nombreArchivo);

            Console.WriteLine("\nPresiona Enter para continuar...");
            Console.ReadLine();
        }

    }

}