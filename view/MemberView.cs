using System; 
using System.Collections.Generic;
using model;

namespace view
{
    public class MemberView 
    {
        public string getMemberName() 
        {        
            Console.Write(">Enter member name: ");
            return Console.ReadLine();
        }

        public string getMemberPersonalNr()
        {
            Console.Write(">Enter member personal number: ");
            return Console.ReadLine();
        }

        public string getMemberId()
        {
           Console.Write(">Enter members member id: "); 
           return Console.ReadLine();
        }

        public void displayMember(Member member)
        {
            Console.Clear();
            this.verboseMemberInfo(member);
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

        public ChangeMember getChangeMemberChoice() 
        {
            int index;
            do
            {  
                Console.WriteLine("\n - Change member information ---------------------\n");
                Console.WriteLine($" 1. Change members name");
                Console.WriteLine($" 2. Change members personal number");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                Console.Write(">Enter menu selection [1-2]: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1 
                    && index <= 2)
                {
                    Console.Clear();
                    return (ChangeMember)index;
                }
            } while (true);
        }

         public int getChosenBoat(Member member, string message)
        {
            int index;
            do
            {
                Console.WriteLine(message);
                this.displayBoats(member);
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
                Console.WriteLine($"Boat nr {boat.Id}");
                Console.WriteLine($"Type: {boat.Type}\nLength: {boat.Length}");
                Console.WriteLine("-----------------------------------------------");

            }
        }

        public float getBoatLength() 
        {
            Console.Write(">Enter boats length in feet: ");
            float.TryParse(Console.ReadLine(), out float length);
            return length;
        }


        public BoatTypes getBoatType() 
        {
            int index;
            do
            { 
                Console.WriteLine("\n - Boat types --------------------------------\n");
                Console.WriteLine(" 1. Sailboat");
                Console.WriteLine(" 2. Motorsailer");
                Console.WriteLine(" 3. kayak");
                Console.WriteLine(" 4. Canoe");
                Console.WriteLine(" 5. Other");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                Console.WriteLine("Enter the nr of the boats type below");
                Console.Write(">Enter menu selection nr [1-5]: ");
                
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1
                    && index <= 5)
                {
                    Console.Clear();
                    return (BoatTypes)index;
                }
            } while (true);
        
        }

         public ChangeBoat getChangeBoatChoice() 
        {
            int index;
            do
            {     
                Console.WriteLine("\n - Menu -----------------------------------\n");
                Console.WriteLine(" 1. Change type");
                Console.WriteLine($" 2. Change length");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                Console.Write(">Enter menu selection [1-2]: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1 
                    && index <= 2)
                {
                    Console.Clear();
                    return (ChangeBoat)index;
                }
            } while (true);
        }

        
        public void showCompactList(IReadOnlyList<Member> members)
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
        }

        public void showVerboseList(IReadOnlyList<Member> members)
        {
            Console.WriteLine("To Look at a specific member enter the member id at the bottom");
            Console.WriteLine("\n═══════════════════ Members ════════════════════════\n");
            foreach(Member member in members)
            {
                this.verboseMemberInfo(member);
            }
        }

    }
}