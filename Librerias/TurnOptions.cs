using HeroesVsMonster_GeneralUtils;

namespace HeroesVsMonster_TurnOptions
{
    public class TurnOptions
    {
        public static void Attack(double attackDamage, ref double monsterHealth, Random random, double monsterDefense)
        {
            const int doubleAttack = 2;

            if (!GeneralUtils.IsMissedAttack(random))
            {
                if (GeneralUtils.IsCriticAttac(random))
                {
                    attackDamage *= doubleAttack;
                    Console.WriteLine("Double damage");
                }
                monsterHealth -= Math.Round(attackDamage - (attackDamage * monsterDefense) / 100.0, 2);
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
        }

        public static void ArcherAbility(ref int monsterKnockout)
        {
            const int knockedTurns = 3;
            monsterKnockout = knockedTurns;
        }

        public static void BarbarianAbility(ref int invulnerability)
        {
            const int invulnerabilityTurns = 3;
            invulnerability = invulnerabilityTurns;
        }

        public static void MageAbility(double mageAttack, ref double monsterHealth)
        {
            const int attackMultiplier = 3;

            monsterHealth -= mageAttack * attackMultiplier;
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
        }
    }
}
