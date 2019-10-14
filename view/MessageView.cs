using System; 

namespace view
{
    public abstract class MessageView
    {
         public void setErrorMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{msg}\n");
            Console.ResetColor();
        }

        public void GetKeyPress(string msg = "\n Press any key to continue")
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

        public void setBoatAddedMsg() 
        {
            this.GetKeyPress("Boat registered, press any key to continue");
        }

        public void setBoatChangedMsg() 
        {
            this.GetKeyPress("Boat has been changed, press any key to continue");
        }

        public void setBoatDeletedMsg() 
        {
            this.GetKeyPress("Boat has been deleted, press any key to continue");
        }

         public void setMemberDeletedMsg() 
        {
            this.GetKeyPress("Member deleted, press any key to continue");
        }

         public void setMemberChangedMsg() 
        {
            this.GetKeyPress("Member information changed, press any key to continue");
        }

         public void setMemberRegisteredMsg() 
        {
            this.GetKeyPress("Member registered, press any key to continue");
        }

        public void invalidPinMsg() 
        {
            this.setErrorMsg("Invalid personal number format (YYMMDDNNNN)");
            this.GetKeyPress();
        }

        public void memberNotFoundMsg()
        {
            this.setErrorMsg("No member with that Id found");
        }

    }
}
