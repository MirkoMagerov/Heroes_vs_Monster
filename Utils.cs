namespace MonstersVsHeroesUtils
{
    public class MenuDecisions
    {
        public static int GetDecision(string menuTitle, string[] options, ref int tries)
        {
            bool validDecision;
            int decision;
            do
            {
                Console.WriteLine(menuTitle);

                for (int i = options.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine($"{i}. {options[i]}");
                }

                Console.Write("Tu elección: ");
                decision = Convert.ToInt16(Console.ReadLine());

                if (decision < 0 || decision > options.Length - 1)
                {
                    validDecision = false;
                }
                else
                {
                    validDecision = true;
                }

                Console.Clear();

                if (!validDecision)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Te has equivocado de opción. Vuelve a intentarlo.");
                    Console.ResetColor();
                    Console.WriteLine();
                    tries--;
                }

            } while (!validDecision && tries > 0);

            return decision;
        }

        public static bool GetMainMenuDecision(ref int tries)
        {
            string[] mainMenuOptions = { "Salir", "Iniciar nueva batalla" };
            return GetDecision("MENÚ", mainMenuOptions, ref tries) != 0;
        }

        public static int GetDifficultyDecision(ref int tires)
        {
            string[] difficultyOptions = { "Random", "Personalizada", "Difícil", "Fácil" };
            return GetDecision("DIFICULTAD", difficultyOptions, ref tires);
        }
    }

    public class CharacterCreation
    {
        public static string CapitalizeFirstLetter(string word)
        {
            return $"{word[0].ToString().ToUpper()}{word.Substring(1).ToLower()}";
        }

        public static bool GetCharactersNames(ref string archerName, ref string barbName, ref string mageName, ref string druidName)
        {
            string userInput;
            string[] separatedNames;

            Console.Write("Introduce 4 nombres separados por comas.\nSe asignarán a los personajes en este orden: Arquera, Bárbaro, Maga, Druida.\nEscribe aqui: ");

            userInput = Console.ReadLine() ?? "";
            userInput = userInput.Replace(" ", "");
            separatedNames = userInput.Split(',');

            for (int i = 0; i < separatedNames.Length; i++)
            {
                separatedNames[i] = CapitalizeFirstLetter(separatedNames[i]);

                switch (i)
                {
                    case 0:
                        archerName = separatedNames[i];
                        break;

                    case 1:
                        barbName = separatedNames[i];
                        break;

                    case 2:
                        mageName = separatedNames[i];
                        break;

                    case 3:
                        druidName = separatedNames[i];
                        break;
                }
            }

            return separatedNames.Length == 4;
        }

        // Dificultad personalizada
        public static double CreateCharacterStat(int minValue, int maxValue)
        {
            int tries = 3;
            double stat;
            bool validDecision;
            do
            {
                Console.Write($"Escoge el valor de la estadística entre los rangos permitidos [{minValue} ... {maxValue}]: ");
                stat = Convert.ToSingle(Console.ReadLine());

                if (stat < minValue || stat > maxValue)
                {
                    validDecision = false;
                }
                else
                {
                    validDecision = true;
                }

                if (!validDecision)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Te has equivocado de opción. Vuelve a intentarlo.");
                    Console.ResetColor();
                    Console.WriteLine();
                    tries--;
                }

            } while (!validDecision && tries > 0);

            if (tries == 0)
            {
                stat = minValue;
            }

            return stat;
        }

        // Dificultad personalizada
        public static void CreateCompleteCharacter(int[,] allStatsRange, int characterIndex, ref double health, ref double attack, ref double defense)
        {
            health = CreateCharacterStat(allStatsRange[characterIndex, 0], allStatsRange[characterIndex, 1]);
            attack = CreateCharacterStat(allStatsRange[characterIndex, 2], allStatsRange[characterIndex, 3]);
            defense = CreateCharacterStat(allStatsRange[characterIndex, 4], allStatsRange[characterIndex, 5]);
        }

        // Dificultad automática
        public static double CreateCharacterStat(int minvalue, int maxValue, int automaticDifficulty, Random random)
        {
            if (automaticDifficulty == 3)
            {
                return maxValue;
            }
            else if (automaticDifficulty == 2)
            {
                return minvalue;
            }
            else
            {
                return Convert.ToSingle(random.Next(minvalue, maxValue + 1));
            }
        }

        // Dificultad automática
        public static void CreateCompleteCharacter(int[,] allStatsRange, int characterIndex, int difficulty, Random random, ref double health, ref double attack, ref double defense)
        {
            health = CreateCharacterStat(allStatsRange[characterIndex, 0], allStatsRange[characterIndex, 1], difficulty, random);
            attack = CreateCharacterStat(allStatsRange[characterIndex, 2], allStatsRange[characterIndex, 3], difficulty, random);
            defense = CreateCharacterStat(allStatsRange[characterIndex, 4], allStatsRange[characterIndex, 5], difficulty, random);
        }
    }

    public class RandomChances
    {

    }

    public class TurnOptions
    {

    }

    public class SpecialAbilities
    {

    }
}