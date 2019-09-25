using System; 
using System.Collections.Generic;
using model;

namespace view
{
    public class ConsoleView 
    {
        public MainMenu showMenu() 
        {
             int index;

            do
            {  
                Console.WriteLine("\n - Menu -----------------------------------\n");
                Console.WriteLine(" 0. Exit.");
                Console.WriteLine(" 1. Add Member");
                Console.WriteLine(" 2. List members compact");
                Console.WriteLine(" 3. List members verbose");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                Console.Write(">Enter menu selection [0-3]: ");
                    
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 3)
                {
                    Console.Clear();
                    return (MainMenu)index;
                }
            } while (true);
        }

        public MemberMenu showMemberMenu()
        {
            int index;
            do
            {  
                Console.WriteLine("\n - Menu -----------------------------------\n");
                Console.WriteLine(" 0. Exit.");
                Console.WriteLine(" 1. Change member");
                Console.WriteLine(" 2. Delete member");
                Console.WriteLine(" 3. Register boat");
                Console.WriteLine(" 4. Change boat information");
                Console.WriteLine(" 5. Delete boat");
                Console.WriteLine("\n ═══════════════════════════════════════════\n");
                Console.Write(">Enter menu selection [0-5]: ");
                    
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 5)
                {
                    Console.Clear();
                    return (MemberMenu)index;
                }
            } while (true);
        }

        public int menuChangeMember() 
        {
            int index;
            do
            {  
                Console.WriteLine("\n - Menu -----------------------------------\n");
                Console.WriteLine(" 0. Exit.");
                Console.WriteLine(" 1. Change name");
                Console.WriteLine(" 2. Change personal number");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                Console.Write(">Enter menu selection [0-2]: ");
                    
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= 2)
                {
                    Console.Clear();
                    return index;
                }
            } while (true);
        }

        public float getBoatLength() 
        {
            Console.Write(">Enter boats length: ");
            float.TryParse(Console.ReadLine(), out float length);
            return length;
        }

        public string getBoatType() 
        {
            Console.Write(">Enter boats type: ");
            return Console.ReadLine();
        
        }


        public string getMemberName() 
        {
            Console.Write(">Enter members name: ");
            return Console.ReadLine();
        }

        public string getMemberPersonalNr()
        {
            Console.Write(">Enter members personal number: ");
            return Console.ReadLine();
        }

        public string getMemberId()
        {
           Console.Write(">Enter members member id: "); 
           string id = Console.ReadLine();
           return id;
        }

        public string showCompactList(IReadOnlyList<Member> members)
        {
            Console.WriteLine("To Look at a specific member enter the member id below");
            Console.WriteLine("\n═══════════════════ Members ════════════════════════\n");
            foreach(var member in members)
            {
                string formatedOutput = String.Format("{0,-12} {1,12} {2,12}",
                $"Name: {member.Name}", $"Id: {member.MemberId}", $"Boats: {member.NrOfBoats}");
                Console.WriteLine(formatedOutput);
                Console.WriteLine("______________________________________________\n");
            }
            return this.getMemberId();
        }

         public void showVerboseList(IReadOnlyList<Member> members)
        {
            Console.WriteLine("Verbose list over members: ");
            Console.WriteLine();
            foreach(var member in members)
            {
                Console.WriteLine($" Name: {member.Name} | Personal number: {member.PersonalNumber} | Id: {member.MemberId}  | Boats: {member.NrOfBoats}");
            }

            Console.ReadKey();
        }

        public MemberMenu displayMember(Member member)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════\n");
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"PersonalNumber: {member.PersonalNumber}");
            Console.WriteLine($"Member id: {member.MemberId}");
            Console.WriteLine($"Boats: {member.NrOfBoats}"); 
            Console.WriteLine("\n═══════════════════════════════════════════════");

            return this.showMemberMenu();
      
        }
       
    }
}