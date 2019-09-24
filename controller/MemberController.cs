using System;
using System.Collections.Generic;
using view;
using model;


namespace controller
{
    public class MemberController
    {
        private ConsoleView view;
        public MemberController(ConsoleView view)
        {
            this.view = view;
        }

        public void createMember() 
        {
           Member member = view.getMemberInfo();
           member.saveMember(member);	
        }

        public void compactList()
        {
            throw new NotImplementedException();
        }

        public void verboseList()
        {
            throw new NotImplementedException();
        }

    }

}