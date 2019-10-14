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
                Console.WriteLine(" 0. Save and exit");
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
                this.handleWrongMenuInput();
            } while (true);
        }

        private void handleWrongMenuInput()
        {
            this.setErrorMsg($"Select a number from the menu list");
            this.GetKeyPress();
        }

        private void displayMemberMenu(bool hasBoats)
        {
            Console.WriteLine("\n - Menu -----------------------------------\n");
            Console.WriteLine(" 0. Main Menu");
            Console.WriteLine(" 1. Change member information");
            Console.WriteLine(" 2. Delete member");
            Console.WriteLine(" 3. Register boat");
            if (hasBoats)
            {
                Console.WriteLine(" 4. Change boat information");
                Console.WriteLine(" 5. Delete boat");
            }
        }

        private int getNrOfMemberMenuChoices(bool hasBoats)
        {
            int nrOfMemberMenuChoices = Enum.GetNames(typeof(MemberMenu)).Length;
            int nrOfHasNoBoatMenuChoices = Enum.GetNames(typeof(MemberMenuNoBoats)).Length;
            return hasBoats ? nrOfMemberMenuChoices  : nrOfHasNoBoatMenuChoices;
        }

        public MemberMenu getMemberMenuChoice(bool hasBoats)
        {
            int memberMenuLength = this.getNrOfMemberMenuChoices(hasBoats);
            do
            {  
                this.displayMemberMenu(hasBoats);
                Console.WriteLine("\n ═══════════════════════════════════════════\n");
                this.setBlueText(">Enter menu selection: ");

                if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 
                    && index <= memberMenuLength)
                {
                    return (MemberMenu)index;
                }

                this.handleWrongMenuInput();

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
                    return (ChangeMember)index;
                }

               this.handleWrongMenuInput();
            } while (true);
        }

        public bool getDeleteConfirm()
        {
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
                    return (ChangeBoat)index;
                }
                this.handleWrongMenuInput();
            } while (true);
        }
    }
}