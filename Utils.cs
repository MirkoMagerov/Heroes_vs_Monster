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
        public static bool IsCriticAttac(Random random)
        {
            return random.Next(0, 10) < 1;
        }

        public static bool IsMissedAttack(Random random)
        {
            return random.Next(0, 20) < 1;
        }
    }

    public class TurnOptions
    {
        public static void Attack(double attackDamage, ref double monsterHealth, Random random)
        {
            const int doubleAttack = 2;

            if (!IsMissedAttack(random))
            {
                if (IsCriticAttac(random))
                {
                    attackDamage *= doubleAttack;
                    Console.WriteLine("Double damage");
                }
                monsterHealth -= attackDamage;
            }
            else
            {
                Console.WriteLine("Missed");
            }
        }

        public static void Defense(int index, ref double archerDefense, ref double barbDefense, ref double mageDefense, ref double druidDefense)
        {
            const int defenseMultiplier = 2;

            switch (index)
            {
                case 0:
                    archerDefense *= defenseMultiplier;
                    break;
                case 1:
                    barbDefense *= defenseMultiplier;
                    break;
                case 2:
                    mageDefense *= defenseMultiplier;
                    break;
                case 3:
                    druidDefense *= defenseMultiplier;
                    break;
            }

            Console.WriteLine("Defensa activada");
        }
    }

    public class SpecialAbilities
    {
        public static void ArcherAbility(ref int monsterKnockout)
        {
            const int knockedTurns = 3;
            monsterKnockout = knockedTurns;

            Console.WriteLine("Noqueado");
        }

        public static void BarbarianAbility(ref int invulnerability)
        {
            const int invulnerabilityTurns = 3;
            invulnerability = invulnerabilityTurns;

            Console.WriteLine("Invulnerabilidad activada");
        }

        public static void MageAbility(double mageAttack, ref double monsterHealth)
        {
            const int attackMultiplier = 3;

            monsterHealth -= mageAttack * attackMultiplier;
            Console.WriteLine("Daño triple");
        }

        public static void DruidAbility(ref double archerHealth, double ogArchHealth, ref double barbarianHealth, double ogBarbHealth, ref double mageHealth, double ogMageHealth, ref double druidHealth, double ogDruidHealth)
        {
            const double healedQuantity = 500;

            if (archerHealth > 0)
            {
                archerHealth += healedQuantity;
                if (archerHealth > ogArchHealth) archerHealth = ogArchHealth;
            }
            if (barbarianHealth > 0)
            {
                barbarianHealth += healedQuantity;
                if (barbarianHealth > ogBarbHealth) barbarianHealth = ogBarbHealth;
            }
            if (mageHealth > 0)
            {
                mageHealth += healedQuantity;
                if (mageHealth > ogMageHealth) mageHealth = ogMageHealth;
            }

            druidHealth += healedQuantity;
            if (druidHealth > ogDruidHealth) druidHealth = ogDruidHealth;

            Console.WriteLine("Curacion");
        }


    }

    public class ProgramFlowHelpers
    {
        public static double GetActualAttackValue(int index, double archerAttack, double barbAttack, double mageAttack, double druidAttack)
        {
            double damage = 0;

            switch (index)
            {
                case 0:
                    damage = archerAttack;
                    break;
                case 1:
                    damage = barbAttack;
                    break;
                case 2:
                    damage = mageAttack;
                    break;
                case 3:
                    damage = druidAttack;
                    break;
            }
            return damage;
        }

        public static void MonsterTurn(ref double archerHealth, double archerDef, ref double barbHealth, double barbDef, ref double mageHealth, double mageDef, ref double druidHealth, double druidDef, int barbInvuln, double monsterAttack)
        {
            if (archerHealth > 0)
            {
                archerHealth -= Math.Max(0, Math.Round(monsterAttack - (monsterAttack * archerDef) / 100.0, 2));

                if (barbInvuln == 0)
                {
                    barbHealth -= Math.Max(0, Math.Round(monsterAttack - (monsterAttack * barbDef) / 100.0, 2));
                }

                mageHealth -= Math.Max(0, Math.Round(monsterAttack - (monsterAttack * mageDef) / 100.0, 2));

                druidHealth -= Math.Max(0, Math.Round(monsterAttack - (monsterAttack * druidDef) / 100.0, 2));
            }
        }

        public static void DecreaseTurnVariables(ref int monsterKnockout, ref int barbarianInvulnerability, ref int archerCooldown, ref int barbCooldown, ref int mageCooldown, ref int druidCooldown)
        {
            if (monsterKnockout > 0)
            {
                monsterKnockout--;
            }

            if (barbarianInvulnerability > 0)
            {
                barbarianInvulnerability--;
            }

            if (archerCooldown > 0)
            {
                archerCooldown--;
            }

            if (barbCooldown > 0)
            {
                barbCooldown--;
            }

            if (mageCooldown > 0)
            {
                mageCooldown--;
            }

            if (druidCooldown > 0)
            {
                druidCooldown--;
            }
        }

        public static void RestoreDefenseValues(ref double archerDefense, double ogArcDef, ref double barbDefense, int barbInvulnerability, double ogBarbDef, ref double mageDefense, double ogMageDef, ref double druidDefense, double ogDruidDef)
        {
            archerDefense = ogArcDef;
            mageDefense = ogMageDef;
            druidDefense = ogDruidDef;

            if (barbInvulnerability == 0)
            {
                barbDefense = ogBarbDef;
            }
        }

        public static string CharacterIndexToNameConverter(int index, string archerName, string barbName, string mageName, string druidName)
        {
            switch (index)
            {
                case 0: return archerName;
                case 1: return barbName;
                case 2: return mageName;
                case 3: return druidName;
                default: return "Error";
            }
        }
    }
}