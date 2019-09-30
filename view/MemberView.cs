using System; 
using System.Collections.Generic;
using model;

namespace view
{
    public class MemberView 
    {
        private ConsoleView _consoleView;

        public MemberView()
        {
            this._consoleView = new ConsoleView();
        }
        public string getMemberName() 
        {
            do
            {      
                this._consoleView.setBlueText(">Enter member name: ");
                string name = Console.ReadLine();
                if (!String.IsNullOrEmpty(name))
                {
                    return name; 
                }
                this._consoleView.setErrorMsg("Member name must be entered");
                this._consoleView.GetKeyPress("Press any key to continue");
            } while(true);
        }

        public string getMemberPersonalNr()
        { 
            do
            {      
                this._consoleView.setBlueText(">Enter members personal number: ");
                double id;

                string personalNr = Console.ReadLine();
                if (double.TryParse(personalNr, out id) && personalNr.Length == 10)
                {
                    return personalNr;
                }
                this._consoleView.setErrorMsg("Personal number  must have format YYMMDDNNNN");
                this._consoleView.GetKeyPress("Press any key to continue");
            } while(true);
        }

        public string getMemberId()
        {
            this._consoleView.setBlueText(">Enter members member id: ");
            return Console.ReadLine();
        }

        public void displayMember(Member member)
        {
            Console.Clear();
            this.verboseMemberInfo(member);
        }

        public void verboseMemberInfo(Member member)
        {
            Console.WriteLine("\n═══════════════ Member Information ════════════════════\n");
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"PersonalNumber: {member.PersonalNumber}");
            Console.WriteLine($"Member id: {member.MemberId}");
            Console.WriteLine($"Nr of boats: {member.NrOfBoats}");
            this.displayBoats(member);
            Console.WriteLine("\n═══════════════════════════════════════════════\n");
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
                this._consoleView.setBlueText("\n>Enter menu selection [1-2]: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1 
                    && index <= 2)
                {
                    Console.Clear();
                    return (ChangeMember)index;
                }

                this._consoleView.setErrorMsg("Error enter number 1 or 2");
                this._consoleView.GetKeyPress("Press any key to continue");
            } while (true);
        }

         public int getChosenBoat(Member member, string message)
        {
            int index;
            do
            {
                this._consoleView.setBlueText(message);
                this.displayBoats(member);
                this._consoleView.setBlueText("\n>Enter nr: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1
                    && index <= member.NrOfBoats)
                {
                    Console.Clear();
                    return index;
                }
                
                this._consoleView.setErrorMsg($"Error enter number 1 and {member.NrOfBoats}");
                this._consoleView.GetKeyPress("Press any key to continue");
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

        public float getBoatLength() 
        {
            this._consoleView.setBlueText(">Enter boats length in feet: ");
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
                this._consoleView.setBlueText("Enter the nr of the boats type \n>Enter menu selection nr [1-5]: ");
                
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1
                    && index <= 5)
                {
                    Console.Clear();
                    return (BoatTypes)index;
                }

                this._consoleView.setErrorMsg("Error enter number 1 or 5");
                this._consoleView.GetKeyPress("Press any key to continue");
            } while (true);
        
        }

         public ChangeBoat getChangeBoatChoice() 
        {
            int index;
            do
            {     
                Console.WriteLine("\n - Change boat information -------------------------\n");
                Console.WriteLine(" 1. Change type");
                Console.WriteLine($" 2. Change length");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                this._consoleView.setBlueText("\n>Enter menu selection [1-2]: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1 
                    && index <= 2)
                {
                    Console.Clear();
                    return (ChangeBoat)index;
                }
                this._consoleView.setErrorMsg("Error enter number 1 or 2");
                this._consoleView.GetKeyPress("Press any key to continue");
            } while (true);
        }

        
        public void showCompactList(IReadOnlyList<Member> members)
        {
            this._consoleView.setBlueText("To Look at a specific member enter the member id below");
            Console.WriteLine("\n═══════════════════ Members ════════════════════════\n");
            foreach(Member member in members)
            {
                string formatedOutput = String.Format("{0,-12} {1,12} {2,12}",
                $"Name: {member.Name}", $"Id: {member.MemberId}", $"Boats: {member.NrOfBoats}");
                Console.WriteLine(formatedOutput);
                Console.WriteLine("______________________________________________\n");
            }

            this._consoleView.setBlueText("To go back to main menu enter 0\n");
        }

        public void showVerboseList(IReadOnlyList<Member> members)
        {
            this._consoleView.setBlueText("To Look at a specific member enter the member id at the bottom");
            Console.WriteLine("\n═══════════════════ Members ════════════════════════\n");
            foreach(Member member in members)
            {
                this.verboseMemberInfo(member);
            }

            this._consoleView.setBlueText("To go back to main menu enter 0\n");
        }
    }
}