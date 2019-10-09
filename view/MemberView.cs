using System; 
using model;
using System.Collections.Generic;

namespace view
{
    public class MemberView : MessageView
    {

        public string getMemberName() 
        {
            Console.Clear();
            // waits for user to enter name;
            do
            {      
                this.setBlueText(">Enter member name: ");
                string name = Console.ReadLine();

                if (!String.IsNullOrEmpty(name))
                {
                    return name; 
                }

                this.setErrorMsg("Member name must be entered");
                this.GetKeyPress("Press any key to continue");
            } while(true);
        }

        public string getMemberPersonalNr()
        { 
            int personalNrLength = 10;
            //waits for user to enter a correct formated personal number
            do
            {      
                this.setBlueText(">Enter members personal number: ");
                double id;

                string personalNr = Console.ReadLine();
                if (double.TryParse(personalNr, out id) && 
                    personalNr.Length == personalNrLength)
                {
                    return personalNr;
                }
                this.setErrorMsg("Personal number  must have format YYMMDDNNNN");
                this.GetKeyPress("Press any key to continue");
            } while(true);
        }

        public string getMemberId()
        {
            this.setBlueText(">Enter members member id: ");
            return Console.ReadLine();
        }

        public void displayMember(Member member)
        {
            Console.Clear();
            Console.WriteLine("\n═══════════════ Member Information ════════════════════\n");
            this.verboseMemberInfo(member);
        }

        public void verboseMemberInfo(Member member)
        {
            Console.WriteLine($"Name: {member.Name}");
            Console.WriteLine($"PersonalNumber: {member.PersonalNumber}");
            Console.WriteLine($"Member id: {member.MemberId}");
            Console.WriteLine($"Nr of boats: {member.NrOfBoats}");
            this.displayBoats(member.Boats);
            Console.WriteLine("\n═══════════════════════════════════════════════\n");
        }

        public int getChosenBoat(Member member)
        {
            Console.Clear();
            int index;
            // waits for user to enter number for boat.
            do
            {
                this.setBlueText("Enter the nr of the boat you want to select below\n");
                this.displayBoats(member.Boats);
                this.setBlueText("\n>Enter nr: ");

                if (int.TryParse(Console.ReadLine(), out index) && index >= 1
                    && index <= member.NrOfBoats)
                {
                    Console.Clear();
                    return index;
                }
                
                this.setErrorMsg($"Error enter a number between 1 and {member.NrOfBoats}");
                this.GetKeyPress("Press any key to continue");
            } while(true);
        }

        public void displayBoats(List<Boat> boats)
        {
            foreach (Boat boat in boats)
            {
                Console.WriteLine("\n-----------------------------------------------\n");
                Console.WriteLine($"Boat nr {boat.Id}\nType: {boat.Type}\nLength: {boat.LengthInFeet}");
            }
        }

        public float getBoatLength() 
        {
            Console.Clear();
            // waits for user to input valid boat length
            do 
            {
                this.setBlueText(">Enter boats length in feet: ");
                string userInput = Console.ReadLine();
                float length;
                if (float.TryParse(userInput, out length) && length > 0)
                {
                    return length;
                }
                this.setErrorMsg("Error boath length not valid");
                this.GetKeyPress("Press any key to continue");

            } while(true);
        }

        public BoatTypes getBoatType() 
        {
            Console.Clear();
            int nrOfBoatTypes = 5;
            int index;
            //waits for user to enter menu choice
            do
            { 
                Console.WriteLine("\n - Boat types --------------------------------\n");
                Console.WriteLine(" 1. Sailboat");
                Console.WriteLine(" 2. Motorsailer");
                Console.WriteLine(" 3. kayak");
                Console.WriteLine(" 4. Canoe");
                Console.WriteLine(" 5. Other");
                Console.WriteLine("\n ══════════════════════════════════════════\n");
                this.setBlueText("Enter the nr of the boats type \n>Enter menu selection nr [1-5]: ");
                
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1
                    && index <= nrOfBoatTypes)
                {
                    Console.Clear();
                    return (BoatTypes)index;
                }

                this.setErrorMsg("Error enter number 1 or 5");
                this.GetKeyPress("Press any key to continue");
            } while (true);
        
        }
        
        public void showCompactList(IReadOnlyList<Member> members)
        {
            Console.Clear();
            this.setBlueText("To Look at a specific member enter the member id below");
            Console.WriteLine("\n═══════════════════ Members ════════════════════════\n");
            // writes out compact info of members
            foreach(Member member in members)
            {
                string formatedOutput = String.Format("{0,-12} {1,12} {2,12}",
                $"Name: {member.Name}", $"Id: {member.MemberId}", $"Boats: {member.NrOfBoats}");
                Console.WriteLine(formatedOutput);
                Console.WriteLine("______________________________________________\n");
            }

            this.setBlueText("To go back to main menu enter 0\n");
        }

        public void showVerboseList(IReadOnlyList<Member> members)
        {
            Console.Clear();
            this.setBlueText("To Look at a specific member enter the member id at the bottom");
            Console.WriteLine("\n═══════════════════ Members ════════════════════════\n");
            // writes out verbose info of members
            foreach(Member member in members)
            {
                this.verboseMemberInfo(member);
            }

            this.setBlueText("To go back to main menu enter 0\n");
        }

    }
}