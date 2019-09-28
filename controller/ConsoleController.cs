using view;
using model;
using System;


namespace controller
{
    public class ConsoleController
    {
        private MemberRegistry _registry;
        private ConsoleView _view;
        private MemberView _memberView;

        public ConsoleController(ConsoleView view, MemberView mView)
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
                this._view.GetKeyPress("\n Press any key to continue"); 
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
                    this._view.GetKeyPress("Member registered, press any key to continue");
                    this.mainMenu();
                    break;

                case MainMenu.CompactList:
                    this.displayCompactList();
                    this.collectMemberEvents(); 
                    break;

                case MainMenu.VerboseList:
                    this.displayVerboseList();
                    this.collectMemberEvents();
                    break;
            }
        }

        private void collectMemberEvents()
        { 
            string memberId = this._memberView.getMemberId();
            if (!String.IsNullOrEmpty(memberId))
            {
                this.memberEvents(memberId);
            } 
        }

        public void memberEvents(string memberId)
        { 
            Member member = this._registry.getMember(memberId);
            this._memberView.displayMember(member);
            MemberMenu choice = this._view.getMemberMenuChoice();

            switch (choice)
            {
                case MemberMenu.GoBack:
                    this.mainMenu();
                    break;

                case MemberMenu.ChangeMember:
                    this.changeMember(member);
                    this.setEventRespone("Member information changed, press any key to continue");
                    break;

                case MemberMenu.DeleteMember:
                    if (this.confirmDelete($"member {memberId}"))
                    {
                        this._registry.deleteMember(memberId);
                        this.setEventRespone("Member deleted, press any key to continue");
                    }
                    this.setEventRespone("Member not deleted, press any key to continue");
                    break;

                case MemberMenu.RegisterBoat:
                    this.registerBoat(memberId);
                    this.setEventRespone("Boat registered, press any key to continue");
                    break;

                case MemberMenu.DeleteBoat:
                    string deleteMsg = "Enter the nr of the boat you want to delete below.";
                    int boatId = this.getBoatId(member, deleteMsg);

                    if (boatId != 0)
                    {  
                        this.getDeleteBoat(member, boatId);
                    }
                    else
                    {
                        this.setEventRespone("Member has no boats, press any key to go back.");
                    }
                    
                    break;

                case MemberMenu.ChangeBoat:
                    string changeMsg = "Enter the nr of the boat you want to change below.";
                    int changeId = this.getBoatId(member, changeMsg);

                    if (changeId != 0)
                    {
                        this.changeBoat(member, changeId);
                        this.setEventRespone("Boat has been changed, press any key to continue");
                    }
                    else
                    {
                        this.setEventRespone("Member has no boats, press any key to go back");
                    }
                    break;
            }
        }

        private void setEventRespone(string msg)
        {
             this._view.GetKeyPress(msg);   
             this.mainMenu();
        }

        private bool confirmDelete(string deleteMsg)
        {
            string confirm = this._view.getDeleteConfirm(deleteMsg);
            return confirm == "y" ? true : false; 
        }

        private void displayCompactList() => this._memberView.showCompactList(this._registry.MemberList);
        
        private void displayVerboseList() => this._memberView.showVerboseList(this._registry.MemberList);

        private void createMember() 
        {
           string name = this._memberView.getMemberName();
           string personalNr = this._memberView.getMemberPersonalNr();
           this._registry.saveMember(name, personalNr);	
        }
        
        private void changeMember(Member member)
        {
            ChangeMember menuChoice = this._memberView.getChangeMemberChoice();
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

        private int getBoatId(Member member, string msg)
        {
            if (member.NrOfBoats != 0)
            {
                int boatId = this._memberView.getChosenBoat(member, msg);
                return boatId;
            }
            else
            {
                return 0;
            }
        }

        private void getDeleteBoat(Member member, int boatId)
        {
            if (this.confirmDelete($"boat {boatId}")) 
            {    
                this._registry.deleteBoat(member, boatId);
                this.setEventRespone("Boat deleted, press any key to continue");
            }
            else
            {
                this.setEventRespone("Boat not deleted, press any key to continue");
            }
        }
            
        private void changeBoat(Member member, int boatId)
        {
            Boat boat = member.getBoat(boatId);
            ChangeBoat menuChoice = this._memberView.getChangeBoatChoice();
            switch (menuChoice)
            {
                case ChangeBoat.ChangeType:
                boat.Type = this._memberView.getBoatType();
                this._registry.updateBoatList(member, boat);
                break;

                case ChangeBoat.ChangeLength:
                boat.Length = this._memberView.getBoatLength();
                this._registry.updateBoatList(member, boat);
                break;
            }      
        }

        private void registerBoat(string id)
        {
            Member member = this._registry.getMember(id);
            BoatTypes type = this._memberView.getBoatType();
            float length = this._memberView.getBoatLength();
            this._registry.addToBoatList(member, type, length);
        }

    }
}