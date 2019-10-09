using System.Linq;
using System.Collections.Generic;

namespace model
{
    public class MemberRegistry {
        
        private List<Member> _memberList = new List<Member>();

        private BoatClubDAL _memberDAL;

        public IReadOnlyList<Member> MemberList => this._memberList.AsReadOnly();
  

        public MemberRegistry()
        {
            this._memberDAL = new BoatClubDAL();
            this._memberList = this._memberDAL.readMemberFile();
        }
  

        public bool doesMemberIdExists(string id) {
            return this._memberList.Exists(member => member.MemberId == id);
        }

        public Member getMember(string id) 
        {     
            return this._memberList.Find(member => member.MemberId == id);
        }

        public void deleteMember(string id) 
        {
           Member memberToDelete = this.getMember(id);

           this._memberList.Remove(memberToDelete);
           this._memberDAL.writeToMemberFile(this._memberList);	
        }

        private string uniqueId(Member newMember)
        {
            do 
            {
                newMember.generateId();
                if(!this.doesMemberIdExists(newMember.MemberId)) {
                    return newMember.MemberId;
                }
            } while (true);
        } 

        public void saveMember(string name, string personalNr)
        {
            Member newMember = new Member(name, personalNr);
            this.uniqueId(newMember);
            this._memberList.Add(newMember);
            this._memberDAL.writeToMemberFile(this._memberList);	
        }

        public void updateMember(Member updatedMember)
        {
            this._memberList 
                .Where(member => member.MemberId == updatedMember.MemberId)
                .ToList()
                .ForEach(member => {
                    member.Name = updatedMember.Name;
                    member.PersonalNumber = updatedMember.PersonalNumber;
                });
                
                 this._memberDAL.writeToMemberFile(this._memberList);
        }

        public void addToBoatList(Member currentMember, BoatTypes type, float length)
        {
            
            currentMember.addBoat(type, length); 
            this._memberDAL.writeToMemberFile(this._memberList);
        }

        public void updateBoatList(Member member, int boatId, float lengthInFeet)
        {
             member.Boats
                .Where(boat => boat.Id == boatId)
                .ToList()
                .ForEach(boat => {
                    boat.LengthInFeet = lengthInFeet;
                });
                
                this._memberDAL.writeToMemberFile(this._memberList);
        }

        public void updateBoatList(Member member, int boatId, BoatTypes type)
        {
             member.Boats
                .Where(boat => boat.Id == boatId)
                .ToList()
                .ForEach(boat => {
                    boat.Type = type;
                });
                
                this._memberDAL.writeToMemberFile(this._memberList);
        }
        public void deleteBoat(Member member, int boatId)
        {
            Boat boat = member.getBoat(boatId);
            member.deleteBoat(boat);
            member.updateBoatsId();
            this._memberDAL.writeToMemberFile(this._memberList);
        }
       
    }
}

