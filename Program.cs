﻿using System;
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
            MemberController controller = new MemberController(view);

            MainMenu choice = view.getMainMenuChoice();

            switch (choice)
            {
                case MainMenu.AddMember:
                controller.createMember();
                break;
                case MainMenu.CompactList:
                controller.compactList();
                break;
                case MainMenu.VerboseList:
                controller.verboseList();
                break;

            }
            } catch (Exception e) 
            {
                Console.WriteLine(e);
            }
        }
    }
}
