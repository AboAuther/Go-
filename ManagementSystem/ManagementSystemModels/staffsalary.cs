using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemModels
{
    [Serializable]
    public class staffsalary
    {
        private string jobID;
        private int year;
        private int month;
        private int basic_salary;
        private int job_salary;
        private int seniorty_salary;
        private int welfare_salary;
        private string name;
        private int totalsalary;

        public int Year { get => year; set => year = value; }
        public int Month { get => month; set => month = value; }
        public int Basic_salary { get => basic_salary; set => basic_salary = value; }
        public int Job_salary { get => job_salary; set => job_salary = value; }
        public int Seniorty_salary { get => seniorty_salary; set => seniorty_salary = value; }
        public int Welfare_salary { get => welfare_salary; set => welfare_salary = value; }
        public string JobID { get => jobID; set => jobID = value; }
        public string Name { get => name; set => name = value; }
        public int Totalsalary { get => totalsalary; set => totalsalary = value; }
    }
}
