namespace HeroesVsMonster_CharactersCreation
{
    public class CharactersCreation
    {
        public static string CapitalizeFirstLetter(string word)
        {
            return $"{word[0].ToString().ToUpper()}{word.Substring(1).ToLower()}";
        }

        // Dificultad personalizada
        public static void PrintCharacterHealthStat(int minValue, int maxValue)
        {
            Console.Write($"Escoge el valor de la estadística entre los rangos permitidos [{minValue} - {maxValue}]: ");
        }

        public static bool CheckCharacterStat(ref double stat, double minValue, double maxValue, ref int tries)
        {
            bool validDecision;

            validDecision = (stat >= minValue && stat <= maxValue);

            if (!validDecision)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Te has equivocado de opción. Vuelve a intentarlo.");
                Console.ResetColor();
                Console.WriteLine();
                tries--;
            }

            if (tries == 0)
            {
                stat = minValue;
            }

            return validDecision;
        }

        public static void CreateCompleteCharacter(int[,] allStatsRange, ref double[,] characterStats, int difficulty, Random random)
        {
            for (int i = 0; i < allStatsRange.GetLength(0); i++)
            {
                for (int j = 0; j < characterStats.GetLength(1); j++)
                {
                    if (i != 4)
                    {
                        characterStats[i, j] = difficulty switch
                        {
                            3 => allStatsRange[i, j * 2 + 1],
                            2 => allStatsRange[i, j * 2],
                            _ => Math.Round(Convert.ToDouble(random.Next(allStatsRange[i, j * 2], allStatsRange[i, j * 2 + 1] + 1)), 2),
                        };
                    }
                    else
                    {
                        characterStats[i, j] = difficulty switch
                        {
                            3 => allStatsRange[i, j * 2],  // Invertir para dificultad fácil
                            2 => allStatsRange[i, j * 2 + 1],  // Invertir para dificultad difícil
                            _ => Math.Round(Convert.ToDouble(random.Next(allStatsRange[i, j * 2], allStatsRange[i, j * 2 + 1] + 1)), 2),
                        };
                    }
                }
            }
        }
    }
}