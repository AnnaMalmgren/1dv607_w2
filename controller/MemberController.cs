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
           string memberId = this._view.showCompactList(this._registry.MemberList);
           if (!String.IsNullOrEmpty(memberId))
           {
               MemberMenu menuChoice = this.getSpecificMember(memberId);
               switch (menuChoice)
               {
                   case MemberMenu.ChangeMember:
                    this.changeMember(memberId);
                    break;

                   case MemberMenu.DeleteMember:
                    this._registry.deleteMember(memberId);
                    break;
               }
           }
        }

        public void verboseList()
        {
            this._view.showVerboseList(this._registry.MemberList);
        }
 
        public MemberMenu getSpecificMember(string id) 
        {
            Member member = this._registry.getMember(id);
             return this._view.displayMember(member);
        }

        public void changeMember(string memberId)
        {
            Member member = this._registry.getMember(memberId);

            ChangeMember menuchoice = this._view.menuChangeMember();
            switch (menuchoice)
            {
                case ChangeMember.ChangeName:
                string name = this._view.getMemberName();
                member.updateName(member, name);
                this._registry.updateMember(member);
                break;

                case ChangeMember.ChangePersonalNr:
                string personalNr = this._view.getMemberPersonalNr();
                member.updatePersonalNumber(member, personalNr);
                this._registry.updateMember(member);
                break;

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