using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace model

{
    public class BoatClubDAL 
    {

        private string _fileName = "members.json";
        private string _filePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this._fileName);
        private bool _doesMemberFileExists => File.Exists(this._filePath);

        public BoatClubDAL() {
            if (!this._doesMemberFileExists)
            {
                this.createEmptyMemberFile();            
            }
        }

        private void createEmptyMemberFile()
        {
            File.Create(this._filePath).Dispose();
        }

        public List<Member> readMemberFile()
        {
            string jsonData = System.IO.File.ReadAllText(this._filePath);
            return JsonConvert.DeserializeObject<List<Member>>(jsonData) ?? new List<Member>();
        }

        public void writeToMemberFile(List<Member> members) {
            string memberInfo = JsonConvert.SerializeObject(members);
            File.WriteAllText(this._filePath, memberInfo);	
        }
    }
}