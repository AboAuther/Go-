using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystemModels;
using ManagementSystemDal;


namespace ManagementSystemBll
{
    public class FinancialAdminManager
    {
        #region 常量变量的定义

        FinancialAdminService fas = new FinancialAdminService();
        StaffService ss = new StaffService(); 
        #endregion

        #region 执行财务部管理员登录检查
        /// <summary>
        /// 执行员工权限登录检查
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>true:登陆成功，false:登陆失败</returns>
        public bool CheckFinancialAdminLogin(string name, string password)
        {
            return fas.CheckFinancialAdminLogin(name, password);
        }
        #endregion

        #region 添加财务部管理员
        public int AddFinancialAdmin(financial_admin admin)
        {
            try
            {
                return fas.AddFinancialAdmin(admin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除财务部管理员
        public int DeleteFinancialAdminByJobID(string jobID)
        {
            try
            {
                return fas.DeleteFinancialAdminByJobID(jobID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region 修改财务部管理员密码
        public int ChangePassword(string jobid, string password)
        {
            try
            {
                return fas.ChangePassword(jobid, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
