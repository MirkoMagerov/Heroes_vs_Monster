namespace HeroesVsMonster_MenuOptions
{
    public class MenuOptions
    {
        public static void PrintMenuOptions(string[] options)
        {
            for (int i = options.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"{i}. {options[i]}");
            }
            Console.WriteLine();
            Console.Write("Tu elección: ");
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static bool CheckMenuDecision(string[] options, int decision, ref int tries)
        {
            bool validDecision;

            validDecision = (decision >= 0 && decision <= options.Length - 1);

            if (!validDecision)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Te has equivocado de opción. Vuelve a intentarlo.");
                Console.ResetColor();
                Console.WriteLine();
                tries--;
            }

            return validDecision;
        }

        public static void PrintMainMenuOptions(string[] mainMenuOptions)
        {
            PrintMenuOptions(mainMenuOptions);
        }

        public static void PrintDifficultyMenuOptions(string[] difficultyOptions)
        {
            PrintMenuOptions(difficultyOptions);
        }

        public static void PrintTurnMenuOptions(string[] turnOptions)
        {
            PrintMenuOptions(turnOptions);
        }
    }
}
