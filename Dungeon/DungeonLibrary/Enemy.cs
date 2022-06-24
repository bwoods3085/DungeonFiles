using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Enemy : Character
    {
        private int _minDamage;

        //properties
        public int MaxDamage { get; set; }
        public string Description { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than the MaxDamage
                //and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    //less than the max and greater than 0, so let it pass
                    _minDamage = value;
                }//end if
                else
                {
                    //tried to set the value outside our range
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage

        //ctors
        //public Monster()
        //{

        //}
        public Enemy(string name, int life, int maxLife, int hitChance,
            int shield, int maxDamage, int minDamage, string description) : base(life, maxLife, name, hitChance, shield)
        {
            //Set MaxLife and MaxDamage first! because other properties
            //depend on them
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }//end fq ctor
        //public Enemy()
        //{

        //}



        //methods
        public override string ToString()
        {
            return $"\n********Enemy********\n{Name}\nLife: {Life} of {MaxLife}\nDamage: {MinDamage} to {MaxDamage}" +
                $"\nShield: {Shield}\nDescription:\n{Description}\n";

            //example using a verbatim string
            //            return $@"
            //********MONSTER********
            //{Name}
            //Life: {Life} of {MaxLife}
            //Damage: {MinDamage} to {MaxDamage}
            //Block: {Block}
            //Description:
            //{Description}
            //";
        }

        //we are overriding the CalcDamage to use the properties
        //MinDamage and MaxDamage
        public override int CalcDamage()
        {
            //return base.CalcDamage();//base returns 0 not what we want
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }//end CalcDamage

        //Add after adding the monster types. Come back as necessary as you add new monster types to add them into the collection.
        public static Enemy GetEnemy()
        {
            Borg b = new("Locutus's Cube", 100, 100, 70, 70, 2, 10, "Borg Cube", false);
            Klingon k = new("IKS B'rel", 50, 50, 70, 8, 1, 9, "B'rel class Bird-of-Prey Scoutship",true);
            Romulan r = new("IRW Albius", 50, 50, 50, 10, 1, 9, "D'deridex-class Warbird",false);
            Cardassian c = new("CDS Avenger", 20, 20, 65, 20, 1, 15, "Galor Class Battleship", false);
            Ferengi f = new("FMS Mroxor",20,20,40,40,1,4,"D'Kora Class Marauder",true);

            List<Enemy> enemies = new() { c,f,k,r,f,b,f,r,c, k,c, k,  };

            return enemies[new Random().Next(enemies.Count)];

        }
    }
}
