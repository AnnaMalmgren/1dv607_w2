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

        public void registerMember(Member member)
        {
            this.setMemberId(member);
            this._members.Add(member);
        }

        private void setMemberId(Member member)
        {
            int suggestedId = this._members.Count + 1;
            if (this._members.Count == 0) {
                 member.setMemberId(suggestedId);
            }
            else
            {
               this.getMinMemberId(suggestedId, member);
            }
        }

        private void getMinMemberId(int suggestedId, Member member)
        {
            List<int> memberIds = this._members.Select(m => m.MemberId).ToList();
                int minNotUsedId = Enumerable.Range(1, suggestedId).Except(memberIds).Min();

            if (minNotUsedId < suggestedId)
            {
                member.setMemberId(minNotUsedId);
            }
            else
            {
                member.setMemberId(suggestedId);
            }
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

        public void addToBoatList(Member member, BoatTypes type, float length)
        { 
            member.addBoat(type, length); 
        }

        public void updateBoatList(Boat selectedBoat, float lengthInFeet)
        {
            selectedBoat.changeBoat(lengthInFeet);
        }

        public void updateBoatList(Boat selectedBoat, BoatTypes type)
        {
            selectedBoat.changeBoat(type);
        }

        public void deleteBoat(Member member, Boat boat) => member.deleteBoat(boat);
        
        public void saveUpdatedMemberRegistry()
        {
            this._memberDAL.writeToMemberFile(this._members);
        }
    }
}

