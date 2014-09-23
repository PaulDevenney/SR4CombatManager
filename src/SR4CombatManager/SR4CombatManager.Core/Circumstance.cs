using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR4CombatManager.Core
{
    public class Circumstance
    {
        public FireMode FireMode { get; set; }

        /// <summary>
        /// Single shot represented as burst of 1
        /// </summary>
        public int NumberOfShotsInBurst { get; set; }

        public bool IsSecondShot { get; set; }

        public BurstType BurstType { get; set; }
    }
}
