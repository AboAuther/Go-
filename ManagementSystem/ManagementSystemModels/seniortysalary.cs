using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemModels
{
    [Serializable]
    public class seniortysalary
    {
        private int seniorty;
        private int seniorty_salary;

        public int Seniorty { get => seniorty; set => seniorty = value; }
        public int Seniorty_salary { get => seniorty_salary; set => seniorty_salary = value; }
    }
}
