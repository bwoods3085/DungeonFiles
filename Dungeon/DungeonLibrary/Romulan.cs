using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Romulan : Enemy
    {

        //fields/properties (using autos)
        public bool IsScoutShip { get; set; }

        //constructors, create an FQ ctor, that we can use to make a super bad monster
        public Romulan(string name, int life, int maxLife, int hitChance,
            int shield, int minDamage, int maxDamage, string description,
            bool isScoutShip)
            : base(name, life, maxLife, hitChance, shield, maxDamage,
            minDamage, description)
        {
            //just handle unique ones
            IsScoutShip = isScoutShip;
        }

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsScoutShip ? "Scout" : "StarShip...");
        }

        //override the block to say if they are fluffy they get a bonus
        //50% to their block value
        public override int CalcShield()
        {
            int calculatedShield = Shield;

            if (IsScoutShip)
            {
                calculatedShield += calculatedShield / 2;
            }

            return calculatedShield;
        }
    }
}
