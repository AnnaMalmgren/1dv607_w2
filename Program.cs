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
            ConsoleView view = new ConsoleView();
            MemberController controller = new MemberController(view);

            MenuChoice choice = view.showMenu();

            if (choice == MenuChoice.AddMember) 
            {
                controller.createMember();

            }

        }
    }
}
