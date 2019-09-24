using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace model
{
    public class Member {
        private static string _dir = Directory.GetCurrentDirectory();
        private string _filePath =$"{_dir}\\Data\\members.json";
        private string _name;
        private string _personalNumber;
        private Guid _memberId;

        public string Name
        {
            get => this._name;
        }

        public string PersonalNumber
        {
            get => this._personalNumber;
        }

        public Guid MemberId
        {
            get => this._memberId;
        }

        public Member(string name, string personalNumber) {
            this._name = name; 
            this._personalNumber = personalNumber;
            this._memberId = Guid.NewGuid();
        }

        public List<Member> getMembers() {
            string jsonData = System.IO.File.ReadAllText(this._filePath);
            List<Member> memberList = JsonConvert.DeserializeObject<List<Member>>(jsonData) ?? new List<Member>();
            return memberList;
        }

        public List<Member> addMember(Member member) {
            List<Member> memberList = this.getMembers();
            memberList.Add(member);
            return memberList;
        }

        public void saveMember(Member member)
        {
            List<Member> memberList = member.addMember(member);
            string memberInfo = JsonConvert.SerializeObject(memberList);
            File.WriteAllText(this._filePath, memberInfo);	
        }
    }
}