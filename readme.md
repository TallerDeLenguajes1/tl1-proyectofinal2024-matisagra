# Vikings

**Vikings** es un videojuego inspirado en los personajes de la serie "Vikings". En este juego, los personajes poseen habilidades específicas para la batalla, tales como velocidad, destreza, fuerza, nivel, armadura y salud.

## Menú Principal

Al iniciar el juego, se despliega el menú principal con las siguientes opciones:

- **Jugar**
- **Historial de Ganadores**

## Jugar

1. **Presentación**: Al seleccionar la opción "Jugar", comienza la partida con una presentación.

En esta etapa verifica si existe un archivo json y extrae los datos de los personajes, si no existe el archivo json crea una lista aleatoria de 10 de personajes y la guarda en el archivo json

2. **Selección de Personaje**: Aparece una lista de personajes disponibles. Selecciona tu personaje para la partida.

En esta etapa se muestra la lista de personajes del archivo json y a tu personaje elegido lo retira de la lista

3. **Enemigos**: Se muestra una lista de personajes con los que te enfrentarás.

En esta etapa muestra la lista de personajes del archivo json sin el personaje que elegiste.

4. **Presentación de la Pelea**: Los personajes seleccionados se presentan frente a frente y tu personaje le cuenta un chiste al oponente.

En esta etapa aparecen tus personajes realizados con arte ASCII y se hace uso de una API de chistes. Tener en cuenta que se requiere conexion a internet para hacer conexion con la API asi que es normal que esta parte del juego pueda demorar

5. **Combate**: Inicia el combate con una animación donde ambos personajes se enfrentan. La salud de los personajes se muestra en la parte superior de la pantalla.

En esta etapa cada golpe de calcula con la formula propuesta por la materia ((ataque * efectividad) - defensa) / constanteAjuste. Donde un factor importante es la suerte para poder dar un golpe critico a tu oponente. Por esa razon suelen ser las mas dificiles las primeras rondas donde tu personaje no fue mejorado.

6. **Ganar**: En esta etapa podrás distribuir 10 puntos de mejora entre las estadísticas de salud y defensa de tu personaje. Si ya derrotaste a todos los guerreros aparecera un texto diciendo que ganaste y te pedira que ingreses tu nombre para guardarlo en el historial de ganadores.

7. **Perder**: En esta etapa si tu personaje es derrotado aparecera un texto diciendo que perdiste y podras volver a inicial una partida.

Despues de cada partida el archivo json de personajes se reinicia asi cuando inicie una nueva partida se generen de nuevo los personajes

## Historial de Ganadores

Muestra el historial de todos las personajes que ganaron el juego con su nombre y personaje que utilizaron.




