
using view;
using model;


namespace controller
{
    public class MemberController
    {
        private MemberView _view;

        private MemberRegistry _registry;
        public MemberController()
        {
            this._view = new MemberView();
            this._registry = new MemberRegistry();
        }

        public void createMember() 
        {
           string name = this._view.getMemberName();
           string personalNr = this._view.getMemberPersonalNr();
           Member newMember = new Member(name, personalNr);
           this._registry.saveMember(newMember);	
        }

       

        public void compactList() => this._view.showCompactList(this._registry.MemberList);
           
        
        public void verboseList() => this._view.showVerboseList(this._registry.MemberList);
    
        

        public Member getSpecificMember(string id)  => this._registry.getMember(id);

        public string getMemberId() => this._view.getMemberId();
        

        public void changeMember(Member member)
        {
           
            ChangeMember menuChoice = this._view.getChangeMemberChoice();
            switch (menuChoice)
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

        public void displayMember(Member member) => this._view.displayMember(member);

        public void deleteMember(string memberId) => this._registry.deleteMember(memberId);

        public int checkBoatId(Member member, string msg)
        {
            if (member.NrOfBoats != 0)
            {
                int boatId = this._view.getChosenBoat(member, msg);
                return boatId;
            }
            else
            {
                return 0;
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

        public void deleteBoat(Member member, int boatId) => this._registry.deleteBoat(member, boatId);
            
    }

}