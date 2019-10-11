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

        public bool mainMenu()
        {
            MainMenu mainEvent = this._view.getMainMenuChoice();

            if (mainEvent == MainMenu.Exit) 
            {
                return false;
            }
           
            if (mainEvent == MainMenu.AddMember)
            {
                this.createMember();
            }
            
            if (mainEvent == MainMenu.CompactList)
            {
                this._memberView.showCompactList(this._registry.MemberList);
                this.collectMemberEvents(); 
            }

            if  (mainEvent == MainMenu.VerboseList)
            {
                this._memberView.showVerboseList(this._registry.MemberList);
                this.collectMemberEvents();
            }

            return true;
                
        }

        private void createMember() 
        {
            try 
            {
                Member memberCredentials = this._memberView.getMemberCredentials();
                this._registry.saveMember(memberCredentials);
                this._view.setMemberRegisteredMsg();
            }
            catch(ArgumentNullException)
            {
                this.handleInvalidCredentials();
            }
            catch(PinFormatException)
            {
                this.handleInvalidCredentials();
            }
        }

        private void handleInvalidCredentials() 
        {
            this._view.setErrorMsg("Wrong info in credentials");
            this._view.GetKeyPress();
            this.createMember();
        }

        private void collectMemberEvents()
        {
            try 
            {
                string memberId = this._memberView.getMemberId();
                Member member = this._registry.getMember(memberId);
                while (this.memberMenuEvents(member, this._view.getMemberMenuChoice()));
            } 
            catch (MemberNotFoundException)
            {
                this._memberView.setErrorMsg("Member not found");
                this._memberView.GetKeyPress();
            }  
        }

        private bool memberMenuEvents(Member member, MemberMenu choice)
        { 
            this._memberView.displayMember(member);

            if (choice == MemberMenu.GoBack) 
            {
                 return false;
            }

            if (choice == MemberMenu.ChangeMember)
            {
                this.changeMember(member);
            }

            if (choice == MemberMenu.DeleteMember)
            {
                this.deleteMember(member);
            }

            if (choice == MemberMenu.RegisterBoat)
            {
                this.registerBoat(member);
            }

            if (choice == MemberMenu.DeleteBoat)
            {
                this.doDeleteBoat(member);
            }

            if (choice == MemberMenu.ChangeBoat)
            {
                this.doChangeBoat(member);
            }

            return true;
        }
        
        private void deleteMember(Member member)
        {
            if (this._view.getDeleteConfirm())
            {
                this._registry.deleteMember(member);
                this._view.setMemberDeletedMsg();
            }
        }
        private void changeMember(Member member)
        {
            ChangeMember menuChoice = this._view.getChangeMemberChoice();

            if (menuChoice == ChangeMember.ChangeName) 
            {
                member.Name = this._memberView.getMemberName();
            }
            
            if (menuChoice == ChangeMember.ChangePersonalNr)
            {
                 member.PersonalNumber = this._memberView.getMemberPersonalNr();
            }
                this._registry.updateMember(member);
                this._view.setMemberChangedMsg(); 
        }

        private void registerBoat(Member member)
        {
            BoatTypes type = this._memberView.getBoatType();
            float length = this._memberView.getBoatLength();
            this._registry.addToBoatList(member, type, length);
            this._view.setBoatAddedMsg();
        }


        private void doDeleteBoat(Member member)
        {
            if (member.Boats.Count > 0)
            {
                Boat selectedBoat = this._memberView.getChosenBoat(member);
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
            if (member.Boats.Count > 0)
            {
                Boat selectedBoat = this._memberView.getChosenBoat(member);
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
                float lengthInFeet = this._memberView.getBoatLength();
                this._registry.updateBoatList(member, boat, lengthInFeet);
                break;
            }      
        }
    
    }
}