using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace model
{
    public class MemberRegistry {
        private string _dir = Directory.GetCurrentDirectory();
        private string _filePath ="\\Data\\members.json";
        private List<Member> _memberList = new List<Member>();

         public IReadOnlyList<Member> MemberList => this._memberList.AsReadOnly();
         

        public MemberRegistry()
        {
            this._memberList = this.readMemberFile();
        }

        public List<Member> readMemberFile()
        {
            string jsonData = System.IO.File.ReadAllText($"{this._dir}{this._filePath}");
            return JsonConvert.DeserializeObject<List<Member>>(jsonData) ?? new List<Member>();
        }

        private void writeToMemberFile() {
            string memberInfo = JsonConvert.SerializeObject(this._memberList);
            File.WriteAllText($"{this._dir}{this._filePath}", memberInfo);	
        }


        public Member getMember(string id) 
        {
            
            if (!this._memberList.Exists(member => member.MemberId == id))
            {
                throw new NullReferenceException($"No member with id: {id}");
            }

            return this._memberList.Find(member => member.MemberId == id);
        }

        public void deleteMember(string id) 
        {
           Member memberToDelete = this.getMember(id);

           this._memberList.Remove(memberToDelete);
           this.writeToMemberFile();	
        }

        public void saveMember(Member newMember)
        {
            this._memberList.Add(newMember);
            this.writeToMemberFile();	
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
                
                this.writeToMemberFile();
        }

        public void addToBoatList(Member currentMember, BoatTypes type, float length)
        {
             this._memberList 
                .Where(member => member.MemberId == currentMember.MemberId)
                .ToList()
                .ForEach(member => {
                    member.addBoat(type, length);
                });
                
                this.writeToMemberFile();
        }

        public void updateBoatList(Member currentMember, Boat updatedBoat)
        {
             currentMember.Boats
                .Where(boat => boat.Id == updatedBoat.Id)
                .ToList()
                .ForEach(boat => {
                    boat = updatedBoat;
                });
                
                this.writeToMemberFile();
        }
        public void deleteBoat(Member member, int boatId)
        {
            Boat boat = member.getBoat(boatId);
            member.deleteBoat(boat);
            this.writeToMemberFile();
        }
    }
}

