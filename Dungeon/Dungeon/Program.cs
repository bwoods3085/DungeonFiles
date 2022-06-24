using DungeonLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Next Generation";
            Console.WriteLine("Space...The Final Frontier..\n");

            int score = 0;

            #region
            Ship ship1701D = new Ship(1, 9, "USS Enterprise 1701-D", 5, false, ShipType.USSEnterpriseD);

            Player player = new Player("Blake",65,10,100,100,Commanders.CaptainPicard,ship1701D);


            #endregion


            bool exit = false;
            do
            {
                //Creating an Enemy
                Enemy enemy = Enemy.GetEnemy();
                //Create room
                Console.WriteLine(GetRoom() + $"\nAs you drop out of warp you're confronted with the: {enemy.Name}");

                bool reload = false;
                do
                {
                    Console.WriteLine("\nChoose an Action:\n" +
                        "A) Attack\n" +
                        "W) Warp Speed Away\n" +
                        "P) Player Info\n" +
                        "E) Enemy Info\n" +
                        "X) Exit\n");

                    string userOption = Console.ReadKey(true).Key.ToString().ToUpper();
                    Console.Clear();

                    switch (userOption)
                    {
                        case "A":
                            Console.WriteLine("Firing phasers!!");
                            //Combat functionality

                            Combat.DoBattle(player, enemy);                      

                            if (enemy.Life <= 0)
                            {
                                score++;
                                //player.Life += 5;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\nYou Killed {enemy.Name}!");
                                Console.ResetColor();
                                reload = true;
                            }
                            break;

                        case "W":
                            Console.WriteLine("Warp 9 Engage!!!!");
                            //monster gets a free attack
                            Console.WriteLine($"{enemy.Name} attacks you as you flee!");
                            Combat.DoAttack(enemy, player);
                            Console.WriteLine();
                            reload = true;//UPDATE new monster and new room reload
                            break;

                        case "P":
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine("Enemies defeated: " + score);
                            break;

                        case "E":
                            Console.WriteLine("Enemy Info");
                            //Print monster info
                            Console.WriteLine(enemy);
                            break;

                        case "X":
                            Console.WriteLine("You Did Not Go Boldly...");
                            reload = true;
                            break;

                        default:
                            Console.WriteLine(userOption);
                            Console.WriteLine("Input not understood, please try again");
                            break;
                    }//End switch

                    if (player.Life <= 0)
                    {
                        Console.WriteLine($"{player.Name} died miserably....\a");
                        exit = true;
                    }

                } while (!reload && !exit);

            } while (!exit);
            Console.WriteLine("Thanks for playing! Final score: " + score);
        }//End Main().

        private static string GetRoom()
        {
            string[] rooms = new string[]
            {
                "You've warped into the Gamma Quadrant...",
                "As you drop out of warp you find yourself in the debris field of Wolf 359...",
                "You were pulled into a wormhole and have found yourself alone...in the Delta Quadrant...",
                "You've left federation space and your escort has been destroyed..",
                "RED ALERT!!!...RED ALERT!!! You've been borded!",
                "You've crossed into the Beta Quadrant..",
                "You've found an spacial anomaly and your reality has become an alternate reality.. ",


            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];
            return room;

        }//End GetRoom()
    }//End class
}//End namespace