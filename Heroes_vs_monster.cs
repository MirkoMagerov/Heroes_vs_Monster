using HeroesVsMonster_CharactersCreation;
using HeroesVsMonster_GeneralUtils;
using HeroesVsMonster_MenuOptions;
using HeroesVsMonster_TurnOptions;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace HeroesVsMonster
{
    public static class ConsoleApp
    {
        // CÓDIGO MAIN
        public static void Main()
        {
            // ****************************** CONSTRAINTS ******************************
            // Messages
            const string MSG_HEROES_VS_MONSTER = "\r\n    __  __ ______ ____   ____   ______ _____    _    __ _____    __  ___ ____   _   __ _____ ______ ______ ____ \r\n   / / / // ____// __ \\ / __ \\ / ____// ___/   | |  / // ___/   /  |/  // __ \\ / | / // ___//_  __// ____// __ \\\r\n  / /_/ // __/  / /_/ // / / // __/   \\__ \\    | | / / \\__ \\   / /|_/ // / / //  |/ / \\__ \\  / /  / __/  / /_/ /\r\n / __  // /___ / _, _// /_/ // /___  ___/ /    | |/ / ___/ /  / /  / // /_/ // /|  / ___/ / / /  / /___ / _, _/ \r\n/_/ /_//_____//_/ |_| \\____//_____/ /____/     |___/ /____/  /_/  /_/ \\____//_/ |_/ /____/ /_/  /_____//_/ |_|  \r\n                                                                                                                \r\n\r\n        ___ \r\n _   __|__ \\\r\n| | / /__/ /\r\n| |/ // __/ \r\n|___//____/ \r\n            \r\n";
            const string MSG_TYPE_TO_CONTINUE = "Pulsa cualquier tecla para continuar . . . ";
            const string MSG_WELCOME = "¡Bienvenido al emocionante juego de estrategia por turnos: \"Héroes vs Monstruo - v2\"!\n\nEn este fascinante enfrentamiento, controlarás a un equipo de cuatro valientes héroes,\ncada uno con habilidades únicas, mientras se enfrentan a un monstruo temible que amenaza nuestro mundo.\n\n¡Prepárate para la batalla y lleva a tus héroes hacia la victoria en este épico duelo por turnos!\n\n¿Estás listo para desafiar a las fuerzas oscuras y demostrar tu destreza estratégica? ¡Que comience la aventura!";
            const string MSG_OPTIONS_INSTRUCTIONS = "Para tomar decisiones y seleccionar opciones, simplemente escribe el número que ves al lado de cada opción.\n\nPor ejemplo, si deseas elegir la opción número 3, solo escribe '3' y presiona Enter.\n\n¡Diviértete explorando el mundo del juego y tomando decisiones que influirán en tu aventura!";
            const string MSG_EXIT = "Has elegido salir de tu aventura. ¡Regresa cuando quieras más emociones y aventuras!";
            const string MSG_PLAY = "¡Has elegido empezar una nueva aventura! Suerte valiente guerrero, ¡y haz que el monstruo pague sus pecados!\nSelecciona la dificultad que deseas para tu aventura.";
            const string MSG_MAIN_MENU = "Selecciona la opción que deseas elegir. Puedes empezar una nueva aventura, o guardar fuerzas y volver en otro momento.";
            const string MSG_ENTER_NAMES = "Introduce 4 nombres separados por comas.\n\nEjemplo: Arquera, Bárbaro, Maga, Druida\n\nEl nombre de cada personaje se asignará en el mismo orden que en el ejemplo.\n\nLa primera letra se convertirá en una mayúscula automáticamente.\n\nEscribe aqui: ";
            const string MSG_WRONG_NAMES = "Te has equivocado con la cantidad de nombres. Recuerda que deben estar separados por comas entre ellos.";
            const string MSG_EASY_DIFFICULTY = "- Fácil: La opción fácil asigna automáticamente los valores más altos disponibles para los héroes y los valores\nmás bajos para el monstruo. ¡Ideal para quienes buscan una experiencia más relajada y centrada en la historia!";
            const string MSG_HARD_DIFFICULTY = "- Difícil: Si buscas un verdadero desafío, elige la dificultad difícil. Aquí, el monstruo tendrá las stats potenciadas\nmientras que tus personajes enfrentarán mayores obstáculos. ¿Estás preparado para la batalla?";
            const string MSG_PERSONALIZED_DIFFICULTY = "- Personalizada: Toma el control total. En la dificultad personalizada, puedes elegir manualmente los valores para tus\npersonajes y monstruos dentro de un rango especificado. ¡Ajusta la dificultad a tu gusto!";
            const string MSG_RANDOM_DIFFICULTY = "- Random: Deja que el azar decida. La opción random asigna de manera aleatoria las estadísticas de todos los\npersonajes, agregando un elemento impredecible a tu aventura. ¿Quién sabe qué desafíos te esperan?";
            const string MSG_CHOOSE_WISELY = "Elige sabiamente y disfruta de tu viaje en este emocionante juego.";

            // Difficulty numbers and general flow constraints
            const int PersonalizedMode = 1;

            // Valid range for every character stats
            const int MinArcherHealthValue = 1500, MaxArcherHealthValue = 2000, MinArcherAttackValue = 180, MaxArcherAttackValue = 300, MinArcherDefenseValue = 25, MaxArcherDefenseValue = 35;
            const int MinBarbarianHealthValue = 3000, MaxBarbarianHealthValue = 3750, MinBarbarianAttackValue = 150, MaxBarbarianAttackValue = 250, MinBarbarianDefenseValue = 35, MaxBarbarianDefenseValue = 45;
            const int MinMageHealthValue = 1100, MaxMageHealthValue = 1500, MinMageAttackValue = 300, MaxMageAttackValue = 400, MinMageDefenseValue = 20, MaxMageDefenseValue = 35;
            const int MinDruidHealthValue = 2000, MaxDruidHealthValue = 2500, MinDruidAttackValue = 70, MaxDruidAttackValue = 120, MinDruidDefenseValue = 25, MaxDruidDefenseValue = 40;
            const int MinMonsterHealthValue = 7000, MaxMonsterHealthValue = 10000, MinMonsterAttackValue = 300, MaxMonsterAttackValue = 400, MinMonsterDefenseValue = 20, MaxMonsterDefenseValue = 30;
            const int IndexArcher = 0, IndexBarbarian = 1, IndexMage = 2, IndexDruid = 3, IndexMonster = 4, IndexHealth = 0, IndexAttack = 1, IndexDefense = 2, numberOfCharacters = 5;
            const int ZERO = 0, ONE = 1, TWO = 2, THREE = 3, FOUR = 4, FIVE = 5, ONE_HUNDRED = 100, FIVE_HUNDRED = 500;

            // ****************************** VARIABLES ******************************
            // Opciones de menús
            string[] mainMenuOptions = { "Salir", "Iniciar nueva batalla" };
            string[] difficultyOptions = { "Random", "Personalizada", "Difícil", "Fácil" };
            string[] turnOptions = { "Usar habilidad especial", "Protegerse", "Atacar" };

            Random random = new();

            string[] names = new string[numberOfCharacters - ONE];

            // Variables de flow general del programa
            bool allHeroesDead = false;
            int tries = 3, mainMenuDecision, difficultyDecision, turnDecision = 0;

            // Special characters variables
            int archerCooldown = 0, barbarianCooldown = 0, mageCooldown = 0, druidCooldown = 0, monsterKnockout = 0, barbarianAbilityTurns = 0;

            // Stats
            double[,] charactersStats = new double[5, 3];

            // Guardar variables originales como vida y defensa en otra matriz aparte
            double[,] originalStats = new double[4, 2];

            int[] turnOrder;

            int[,] allStatsRange = new int[,]
            {
                { MinArcherHealthValue, MaxArcherHealthValue, MinArcherAttackValue, MaxArcherAttackValue, MinArcherDefenseValue, MaxArcherDefenseValue },
                { MinBarbarianHealthValue, MaxBarbarianHealthValue, MinBarbarianAttackValue, MaxBarbarianAttackValue, MinBarbarianDefenseValue, MaxBarbarianDefenseValue },
                { MinMageHealthValue, MaxMageHealthValue, MinMageAttackValue, MaxMageAttackValue, MinMageDefenseValue, MaxMageDefenseValue },
                { MinDruidHealthValue, MaxDruidHealthValue, MinDruidAttackValue, MaxDruidAttackValue, MinDruidDefenseValue, MaxDruidDefenseValue },
                { MinMonsterHealthValue, MaxMonsterHealthValue, MinMonsterAttackValue, MaxMonsterAttackValue, MinMonsterDefenseValue, MaxMonsterDefenseValue }
            };

            // ****************************** PROGRAM ******************************
            // Titulo del juego
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MSG_HEROES_VS_MONSTER);
            Console.ResetColor();
            Console.Write(MSG_TYPE_TO_CONTINUE);
            Console.ReadKey();
            Console.Clear();

            // Descripción básica del juego
            Console.WriteLine(MSG_WELCOME);
            Console.WriteLine();
            Console.Write(MSG_TYPE_TO_CONTINUE);
            Console.ReadKey();
            Console.Clear();

            // Explicar la manera de escoger las opciones de los menús
            Console.WriteLine(MSG_OPTIONS_INSTRUCTIONS);
            Console.WriteLine();
            Console.Write(MSG_TYPE_TO_CONTINUE);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(MSG_MAIN_MENU);
            Console.WriteLine();

            do // Menu de jugar o salir
            {
                MenuOptions.PrintMainMenuOptions(mainMenuOptions);
                string input = Console.ReadLine() ?? "".Trim();
                Console.ResetColor();

                if (input != "") mainMenuDecision = Convert.ToInt32(input);
                else mainMenuDecision = -1;
                Console.Clear();

            } while (!MenuOptions.CheckMenuDecision(mainMenuOptions, mainMenuDecision, ref tries) && tries > 0);

            Console.Clear();

            // Salir
            if (mainMenuDecision == 0)
            {
                Console.Clear();
                Console.WriteLine(MSG_EXIT);
            }

            // Jugar
            else if (tries > 0 && mainMenuDecision == 1)
            {
                // ************************** Nombres de los personajes **************************
                string[] tempNames;
                do
                {
                    Console.Write(MSG_ENTER_NAMES);
                    string namesInput = Console.ReadLine() ?? "".Trim();
                    namesInput = namesInput.Replace(" ", "");
                    tempNames = namesInput.Split(",");
                    Console.Clear();

                    if (tempNames.Length != 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(MSG_WRONG_NAMES);
                        Console.ResetColor();
                        Console.WriteLine();
                    }

                } while (tempNames.Length != 4);

                for (int i = 0; i < names.Length; i++)
                {
                    names[i] = CharactersCreation.CapitalizeFirstLetter(tempNames[i]);
                }

                // ************************* Escoger dificultad **************************

                Console.WriteLine(MSG_PLAY);
                Console.WriteLine();
                Console.WriteLine(MSG_EASY_DIFFICULTY);
                Console.WriteLine();
                Console.WriteLine(MSG_HARD_DIFFICULTY);
                Console.WriteLine();
                Console.WriteLine(MSG_PERSONALIZED_DIFFICULTY);
                Console.WriteLine();
                Console.WriteLine(MSG_RANDOM_DIFFICULTY);
                Console.WriteLine();
                Console.WriteLine(MSG_CHOOSE_WISELY);
                Console.WriteLine();

                tries = 3;
                do
                {
                    MenuOptions.PrintDifficultyMenuOptions(difficultyOptions);
                    string input = Console.ReadLine() ?? "".Trim();
                    Console.ResetColor();

                    if (input != "") difficultyDecision = Convert.ToInt32(input);
                    else difficultyDecision = -1;
                    Console.Clear();

                } while (!MenuOptions.CheckMenuDecision(difficultyOptions, difficultyDecision, ref tries) && tries > 0);

                if (tries > 0)
                {
                    // ************************** Creación personajes según dificultad **************************
                    if (difficultyDecision == PersonalizedMode)
                    {
                        for (int i = 0; i < numberOfCharacters; i++)
                        {
                            for (int j = 0; j < charactersStats.GetLength(1); j++)
                            {
                                tries = 3;
                                string input;
                                double stat;

                                do
                                {
                                    if (j == 0)
                                    {
                                        Console.Write("Introduce la ");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("vida ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("para ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"names[i].");
                                        Console.ResetColor();

                                        CharactersCreation.PrintCharacterHealthStat(allStatsRange[i, ZERO], allStatsRange[i, ONE]);
                                    }
                                    else if (j == 1)
                                    {
                                        Console.Write("Introduce el ");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("ataque ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("para ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"names[i].");
                                        Console.ResetColor();

                                        CharactersCreation.PrintCharacterHealthStat(allStatsRange[i, TWO], allStatsRange[i, THREE]);
                                    }
                                    else
                                    {
                                        Console.Write("Introduce la ");
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.Write("defensa ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("para ");
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"names[i].");
                                        Console.ResetColor();

                                        CharactersCreation.PrintCharacterHealthStat(allStatsRange[i, FOUR], allStatsRange[i, FIVE]);
                                    }

                                    input = Console.ReadLine() ?? "".Trim();

                                    if (input != "") stat = Math.Round(Convert.ToDouble(input), TWO);
                                    else stat = -1;

                                    Console.Clear();

                                } while (!CharactersCreation.CheckCharacterStat(ref stat, allStatsRange[i, j * TWO], allStatsRange[i, j * TWO + ONE], ref tries) && tries > 0);

                                if (tries == 0) charactersStats[i, j] = allStatsRange[i, j * 2];
                                else charactersStats[i, j] = stat;
                            }
                        }
                    }

                    else
                    {
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, ref charactersStats, difficultyDecision, random);
                    }

                    // ************************** Guardar atributos originales en otras variables **************************
                    for (int i = 0; i < originalStats.GetLength(0); i++)
                    {
                        for (int j = 0; j < originalStats.GetLength(1); j++)
                        {
                            originalStats[i, j] = charactersStats[i, j == 0 ? IndexHealth : IndexDefense];
                        }
                    }

                    Console.Clear();

                    // ************************** Sistema de combate por turnos **************************
                    while (charactersStats[IndexMonster, IndexHealth] > 0 && !allHeroesDead)
                    {
                        turnOrder = GeneralUtils.GetRandomTurnOrder(random, IndexArcher, IndexBarbarian, IndexMage, IndexDruid); // Turnos aleatorios sin que se repita el mismo personaje

                        for (int i = 0; i < turnOrder.Length; i++)
                        {
                            tries = 3;
                            if (charactersStats[turnOrder[i], IndexHealth] > 0 && charactersStats[IndexMonster, IndexHealth] > 0) // Personaje actual vivo y monstruo vivo
                            {
                                bool specialAbilityValidOption;
                                do
                                {
                                    specialAbilityValidOption = true;
                                    Console.WriteLine($"Turno de: {names[turnOrder[i]]}");
                                    Console.WriteLine();
                                    MenuOptions.PrintTurnMenuOptions(turnOptions);
                                    turnDecision = Convert.ToInt32(Console.ReadLine() ?? "");
                                    Console.ResetColor();

                                    if (turnDecision == 0) // Si elige la opción de usar habilidad especial y está en cooldown, se le resta un intento pero vuelve a poder elegir otra opción
                                    {
                                        specialAbilityValidOption = GeneralUtils.CheckAbilityOnCooldown(turnOrder[i], archerCooldown, barbarianCooldown, mageCooldown, druidCooldown);

                                        if (!specialAbilityValidOption)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.BackgroundColor = ConsoleColor.White;
                                            Console.WriteLine("Habilidad en cooldown. Elije otra opción de turno.");
                                            Console.ResetColor();
                                            Console.WriteLine();
                                            tries--; // No se va a restar dos veces los intentos ya que realmente la opción del usuario está dentro de las opciones disponibles, por eso se resta aquí y el el while no.
                                        }
                                    }

                                } while ((!MenuOptions.CheckMenuDecision(turnOptions, turnDecision, ref tries) || !specialAbilityValidOption) && tries > 0);
                            }

                            Console.Clear();

                            if (tries > 0)
                            {
                                switch (turnDecision)
                                {
                                    // Ataque
                                    case 2:
                                        double damage = TurnOptions.Attack(turnOrder[i], charactersStats, IndexMonster, IndexAttack, IndexDefense, random, names);
                                        charactersStats[IndexMonster, IndexHealth] -= damage;
                                        break;

                                    // Defensa
                                    case 1:
                                        charactersStats[turnOrder[i], IndexDefense] *= TWO;
                                        charactersStats[turnOrder[i], IndexDefense] = Math.Round(charactersStats[turnOrder[i], IndexDefense], 2);
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write($"{names[turnOrder[i]]} ");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Write("ha ");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("duplicado ");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.Write("su defensa durante un turno.");
                                        break;

                                    // Habilidad especial (no verifico que el cooldown esté en 0 ya que si hay cooldown el usuario no puede elegir la
                                    // opción de habilidad especial y por tanto no entraría aquí ya que se acabarian los intentos si elige esta opción todo el rato)
                                    case 0:
                                        switch (turnOrder[i])
                                        {
                                            case 0:
                                                monsterKnockout = TWO;
                                                Console.BackgroundColor = ConsoleColor.White;
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.Write($"{names[turnOrder[i]]} ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("ha ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("noqueado ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("al ");
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.Write("monstruo ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("durante ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write(monsterKnockout);
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.WriteLine(" turnos con éxito.");
                                                archerCooldown = 5;
                                                break;

                                            case 1:
                                                Console.BackgroundColor = ConsoleColor.White;
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.Write($"{names[turnOrder[i]]} ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("se ha vuelto ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("inmune ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.WriteLine("durante 2 turnos.");
                                                charactersStats[IndexBarbarian, IndexDefense] = ONE_HUNDRED;
                                                barbarianAbilityTurns = 2;
                                                barbarianCooldown = 5;
                                                break;

                                            case 2:
                                                Console.BackgroundColor = ConsoleColor.White;
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.Write($"{names[turnOrder[i]]} ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("ha hecho ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("daño triple ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("al ");
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("monstruo.");
                                                charactersStats[IndexMonster, IndexHealth] -= TurnOptions.Attack(turnOrder[i], charactersStats, IndexMonster, IndexAttack, IndexDefense, random, names, THREE);
                                                mageCooldown = 5;
                                                break;

                                            case 3:
                                                Console.BackgroundColor = ConsoleColor.White;
                                                Console.ForegroundColor = ConsoleColor.Blue;
                                                Console.Write($"{names[turnOrder[i]]} ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.Write("ha usado su habilidad especial y ha ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("curado a");
                                                Console.ForegroundColor = ConsoleColor.Blue;

                                                for (int j = 0; j < turnOrder.Length - 1; j++) // Excluimos al druida
                                                {
                                                    charactersStats[IndexDruid, IndexHealth] += FIVE_HUNDRED;
                                                    if (charactersStats[IndexDruid, IndexHealth] > originalStats[IndexDruid, IndexHealth]) charactersStats[IndexDruid, IndexHealth] = originalStats[IndexDruid, IndexHealth];

                                                    if (charactersStats[j, IndexHealth] > 0)
                                                    {
                                                        Console.Write($" {names[j]},");
                                                        charactersStats[j, IndexHealth] += FIVE_HUNDRED;
                                                        if (charactersStats[j, IndexHealth] > originalStats[j, IndexHealth]) charactersStats[j, IndexHealth] = originalStats[j, IndexHealth];
                                                    }
                                                }
                                                Console.Write($" {names[IndexDruid]} ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.Write("500 ");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.WriteLine("puntos de vida.");
                                                druidCooldown = 5;
                                                break;
                                        }
                                        break;
                                }
                                Console.ResetColor();
                                Console.WriteLine();
                            }
                            tries = 3;
                        }

                        if (charactersStats[IndexMonster, IndexHealth] > 0)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            if (monsterKnockout == 0) // Turno del monstruo en caso de que no este noqueado
                            {
                                for (int i = 0; i < turnOrder.Length; i++)
                                {
                                    double damage = GeneralUtils.MonsterTurnAttack(charactersStats, IndexMonster, i, IndexAttack, IndexDefense);
                                    charactersStats[i, IndexHealth] -= damage;
                                    Console.Write($"El ");
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write(" monstruo");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($" ha atacado a");
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write($" {names[i]}");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($" y le ha causado");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write($" {damage}");
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine($" puntos de daño.");
                                }
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Monstruo");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" noqueado");
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(" durante ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(monsterKnockout);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine(" turno/s.");
                                monsterKnockout--;
                            }

                            for (int i = 0; i < turnOrder.Length; i++) // Restablecer valores de defensa a su valor original
                            {
                                if (i == IndexBarbarian && barbarianAbilityTurns > 0)
                                {
                                    barbarianAbilityTurns--;
                                }
                                else
                                {
                                    charactersStats[i, IndexDefense] = originalStats[i, IndexDefense - ONE]; // El - ONE sirve para especificar la posición correcta de originalStats ya que solo tiene 2 columnas, debido a que no se guarda el ataque.
                                }
                            }

                            // ---------- NO FUNCIONA ----------
                            // GeneralUtils.DisplayCharactersHealthDesc(charactersStats,IndexHealth,names);

                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("Vida restante del ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(" monstruo: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(charactersStats[IndexMonster, IndexHealth]);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(" puntos.");

                            if (archerCooldown > 0) archerCooldown--;
                            if (barbarianCooldown > 0) barbarianCooldown--;
                            if (mageCooldown > 0) mageCooldown--;
                            if (druidCooldown > 0) druidCooldown--;

                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        int k = 0;
                        allHeroesDead = true;
                        while (allHeroesDead && k < turnOrder.Length)
                        {
                            if (charactersStats[k, IndexHealth] > 0)
                            {
                                allHeroesDead = false;
                            }
                            k++;
                        }
                    }

                    if (allHeroesDead)
                    {
                        Console.Clear();
                        Console.WriteLine("Héroes muertos.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Monstruo muerto.");
                    }
                }
            }

            if (tries == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine("Te has quedado sin intentos. Quizá esto es demasiado para ti.");
                Console.ResetColor();
            }
        }
    }
}