using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystemDal;
using ManagementSystemModels;

namespace ManagementSystemBll
{
    public class WelfareSalaryManager
    {
        WelfareSalaryService wss = new WelfareSalaryService();
        #region 通过福利名称获取工资
        public welfare_salary GetSalaryByName(string name)
        {
            try
            {
                return wss.GetSalaryByName(name);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
