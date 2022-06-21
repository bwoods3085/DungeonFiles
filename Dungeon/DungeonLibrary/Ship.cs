using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //only the first class is public, all the others default to internal. MAKE IT PUBLIC
    public class Ship
    {
        //Fields
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;
        private ShipType _type;


        //Properties
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value <= MaxDamage ? value : MaxDamage; }
        }//end MinDamage
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//end MaxDamage
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//end BonusHitChance
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//end IsTwoHanded
        public ShipType Type
        {
            get { return _type; }
            set { _type = value; }
        }


        //Constructors
        public Ship(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded, ShipType type)
        {
            //handle MaxDamage assignment FIRST, since MinDamage uses it in the setter.
            //If you have ANY properties that have business rules
            //that are based off of any OTHER properties... 
            //set the other properties first!!
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            Type = type;
        }//end FQ CTOR

        //Methods
        public override string ToString()
        {
            return $"{Name}\t{MinDamage} to {MaxDamage} Damage\n" +
                $"Bonus Hit: {BonusHitChance}%\n" +
                $"Type: {Type}\t\t{(IsTwoHanded ? "Two-Handed" : "One-Handed")}";
        }//end ToString() override
    }//end class
}//end namespace
