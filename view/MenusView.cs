using System; 
using System.Collections.Generic;
using model;

namespace view
{
    public class MenusView
    {
        public int MainLength => 3;
        public int MemberLength => 5;
        public int ChangeLength => 2;

        public int BoatTypes => 5;

        public void MainMenu() 
        { 
            Console.WriteLine("\n - Menu -----------------------------------\n");
            Console.WriteLine(" 0. Exit.");
            Console.WriteLine(" 1. Add Member");
            Console.WriteLine(" 2. List members compact");
            Console.WriteLine(" 3. List members verbose");
            Console.WriteLine("\n ══════════════════════════════════════════\n");
            Console.Write(">Enter menu selection [0-3]: ");
        }

        public void MemberMenu()
        {
            Console.WriteLine("\n - Menu -----------------------------------\n");
            Console.WriteLine(" 0. Exit.");
            Console.WriteLine(" 1. Change member information");
            Console.WriteLine(" 2. Delete member");
            Console.WriteLine(" 3. Register boat");
            Console.WriteLine(" 4. Change boat information");
            Console.WriteLine(" 5. Delete boat");
            Console.WriteLine("\n ═══════════════════════════════════════════\n");
            Console.Write(">Enter menu selection [0-5]: ");
        }

        public void ChangeMenu(string changeAltOne, string changeAltTwo) 
        {
            Console.WriteLine("\n - Menu -----------------------------------\n");
            Console.WriteLine(" 0. Exit.");
            Console.WriteLine($" 1. Change {changeAltOne}");
            Console.WriteLine($" 2. Change {changeAltTwo}");
            Console.WriteLine("\n ══════════════════════════════════════════\n");
            Console.Write(">Enter menu selection [0-2]: ");
        }

        public void BoatTypesMenu()
        {
            Console.WriteLine("\n - Boat typs --------------------------------\n");
            Console.WriteLine(" 0. Exit");
            Console.WriteLine(" 1. Sailboat");
            Console.WriteLine(" 2. Motorsailer");
            Console.WriteLine(" 3. kayak");
            Console.WriteLine(" 4. Canoe");
            Console.WriteLine(" 5. Other");
            Console.WriteLine("\n ══════════════════════════════════════════\n");
            Console.Write("Enter the nr of the boats type below");
            Console.Write(">Enter menu selection nr [0-5]: ");
        }
    }
}