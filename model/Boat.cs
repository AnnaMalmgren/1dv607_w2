using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace model
{
    public class Boat 
    {
        private string _type;
        private float _length;

        public float Length 
        {
            get => _length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Length must have a value over 0");
                }
                _length = value;
            }
        }

        public string Type 
        {
            get => _type;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The boat must have a type.");
                }
                _type = value;
            }
        }

        public Boat (string type, float length) 
        {
            this._type = type;
            this._length = length;
        }
    }
}