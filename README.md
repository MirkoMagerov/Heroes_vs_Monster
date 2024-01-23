# CLASES DE EQUIVALÉNCIA

## Clase - Menu Options

### CheckMenuDecision()

| Dominio | Clase | Tipo | Return | Limite Inferior | Limite superior  |
|:--------|:------|:-----|:-------:|:---------------:|:----------------:|
| N. Enteros | (-Infinito, -1) | No válida | FALSE | -100 | -1 |
| N. Enteros | (0, Número de opciones del menu) | Válida | TRUE | 0 | Número de opciones del menu |
| N. Enteros | (Número de opciones del menu +1, Infinito) | No válida | FALSE | Número de opciones del menu +1 | 100 |

## Clase - Characters Creation

### CheckCharacterStat()

| Dominio | Clase | Tipo | Return | Limite Inferior | Limite superior  |
|:--------|:------|:-----|:-------:|:---------------:|:----------------:|
| N. Enteros | (-Infinito, Limite inferior de stat -1) | No válida | FALSE | -100 | Limite inferior de stat -1 |
| N. Enteros | (Limite inferior de stat, Limite superior de stat) | Válida | TRUE | Limite inferior de stat | Limite superior de stat |
| N. Enteros | (Limite superior de stat +1, Infinito) | No válida | FALSE | Limite superior de stat +1 | Infinito |

## Clase - General Utils

### CheckAbilityOnCooldown()
| Dominio | Clase | Tipo | Return | Limite Inferior | Limite superior  |
|:--------|:------|:-----|:-------:|:---------------:|:----------------:|
| N. Enteros (charIndex) | (-Infinito, -1) | No válida | FALSE | -Infinito | -1 |
| N. Enteros (charIndex) | (0, 3) | Válida | TRUE | 0 | 1 |
| N. Enteros (charIndex) | (4, Infinito) | No válida | FALSE | 4 | Infinito |
| N. Enteros (cooldowns) | (-Infinito, -1) | No válida | FALSE | -Infinito | -1 |
| N. Enteros (cooldowns) | (0, 5) | Válida | TRUE / FALSE (depende del cooldown) | 0 | 5 |
| N. Enteros (cooldowns) | (6, Infinito) | No válida | FALSE | 6 | Infinito |

## Sin clases ni métodos

### Pedir nombres de los personajes
| Dominio | Clase | Tipo | Return | Limite Inferior | Limite superior  |
|:--------|:------|:-----|:-------:|:---------------:|:----------------:|
| String | (Sin comas) | No válida | FALSE | Sin comas | Sin comas |
| String | (Menos de 1 coma, 2 comas) | No válida | FALSE | -1 | 2 |
| String | (3, 3) | Válida | TRUE | 3 | 3 |
| String | (4, Más de 4 comas) | No válida | FALSE | 4 | +4 |

## Funcionalidades Extra

### 🔠 Método para poner la primera letra de cada nombre en mayúscula porque son nombres propios (CapitalizeFirstLetter()) 🔠

### 🔃 Si el usuario elije la opción de usar habilidad especial y está en cooldown, se le vuelve a preguntar para que elija otra opción de turno pero se le resta un intento 🔃

### 🎥 Se añaden dibujos para representar cada personaje y para cuando alguno de los dos bandos gane 🎥

### 💫 Se añaden diferentes colores para visualizar de manera sencilla datos, como por ejemplo color verde cuando se le quita vida al monstruo o ocurre algo positivo hacia los héroes, y en rojo cuando se le quita vida a los héroes o ocurre algo negativo hacia los héroes 💫

### 📝 Se añade una pequeña descripción del juego y de las dificultades, y una pequeña instrucción para explicar como elegir las opciones que el usuario desee en cada caso 📝