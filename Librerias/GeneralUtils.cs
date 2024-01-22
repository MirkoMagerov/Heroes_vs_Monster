using System.Xml.Linq;

namespace HeroesVsMonster_GeneralUtils
{
    public class GeneralUtils
    {
        public static void DisplayCharacterStats(double[,] charactersStats)
        {
            string[] characters = { "Arquera", "Barbaro", "Maga", "Druida", "Monstruo" };
            string[] stats = { "Vida", "Ataque", "Defensa" };

            for (int i = 0; i < characters.GetLength(0); i++)
            {
                Console.WriteLine($"Personaje: {characters[i]}");

                for (int j = 0; j < stats.GetLength(0); j++)
                {
                    Console.Write($"{stats[j]}: {charactersStats[i, j]}");

                    // Agrega una coma si no es la última estadística
                    if (j < stats.GetLength(0) - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine(); // Salto de línea para el próximo personaje
            }
        }

        public static int[] GetRandomTurnOrder(Random random, int archerIndex, int barbarianIndex, int mageIndex, int druidIndex)
        {
            int[] randomOrder = { archerIndex, barbarianIndex, mageIndex, druidIndex };

            for (int i = randomOrder.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                (randomOrder[j], randomOrder[i]) = (randomOrder[i], randomOrder[j]);
            }

            return randomOrder;
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
            for (int i = 0; i < names.Length; i++)
            {
                for (int j = 0; j < names.Length - 1; j++)
                {
                    if (charStats[j, healthIndex] < charStats[j + 1, healthIndex])
                    {
                        double tempStat = charStats[j, healthIndex];
                        charStats[j, healthIndex] = charStats[j + 1, healthIndex];
                        charStats[j + 1, healthIndex] = tempStat;

                        string tempName = names[j];
                        names[j] = names[j + 1];
                        names[j + 1] = tempName;
                    }
                }
            }

            for (int i = 0; i < charStats.GetLength(0) - 1; i++)
            {
                if (charStats[i, healthIndex] > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Vida restante de ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{names[i]}: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(charStats[i, healthIndex]);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(" puntos.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{names[i]} ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("esta muerto/a.");
                }
            }
        }
    }
}