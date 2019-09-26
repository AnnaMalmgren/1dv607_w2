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
            this._memberList = this.getAllCurrentMembers();
        }


        public Member getMember(string id) 
        {
            
            if (!this._memberList.Exists(member => member.MemberId == id))
            {
                throw new NullReferenceException($"No member with id: {id}");
            }

            return this._memberList.Find(member => member.MemberId == id);
        }

        private List<Member> getAllCurrentMembers() 
        {
            string jsonData = System.IO.File.ReadAllText($"{this._dir}{this._filePath}");
            return JsonConvert.DeserializeObject<List<Member>>(jsonData) ?? new List<Member>();

        }

        public void deleteMember(string id) 
        {
           Member memberToDelete = this.getMember(id);

           this._memberList.Remove(memberToDelete);
           string memberInfo = JsonConvert.SerializeObject(this._memberList);
           File.WriteAllText($"{this._dir}{this._filePath}", memberInfo);	
        }

        public void saveMember(Member newMember)
        {
            this._memberList.Add(newMember);
            string memberInfo = JsonConvert.SerializeObject(this._memberList);
            File.WriteAllText($"{this._dir}{this._filePath}", memberInfo);	
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
                
                string memberInfo = JsonConvert.SerializeObject(this._memberList);
                File.WriteAllText($"{this._dir}{this._filePath}", memberInfo);
        }

        public void addBoat() 
        {
            throw new NotImplementedException();

        }

        public void deleteBoat()
        {
            throw new NotImplementedException();
        }

        public void changeBoat()
        {
            throw new NotImplementedException();
        }
    }
}

