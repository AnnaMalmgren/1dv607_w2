using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class Member {
        private string _name;
        private string _personalNumber;

        public List<Boat> Boats { get; private set; }

        public int NrOfBoats => Boats.Count;

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

            set 
            {
                if (value.Length != 10)
                {
                    throw new ArgumentNullException("Member must have a name");
                }

                this._personalNumber = value;
            }
        }

        public string MemberId { get; private set; }

        public Member(string name, string personalNumber) 
        {
            this.Name = name; 
            this.PersonalNumber = personalNumber;
            this.MemberId = this.generateId();
            this.Boats = new List<Boat>();
        }

        private string generateId() {
            string name = this._name.Substring(0, 2); 
            string personalNumber = this._personalNumber.Substring(5, 4);      
            return $"{name}{personalNumber}";
        }


        public void addBoat(BoatTypes type, float length) {
            int id = this.NrOfBoats + 1;
            this.Boats.Add(new Boat(type, length, id));
        }

        public Boat getBoat(int id) => this.Boats.FirstOrDefault(boat => boat.Id == id);
        

        public void deleteBoat(Boat boatToRemove) => this.Boats.Remove(boatToRemove);
    }
}