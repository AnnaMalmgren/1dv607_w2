using System;


namespace model
{
    public enum BoatTypes
    {
        Sailboat = 1, 
        Motorsailer, 
        kayak,
        Canoe, 
        Other
    }
    public class Boat 
    {
        private float _lengthInFeet;

        public float LengthInFeet 
        {
            get => this._lengthInFeet;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _lengthInFeet = value;
            }
        }

         public int Id {get; set;}

        public BoatTypes Type { get; private set; }

        public Boat (BoatTypes type, float lengthInFeet, int id) 
        {
            this.Type = type;
            this.LengthInFeet = lengthInFeet;
            this.Id = id;
        }

        public void changeBoat(BoatTypes type)
        {
            this.Type = type;
        }

         public void changeBoat(float length)
        {
            this.LengthInFeet = length;
        }
        
    }

}