using System; 

namespace view
{
    public class MenusView : MessageView
    {
        public MainMenu getMainMenuChoice() 
        {
            Console.Clear();
            int mainMenuLength = Enum.GetNames(typeof(MainMenu)).Length;
            do
            {  
                Console.WriteLine("\n═══════════════════ Main Menu ══════════════════════\n");;
                Console.WriteLine(" 0. Exit");
                Console.WriteLine(" 1. Add Member");
                Console.WriteLine(" 2. List members compact");
                Console.WriteLine(" 3. List members verbose");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                this.setBlueText(">Enter menu selection [0-3]: "); 

                if (int.TryParse(Console.ReadLine(), out int index) && index >= 0
                    && index <= mainMenuLength)
                {
                    Console.Clear();
                    return (MainMenu)index;
                }

                this.setErrorMsg($"Select a number from the menu list");
                this.GetKeyPress();

            } while (true);
        }

        public MemberMenu getMemberMenuChoice()
        {
            int memberMenuLength = Enum.GetNames(typeof(MemberMenu)).Length;
            do
            {  
                Console.WriteLine("\n - Menu -----------------------------------\n");
                Console.WriteLine(" 0. Main Menu");
                Console.WriteLine(" 1. Change member information");
                Console.WriteLine(" 2. Delete member");
                Console.WriteLine(" 3. Register boat");
                Console.WriteLine(" 4. Change boat information");
                Console.WriteLine(" 5. Delete boat");
                Console.WriteLine("\n ═══════════════════════════════════════════\n");
                this.setBlueText(">Enter menu selection [0-5]: ");

                if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 
                    && index <= memberMenuLength)
                {
                    Console.Clear();

                   return (MemberMenu)index;
                }

                this.setErrorMsg($"Select a number from the menu list");
                this.GetKeyPress();

            } while (true);
        }

        public ChangeMember getChangeMemberChoice() 
        {
            int changeMenuLength = Enum.GetNames(typeof(ChangeMember)).Length;
            do
            {  
                Console.WriteLine("\n - Change member information ---------------------\n");
                Console.WriteLine($" 1. Change members name");
                Console.WriteLine($" 2. Change members personal number");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                this.setBlueText("\n>Enter menu selection [1-2]: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 
                    && index <= changeMenuLength)
                {
                    Console.Clear();
                    return (ChangeMember)index;
                }

                this.setErrorMsg($"Select a number from the menu list");
                this.GetKeyPress();
            } while (true);
        }

        public bool getDeleteConfirm()
        {
            // user should press y for confirm delete and n for no.
            do
            {
                this.setBlueText($"\nAre you sure you want to delete (y/n): ");
                string confirm = Console.ReadLine();
                if (confirm == "y")
                {
                    return true;
                }
                if ( confirm == "n") {
                    return false;
                }
             
                this.setErrorMsg("Error you have to enter y for yes or n for no");
                this.GetKeyPress();
            } while (true);
        }

        public ChangeBoat getChangeBoatChoice() 
        {
            // waits for user to enter change boat choice
            int changeBoatLength = Enum.GetNames(typeof(ChangeBoat)).Length;
            do
            {     
                Console.WriteLine("\n - Change boat information -------------------------\n");
                Console.WriteLine(" 1. Change type");
                Console.WriteLine(" 2. Change length");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                this.setBlueText("\n>Enter menu selection [1-2]: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 
                    && index <= changeBoatLength)
                {
                    Console.Clear();
                    return (ChangeBoat)index;
                }
                this.setErrorMsg($"Select a number from the menu list");
                this.GetKeyPress();
            } while (true);
        }

     
    }
}