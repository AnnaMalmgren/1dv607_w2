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
                    this.setEventRespone("Member registered, press any key to continue");
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
                if (memberId == "0")
                {
                    this.mainMenu();
                }
                else
                {
                    this.Events(memberId);
                }
            } 
        }

        public void Events(string memberId)
        { 
            if (!this._registry.validateMemberId(memberId))
            {
                this._view.setErrorMsg("Member id does not exist");
                this._view.GetKeyPress("\n Press any key to continue"); 
                this.mainMenu();
            }
            else
            {
                Member member = this._registry.getMember(memberId);
                this._memberView.displayMember(member);
                MemberMenu choice = this._view.getMemberMenuChoice();
                this.memberMenuEvents(member, choice);
            }      
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
                    this.setEventRespone("Member information changed, press any key to continue");
                    break;

                case MemberMenu.DeleteMember:
                    if (this.confirmDelete($"member {member.MemberId}"))
                    {
                        this._registry.deleteMember(member.MemberId);
                        this.setEventRespone("Member deleted, press any key to continue");
                    }
                    this.setEventRespone("Member not deleted, press any key to continue");
                    break;

                 case MemberMenu.RegisterBoat:
                    this.registerBoat(member.MemberId);
                    this.setEventRespone("Boat registered, press any key to continue");
                    break;

                case MemberMenu.DeleteBoat:
                    this.doDeleteBoat(member);
                    break;

                case MemberMenu.ChangeBoat:
                    this.doChangeBoat(member);
                    break;
            }
        }

        private void setEventRespone(string msg)
        {
             this._view.GetKeyPress(msg);   
             this.mainMenu();
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

        private void registerBoat(string id)
        {
            Member member = this._registry.getMember(id);
            BoatTypes type = this._memberView.getBoatType();
            float length = this._memberView.getBoatLength();
            this._registry.addToBoatList(member, type, length);
        }


        private void doDeleteBoat(Member member)
        {
            string deleteMsg = "Enter the nr of the boat you want to delete below\n";
            int boatId = this.getBoatId(member, deleteMsg);

            if (boatId != 0)
            {  
                this.handleDeleteBoat(member, boatId);
            }
            else
            {
                this.setEventRespone("Member has no boats, press any key to go back.");
            }
        }

        private void handleDeleteBoat(Member member, int boatId)
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

        private void doChangeBoat(Member member)
        {
            string changeMsg = "Enter the nr of the boat you want to change below\n";
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
        }
            
        private void changeBoat(Member member, int boatId)
        {
            
            ChangeBoat menuChoice = this._memberView.getChangeBoatChoice();
            switch (menuChoice)
            {
                case ChangeBoat.ChangeType:
                BoatTypes type = this._memberView.getBoatType();
                this._registry.updateBoatList(member, boatId, type);
                break;

                case ChangeBoat.ChangeLength:
                float length = this._memberView.getBoatLength();
                this._registry.updateBoatList(member, boatId, length);
                break;
            }      
        }
        
        private bool confirmDelete(string deleteMsg)
        {
            string confirm = this._view.getDeleteConfirm(deleteMsg);
            return confirm == "y" ? true : false; 
        }
    }
}