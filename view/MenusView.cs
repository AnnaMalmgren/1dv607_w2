using System; 

namespace view
{
    public class MenusView : MessageView
    {
        public MainMenu getMainMenuChoice() 
        {
            Console.Clear();
          
            Console.WriteLine("\n═══════════════════ Main Menu ══════════════════════\n");;
            Console.WriteLine(" 0. Save and exit");
            Console.WriteLine(" 1. Add Member");
            Console.WriteLine(" 2. List members compact");
            Console.WriteLine(" 3. List members verbose");
            Console.WriteLine("\n ══════════════════════════════════════════\n");
            this.setBlueText(">Enter menu selection [0-3]: "); 
            int mainMenuLength = Enum.GetNames(typeof(MainMenu)).Length;
            return (MainMenu)this.getMenuChoiceNr(mainMenuLength);
        }

        private int getMenuChoiceNr(int menuLength)
        {
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0
                && index <= menuLength)
            {
                Console.Clear();
                return index;
            }
            else 
            {
                return -1;
            }

        }

        public MemberMenu getMemberMenuChoice(bool memberHasBoats)
        {
            this.displayMemberMenu(memberHasBoats);
            int memberMenuLength = this.getNrOfMemberMenuChoices(memberHasBoats);
            return (MemberMenu)this.getMenuChoiceNr(memberMenuLength);
        }

        private void displayMemberMenu(bool memberHasBoats)
        {
            Console.WriteLine("\n - Menu -----------------------------------\n");
            Console.WriteLine(" 0. Main Menu");
            Console.WriteLine(" 1. Change member information");
            Console.WriteLine(" 2. Delete member");
            Console.WriteLine(" 3. Register boat");

            if (memberHasBoats)
            {
                Console.WriteLine(" 4. Change boat information");
                Console.WriteLine(" 5. Delete boat");
            }
            
            Console.WriteLine("\n ═══════════════════════════════════════════\n");
            this.setBlueText(">Enter menu selection: ");
        }

        private int getNrOfMemberMenuChoices(bool memberHasBoats)
        {
            int nrOfMemberMenuChoices = Enum.GetNames(typeof(MemberMenu)).Length;
            int nrOfHasNoBoatMenuChoices = Enum.GetNames(typeof(MemberMenuNoBoats)).Length;
            return memberHasBoats ? nrOfMemberMenuChoices  : nrOfHasNoBoatMenuChoices;
        }

        public ChangeMember getChangeMemberChoice() 
        {
            Console.WriteLine("\n - Change member information ---------------------\n");
            Console.WriteLine($" 0. Go back");
            Console.WriteLine($" 1. Change members name");
            Console.WriteLine($" 2. Change members personal number");
            Console.WriteLine("\n ══════════════════════════════════════════\n");
            this.setBlueText("\n>Enter menu selection [1-2]: ");
             int changeMenuLength = Enum.GetNames(typeof(ChangeMember)).Length;
            return (ChangeMember)this.getMenuChoiceNr(changeMenuLength);
        }

        public ChangeBoat getChangeBoatChoice() 
        {
            Console.WriteLine("\n - Change boat information -------------------------\n");
            Console.WriteLine($" 0. Go back");
            Console.WriteLine(" 1. Change type");
            Console.WriteLine(" 2. Change length");
            Console.WriteLine("\n ══════════════════════════════════════════\n");
            this.setBlueText("\n>Enter menu selection [1-2]: ");
            int changeBoatLength = Enum.GetNames(typeof(ChangeBoat)).Length;
            return (ChangeBoat)getMenuChoiceNr(changeBoatLength);
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
             
                this.setErrorMsg("You have to enter y for yes or n for no");
                this.GetKeyPress();
            } while (true);
        }

    }
}