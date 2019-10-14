using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class Member {
        private string _name;

        private string _personalNumber;

        private int _personalNrLength = 10;
        
        public List<Boat> Boats { get; private set; }

        public int NrOfBoats => Boats.Count;

        public string Name
        {
            get => this._name;

            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this._name = value;
            }
        }
 
        public string PersonalNumber
        {
            get => this._personalNumber;

            set 
            {
                if (!double.TryParse(value, out double pin) || value.Length != this._personalNrLength)
                {
                    throw new ArgumentException();
                }

                this._personalNumber = value;
            }
        }

        public int MemberId { get; private set; }

        public Member(string name, string personalNumber) 
        {
            this.Name = name; 
            this.PersonalNumber = personalNumber;
            this.Boats = new List<Boat>();
        }

        public void setMemberId(int id)
        {
            this.MemberId = id;
        }

        public void addBoat(BoatTypes type, float length) {
            int id = this.NrOfBoats + 1;
            this.Boats.Add(new Boat(type, length, id));
        }

        public Boat getBoat(int id)
        {
            return this.Boats.FirstOrDefault(boat => boat.Id == id);
        }

        public void deleteBoat(Boat boatToRemove)
        {
            this.Boats.Remove(boatToRemove);
            this.updateBoatsId();
        }

        private void updateBoatsId()
        {
            int count = 1;
            foreach (Boat boat in this.Boats)
            {  
                boat.Id = count;
                count++;
            }
        }

    }
}