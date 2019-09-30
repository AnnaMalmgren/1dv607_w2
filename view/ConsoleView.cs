using System; 

namespace view
{
    public class ConsoleView 
    {

        public MainMenu getMainMenuChoice() 
        {
            Console.Clear();
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
                    && index <= 3)
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
                    && index <= 5)
                {
                    Console.Clear();

                   return (MemberMenu)index;
                }

                this.setErrorMsg("Error! Enter a number between 0 and 5");
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