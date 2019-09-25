using System;
using view;
using model;


namespace controller
{
    public class MemberController
    {
        private ConsoleView _view;

        private MemberRegistry _registry;
        public MemberController(ConsoleView view)
        {
            this._view = view;
            this._registry = new MemberRegistry();
        }

        public void createMember() 
        {
           string name = this._view.getMemberName();
           string personalNr = this._view.getMemberPersonalNr();
           Member newMember = new Member(name, personalNr);
           this._registry.saveMember(newMember);	
        }

        public void compactList()
        {
           string memberId = this._view.showCompactList(this._registry.getMemberList());
           if (!String.IsNullOrEmpty(memberId))
           {
               MemberMenu menuChoice = this.getSpecificMember(memberId);
               switch (menuChoice)
               {
                   case MemberMenu.ChangeMember:

                   case MemberMenu.DeleteMember:
                    this._registry.deleteMember(memberId);
                   break;
               }
           }
        }

        public void verboseList()
        {
            this._view.showVerboseList(this._registry.getMemberList());
        }
 
        public MemberMenu getSpecificMember(string id) 
        {
            Member member = this._registry.getMember(id);
             return this._view.displayMember(member);
        }

        public void changeMember(string memberId)
        {
            Member member = this._registry.getMember(memberId);

            int menuchoice = this._view.menuChangeMember();
            if (menuchoice == 1) 
            {
                string name = this._view.getMemberName();
                member.updateName(member, name);
                this._registry.saveMember(member);
            } 
            else if (menuchoice == 2)
            {
                string personalNr = this._view.getMemberPersonalNr();
                member.updateName(member, personalNr);
                this._registry.updateMember(member);
            }

        }


        public void registerBoat()
        {
            string id = this._view.getMemberId();
            Member member = this._registry.getMember(id);
            string type = this._view.getBoatType();
            float length = this._view.getBoatLength();
            Boat newBoat = new Boat(type, length);
            member.addBoat(newBoat);
            
        }

    }

}