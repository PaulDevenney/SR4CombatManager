using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR4CombatManager.Core
{
    public class Combatant
    {
        public int Agility { get; set; }

        /// <summary>
        /// Work out the correct skill value for the weapon category (checks for firearms group etc)
        /// </summary>
        /// <param name="weaponCategory"></param>
        /// <returns></returns>
        public int ResolveAttackSkill(WeaponCategory weaponCategory)
        {
            return 0;
        }

        public bool HasSmartLink { get; set; }
    }
}
