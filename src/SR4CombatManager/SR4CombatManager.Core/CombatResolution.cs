namespace SR4CombatManager.Core
{
    public class CombatResolution
    {
        public AttackValues CalculateAttackValues(Combatant attacker, Weapon weapon, Circumstance circumstance)
        {
            var result = new AttackValues();

            var skillDice = attacker.ResolveAttackSkill(WeaponCategory.Pistols);
            result.AttackDice = attacker.Agility + skillDice;

            if (weapon.HasSmartLink && attacker.HasSmartLink)
            {
                result.AttackDice += 2;
            }
            else if (weapon.HasLaserSight)
            {
                result.AttackDice++;
            }

            result.DefendingArmourType = ArmourType.Ballistic;

            result.ArmourPiercingModifier = weapon.ArmourPiercing;

            if (skillDice == 0)
            {
                result.AttackDice -= 1; //unskilled penalty
            }

            result.BaseDamageValue = weapon.DamageCode.Value;
            result.DamageType = weapon.DamageCode.Type;

            //ammo type
            switch (weapon.AmmoType)
            {
                case AmmoType.APDS:
                    {
                        result.ArmourPiercingModifier -= 4;
                        break;
                    }
                case AmmoType.Explosive:
                    {
                        result.ArmourPiercingModifier--;
                        result.BaseDamageValue++;
                        break;
                    }
                case AmmoType.HighExplosive:
                    {
                        result.ArmourPiercingModifier -= 2;
                        result.BaseDamageValue += 2;
                        break;
                    }
                case AmmoType.Flechette:
                    {
                        result.ArmourPiercingModifier += 5;
                        result.BaseDamageValue += 2;
                        result.DefendingArmourType = ArmourType.Impact;
                        break;
                    }
                case AmmoType.GelRounds:
                {
                    result.DamageType = DamageType.Stun;
                    result.ArmourPiercingModifier += 2;
                    break;
                }
                default:
                    {
                        break;
                    }
            }

            //should check here if the combatant has enough ammo for desired burst or if it needs to be limited? Or should this already have been passed?

            result.RecoilPenalty = 0;
            //burst modifiers
            result.RecoilPenalty = -circumstance.NumberOfShotsInBurst + 1;
            if(circumstance.IsSecondShot)
            {
                result.RecoilPenalty--;
            }
            result.RecoilPenalty += weapon.RecoilCompensation; //how to handle basic and full compensation (for items with stocks for example)

            result.BurstDamageModifier= 0;
           result.BurstDefenceModifier = 0;
            switch (circumstance.BurstType)
            {
                    case BurstType.Narrow:
                {
                    result.BurstDamageModifier += circumstance.NumberOfShotsInBurst - 1;
                    break;
                }
                    case BurstType.Wide:
                {
                    result.BurstDefenceModifier -= (circumstance.NumberOfShotsInBurst - 1);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return result;
        }
    }

    public enum BurstType 
    {
        None,
        Narrow,
        Wide
    }

    public enum ArmourType
    {
        Ballistic,
        Impact
    }
}
