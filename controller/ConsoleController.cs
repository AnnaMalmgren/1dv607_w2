using System;
using view;
using model;

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
                this._registry.saveMemberRegistry();
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
                this._registry.registerMember(this._memberView.getMemberCredentials());
                this._view.setMemberRegisteredMsg();
            }
            catch(ArgumentException)
            {
                this._view.invalidPinMsg();
                this.createMember();
            }
        }

        private void collectMemberEvents()
        {
            try 
            {
                int memberId = this._memberView.getMemberId();
                if (this._memberView.userWantToGoBack(memberId))
                {
                    return;
                }
                Member member = this._registry.getMember(memberId);
                this._memberView.displayMember(member);
                while (this.memberMenuEvents(member, this._view.getMemberMenuChoice(member.Boats.Count > 0)));
                
            } 
            catch (ArgumentException)
            {
                this._view.memberNotFoundMsg();
            }  
        }

        private bool memberMenuEvents(Member member, MemberMenu menuEvent)
        { 
            if (menuEvent == MemberMenu.GoBack) 
            {
                 return false;
            }

            if (menuEvent == MemberMenu.ChangeMember)
            {
                this.changeMember(member);
            }

            if (menuEvent == MemberMenu.DeleteMember)
            {
                if (this._view.getDeleteConfirm())
                {
                    this._registry.deleteMember(member);
                    this._view.setMemberDeletedMsg();
                    return false;
                }
            }

            if (menuEvent == MemberMenu.RegisterBoat)
            {
                this.registerBoat(member);
            }

            if (menuEvent == MemberMenu.DeleteBoat)
            {
                this.deleteBoat(member);
            }

            if (menuEvent == MemberMenu.ChangeBoat)
            {
                this.changeBoat(member);
            }
            this._memberView.displayMember(member);
            return true;
        }
        
        private void changeMember(Member member)
        {
            ChangeMember menuEvent = this._view.getChangeMemberChoice();
            if (menuEvent == ChangeMember.GoBack)
            {
                return;
            }
            this.handleChangeMemberInfo(member, menuEvent);
            this._registry.updateMember(member);
            this._view.setMemberChangedMsg();
        }

        private void handleChangeMemberInfo(Member member, ChangeMember menuEvent)
        {
            try
            { 
                if (menuEvent == ChangeMember.ChangeName) 
                {
                    member.Name = this._memberView.getMemberName();
                }
                if (menuEvent == ChangeMember.ChangePersonalNr)
                {
                    member.PersonalNumber = this._memberView.getMemberPersonalNr();
                }
             }
            catch (ArgumentException)
            {
                this._view.invalidPinMsg();
                this.handleChangeMemberInfo(member, menuEvent);
            }
        }

        private void registerBoat(Member member)
        {
            BoatTypes type = this._memberView.getBoatType();
            float length = this._memberView.getBoatLength();
            this._registry.addToBoatList(member, type, length);
            this._view.setBoatAddedMsg();
        }

        private void deleteBoat(Member member)
        {
            Boat selectedBoat = this._memberView.getChosenBoat(member);
            if (this._view.getDeleteConfirm()) 
            {    
                this._registry.deleteBoat(member, selectedBoat);
                this._view.setBoatDeletedMsg();
            }
        }

        private void changeBoat(Member member)
        {
            Boat selectedBoat = this._memberView.getChosenBoat(member);
            this.handleChangeBoat(selectedBoat);
        }
            
        private void handleChangeBoat(Boat boat)
        {
            ChangeBoat menuChoice = this._view.getChangeBoatChoice();

            if (menuChoice == ChangeBoat.GoBack)
            {
                return;
            }

            if (menuChoice == ChangeBoat.ChangeType)
            {
                BoatTypes type = this._memberView.getBoatType();
                this._registry.updateBoatList(boat, type);
            }

            if (menuChoice == ChangeBoat.ChangeLength)
            {
                float lengthInFeet = this._memberView.getBoatLength();
                this._registry.updateBoatList(boat, lengthInFeet);
            }

            this._view.setBoatChangedMsg();
        }
    }
}