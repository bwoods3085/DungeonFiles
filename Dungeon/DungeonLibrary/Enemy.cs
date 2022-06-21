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
            int block, int maxDamage, int minDamage, string description) : base(life, maxLife, name, hitChance, block)
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
            return $"\n********MONSTER********\n{Name}\nLife: {Life} of {MaxLife}\nDamage: {MinDamage} to {MaxDamage}\nBlock: {Block}\nDescription:\n{Description}\n";

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
            Rabbit r = new("White Rabbit", 25, 25, 50, 20, 2, 8, "That's no ordinary rabbit! Look at the bones!", true);
            Vampire v = new("Dracula", 30, 30, 70, 8, 1, 8, "The father of all the undead");
            Turtle t = new("Mikey", 25, 25, 50, 10, 1, 4, "He is no longer a teenager but he is still a mutant turtle", 3, 10);
            Dragon d = new("Smaug", 20, 20, 65, 20, 1, 15, "The last great dragon.", true);
            //Rabbit babyRabbit = new Rabbit();

            List<Enemy> enemies = new() { r, t, v, d, r, r,  };

            return enemies[new Random().Next(enemies.Count)];

        }
    }
}
