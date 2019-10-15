using System;
using view;
using model;

namespace controller
{
    public class ConsoleController
    {
        private MemberRegistry _registry;
        private MenusView _menuView;
        private MemberView _view;

        public ConsoleController(MenusView mView, MemberView view)
        {
            this._view = view;
            this._menuView = mView;
            this._registry = new MemberRegistry();
        }

        public bool mainMenu()
        {
            MainMenu mainEvent = this._menuView.getMainMenuChoice();

            if (mainEvent == MainMenu.Exit) 
            {
                this._registry.saveUpdatedMemberRegistry();
                return false;
            }
           
            if (mainEvent == MainMenu.AddMember)
            {
                this.createMember();
            }
            
            if (mainEvent == MainMenu.CompactList)
            {
                this._view.showCompactList(this._registry.Members);
                this.collectMemberEvents(); 
            }

            if  (mainEvent == MainMenu.VerboseList)
            {
                this._view.showVerboseList(this._registry.Members);
                this.collectMemberEvents();
            }
            return true;    
        }

        private void createMember() 
        {
            try 
            {
                this._registry.registerMember(this._view.getMemberName(), this._view.getMemberPIN());
            }
            catch(ArgumentException)
            {
                this._view.setInvalidInputMsg();
                this.createMember();
            }
        }

        private void collectMemberEvents()
        {
            try 
            {
                int memberId = this._view.getMemberId();
                if (this._view.userWantToGoBack(memberId))
                {
                    return;
                }

                Member member = this._registry.getMember(memberId);
                this._view.displayMember(member);
                while (this.memberMenuEvents(member));
            } 
            catch (ArgumentException)
            {
                this._view.setInvalidInputMsg();
            }  
        }

        private bool memberMenuEvents(Member member)
        { 
            MemberMenu menuEvent = this._menuView.getMemberMenuChoice(member.Boats.Count > 0);

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
                if (this._menuView.getDeleteConfirm())
                {
                    this._registry.deleteMember(member);
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

            this._view.displayMember(member);
            return true;
        }
        
        private void changeMember(Member member)
        {
            ChangeMember menuEvent = this._menuView.getChangeMemberChoice();
            this.handleChangeMemberInfo(member, menuEvent);
        }

        private void handleChangeMemberInfo(Member member, ChangeMember menuEvent)
        {
            try
            { 
                if (menuEvent == ChangeMember.GoBack)
                {
                    return;
                }
                if (menuEvent == ChangeMember.ChangeName) 
                {
                    member.Name = this._view.getMemberName();
                }
                if (menuEvent == ChangeMember.ChangePersonalNr)
                {
                    member.PersonalNumber = this._view.getMemberPIN();
                }
                this._registry.updateMember(member);
             }
            catch (ArgumentException)
            {
                this._view.setInvalidInputMsg();
                this.handleChangeMemberInfo(member, menuEvent);
            }
        }

        private void registerBoat(Member member)
        {
            try
            {
                this._registry.addToBoatList(member, this._view.getBoatType(), this._view.getBoatLength());
            }
            catch (ArgumentException)
            {
                this._view.setInvalidInputMsg();
                this.registerBoat(member);
            }
        }

        private void deleteBoat(Member member)
        {
            Boat selectedBoat = this._view.getChosenBoat(member);
            if (this._menuView.getDeleteConfirm()) 
            {    
                this._registry.deleteBoat(member, selectedBoat);
            }
        }

        private void changeBoat(Member member)
        {
            Boat selectedBoat = this._view.getChosenBoat(member);
            ChangeBoat menuChoice = this._menuView.getChangeBoatChoice();
            this.handleChangeBoat(selectedBoat, menuChoice);
        }
            
        private void handleChangeBoat(Boat boat, ChangeBoat menuChoice)
        {
            if (menuChoice == ChangeBoat.GoBack)
            {
                return;
            }
           
            if (menuChoice == ChangeBoat.ChangeType)
            {
                this._registry.updateBoatList(boat, this._view.getBoatType());
            }

            if (menuChoice == ChangeBoat.ChangeLength)
            {
               this.tryUpdateBoatLength(boat);
            }
        }
        private void tryUpdateBoatLength(Boat boat)
        {
             try
                {
                    string lengthInFeet = this._view.getBoatLength();
                    this._registry.updateBoatList(boat, lengthInFeet);
                }
                catch(ArgumentException)
                {
                    this._view.setInvalidInputMsg();
                    this.tryUpdateBoatLength(boat);
                }
        }
    }
}