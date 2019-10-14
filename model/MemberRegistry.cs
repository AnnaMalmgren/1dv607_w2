using System;
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

        public Member getMember(int id) 
        {
            if (!this.doesMemberIdExists(id))
            {
                throw new ArgumentException();
            }
            return this._memberList.Find(member => member.MemberId == id);
        }
        private bool doesMemberIdExists(int id) {
            return this._memberList.Exists(member => member.MemberId == id);
        }

        public void deleteMember(Member member) => this._memberList.Remove(member);
        

         public void registerMember(Member member)
        {
            this.setMemberId(member);
            this._memberList.Add(member);
        }

        private void setMemberId(Member member)
        {
            int suggestedId = this._memberList.Count + 1;
            if (this._memberList.Count == 0) {
                 member.MemberId = suggestedId;
            }
            else
            {
                List<int> memberIds = this._memberList.Select(m => m.MemberId).ToList();
                int minNotUsedIds = Enumerable.Range(1, suggestedId).Except(memberIds).Min();;

                int memberId = minNotUsedIds < suggestedId ? 
                    member.MemberId = minNotUsedIds :  member.MemberId = suggestedId;
            }
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
        }

        public void addToBoatList(Member currentMember, BoatTypes type, float length)
        { 
            currentMember.addBoat(type, length); 
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
        

        public void saveMemberRegistry()
        {
            this._memberDAL.writeToMemberFile(this._memberList);
        }
    }
}

