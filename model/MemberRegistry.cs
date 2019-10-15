using System;
using System.Linq;
using System.Collections.Generic;

namespace model
{
    public class MemberRegistry {
        
        private List<Member> _members = new List<Member>();

        private BoatClubDAL _memberDAL;

        public IReadOnlyList<Member> Members => this._members.AsReadOnly();
  
        public MemberRegistry()
        {
            this._memberDAL = new BoatClubDAL();
            this._members = this._memberDAL.readMemberFile();
        }

        public Member getMember(int id) 
        {
            if (!this.doesMemberIdExists(id))
            {
                throw new ArgumentException();
            }

            return this._members.Find(member => member.MemberId == id);
        }
        private bool doesMemberIdExists(int id) {
            return this._members.Exists(member => member.MemberId == id);
        }

        public void deleteMember(Member member) => this._members.Remove(member);

        public void registerMember(string name, string pin)
        {
            int id = this.getMinMemberId();
            Member member = new Member(name, pin, id);
            this._members.Add(member);
        }

        private int getMinMemberId()
        {
            int suggestedId = this._members.Count + 1;

            if (this._members.Count == 0) {
                return suggestedId;
            }

            List<int> memberIds = this._members.Select(m => m.MemberId).ToList();
                int minNotUsedId = Enumerable.Range(1, suggestedId).Except(memberIds).Min();

            return minNotUsedId < suggestedId ? minNotUsedId : suggestedId;
        }

        public void updateMember(Member updatedMember)
        {
            this._members 
                .Where(member => member.MemberId == updatedMember.MemberId)
                .ToList()
                .ForEach(member => {
                    member.Name = updatedMember.Name;
                    member.PersonalNumber = updatedMember.PersonalNumber;
                });
        }

        public void addToBoatList(Member member, BoatTypes type, string length)
        {
            int boatId = member.Boats.Count + 1; 
            member.Boats.Add(new Boat(type, length, boatId)); 
        }

        public void updateBoatList(Boat selectedBoat, string lengthInFeet)
        {
            selectedBoat.LengthInFeet = lengthInFeet;
        }

        public void updateBoatList(Boat selectedBoat, BoatTypes type)
        {
            selectedBoat.Type = type;
        }

        public void deleteBoat(Member member, Boat boat) => member.deleteBoat(boat);
        
        public void saveUpdatedMemberRegistry()
        {
            this._memberDAL.writeToMemberFile(this._members);
        }
    }
}

