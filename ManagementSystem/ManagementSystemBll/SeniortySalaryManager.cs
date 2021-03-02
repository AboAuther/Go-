using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystemDal;
using ManagementSystemModels;

namespace ManagementSystemBll
{
    public class SeniortySalaryManager
    {
        SeniortySalaryService sss = new SeniortySalaryService();

        #region 根据姓名工号选择工龄
        public seniortysalary GetSeniortyByJobIDandName(string jobid, string name)
        {
            try
            {
                return sss.GetSeniortyByJobIDandName(jobid,name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 根据工龄选择工龄工资
        public seniortysalary GetSeniortySalaryBySeniorty(int seniorty)
        {
            try
            {
                return sss.GetSeniortySalaryBySeniorty(seniorty);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        
    }
}
