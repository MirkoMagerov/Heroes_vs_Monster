namespace HeroesVsMonster_CharactersCreation
{
    public class CharactersCreation
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
            }

            archerName = separatedNames[0];
            barbName = separatedNames[1];
            mageName = separatedNames[2];
            druidName = separatedNames[3];

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
}
