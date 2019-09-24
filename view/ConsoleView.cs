using System; 
using model;

namespace view
{
    public class ConsoleView 
    {
        public MenuChoice showMenu() 
        {
             int index;

            do
            {  
                Console.WriteLine("\n - Menu -----------------------------------\n");
                Console.WriteLine(" 0. Exit.");
                Console.WriteLine(" 1. Add Member");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                Console.Write(">Enter menu selection [0-1]: ");
                    
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 1)
                {
                    Console.Clear();
                    return (MenuChoice)index;
                }
            } while (true);
        }

        public Member getMemberInfo() {
            Console.WriteLine(">Enter members name: ");
            string memberName = Console.ReadLine();
            Console.WriteLine(">Enter members personal number: ");
            string personalNumber = Console.ReadLine();
            return new Member(memberName, personalNumber);
        }
       
    }
}