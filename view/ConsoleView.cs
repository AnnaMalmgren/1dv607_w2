using System; 
using System.Collections.Generic;
using model;

namespace view
{
    public class ConsoleView 
    {
        private MenusView _menu;
        public ConsoleView()
        {
            this._menu= new MenusView();
        }
        public MainMenu getMainMenuChoice() 
        {
             int index;
            do
            {  
                this._menu.MainMenu();  

                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 
                    && index <= this._menu.MainLength)
                {
                    Console.Clear();
                    return (MainMenu)index;
                }
            } while (true);
        }

        public MemberMenu getMemberMenuChoice()
        {
            int index;
            do
            {  
                this._menu.MemberMenu();
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 
                    && index <= this._menu.MemberLength)
                {
                    Console.Clear();
                    return (MemberMenu)index;
                }
            } while (true);
        }

        public ChangeMember getChangeMemberChoice() 
        {
            int index;
            do
            {  
                this._menu.ChangeMemberMenu();
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 
                    && index <= this._menu.ChangeLength)
                {
                    Console.Clear();
                    return (ChangeMember)index;
                }
            } while (true);
        }

        public float getBoatLength() 
        {
            Console.Write(">Enter boats length: ");
            float.TryParse(Console.ReadLine(), out float length);
            return length;
        }

        public BoatTypes getBoatType() 
        {
            int index;
            do
            {  
                this._menu.BoatTypesMenu();
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 
                    && index <= this._menu.BoatTypes)
                {
                    Console.Clear();
                    return (BoatTypes)index;
                }
            } while (true);
        
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
            foreach(Member member in members)
            {
                string formatedOutput = String.Format("{0,-12} {1,12} {2,12}",
                $"Name: {member.Name}", $"Id: {member.MemberId}", $"Boats: {member.NrOfBoats}");
                Console.WriteLine(formatedOutput);
                Console.WriteLine("______________________________________________\n");
            }
            return this.getMemberId();
        }

         public string showVerboseList(IReadOnlyList<Member> members)
        {
            Console.WriteLine("To Look at a specific member enter the member id at the bottom");
            Console.WriteLine("\n═══════════════════ Members ════════════════════════\n");
            foreach(Member member in members)
            {
                this.verboseMemberInfo(member);
            }
             return this.getMemberId();
        }

        public MemberMenu displayMember(Member member)
        {
            Console.Clear();
            this.verboseMemberInfo(member);
            return this.getMemberMenuChoice();
        }

        public void verboseMemberInfo(Member member)
        {
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"PersonalNumber: {member.PersonalNumber}");
            Console.WriteLine($"Member id: {member.MemberId}");
            Console.WriteLine($"Nr of boats: {member.NrOfBoats}");
            this.displayBoats(member);
            Console.WriteLine("\n═══════════════════════════════════════════════");
        }

        public int getBoatToDelete(Member member)
        {
            int index;
            do
            {
                this.displayBoats(member);
                Console.WriteLine("Enter the nr of the boat you want to delete below.");
                Console.WriteLine("Press nr 0 to go back.");
                Console.Write(">Enter nr: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 
                    && index <= member.NrOfBoats)
                {
                    Console.Clear();
                    return index;
                }
            } while(true);
        }

        public void displayBoats(Member member)
        {
            foreach (Boat boat in member.Boats)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"Boat nr {boat.Id}");
                Console.WriteLine($"Type: {boat.Type}\nLength: {boat.Length}");

            }
        }
       
    }
}