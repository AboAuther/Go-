using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemModels
{
    [Serializable]
    public class staffmessage
    {
        private string jobID;
        private string name;
        private string gender;
        private int age;
        private int hireyear;
        private int seniorty;
        private int postnumber;
        private string post;
        private string password;
        private string pic_url;

        public string JobID { get => JobID1; set => JobID1 = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public int Hireyear { get => hireyear; set => hireyear = value; }
        public int Seniorty { get => seniorty; set => seniorty = value; }
        public int Postnumber { get => postnumber; set => postnumber = value; }
        public string Post { get => post; set => post = value; }
        public string Password { get => password; set => password = value; }
        public string Pic_url { get => pic_url; set => pic_url = value; }
        public string JobID1 { get => jobID; set => jobID = value; }
    }
}
