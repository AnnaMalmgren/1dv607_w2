
using view;
using controller;


namespace _1dv607_w2
{
    class Program
    {
        static void Main(string[] args)
        {

            ConsoleView cView = new ConsoleView();
            MemberView mView = new MemberView();
            ConsoleController controller = new ConsoleController(cView, mView);
                
            controller.startApp();
         
        }
    }
}
