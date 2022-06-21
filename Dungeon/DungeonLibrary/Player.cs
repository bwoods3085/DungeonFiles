using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public Commanders CharacterCommander { get; set; }
        public Ship EquippedShip { get; set; }//CONTAINMENT

        public Player(string name, int hitChance, int block, int maxLife, int life, Commanders characterRace, Ship equippedShip)
            : base(life, maxLife, name, hitChance, block)
        {
            CharacterCommander = characterRace;
            EquippedShip = equippedShip;
            //Potential Expansion - Modify prop values based on the chosen Race
            switch (CharacterCommander)
            {
                case Commanders.CaptainKirk:
                    break;
                case Commanders.CaptainPicard:
                    break;
                case Commanders.CaptainJaneway:
                    HitChance += 5;
                    break;
                case Commanders.CommanderSisco:
                    break;
                default:
                    break;
            }
        }//FQ Ctor

        public override string ToString()
        {
            string description = "";
            switch (CharacterCommander)
            {
                case Commanders.CaptainKirk:
                    description = "Captain Kirk";
                    break;
                case Commanders.CaptainPicard:
                    description = "Captain Picard";
                    break;
                case Commanders.CaptainJaneway:
                    description = "Captain Janeway";
                    break;
                case Commanders.CommanderSisco:
                    description = "Commander Sisco";
                    break;
            }//end switch

            return base.ToString() + $"\nWeapon: {EquippedShip.Name}\n" +
                                     $"Total Hit Chance: {CalcHitChance()}\n" +
                                     $"Description: {description}";
        }//end ToString();

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedShip.MinDamage, EquippedShip.MaxDamage + 1);
            return damage;
        }//end CalcDamage() override
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedShip.BonusHitChance;
        }
    }
}
