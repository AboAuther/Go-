using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemModels
{
    [Serializable]
    public class financial_admin
    {
        private string jobID;
        private string name;
        private int postnumber;
        private string password;
        /// <summary>
        /// 工号
        /// </summary>
        public string JobID { get => jobID; set => jobID = value; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 部门号
        /// </summary>
        public int Postnumber { get => postnumber; set => postnumber = value; }
       /// <summary>
       /// 密码
       /// </summary>
        public string Password { get => password; set => password = value; }
        
    }
}
