using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemModels
{
    [Serializable]
    public class welfare_salary
    {
        private string welfare_name;
        private int _welfare_salary;

        public string Welfare_name { get => welfare_name; set => welfare_name = value; }
        public int Welfare_salary { get => _welfare_salary; set => _welfare_salary = value; }
    }
}
