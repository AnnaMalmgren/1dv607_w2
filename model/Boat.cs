using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace model
{
    public class Boat 
    {
        private string type;
        private float length;

        public Boat (string type, float length) 
        {
            this.type = type;
            this.length = length;
        }
    }
}