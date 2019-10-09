using view;
using model;
using System;


namespace controller
{
    public class ConsoleController
    {
        private MemberRegistry _registry;
        private MenusView _view;
        private MemberView _memberView;

        public ConsoleController(MenusView view, MemberView mView)
        {
            this._view = view;
            this._memberView = mView;
            this._registry = new MemberRegistry();
        }

        public void startApp()
        {
            try
            {
                this.mainMenu();
            }
            catch(Exception e)
            {
                this._view.setErrorMsg(e.Message);
                this._view.GetKeyPress(); 
                this.mainMenu();
            }
        }
        
        public void mainMenu()
        {
            MainMenu choice = this._view.getMainMenuChoice();
            switch (choice)
            {
                case MainMenu.AddMember:
                    this.createMember();
                    break;

                case MainMenu.CompactList:
                    this._memberView.showCompactList(this._registry.MemberList);
                    this.collectMemberEvents(); 
                    break;

                case MainMenu.VerboseList:
                    this._memberView.showVerboseList(this._registry.MemberList);
                    this.collectMemberEvents();
                    break;
            }
        }

        private void collectMemberEvents()
        { 
            string memberId = this._memberView.getMemberId();

            if (this._registry.doesMemberIdExists(memberId))
            {
                Member member = this._registry.getMember(memberId);
                this.setMemberMenuChoice(member);
            }

             else
            {
                this._view.setErrorMsg("Member id does not exist");
                this._view.GetKeyPress(); 
                this.mainMenu();
            }      
        }

        public void setMemberMenuChoice(Member member)
        { 
            this._memberView.displayMember(member);
            MemberMenu choice = this._view.getMemberMenuChoice();
            this.memberMenuEvents(member, choice); 
        }

        private void memberMenuEvents(Member member, MemberMenu choice)
        { 
            switch (choice)
            {
                case MemberMenu.GoBack:
                    this.mainMenu();
                    break;

                case MemberMenu.ChangeMember:
                    this.changeMember(member);
                    this._view.setMemberChangedMsg();
                    break;

                case MemberMenu.DeleteMember:
                    if (this._view.getDeleteConfirm())
                    {
                        this._registry.deleteMember(member.MemberId);
                        this._view.setMemberDeletedMsg();
                    }
                    break;

                 case MemberMenu.RegisterBoat:
                    this.registerBoat(member.MemberId);
                    break;

                case MemberMenu.DeleteBoat:
                    this.doDeleteBoat(member);
                    break;

                case MemberMenu.ChangeBoat:
                    this.doChangeBoat(member);
                    break;
            }
        }

        private void createMember() 
        {
           string name = this._memberView.getMemberName();
           string personalNr = this._memberView.getMemberPersonalNr();
           this._registry.saveMember(name, personalNr);
           this._view.setMemberRegisteredMsg();
        }
        
        private void changeMember(Member member)
        {
            ChangeMember menuChoice = this._view.getChangeMemberChoice();
            switch (menuChoice)
            {
                case ChangeMember.ChangeName:
                member.Name = this._memberView.getMemberName();
                this._registry.updateMember(member);
                break;

                case ChangeMember.ChangePersonalNr:
                member.PersonalNumber = this._memberView.getMemberPersonalNr();
                this._registry.updateMember(member);
                break;
            }   
        }

        private void registerBoat(string id)
        {
            Member member = this._registry.getMember(id);
            BoatTypes type = this._memberView.getBoatType();
            float length = this._memberView.getBoatLength();
            this._registry.addToBoatList(member, type, length);
            this._view.setBoatAddedMsg();
        }


        private void doDeleteBoat(Member member)
        {
            Boat selectedBoat = this._memberView.getChosenBoat(member);
            if (!member.HasNoBoats)
            {  
                this.handleDeleteBoat(member, selectedBoat);
            }
            else
            {
                this._view.setNoBoatsMsg();
            }
        }

        private void handleDeleteBoat(Member member, Boat boat)
        {
            if (this._view.getDeleteConfirm()) 
            {    
                this._registry.deleteBoat(member, boat);
                this._view.setBoatDeletedMsg();
            }

        }

        private void doChangeBoat(Member member)
        {
            Boat selectedBoat = this._memberView.getChosenBoat(member);

            if (!member.HasNoBoats)
            {
                this.changeBoat(member, selectedBoat);
                this._view.setBoatChangedMsg();
            }
            else
            {
                this._view.setNoBoatsMsg();
            }
        }
            
        private void changeBoat(Member member, Boat boat)
        {
            
            ChangeBoat menuChoice = this._view.getChangeBoatChoice();
            switch (menuChoice)
            {
                case ChangeBoat.ChangeType:
                BoatTypes type = this._memberView.getBoatType();
                this._registry.updateBoatList(member, boat, type);
                break;

                case ChangeBoat.ChangeLength:
                float length = this._memberView.getBoatLength();
                this._registry.updateBoatList(member, boat, length);
                break;
            }      
        }
    
    }
}