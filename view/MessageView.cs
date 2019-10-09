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

        public void GetKeyPress(string msg)
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
    }
}
