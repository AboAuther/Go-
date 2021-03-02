using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ManagementSystemModels;
using System.Data;
using System.Data.SqlClient;
using ManagementSystemDal;

namespace ManagementSystemDal
{
    public class SeniortySalaryService
    {
        #region 常量,变量的定义
        private readonly string connstring = ConfigurationManager.ConnectionStrings["ManagementSystem"].ConnectionString;
        #endregion

        #region 获取全部工龄工资信息
        /// <summary>
        /// 获取全部工龄工资信息
        /// </summary>
        /// <returns>返回所有工龄工资信息</returns>
        public List<seniortysalary> GetSeniortySalaryData()
        {
            List<seniortysalary> salarys = new List<seniortysalary>();
            string sql = "select * from seniortysalary";
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                //打开连接
                conn.Open();
                //执行
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    seniortysalary salary = new seniortysalary();
                    salary.Seniorty = Convert.ToInt32(reader["seniorty"]);
                    salary.Seniorty_salary = Convert.ToInt32(reader["seniorty_salary"]);
                    salarys.Add(salary);
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
            return salarys;
        }
        #endregion

        #region 修改工龄工资
        /// <summary>
        /// 修改工龄工资
        /// </summary>
        /// <param name="wage">工资实体</param>
        /// <returns></returns>
        public int UpdateSeniortySalary(seniortysalary salary)
        {
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("update seniortysalary");
            stringBuilder.AppendLine("set seniorty_salary=@Seniorty_salary");
            stringBuilder.AppendLine("where seniorty=@Seniorty");
            SqlParameter paras = new SqlParameter("@Seniorty_salary", salary.Seniorty_salary);
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), conn);
                //创建执行工具的参数
                command.Parameters.Add(paras);
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

        #region 根据工龄选择工龄工资
        public seniortysalary GetSeniortySalaryBySeniorty(int seniorty)
        {
            seniortysalary ss = new seniortysalary();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select max(seniorty_salary) from seniortysalary");
            stringBuilder.AppendLine("  where seniorty < = @Seniorty ");
            //stringBuilder.AppendLine("(select seniorty from staffmessage where name=@Name and jobID=@JobID)");
            SqlParameter[] paras =
            {
                new SqlParameter("@Seniorty",seniorty)
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
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ss.Seniorty_salary = Convert.ToInt32(reader.GetInt32(0));
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
            return ss;
        }
        #endregion

        #region 根据姓名工号选择工龄
        public seniortysalary GetSeniortyByJobIDandName(string jobid, string name)
        {
            seniortysalary ss = new seniortysalary();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select seniorty from staffmessage where name=@Name and jobID=@JobID");
            SqlParameter[] paras =
            {
                new SqlParameter("@Name",name),
                new SqlParameter("@JobID",jobid),
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
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ss.Seniorty = Convert.ToInt32(reader["seniorty"]);
                }
                //reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return ss;
        }
        #endregion


        

    }
}