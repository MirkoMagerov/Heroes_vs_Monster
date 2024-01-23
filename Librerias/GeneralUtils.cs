namespace HeroesVsMonster_GeneralUtils
{
    public class GeneralUtils
    {
        public static int[] GetRandomTurnOrder(Random random, int archerIndex, int barbarianIndex, int mageIndex, int druidIndex, double[,] charactersStats, int IndexHealth)
        {
            int[] randomOrder = { archerIndex, barbarianIndex, mageIndex, druidIndex };
            int aliveCount = 0;

            // Contar la cantidad de personajes vivos
            for (int i = 0; i < randomOrder.Length; i++)
            {
                if (charactersStats[randomOrder[i], IndexHealth] > 0)
                {
                    aliveCount++;
                }
            }

            if (aliveCount == 0)
            {
                return randomOrder;
            }

            int[] finalOrder = new int[aliveCount];

            int currentIndex = 0;
            for (int i = 0; i < randomOrder.Length; i++)
            {
                if (charactersStats[randomOrder[i], IndexHealth] > 0)
                {
                    finalOrder[currentIndex] = randomOrder[i];
                    currentIndex++;
                }
            }

            if (aliveCount == 1)
            {
                return finalOrder;
            }

            for (int i = finalOrder.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                // Intercambiar elementos en finalOrder
                (finalOrder[i], finalOrder[j]) = (finalOrder[j], finalOrder[i]);
            }

            return finalOrder;
        }

        public static bool CheckAbilityOnCooldown(int charIndex, int archerCooldown, int barbarianCooldown, int mageCooldown, int druidCooldown)
        {
            return charIndex switch
            {
                0 => archerCooldown == 0,
                1 => barbarianCooldown == 0,
                2 => mageCooldown == 0,
                3 => druidCooldown == 0,
                _ => false,
            };
        }

        public static double MonsterTurnAttack(double[,] charStats, int monsterIndex, int heroIndex, int damage, int defense)
        {
            double characterDamage;

            characterDamage = Math.Max(0, Math.Round(charStats[monsterIndex, damage] - (charStats[monsterIndex, damage] * (charStats[heroIndex, defense]) / 100.0), 2));

            return characterDamage;
        }

        public static bool IsCriticAttac(Random random)
        {
            return random.Next(0, 10) < 1;
        }

        public static bool IsMissedAttack(Random random)
        {
            return random.Next(0, 20) < 1;
        }

        public static void DisplayCharactersHealthDesc(double[,] charStats, int healthIndex, string[] names)
        {
            // Clonamos la matriz de stats y el array de nombres para no influir en las constantes de índices y en la generación de turnos aleatoria
            double[] copyHealthStats = new double[charStats.GetLength(0) - 1];

            for (int i = 0; i < copyHealthStats.Length; i++)
            {
                copyHealthStats[i] = charStats[i, healthIndex];
            }

            string[] copyNames = new string[names.Length];

            for (int i = 0; i < copyNames.Length; i++)
            {
                copyNames[i] = names[i];
            }

            // Ordenamos los personajes de manera descendente por vida y cambiamos el nombre de la misma manera
            for (int i = names.Length - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (copyHealthStats[j] < copyHealthStats[j + 1])
                    {
                        (copyHealthStats[j + 1], copyHealthStats[j]) = (copyHealthStats[j], copyHealthStats[j + 1]);
                        (copyNames[j + 1], copyNames[j]) = (copyNames[j], copyNames[j + 1]);
                    }
                }
            }

            for (int i = 0; i < charStats.GetLength(0) - 1; i++)
            {
                if (copyHealthStats[i] > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Vida restante de ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{copyNames[i]}: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(copyHealthStats[i]);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(" puntos.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{copyNames[i]} ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("esta muerto/a.");
                }
            }
        }
    }
}