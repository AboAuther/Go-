using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ManagementSystemModels;
using System.Data;
using System.Data.SqlClient;


namespace ManagementSystemDal
{
    /// <summary>
    /// 提供财务部管理员信息操作
    /// </summary>
    public class FinancialAdminService
    {
        #region 常量,变量的定义
        private readonly string connstring = ConfigurationManager.ConnectionStrings["ManagementSystem"].ConnectionString;
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
            bool flag = false;
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select * from financial_admin");
            stringBuilder.AppendLine("where name=@Name and password=@Password");

            //设置参数
            SqlParameter[] paras =
            {
                new SqlParameter("@Name",name),
                new SqlParameter("@Password",password)
            };
            //创建连接对象
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), conn);
                //创建执行工具的参数
                command.Parameters.AddRange(paras);
                //打开连接
                conn.Open();
                //执行
                SqlDataReader reader = command.ExecuteReader();
                //判断
                if (reader.Read())
                {
                    flag = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }
        #endregion

        #region 添加财务部管理员
        public int AddFinancialAdmin(financial_admin admin)
        {
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("insert into financial_admin");
            stringBuilder.AppendLine("values(@JobID,@Name,@Password,@Postnumber)");
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",admin.JobID),
                new SqlParameter("@Name",admin.Name),
                new SqlParameter("@Password",admin.Password),
                new SqlParameter("@Postnumber",admin.Postnumber)
            };
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), conn);
                //创建执行工具的参数
                command.Parameters.AddRange(paras);
                //打开连接
                conn.Open();
                //执行
                int result = command.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion

        #region 删除财务部管理员
        public int DeleteFinancialAdminByJobID(string jobID)
        {
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();   
            stringBuilder.AppendLine("delete from financial_admin where jobID=@JobID");
            SqlParameter parameter = new SqlParameter("@JobID", jobID);
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), conn);
                //创建执行工具的参数
                command.Parameters.Add(parameter);
                //打开连接
                conn.Open();
                //执行
                int result = command.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }


        }
        #endregion

        #region 修改财务部管理员密码
        public int ChangePassword(string jobid, string password)
        {
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("update financial_admin");
            stringBuilder.AppendLine("set password=@Password");
            stringBuilder.AppendLine("where jobID=@JobID");
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",jobid),
                new SqlParameter("@Password",password)
            };
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), conn);
                //创建执行工具的参数
                command.Parameters.AddRange(paras);
                //打开连接
                conn.Open();
                //执行
                int result = command.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
