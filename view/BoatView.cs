using System; 
using model;
using System.Collections.Generic;

namespace view
{
    public class BoatView : MessageView
    {
        public int getChosenBoat(Member member, string message)
        {
            Console.Clear();
            int index;
            // waits for user to enter number for boat.
            do
            {
                this.setBlueText(message);
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

    }
}