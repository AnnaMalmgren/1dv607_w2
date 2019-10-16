using System;
using view;
using controller;


namespace _1dv607_w2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MenusView view = new MenusView();
                MemberView mView = new MemberView();
                ConsoleController app = new ConsoleController(view, mView);
                
                while(app.mainMenu());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
     
        }
    }
}
