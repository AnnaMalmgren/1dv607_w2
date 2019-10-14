
using view;
using controller;
using System;


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
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
         
        }
    }
}
