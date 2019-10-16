using System;

namespace model
{
    public enum BoatTypes
    {
        Sailboat = 1, 
        Motorsailer, 
        Kayak,
        Canoe, 
        Other
    }

    public class Boat 
    {
        private string _lengthInFeet;

        private int _id;

        public string LengthInFeet 
        {
            get => this._lengthInFeet;
            set
            {
                if (!float.TryParse(value, out float length) || length < 0)
                {
                    throw new ArgumentException();
                }
                
                this._lengthInFeet = value;
            }
        }

         public int Id 
         {
             get => this._id; 
             set
             {
                 if(value <= 0)
                 {
                     throw new ArgumentOutOfRangeException();
                 }

                 this._id = value;
             }
        }

        public BoatTypes Type { get; set; }

        public Boat (BoatTypes type, string lengthInFeet, int id) 
        {
            this.Type = type;
            this.LengthInFeet = lengthInFeet;
            this.Id = id;
        }

    }

}