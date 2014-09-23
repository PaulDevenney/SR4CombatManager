using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR4CombatManager.Core
{
    public class Weapon
    {
        public WeaponCategory Category { get; set; }

        public AmmoType AmmoType { get; set; }
        public int ArmourPiercing { get; set; }
        public DamageCode DamageCode { get; set; }

        public int RecoilCompensation { get; set; }

        public bool HasSmartLink { get; set; }

        public bool HasLaserSight { get; set; }
    }

    public class DamageCode
    {
        public int Value { get; set; }
        public DamageType Type { get; set;  }
    }

    public enum DamageType
    {
        Physical,
        Stun
    }
}
