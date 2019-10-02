using System;
using System.Collections.Generic;
using System.Linq;

namespace model
{
    public class Member {
        private string _name;
        private string _personalNumber;

        private int personalNrLength = 10;

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
                if (!double.TryParse(value, out id) || value.Length != this.personalNrLength)
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
            // take the two first letters from username.
            string id = this._name.Substring(0, 2);

            // create three random int and two random chars.
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


        public string boatsToString()
        {
            string boatString = "";
            foreach (Boat boat in this.Boats)
            {
                boatString += "\n-----------------------------------------------\n";
                boatString += $"Boat nr {boat.Id}\nType: {boat.Type}\nLength: {boat.Length}";
            }

            return boatString;
        }

    }
}