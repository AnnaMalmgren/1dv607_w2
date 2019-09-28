using view;
using model;
using System;


namespace controller
{
    public class ConsoleController
    {
        private MemberController _memberController;
        private ConsoleView _view;

        public ConsoleController(ConsoleView view)
        {
            this._view = view;
            this._memberController = new MemberController();
        }

        public void mainMenu()
        {
            MainMenu choice = this._view.getMainMenuChoice();

            switch (choice)
            {
                case MainMenu.AddMember:
                    this._memberController.createMember();
                    this._view.GetKeyPress("Member registered, press any key to continue");
                    this.mainMenu();
                    break;

                case MainMenu.CompactList:
                    this._memberController.compactList();
                    this.collectMemberEvents(); 
                    break;

                case MainMenu.VerboseList:
                    this._memberController.verboseList();
                    this.collectMemberEvents();
                    break;
            }

        }

         public void memberEvents(string memberId)
        { 
            Member member = this._memberController.getSpecificMember(memberId);
            this._memberController.displayMember(member);
            MemberMenu menuChoice = this._view.getMemberMenuChoice();

            switch (menuChoice)
            {
                case MemberMenu.GoBack:
                    this.mainMenu();
                    break;

                case MemberMenu.ChangeMember:
                    this._memberController.changeMember(member);
                    this.setEventRespone(member, "Member information changed, press any key to continue");
                    break;

                case MemberMenu.DeleteMember:
                    if (this.confirmDelete($"member {memberId}"))
                    {
                        this._memberController.deleteMember(memberId);
                        this._view.GetKeyPress("Member deleted, press any key to continue");
                    }
                    this._memberController.displayMember(member);
                    break;

                case MemberMenu.RegisterBoat:
                    this._memberController.registerBoat(memberId);
                    this.setEventRespone(member, "Boat registered, press any key to continue");
                    break;

                case MemberMenu.DeleteBoat:
                    string deleteMsg = "Enter the nr of the boat you want to delete below.";
                    int boatId = this.getBoatId(member, deleteMsg);
                    if (boatId != 0 && this.confirmDelete($"boat {boatId}"))
                    {       
                        this._memberController.deleteBoat(member, boatId);
                        this.setEventRespone(member, "Boat deleted, press any key to continue");
                    }
                    else
                    {
                        this.setEventRespone(member, "Member has no boats, press any key to go back.");
                    }
                    
                    break;

                case MemberMenu.ChangeBoat:
                    string changeMsg = "Enter the nr of the boat you want to change below.";
                    int changeId = this.getBoatId(member, changeMsg);

                    if (changeId != 0)
                    {
                        this._memberController.changeBoat(member, changeId);
                        this._view.GetKeyPress($"Boat has been changed, press any key to continue");
                    }
                    else
                    {
                        this._view.GetKeyPress("Member has no boats, press any key to go back.");
                    }
                     this._memberController.displayMember(member);
                    break;
            }
        }

        private void setEventRespone(Member member, string msg)
        {
             this._view.GetKeyPress(msg);   
             this._memberController.displayMember(member);
        }

        private void collectMemberEvents()
        {
            string memberId = this._memberController.getMemberId();
                if (!String.IsNullOrEmpty(memberId))
                {
                    this.memberEvents(memberId);
                }
        }

        private int getBoatId(Member member, string msg) => this._memberController.checkBoatId(member, msg);

        private bool confirmDelete(string deleteMsg)
        {
            string confirm = this._view.getDeleteConfirm(deleteMsg);
            if (confirm == "y" || confirm == "Y")
            {
                return true;
            } 
            else
            {
                return false;
            } 
        }

        
    }
}