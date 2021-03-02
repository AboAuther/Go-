using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystemDal;
using ManagementSystemModels;

namespace ManagementSystemBll
{
    public class StaffSalaryManager
    {
        StaffSalatyService sss = new StaffSalatyService();

        #region 添加工资记录
        public int AddSalary(staffsalary ss)
        {
            try
            {
                return sss.AddSalary(ss);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 通过月份年份查看工资记录
        public List<staffsalary> GetStaffsalariesByYearandMonth(int year, int month)
        {
            try
            {
                return sss.GetStaffsalariesByYearandMonth(year, month);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region 检测有无已经添加过的工资记录
        public bool CheckIsSalaryRecord(int year, int month, string jobid)
        {
            try
            {
                return sss.CheckIsSalaryRecord(year, month, jobid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 通过工号查看员工工资
        public List<staffsalary> GetStaffsalariesByJobID(string jobid)
        {
            try
            {
                return sss.GetStaffsalariesByJobID(jobid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 通过工号月份年份查看工资记录
        public List<staffsalary> GetStaffsalariesByYearandMonthandJobID(string jobid, int year, int month)
        {
            try
            {
                return sss.GetStaffsalariesByYearandMonthandJobID(jobid,year,month);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
    }
}
