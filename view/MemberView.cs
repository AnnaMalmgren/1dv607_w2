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
            do
            {
                this.setBlueText(">Enter members name: ");
                string name = Console.ReadLine();
                if(!String.IsNullOrEmpty(name))
                {
                    return name;
                }
                this.setErrorMsg("Member name must be entered");
            } while (true);
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

        public int getMemberId()
        {
            do
            {
                this.setBlueText(">Enter members member id: ");
                if (int.TryParse(Console.ReadLine(), out int userId))
                {
                    return userId;
                }
                this.setErrorMsg("Member id must be a number");
            } while(true); 
        }

        public bool userWantToGoBack(int input) => input == 0 ? true : false;

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
                    return member.getBoat(boatId);
                }
                
                this.setErrorMsg($"Error enter a number between 1 and {member.NrOfBoats}");
            } while(true);
        }

        public void displayBoats(IReadOnlyList<Boat> boats)
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
            do 
            {
                this.setBlueText(">Enter boats length in feet: ");
                string userInput = Console.ReadLine();
                if (float.TryParse(userInput, out float length) && length > 0)
                {
                    return length;
                }
                this.setErrorMsg("Boat length must be a positive numeric value");
            } while(true);
        }

        public BoatTypes getBoatType() 
        {
            Console.Clear();
            int nrOfBoatTypes = Enum.GetNames(typeof(BoatTypes)).Length;
            do
            {
                this.displayBoatTypesMenu(); 
               
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 1
                    && index <= nrOfBoatTypes)
                {
                    return (BoatTypes)index;
                }

                this.setErrorMsg($"Enter number 1 or {nrOfBoatTypes}");
                this.GetKeyPress();
            } while (true);
        }

        private void displayBoatTypesMenu() 
        {
           
            Console.WriteLine("\n - Boat types --------------------------------\n");
            this.displayBoatTypes();
            Console.WriteLine("\n ══════════════════════════════════════════\n");
            this.setBlueText("Enter menu selection nr: ");
        }

        private void displayBoatTypes()
        {
             int currentNr  = 1;
             foreach (string boatType in Enum.GetNames(typeof(BoatTypes)))
            {
                Console.WriteLine($"{currentNr}. {boatType}");
                currentNr++;
            }

        }

        public void showCompactList(IReadOnlyList<Member> members)
        {
            this.displayMemberListHeader();

            foreach(Member member in members)
            {
                this.printCompactMemberInfo(member);
            }
        }

          private void displayMemberListHeader()
        {
            Console.Clear();
            this.setBlueText("To Look at a specific member enter the member id below\n");
            this.setBlueText("To go back to main menu enter number 0 and press enter\n");
            Console.WriteLine("\n═══════════════════ Members ════════════════════════\n");
        }
        
        private void printCompactMemberInfo(Member member) {
            string formatedOutput = String.Format("{0,-12} {1,12} {2,12}",
            $"Name: {member.Name}", $"Id: {member.MemberId}", $"Boats: {member.NrOfBoats}");
            Console.WriteLine(formatedOutput);
            Console.WriteLine("______________________________________________\n");
        }

        public void showVerboseList(IReadOnlyList<Member> members)
        {
            this.displayMemberListHeader();

            foreach(Member member in members)
            {
                this.verboseMemberInfo(member);
            }
        }
    }
}