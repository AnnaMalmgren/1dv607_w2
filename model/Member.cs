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
                double id;
                if (!double.TryParse(value, out id) || value.Length != 10)
                {
                    throw new ArgumentException("Personal number must be format YYMMDDNNNN");
                }

                this._personalNumber = value;
            }
        }

        public string MemberId { get; set; }

        public Member(string name, string personalNumber) 
        {
            this.Name = name; 
            this.PersonalNumber = personalNumber;
            this.Boats = new List<Boat>();
        }

        public void generateId() 
        {
            string id = this._name.Substring(0, 2);
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
               id += rnd.Next(0, 10);
            }
            for (int i = 0; i < 2; i++)
            {
               id += (char)rnd.Next('a','z');  
            } 

            this.MemberId = id;
        }


        public void addBoat(BoatTypes type, float length) {
            int id = this.NrOfBoats + 1;
            this.Boats.Add(new Boat(type, length, id));
        }

        public Boat getBoat(int id) => this.Boats.FirstOrDefault(boat => boat.Id == id);

        public void updateBoatsId()
        {
            int count = 1;
            foreach (Boat boat in this.Boats)
            {  
                boat.Id = count;
                count++;
            }
        }
        
        public void deleteBoat(Boat boatToRemove) => this.Boats.Remove(boatToRemove);
    }
}