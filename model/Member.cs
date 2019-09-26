using System;
using System.Collections.Generic;

namespace model
{
    public class Member {
        private string _name;
        private string _personalNumber;

        private List<Boat> _boats = new List<Boat>();

        public int NrOfBoats => _boats.Count;

        public string Name
        {
            get => this._name;

            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Member must have a name");
                }

                this._name = value;
            }
        }

        public string PersonalNumber
        {
            get => this._personalNumber;
            set => this._personalNumber = value;
        }

        public string MemberId { get; private set; }

        public Member(string name, string personalNumber) 
        {
            this.Name = name; 
            this.PersonalNumber = personalNumber;
            this.MemberId = this.generateId();
        }

        private string generateId() {
            string name = this._name.Substring(0, 2); 
            string personalNumber = this._personalNumber.Substring(5, 4);      
            return $"{name}{personalNumber}";
        }

        public Member updateName(Member member, string name) 
        {
            member.Name = name;
            return member; 
        }

        public Member updatePersonalNumber(Member member, string personalNumber)
        {
            member.PersonalNumber = personalNumber;
            return member;
        }

        public void addBoat(Boat boat)
        {
            this._boats.Add(boat);
        } 
    }
}