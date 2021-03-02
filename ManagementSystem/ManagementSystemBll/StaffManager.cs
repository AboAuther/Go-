using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystemDal;
using ManagementSystemModels;

namespace ManagementSystemBll
{
    public class StaffManager
    {
        #region 常量变量的定义
        StaffService ss = new StaffService(); 
        #endregion

        #region 执行员工登录检查
        /// <summary>
        /// 执行员工权限登录检查
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>true:登陆成功，false:登陆失败</returns>
        public bool CheckStaffLogin(string name, string password)
        {
            return ss.CheckStaffLogin(name, password);
        }
        #endregion

        #region 获取员工信息

        public List<staffmessage> GetStaffData()
        {
            try
            {
                return ss.GetStaffData();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 通过工号获取员工信息
        public staffmessage GetStaffmessageByJobID(string jobID)
        {
            try
            {
                return ss.GetStaffmessageByJobID(jobID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 通过工号获取员工姓名
        public staffmessage GetNameByJobID(string jobID)
        {
            try
            {
                return ss.GetNameByJobID(jobID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 删除员工
        public int DeleteStaffmessageByJobID(string jobID)
        {
            try
            {
                return ss.DeleteStaffmessageByJobID(jobID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 添加员工
        /// <summary>
        /// 新增员工信息
        /// </summary>
        /// <param name="staff">员工个体</param>
        /// <returns>返回受影响行数</returns>
        public int AddStaff(staffmessage staff)
        {
            try
            {
                return ss.AddStaff(staff);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 修改员工信息
        public int UpdateStaff(staffmessage staff)
        {
            try
            {
                return ss.UpdateStaff(staff);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 通过姓名密码获取工号
        public staffmessage GetJobIDByNameAndPassword(string name, string password)
        {
            try
            {
                return ss.GetJobIDByNameAndPassword(name, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 通过工号姓名检查员工是否存在

        public bool CheckStaffIsExistsByJobIDandName(string jobID,string name)
        {
            try
            {
                return ss.CheckStaffIsExistsByJobIDandName(jobID,name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 修改密码
        public int ChangePassword(string jobid, string password)
        {
            try
            {
                return ss.ChangePassword(jobid, password);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 添加员工照片路径
        /// <summary>
        /// 新增员工照片路径
        /// </summary>
        /// <param name="staff">员工个体</param>
        /// <returns>返回受影响行数</returns>
        public int AddStaffPic_url(string pic_url, string jobid)
        {
            try
            {
                return ss.AddStaffPic_url(pic_url, jobid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 个人修改员工信息
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="staff">员工个体</param>
        /// <returns>返回受影响行数</returns>
        public int UpdateStaffPersonally(staffmessage staff)
        {
            try
            {
                return ss.UpdateStaffPersonally(staff);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 通过工号姓名检查员工是否存在
        public bool CheckStaffIsExistsByJobIDandPassword(string jobID, string password)
        {
            try
            {
                return ss.CheckStaffIsExistsByJobIDandPassword(jobID, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
