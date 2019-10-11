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
            this.setBlueText(">Enter members name: ");
            return Console.ReadLine();
        
        }

        public string getMemberPersonalNr()
        { 
            this.setBlueText(">Enter members personal number: ");
            return Console.ReadLine();
        }

        public Member getMemberCredentials() 
        {
            return new Member(this.getMemberName(), this.getMemberPersonalNr());
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

        public Boat getChosenBoat(Member member)
        {
            Console.Clear();
            do
            {
                this.setBlueText("Enter the nr of the boat you want to select below\n");
                this.displayBoats(member.Boats);
                this.setBlueText("\n>Enter nr: ");

                if (int.TryParse(Console.ReadLine(), out int boatId) && boatId >= 1
                    && boatId <= member.NrOfBoats)
                {
                    Console.Clear();
                    return member.getBoat(boatId);
                }
                
                this.setErrorMsg($"Error enter a number between 1 and {member.NrOfBoats}");
                this.GetKeyPress();
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
                if (float.TryParse(userInput, out length))
                {
                    return length;
                }
                this.setErrorMsg("Error boat length must be a numeric value");
                this.GetKeyPress();
            } while(true);
        }

        public BoatTypes getBoatType() 
        {
            Console.Clear();
            int nrOfBoatTypes = Enum.GetNames(typeof(BoatTypes)).Length;
            int index;
            //waits for user to enter menu choice
            do
            {
                this.printBoatTypesList(); 
               
                if (int.TryParse(Console.ReadLine(), out index) && index >= 1
                    && index <= nrOfBoatTypes)
                {
                    Console.Clear();
                    return (BoatTypes)index;
                }

                this.setErrorMsg($"Error enter number 1 or {nrOfBoatTypes}");
                this.GetKeyPress();
            } while (true);
        }

        private void printBoatTypesList() 
        {
            int currentNr  = 1;
            Console.WriteLine("\n - Boat types --------------------------------\n");
            foreach (string boatType in Enum.GetNames(typeof(BoatTypes)))
            {
                Console.WriteLine($"{currentNr}. {boatType}");
                currentNr++;
            }
            Console.WriteLine("\n ══════════════════════════════════════════\n");
            this.setBlueText("Enter menu selection nr: ");
        }
        
        public void showCompactList(IReadOnlyList<Member> members)
        {
            Console.Clear();
            this.setBlueText("To Look at a specific member enter the member id below");
            Console.WriteLine("\n═══════════════════ Members ════════════════════════\n");
            foreach(Member member in members)
            {
                this.printCompactMemberInfo(member);
            }

            this.setBlueText("To go back to main menu enter 0\n");
        }

        private void printCompactMemberInfo(Member member) {
            string formatedOutput = String.Format("{0,-12} {1,12} {2,12}",
            $"Name: {member.Name}", $"Id: {member.MemberId}", $"Boats: {member.NrOfBoats}");
            Console.WriteLine(formatedOutput);
            Console.WriteLine("______________________________________________\n");
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