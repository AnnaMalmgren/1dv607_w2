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

        public void setBlueText(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(msg); 
            Console.ResetColor();
        }

        public void setInvalidInputMsg()
        {
            this.setErrorMsg("Invalid input, please try again. Press any key to continue");
            Console.ReadKey();
        }
    }
}
