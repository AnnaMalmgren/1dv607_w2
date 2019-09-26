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
        private float _length;

        public float Length 
        {
            get => this._length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Length must have a value over 0");
                }
                _length = value;
            }
        }

         public int Id  => this._id;
      

        private int _id;

        public BoatTypes Type { get; set; }

        public Boat (BoatTypes type, float length, int id) 
        {
            this.Type = type;
            this.Length = length;
            this._id = id;
        }
    }

}