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

            bool exit = false;
            do
            {

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
                            
                            break;
                        case "W":
                            break;
                        case "P":
                            break;
                        case "E":
                            break;
                        case "X":
                            Console.WriteLine("You Did Not Go Boldly...");
                            reload = true;
                            break;

                        default:
                            break;
                    }//End switch

                } while (!reload && !exit);

            } while (!exit);

        }//End Main().

        private static string GetRoom()
        {
            string[] rooms = new string[]
            {

            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];
            return room;

        }//End GetRoom()
    }//End class
}//End namespace