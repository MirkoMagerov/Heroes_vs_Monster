using HeroesVsMonster_CharactersCreation;
using HeroesVsMonster_GeneralUtils;
using HeroesVsMonster_MenuOptions;
using HeroesVsMonster_TurnOptions;

namespace HeroesVsMonster
{
    public static class ConsoleApp
    {
        // CÓDIGO MAIN
        public static void Main()
        {

            // ****************************** CONSTRAINTS ******************************
            // Messages

            // Difficulty numbers and general flow constraints
            const int EasyMode = 3, HardMode = 2, PersonalizedMode = 1;

            // Valid range for every character stats
            const int MinArcherHealthValue = 1500, MaxArcherHealthValue = 2000, MinArcherAttackValue = 180, MaxArcherAttackValue = 300, MinArcherDefenseValue = 25, MaxArcherDefenseValue = 35;
            const int MinBarbarianHealthValue = 3000, MaxBarbarianHealthValue = 3750, MinBarbarianAttackValue = 150, MaxBarbarianAttackValue = 250, MinBarbarianDefenseValue = 35, MaxBarbarianDefenseValue = 45;
            const int MinMageHealthValue = 1100, MaxMageHealthValue = 1500, MinMageAttackValue = 300, MaxMageAttackValue = 400, MinMageDefenseValue = 20, MaxMageDefenseValue = 35;
            const int MinDruidHealthValue = 2000, MaxDruidHealthValue = 2500, MinDruidAttackValue = 70, MaxDruidAttackValue = 120, MinDruidDefenseValue = 25, MaxDruidDefenseValue = 40;
            const int MinMonsterHealthValue = 7000, MaxMonsterHealthValue = 10000, MinMonsterAttackValue = 300, MaxMonsterAttackValue = 400, MinMonsterDefenseValue = 20, MaxMonsterDefenseValue = 30;
            const int IndexArcher = 0, IndexBarbarian = 1, IndexMage = 2, IndexDruid = 3, IndexMonster = 4;

            // ****************************** VARIABLES ******************************
            Random random = new();

            string archerName = "";
            string barbarianName = "";
            string mageName = "";
            string druidName = "";

            // General program flow variables
            bool correctNameCreation;
            int difficultyDecision, tries = 3;

            // Special characters variables
            int archerCooldown = 0, barbarianCooldown = 0, mageCooldown = 0, druidCooldown = 0, monsterKnockout = 0, barbarianInvulnerability = 0;

            // Stats
            double archerHealth = 0, archerAttack = 0, archerDefense = 0;
            double barbarianHealth = 0, barbarianAttack = 0, barbarianDefense = 0;
            double mageHealth = 0, mageAttack = 0, mageDefense = 0;
            double druidHealth = 0, druidAttack = 0, druidDefense = 0;
            double monsterHealth = 0, monsterAttack = 0, monsterDefense = 0;
            // Store original health and defense so we can restore them to the default value
            double ogArcherHealth, ogBarbarianHealth, ogMageHealth, ogDruidHealth, ogArcherDefense, ogBarbarianDefense, ogMageDefense, ogDruidDefense;

            int[] turnOrder;

            int[,] allStatsRange = new int[,]
            {
                { MinArcherHealthValue, MaxArcherHealthValue, MinArcherAttackValue, MaxArcherAttackValue, MinArcherDefenseValue, MaxArcherDefenseValue },
                { MinBarbarianHealthValue, MaxBarbarianHealthValue, MinBarbarianAttackValue, MaxBarbarianAttackValue, MinBarbarianDefenseValue, MaxBarbarianDefenseValue },
                { MinMageHealthValue, MaxMageHealthValue, MinMageAttackValue, MaxMageAttackValue, MinMageDefenseValue, MaxMageDefenseValue },
                { MinDruidHealthValue, MaxDruidHealthValue, MinDruidAttackValue, MaxDruidAttackValue, MinDruidDefenseValue, MaxDruidDefenseValue },
                { MinMonsterHealthValue, MaxMonsterHealthValue, MinMonsterAttackValue, MaxMonsterAttackValue, MinMonsterDefenseValue, MaxMonsterDefenseValue }
            };

            // ****************************** MAIN PROGRAM ******************************

            // Salir
            if (!MenuOptions.GetMainMenuDecision(ref tries))
            {
                // Despedida del juego
            }

            // Jugar
            else if (tries > 0)
            {
                tries = 3;
                difficultyDecision = MenuOptions.GetDifficultyDecision(ref tries);

                if (tries > 0)
                {
                    tries = 3;

                    // ************************** Creación personajes según dificultad **************************
                    if (difficultyDecision == PersonalizedMode)
                    {
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexArcher, ref archerHealth, ref archerAttack, ref archerDefense);
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexBarbarian, ref barbarianHealth, ref barbarianAttack, ref barbarianDefense);
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexMage, ref mageHealth, ref mageAttack, ref mageDefense);
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexDruid, ref druidHealth, ref druidAttack, ref druidDefense);
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexMonster, ref monsterHealth, ref monsterAttack, ref monsterDefense);
                    }

                    else
                    {
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexArcher, difficultyDecision, random, ref archerHealth, ref archerAttack, ref archerDefense);
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexBarbarian, difficultyDecision, random, ref barbarianHealth, ref barbarianAttack, ref barbarianDefense);
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexMage, difficultyDecision, random, ref mageHealth, ref mageAttack, ref mageDefense);
                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexDruid, difficultyDecision, random, ref druidHealth, ref druidAttack, ref druidDefense);

                        // Cambiar dificultad para adaptarla a las stats del monstruo
                        if (difficultyDecision == EasyMode)
                        {
                            difficultyDecision = HardMode;
                        }
                        else if (difficultyDecision == HardMode)
                        {
                            difficultyDecision = EasyMode;
                        }

                        CharactersCreation.CreateCompleteCharacter(allStatsRange, IndexMonster, difficultyDecision, random, ref monsterHealth, ref monsterAttack, ref monsterDefense);
                    }

                    // ************************** Guardar atributos originales en otras variables **************************
                    ogArcherHealth = archerHealth;
                    ogArcherDefense = archerDefense;
                    ogBarbarianHealth = barbarianHealth;
                    ogBarbarianDefense = barbarianDefense;
                    ogMageHealth = mageHealth;
                    ogMageDefense = mageDefense;
                    ogDruidHealth = druidHealth;
                    ogDruidDefense = druidDefense;

                    // ************************** Nombres de los personajes **************************
                    do
                    {
                        correctNameCreation = CharactersCreation.GetCharactersNames(ref archerName, ref barbarianName, ref mageName, ref druidName);

                    } while (!correctNameCreation);

                    while (monsterHealth > 0 && (archerHealth > 0 || barbarianHealth > 0 || mageHealth > 0 || druidHealth > 0))
                    {
                        Console.Clear();
                        // ************************** Sistema de turnos **************************
                        turnOrder = MenuOptions.GetRandomTurnOrder(random, IndexArcher, IndexBarbarian, IndexMage, IndexDruid);

                        for (int i = 0; i < turnOrder.Length; i++)
                        {
                            Console.WriteLine(GeneralUtils.CharacterIndexToNameConverter(turnOrder[i], archerName, barbarianName, mageName, druidName));
                            int turnDecision = MenuOptions.GetTurnDecision(ref tries);
                            // Pasar turno si se equivoca 3 veces en elegir opción
                            if (tries > 0)
                            {
                                tries = 3;
                                switch (turnDecision)
                                {
                                    // Ataque
                                    case 2:
                                        TurnOptions.Attack(GeneralUtils.GetActualAttackValue(turnOrder[i], archerAttack, barbarianAttack, mageAttack, druidAttack), ref monsterHealth, random, monsterDefense);
                                        break;

                                    // Defensa
                                    case 1:
                                        TurnOptions.Defense(turnOrder[i], ref archerDefense, ref barbarianDefense, ref mageDefense, ref druidDefense);
                                        break;

                                    // Habilidad especial
                                    case 0:
                                        switch (turnOrder[i])
                                        {
                                            case 0:
                                                if (archerCooldown == 0)
                                                {
                                                    TurnOptions.ArcherAbility(ref monsterKnockout);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("On Cooldown");
                                                }
                                                break;

                                            case 1:
                                                if (barbarianCooldown == 0)
                                                {
                                                    TurnOptions.BarbarianAbility(ref barbarianInvulnerability);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("On Cooldown");
                                                }
                                                break;

                                            case 2:
                                                if (mageCooldown == 0)
                                                {
                                                    TurnOptions.MageAbility(mageAttack, ref monsterHealth);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("On Cooldown");
                                                }
                                                break;

                                            case 3:
                                                if (druidCooldown == 0)
                                                {
                                                    TurnOptions.DruidAbility(ref archerHealth, ogArcherHealth, ref barbarianHealth, ogBarbarianHealth, ref mageHealth, ogMageHealth, ref druidHealth, ogDruidHealth);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("On Cooldown");
                                                }
                                                break;
                                        }
                                        break;
                                }
                                Console.WriteLine("******************");
                                Console.WriteLine($"Estadisticas arquera: {archerHealth} | {archerDefense} | {archerCooldown}");
                                Console.WriteLine($"Estadisticas barbaro: {barbarianHealth} | {barbarianDefense} | {barbarianCooldown}");
                                Console.WriteLine($"Estadisticas maga: {mageHealth} | {mageDefense} | {mageCooldown}");
                                Console.WriteLine($"Estadisticas druida: {druidHealth} | {druidDefense} | {druidCooldown}");
                                Console.WriteLine($"Estadisticas monstruo: {monsterHealth}");
                                Console.WriteLine("******************");
                                Console.WriteLine();
                            }
                        }

                        GeneralUtils.MonsterTurn(ref archerHealth, archerDefense, ref barbarianHealth, barbarianDefense, ref mageHealth, mageDefense, ref druidHealth, druidDefense, barbarianInvulnerability, monsterAttack);

                        GeneralUtils.DecreaseTurnVariables(ref monsterKnockout, ref barbarianInvulnerability, ref archerCooldown, ref barbarianCooldown, ref mageCooldown, ref druidCooldown);
                        GeneralUtils.RestoreDefenseValues(ref archerDefense, ogArcherDefense, ref barbarianDefense, barbarianInvulnerability, ogBarbarianDefense, ref mageDefense, ogMageDefense, ref druidDefense, ogDruidDefense);
                    }
                }
            }

            if (tries == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("TE HAS QUEDADO SIN INTENTOS");
                Console.ResetColor();
            }

            // ************************** FIN MAIN **************************
        }
    }
}