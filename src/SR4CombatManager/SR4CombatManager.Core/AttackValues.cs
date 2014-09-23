
namespace SR4CombatManager.Core
{
    public class AttackValues
    {
        public int AttackDice { get; set; }
       
        public int ArmourPiercingModifier { get; set; }
        public int BaseDamageValue { get; set; }
        public DamageType DamageType { get; set; }
        public int RecoilPenalty { get; set; }

        public ArmourType DefendingArmourType { get; set; }
        public int BurstDefenceModifier { get; set; }

        public int BurstDamageModifier { get; set; }

        public int AmmoUsed { get; set; }
    }
}
