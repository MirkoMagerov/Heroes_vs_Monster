using HeroesVsMonster_GeneralUtils;

namespace HeroesVsMonster_TurnOptions
{
    public class TurnOptions
    {
        public static double Attack(int charIndex, double[,] stats, int monsterIndex, int attack, int defense, Random random, string[] names)
        {
            const int TWO = 2;
            const double ONE_HUNDRED = 100.0;
            double attackDamage;

            Console.BackgroundColor = ConsoleColor.White;
            if (!GeneralUtils.IsMissedAttack(random))
            {
                attackDamage = Math.Round(stats[charIndex, attack] - (stats[charIndex, attack] * stats[monsterIndex, defense]) / ONE_HUNDRED, TWO);

                if (GeneralUtils.IsCriticAttac(random))
                {
                    attackDamage *= TWO;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{names[charIndex]} ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("ha hecho un ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("ataque crítico ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("y ha causado el ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("doble de daño");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("!");
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{names[charIndex]} ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"ha hecho ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{attackDamage} ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"puntos de daño al ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"monstruo");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($".");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("¡Que pena! ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{names[charIndex]} ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("ha ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("fallado ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("su ataque debido a que ha escuchado 'Base de datos' y se ha dormido por este turno.");
                attackDamage = 0;
            }

            Console.ResetColor();
            return attackDamage;
        }

        public static double Attack(int charIndex, double[,] stats, int monsterIndex, int attack, int defense, Random random, string[] names, int multiplier) // Multiplicador de daño de la maga
        {
            const int TWO = 2;
            const double ONE_HUNDRED = 100.0;
            double attackDamage;

            attackDamage = Math.Round(stats[charIndex, attack] - (stats[charIndex, attack] * stats[monsterIndex, defense]) / ONE_HUNDRED, TWO);
            attackDamage *= multiplier;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{names[charIndex]} ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"ha hecho ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{attackDamage} ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"puntos de daño al ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"monstruo");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($".");
            Console.ResetColor();

            return attackDamage;
        }

        public static void Defense(ref double[,] charactersStats, int[] turnOrder, int index, int IndexDefense, string[] names)
        {
            const int TWO = 2;

            charactersStats[turnOrder[index], IndexDefense] *= TWO;
            charactersStats[turnOrder[index], IndexDefense] = Math.Round(charactersStats[turnOrder[index], IndexDefense], 2);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{names[turnOrder[index]]} ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("ha ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("duplicado ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("su defensa durante un turno.");
        }
    }
}
