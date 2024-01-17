namespace HeroesVsMonster_GeneralUtils
{
    public class GeneralUtils
    {
        public static bool IsCriticAttac(Random random)
        {
            return random.Next(0, 10) < 1;
        }

        public static bool IsMissedAttack(Random random)
        {
            return random.Next(0, 20) < 1;
        }

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
            return index switch
            {
                0 => archerName,
                1 => barbName,
                2 => mageName,
                3 => druidName,
                _ => "ERROR",
            };
        }
    }
}