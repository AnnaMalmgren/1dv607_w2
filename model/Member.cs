using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class Member {
        private string _name;

        private string _personalNumber;

        private int _memberId;

        private int _personalNrLength = 10;
        
        public List<Boat> Boats { get; private set; }

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

        public int MemberId { 
            get => this._memberId; 
            set
            {
                this._memberId = value;
            }
        }

        public Member(string name, string personalNumber, int id) 
        {
            this.Name = name; 
            this.PersonalNumber = personalNumber;
            this.MemberId = id;
            this.Boats = new List<Boat>();
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