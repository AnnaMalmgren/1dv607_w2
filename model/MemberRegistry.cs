using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace model
{
    public class MemberRegistry {
        private string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "members.json");
        
        private List<Member> _memberList = new List<Member>();

        public IReadOnlyList<Member> MemberList => this._memberList.AsReadOnly();
  

        public MemberRegistry()
        {
            this.CreateEmptyFile();
            this._memberList = this.readMemberFile();
        }

        public void CreateEmptyFile()
        {
            if (!File.Exists(this._filePath))
            {
                File.Create(this._filePath).Dispose();
            }
        }

        public List<Member> readMemberFile()
        {
            string jsonData = System.IO.File.ReadAllText(this._filePath);
            return JsonConvert.DeserializeObject<List<Member>>(jsonData) ?? new List<Member>();
        }

        private void writeToMemberFile() {
            string memberInfo = JsonConvert.SerializeObject(this._memberList);
            File.WriteAllText(this._filePath, memberInfo);	
        }
  
        public bool validateMemberId(string id)
        {
            if (!this._memberList.Exists(member => member.MemberId == id))
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public Member getMember(string id) 
        {     
            return this._memberList.Find(member => member.MemberId == id);
        }

        public void deleteMember(string id) 
        {
           Member memberToDelete = this.getMember(id);

           this._memberList.Remove(memberToDelete);
           this.writeToMemberFile();	
        }

        private string uniqueId(Member newMember)
        {
            do 
            {
                newMember.generateId();
                if(!this._memberList.Exists(member => member.MemberId == newMember.MemberId)) {
                    return newMember.MemberId;
                }
            } while (true);
        } 

        public void saveMember(string name, string personalNr)
        {
            Member newMember = new Member(name, personalNr);
            this.uniqueId(newMember);
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

        public void updateBoatList(Member member, int boatId, float length)
        {
             member.Boats
                .Where(boat => boat.Id == boatId)
                .ToList()
                .ForEach(boat => {
                    boat.Length = length;
                });
                
                this.writeToMemberFile();
        }

        public void updateBoatList(Member member, int boatId, BoatTypes type)
        {
             member.Boats
                .Where(boat => boat.Id == boatId)
                .ToList()
                .ForEach(boat => {
                    boat.Type = type;
                });
                
                this.writeToMemberFile();
        }
        public void deleteBoat(Member member, int boatId)
        {
            Boat boat = member.getBoat(boatId);
            member.deleteBoat(boat);
            member.updateBoatsId();
            this.writeToMemberFile();
        }
       
    }
}

