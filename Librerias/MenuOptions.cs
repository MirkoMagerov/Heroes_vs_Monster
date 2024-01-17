namespace HeroesVsMonster_MenuOptions
{
    public class MenuOptions
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

                validDecision = decision >= 0 || decision >= options.Length - 1;

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

        public static int[] GetRandomTurnOrder(Random random, int archerIndex, int barbarianIndex, int mageIndex, int druidIndex)
        {
            int[] randomOrder = { archerIndex, barbarianIndex, mageIndex, druidIndex };

            for (int i = randomOrder.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (randomOrder[i], randomOrder[j]) = (randomOrder[j], randomOrder[i]);
            }

            return randomOrder;
        }

        public static int GetTurnDecision(ref int tries)
        {
            string[] difficultyOptions = { "Usar habilidad especial", "Protegerse", "Atacar" };
            return GetDecision("OPCIONES DE TURNO", difficultyOptions, ref tries);
        }
    }
}
