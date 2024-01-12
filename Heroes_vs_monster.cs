/*
* Author: Miroslav Magerov
* M03. Programació UF2
* v1. dd/mm/aa
* Exercici Modular - Heroes vs Monster.
*/
using MonstersVsHeroesUtils;

namespace Proyecto
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
            // Variables para guardar la vida original de los personajes y stats importantes
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
            if (!MenuDecisions.GetMainMenuDecision(ref tries))
            {
                // Despedida del juego
            }

            // Jugar
            else if (tries > 0)
            {
                tries = 3;
                difficultyDecision = MenuDecisions.GetDifficultyDecision(ref tries);

                if (tries > 0)
                {
                    tries = 3;

                    // ************************** Creación personajes según dificultad **************************
                    if (difficultyDecision == PersonalizedMode)
                    {
                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexArcher, ref archerHealth, ref archerAttack, ref archerDefense);
                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexBarbarian, ref barbarianHealth, ref barbarianAttack, ref barbarianDefense);
                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexMage, ref mageHealth, ref mageAttack, ref mageDefense);
                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexDruid, ref druidHealth, ref druidAttack, ref druidDefense);
                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexMonster, ref monsterHealth, ref monsterAttack, ref monsterDefense);
                    }

                    else
                    {
                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexArcher, difficultyDecision, random, ref archerHealth, ref archerAttack, ref archerDefense);
                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexBarbarian, difficultyDecision, random, ref barbarianHealth, ref barbarianAttack, ref barbarianDefense);
                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexMage, difficultyDecision, random, ref mageHealth, ref mageAttack, ref mageDefense);
                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexDruid, difficultyDecision, random, ref druidHealth, ref druidAttack, ref druidDefense);

                        // Cambiar dificultad para adaptarla a las stats del monstruo
                        if (difficultyDecision == EasyMode)
                        {
                            difficultyDecision = HardMode;
                        }
                        else if (difficultyDecision == HardMode)
                        {
                            difficultyDecision = EasyMode;
                        }

                        CharacterCreation.CreateCompleteCharacter(allStatsRange, IndexMonster, difficultyDecision, random, ref monsterHealth, ref monsterAttack, ref monsterDefense);
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
                        correctNameCreation = CharacterCreation.GetCharactersNames(ref archerName, ref barbarianName, ref mageName, ref druidName);

                    } while (!correctNameCreation);
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