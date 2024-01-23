using HeroesVsMonster_MenuOptions;
using HeroesVsMonster_CharactersCreation;
using HeroesVsMonster_TurnOptions;
using HeroesVsMonster_GeneralUtils;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // *********************** Tests de la clase MenuOptions *****************************
        [TestMethod]
        public void CheckMenuDecision_True()
        {
            // Arrange
            string[] options = { "a", "b", "c" };
            int decision = 1, tries = 3;

            // Act
            bool result = MenuOptions.CheckMenuDecision(options, decision, ref tries);

            // Assert
            Assert.IsTrue(result && tries == 3);
        }

        [TestMethod]
        public void CheckMenuDecision_False()
        {
            // Arrange
            string[] options = { "a", "b", "c" };
            int decision = 10, tries = 3;

            // Act
            bool result = MenuOptions.CheckMenuDecision(options, decision, ref tries);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PrintMenuOptions()
        {
            // Arrange
            string[] options = { "a", "b", "c" };
            string expected1 = "0. a", expected2 = "1. b";

            // Act
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            MenuOptions.PrintMenuOptions(options);
            string output = sw.ToString();

            // Assert
            Assert.IsTrue(output.Contains(expected1) && output.Contains(expected2));
        }


        // *********************** Tests de la clase MenuOptions *****************************
        [TestMethod]
        public void Attack()
        {
            // Arrange
            Random random = new Random();
            string[] names = { "Arquera", "Monstruo" };
            int charIndex = 0, monsterIndex = 1, attackIndex = 0, defenseIndex = 1;
            double expectedDamage = 16, missedDamage = 0, doubleDamage = 32;
            double[,] stats =
            {
                {20, 20 },
                {40, 20 }
            };

            // Act
            double damage = TurnOptions.Attack(charIndex, stats, monsterIndex, attackIndex, defenseIndex, random, names);

            // Assert
            Assert.IsTrue(damage == expectedDamage || damage == missedDamage || damage == doubleDamage);
        }

        [TestMethod]
        public void MageAttackAbility()
        {
            // Arrange
            Random random = new Random();
            string[] names = { "Maga", "Monstruo" };
            int charIndex = 0, monsterIndex = 1, attackIndex = 0, defenseIndex = 1, multiplier = 3;
            double expectedDamage = 48;
            double[,] stats =
            {
                {20, 20 },
                {40, 20 }
            };

            // Act
            double damage = TurnOptions.Attack(charIndex, stats, monsterIndex, attackIndex, defenseIndex, names, multiplier);

            // Assert
            Assert.IsTrue(damage == expectedDamage);
        }

        [TestMethod]
        public void Defense()
        {
            // Arrange
            string[] names = { "Arquera", "Monstruo" };
            int charIndex = 0, defenseIndex = 1;
            int[] turnOrder = { 0, 1 };
            double[,] stats =
            {
                {20, 20 },
                {40, 20 }
            };
            double expectedNewStat = 40;

            // Act
            TurnOptions.Defense(ref stats, turnOrder, charIndex, defenseIndex, names);

            // Assert
            Assert.IsTrue(stats[0, 1] == expectedNewStat);
        }


        // *********************** Tests de la clase CharactersCreation *****************************

        [TestMethod]
        public void CapitalizeFirstLetter()
        {
            // Arrange
            string name = "druida", expected = "Druida";

            // Act
            bool result = CharactersCreation.CapitalizeFirstLetter(name) == expected;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckCharacterStat_ValidStat()
        {
            // Arrange
            int tries = 3;
            double minValue = 5, maxValue = 10, stat = 7;

            // Act
            bool result = CharactersCreation.CheckCharacterStat(ref stat, minValue, maxValue, ref tries);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckCharacterStat_BiggerRangeStat()
        {
            // Arrange
            int tries = 3;
            double minValue = 5, maxValue = 10, stat = 15;

            // Act
            bool result = CharactersCreation.CheckCharacterStat(ref stat, minValue, maxValue, ref tries);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCharacterStat_LowerRangeStat()
        {
            // Arrange
            int tries = 3;
            double minValue = 5, maxValue = 10, stat = 2;

            // Act
            bool result = CharactersCreation.CheckCharacterStat(ref stat, minValue, maxValue, ref tries);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckCharacterStat_AutomaticEasyAssignation()
        {
            // Arrange
            int tries = 1;
            double minValue = 5, maxValue = 10, stat = 15;

            // Act
            bool result = CharactersCreation.CheckCharacterStat(ref stat, minValue, maxValue, ref tries);

            // Assert
            Assert.IsTrue(minValue == stat && !result);
        }


        // *********************** Tests de la clase CharactersCreation *****************************

        [TestMethod]
        public void GetRandomTurnOrder_FourCharactersAlive()
        {
            // Arrange
            Random random = new Random();
            int aIndex = 0, bIndex = 1, mIndex = 2, dIndex = 3, indexHealth = 0;
            double[,] stats =
            {
                {10},
                {10},
                {10},
                {10}
            };

            // Act
            int[] firstOrder = GeneralUtils.GetRandomTurnOrder(random, aIndex, bIndex, mIndex, dIndex, stats, indexHealth);
            int[] secondOrder = GeneralUtils.GetRandomTurnOrder(random, aIndex, bIndex, mIndex, dIndex, stats, indexHealth);

            // Assert
            Assert.AreNotEqual(firstOrder, secondOrder);
        }

        [TestMethod]
        public void GetRandomTurnOrder_ThreeCharactersAlive()
        {
            // Arrange
            Random random = new Random();
            int aIndex = 0, bIndex = 1, mIndex = 2, dIndex = 3, indexHealth = 0;
            double[,] stats =
            {
                {10},
                {0},
                {10},
                {10}
            };

            // Act
            int[] firstOrder = GeneralUtils.GetRandomTurnOrder(random, aIndex, bIndex, mIndex, dIndex, stats, indexHealth);
            int[] secondOrder = GeneralUtils.GetRandomTurnOrder(random, aIndex, bIndex, mIndex, dIndex, stats, indexHealth);

            // Assert
            Assert.AreNotEqual(firstOrder, secondOrder);
        }

        [TestMethod]
        public void GetRandomTurnOrder_OneCharacterAlive()
        {
            // Arrange
            Random random = new Random();
            int aIndex = 0, bIndex = 1, mIndex = 2, dIndex = 3, indexHealth = 0;
            double[,] stats =
            {
                {0},
                {0},
                {0},
                {10}
            };

            // Act
            int[] firstOrder = GeneralUtils.GetRandomTurnOrder(random, aIndex, bIndex, mIndex, dIndex, stats, indexHealth);
            int[] secondOrder = GeneralUtils.GetRandomTurnOrder(random, aIndex, bIndex, mIndex, dIndex, stats, indexHealth);

            // Assert
            Assert.AreNotEqual(firstOrder, secondOrder);
        }

        [TestMethod]
        public void CheckAbilityOnCooldown_NotCooldown()
        {
            // Arrange
            int index = 1, aCooldown = 0, bCooldown = 0, mCooldown = 0, dCooldown = 0;

            // Act
            bool result = GeneralUtils.CheckAbilityOnCooldown(index, aCooldown, bCooldown, mCooldown, dCooldown);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckAbilityOnCooldown_HasCooldown()
        {
            // Arrange
            int index = 3, aCooldown = 0, bCooldown = 0, mCooldown = 0, dCooldown = 3;

            // Act
            bool result = GeneralUtils.CheckAbilityOnCooldown(index, aCooldown, bCooldown, mCooldown, dCooldown);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MonsterTurnAttack()
        {
            // Arrange
            int monsterIndex = 1, heroIndex = 0, attackIndex = 1, defenseIndex = 2;
            double expected = 15;
            double[,] stats =
            {
                {20, 40, 25 },
                {40, 20, 20}
            };

            // Act
            double damage = GeneralUtils.MonsterTurnAttack(stats, monsterIndex, heroIndex, attackIndex, defenseIndex);

            // Assert
            Assert.AreEqual(expected, damage);
        }
    }
}