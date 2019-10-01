using System; 

namespace view
{
    public class MenusView : IMessageView
    {
        public MainMenu getMainMenuChoice() 
        {
            Console.Clear();
            int mainMenuLength = 3;
            int index;
            do
            {  
                Console.WriteLine("\n═══════════════════ Main Menu ══════════════════════\n");;
                Console.WriteLine(" 0. Exit");
                Console.WriteLine(" 1. Add Member");
                Console.WriteLine(" 2. List members compact");
                Console.WriteLine(" 3. List members verbose");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                this.setBlueText(">Enter menu selection [0-3]: "); 

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0
                    && index <= mainMenuLength)
                {
                    Console.Clear();
                    return (MainMenu)index;
                }

                this.setErrorMsg("Error! Enter a number between 0 and 3");
                this.GetKeyPress("Press any key to continue");

            } while (true);
        }

        public MemberMenu getMemberMenuChoice()
        {
            int memberMenuLength = 5;
            int index;
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

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 
                    && index <= memberMenuLength)
                {
                    Console.Clear();

                   return (MemberMenu)index;
                }

                this.setErrorMsg("Error! Enter a number between 0 and 5");
                this.GetKeyPress("Press any key to continue");

            } while (true);
        }

        public ChangeMember getChangeMemberChoice() 
        {
            int changeMenuLength = 2;
            int index;
            do
            {  
                Console.WriteLine("\n - Change member information ---------------------\n");
                Console.WriteLine($" 1. Change members name");
                Console.WriteLine($" 2. Change members personal number");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                this.setBlueText("\n>Enter menu selection [1-2]: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1 
                    && index <= changeMenuLength)
                {
                    Console.Clear();
                    return (ChangeMember)index;
                }

                this.setErrorMsg("Error enter number 1 or 2");
                this.GetKeyPress("Press any key to continue");
            } while (true);
        }

        public string getDeleteConfirm(string msg)
        {
            do
            {
                this.setBlueText($"\nAre you sure you want to delete {msg} (y/n): ");
                string confirm = Console.ReadLine();
                if (confirm == "y" || confirm == "n")
                {
                    return confirm;
                }
             
                this.setErrorMsg("Error you have to enter y for yes or n for no");
                this.GetKeyPress("Press any key to continue");
            } while (true);
        }

        public ChangeBoat getChangeBoatChoice() 
        {
            int changeMenuLength = 2;
            int index;
            do
            {     
                Console.WriteLine("\n - Change boat information -------------------------\n");
                Console.WriteLine(" 1. Change type");
                Console.WriteLine(" 2. Change length");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                this.setBlueText("\n>Enter menu selection [1-2]: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1 
                    && index <= changeMenuLength)
                {
                    Console.Clear();
                    return (ChangeBoat)index;
                }
                this.setErrorMsg("Error enter number 1 or 2");
                this.GetKeyPress("Press any key to continue");
            } while (true);
        }

        public void setErrorMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{msg}\n");
            Console.ResetColor();
        }

        public void GetKeyPress(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write($"\n {msg}");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        public void setBlueText(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(msg); 
            Console.ResetColor();
        }
     
    }
}