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