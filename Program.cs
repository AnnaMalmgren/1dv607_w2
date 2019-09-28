using System;
using view;
using controller;
using System.Collections.Generic;

namespace _1dv607_w2
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                ConsoleView view = new ConsoleView();
                ConsoleController controller = new ConsoleController(view);
                controller.mainMenu();
            } catch (Exception e) 
            {
                Console.WriteLine(e);
            }
        }
    }
}
