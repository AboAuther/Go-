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
    public class WelfareSalaryService
    {
        #region 常量,变量的定义
        private readonly string connstring = ConfigurationManager.ConnectionStrings["ManagementSystem"].ConnectionString;
        #endregion

        #region 通过福利名称获取工资
        public welfare_salary GetSalaryByName(string name)
        {
            welfare_salary ws = new welfare_salary();
            string sql = "select _welfare_salary from welfare_salary where welfare_name=@Name";
            SqlParameter[] paras =
            {
                new SqlParameter("@Name",name)
            };
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                //创建执行工具的参数
                command.Parameters.AddRange(paras);
                //打开连接
                conn.Open();
                //执行
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ws.Welfare_salary = Convert.ToInt32(reader["_welfare_salary"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return ws;
        }
        #endregion
    }
}
