
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
                ConsoleController controller = new ConsoleController(view, mView);
                controller.startApp();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);

            }
         
        }
    }
}
