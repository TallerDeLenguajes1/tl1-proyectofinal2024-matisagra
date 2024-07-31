# Vikingos

**Vikingos** es un videojuego inspirado en los personajes de la serie "Vikings". En este juego, los personajes poseen habilidades específicas para la batalla, tales como velocidad, destreza, fuerza, nivel, armadura y salud.

## Menú Principal

Al iniciar el juego, se despliega el menú principal con las siguientes opciones:

- **Jugar**
- **Historial de Ganadores**

## Jugar

1. **Presentación**: Al seleccionar la opción "Jugar", comienza la partida con una presentación.

   En esta etapa se verifica si existe un archivo JSON y se extraen los datos de los personajes. Si no existe el archivo JSON, se crea una lista aleatoria de 10 personajes y se guarda en el archivo JSON.

2. **Selección de Personaje**: Aparece una lista de personajes disponibles. Selecciona tu personaje para la partida.

   En esta etapa se muestra la lista de personajes del archivo JSON y se retira de la lista al personaje que elegiste.

3. **Enemigos**: Se muestra una lista de personajes con los que te enfrentarás.

   En esta etapa se muestra la lista de personajes del archivo JSON sin el personaje que elegiste.

4. **Presentación de la Pelea**: Los personajes seleccionados se presentan frente a frente y tu personaje le cuenta un chiste al oponente.

   En esta etapa aparecen tus personajes representados con arte ASCII y se utiliza una [API de chistes](https://v2.jokeapi.dev/). Ten en cuenta que se requiere conexión a Internet para hacer conexión con la API, así que es normal que esta parte del juego pueda demorar.

5. **Combate**: Inicia el combate con una animación donde ambos personajes se enfrentan. La salud de los personajes se muestra en la parte superior de la pantalla.

   En esta etapa, cada golpe se calcula con la fórmula propuesta por la materia: `(ataque * efectividad) - defensa / constanteAjuste`. Un factor importante es la suerte para poder dar un golpe crítico a tu oponente, por lo que suelen ser más difíciles las primeras rondas donde tu personaje no ha sido mejorado.

6. **Ganar**: Si ganas, podrás distribuir 10 puntos de mejora entre las estadísticas de salud y defensa de tu personaje. Si derrotas a todos los guerreros, aparecerá un texto diciendo que ganaste y te pedirá que ingreses tu nombre para guardarlo en el historial de ganadores.

7. **Perder**: Si tu personaje es derrotado, aparecerá un texto diciendo que perdiste y podrás iniciar una nueva partida.

Después de cada partida, el archivo JSON de personajes se reinicia para que cuando inicie una nueva partida se generen de nuevo los personajes.

## Historial de Ganadores

Muestra el historial de todos los personajes que ganaron el juego con su nombre y el personaje que utilizaron. 





