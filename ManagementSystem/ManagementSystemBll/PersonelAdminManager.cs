using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystemModels;
using ManagementSystemDal;

namespace ManagementSystemBll
{
    public class PersonelAdminManager
    {
        #region 常量变量的定义
        PersonelAdminService pas = new PersonelAdminService(); 
        #endregion

        #region 执行人事部管理员登录检查
        /// <summary>
        /// 执行员工权限登录检查
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>true:登陆成功，false:登陆失败</returns>
        public bool CheckPersonelAdminLogin(string name, string password)
        {
            return pas.CheckPersonelAdminLogin(name, password);
        }
        #endregion

        #region 添加人事部管理员
        public int AddPersonelAdmin(personel_admin admin)
        {
            try
            {
                return pas.AddPersonelAdmin(admin);
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
                return pas.ChangePassword(jobid, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 删除人事部管理员
        public int DeletePersonelAdminByJobID(string jobID)
        {
            try
            {
                return pas.DeletePersonelAdminByJobID(jobID);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
    }

}
