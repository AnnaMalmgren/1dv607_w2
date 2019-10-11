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
            if (!this.doesMemberIdExists(id))
            {
                throw new MemberNotFoundException();
            }
            
            return this._memberList.Find(member => member.MemberId == id);
        }

        public void deleteMember(Member member) 
        {
           this._memberList.Remove(member);
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

        public void saveMember(Member member)
        {
            this.uniqueId(member);
            this._memberList.Add(member);
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

        public void updateBoatList(Member member, Boat selectedBoat, float lengthInFeet)
        {
             member.Boats
                .Where(boat => boat.Id == selectedBoat.Id)
                .ToList()
                .ForEach(boat => {
                    boat.LengthInFeet = lengthInFeet;
                });
                
                this._memberDAL.writeToMemberFile(this._memberList);
        }

        public void updateBoatList(Member member, Boat selectedBoat, BoatTypes type)
        {
             member.Boats
                .Where(boat => boat.Id == selectedBoat.Id)
                .ToList()
                .ForEach(boat => {
                    boat.Type = type;
                });
                
                this._memberDAL.writeToMemberFile(this._memberList);
        }
        public void deleteBoat(Member member, Boat boat)
        {
            member.deleteBoat(boat);
            member.updateBoatsId();
            this._memberDAL.writeToMemberFile(this._memberList);
        }
       
    }
}

