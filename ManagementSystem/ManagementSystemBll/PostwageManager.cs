using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystemDal;
using ManagementSystemModels;

namespace ManagementSystemBll
{
    public class PostwageManager
    {
        PostwageService ps = new PostwageService();

        #region 获取全部岗位工资信息
        /// <summary>
        /// 获取全部岗位工资信息
        /// </summary>
        /// <returns>返回所有岗位工资信息</returns>
        public List<postwage> GetPostwageData()
        {
            try
            {
                return ps.GetPostwageData();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 修改岗位工资
        /// <summary>
        /// 修改岗位工资
        /// </summary>
        /// <param name="wage">工资实体</param>
        /// <returns></returns>
        public int UpdatePostwage(postwage wage)
        {
            try
            {
                return ps.UpdatePostwage(wage);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 通过岗位编号获取工资信息
        public postwage GetPostwageByPostnumber(int postnumber)
        {
            try
            {
                return ps.GetPostwageByPostnumber(postnumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 通过岗位获取工资信息
        public postwage GetPostwageByPost(string post)
        {
            try
            {
                return ps.GetPostwageByPost(post);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 通过部门岗位获取员工岗位号
        /// <summary>
        /// 检查工号是否存在
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns>true：存在 false: 不存在</returns>
        public postwage SelecJobIDByDepartmentAndPost(string department, string post)
        {
            try
            {
                return ps.SelecJobIDByDepartmentAndPost(department, post);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region 通过工号获取部门名称
        /// <summary>
        /// 检查工号是否存在
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns>true：存在 false: 不存在</returns>
        public postwage SelectDepartmentByJobID(string jobid)
        {
            try
            {
                return ps.SelectDepartmentByJobID(jobid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
