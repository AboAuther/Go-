using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemModels
{
    [Serializable]
    public class postwage
    {
        private int postnumber;
        private string department;
        private string post;
        private int post_wage;
        private int basicsalary;

        public string Department { get => department; set => department = value; }
        public string Post { get => post; set => post = value; }
        public int Post_wage { get => post_wage; set => post_wage = value; }
        public int Basicsalary { get => basicsalary; set => basicsalary = value; }
        public int Postnumber { get => postnumber; set => postnumber = value; }
    }
}
