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
           Member member = this._registry.getMember(memberId);

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

                    case MemberMenu.RegisterBoat:
                    this.registerBoat(memberId);
                    break;

                    case MemberMenu.DeleteBoat:
                    string deleteMessage = "Enter the nr of the boat you want to delete below.";
                    int deleteId = this._view.getChosenBoat(member, deleteMessage);
                    this._registry.deleteBoat(member, deleteId);
                    break;

                    case MemberMenu.ChangeBoat:
                    string message = "Enter the nr of the boat you want to change at the bottom.";
                    int changeId = this._view.getChosenBoat(member, message);
                    this.changeBoat(member, changeId);
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

            ChangeMember menuchoice = this._view.getChangeMemberChoice();
            switch (menuchoice)
            {
                case ChangeMember.ChangeName:
                member.Name = this._view.getMemberName();
                this._registry.updateMember(member);
                break;

                case ChangeMember.ChangePersonalNr:
                member.PersonalNumber = this._view.getMemberPersonalNr();
                this._registry.updateMember(member);
                break;

            }      
        }

         public void changeBoat(Member member, int boatId)
        {
             Boat boat = member.getBoat(boatId);
             ChangeBoat menuChoice = this._view.getChangeBoatChoice();
            switch (menuChoice)
            {
                case ChangeBoat.ChangeType:
                boat.Type = this._view.getBoatType();
                this._registry.updateBoatList(member, boat);
                break;

                case ChangeBoat.ChangeLength:
                boat.Length = this._view.getBoatLength();
                this._registry.updateBoatList(member, boat);
                break;

            }      
        }

        public void registerBoat(string id)
        {
            Member member = this._registry.getMember(id);
            BoatTypes type = this._view.getBoatType();
            float length = this._view.getBoatLength();
            this._registry.addToBoatList(member, type, length);
        }

    }

}