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
    public class StaffSalatyService
    {
        #region 常量,变量的定义
        private readonly string connstring = ConfigurationManager.ConnectionStrings["ManagementSystem"].ConnectionString;

        #endregion

        #region 添加工资记录
        public int AddSalary(staffsalary ss)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("insert into staffsalary");
            stringBuilder.AppendLine("values(@JobID,@Name,@Year,@Month,@Basic_salary,@Job_salary,@Seniorty_salary,@Welfare_salary,@Totalsalary)");
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",ss.JobID),
                new SqlParameter("@Name",ss.Name),
                new SqlParameter("@Year",ss.Year),
                new SqlParameter("@Month",ss.Month),
                new SqlParameter("@Basic_salary",ss.Basic_salary),
                new SqlParameter("@Job_salary",ss.Job_salary),
                new SqlParameter("@Seniorty_salary",ss.Seniorty_salary),
                new SqlParameter("@Welfare_salary",ss.Welfare_salary),
                new SqlParameter("@Totalsalary",ss.Totalsalary)
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

        #region 检测有无已经添加过的工资记录
        public bool CheckIsSalaryRecord(int year, int month, string jobid)
        {
            bool flag = false;
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select * from staffsalary");
            stringBuilder.AppendLine("where year=@Year and month=@Month and jobID=@JobID");

            //设置参数
            SqlParameter[] paras =
            {
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month),
                new SqlParameter("@JobID",jobid)
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

        #region 通过月份年份查看工资记录
        public List<staffsalary> GetStaffsalariesByYearandMonth(int year, int month)
        {
            List<staffsalary> sss = new List<staffsalary>();
            string sql = "select * from staffsalary where year=@Year and month=@Month";
            SqlParameter[] paras =
            {
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month)
            };
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                //打开连接
                conn.Open();
                command.Parameters.AddRange(paras);
                //执行
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    staffsalary ss = new staffsalary();
                    ss.JobID = Convert.ToString(reader["jobID"]);
                    ss.Name = Convert.ToString(reader["name"]);
                    ss.Year = Convert.ToInt32(reader["year"]);
                    ss.Month = Convert.ToInt32(reader["month"]);
                    ss.Basic_salary = Convert.ToInt32(reader["basic_salary"]);
                    ss.Job_salary = Convert.ToInt32(reader["job_salary"]);
                    ss.Seniorty_salary = Convert.ToInt32(reader["seniorty_salary"]);
                    ss.Welfare_salary = Convert.ToInt32(reader["welfare_salary"]);
                    ss.Totalsalary = Convert.ToInt32(reader["totalsalary"]);
                    sss.Add(ss);
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
            return sss;

        }
        #endregion

        #region 通过工号查看员工工资
        public List<staffsalary> GetStaffsalariesByJobID(string jobid)
        {
            List<staffsalary> sss = new List<staffsalary>();
            string sql = "select * from staffsalary where jobID=@JobID";
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",jobid)
            };
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                //打开连接
                conn.Open();
                command.Parameters.AddRange(paras);
                //执行
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    staffsalary ss = new staffsalary();
                    ss.JobID = Convert.ToString(reader["jobID"]);
                    ss.Name = Convert.ToString(reader["name"]);
                    ss.Year = Convert.ToInt32(reader["year"]);
                    ss.Month = Convert.ToInt32(reader["month"]);
                    ss.Basic_salary = Convert.ToInt32(reader["basic_salary"]);
                    ss.Job_salary = Convert.ToInt32(reader["job_salary"]);
                    ss.Seniorty_salary = Convert.ToInt32(reader["seniorty_salary"]);
                    ss.Welfare_salary = Convert.ToInt32(reader["welfare_salary"]);
                    ss.Totalsalary = Convert.ToInt32(reader["totalsalary"]);
                    sss.Add(ss);
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
            return sss;
        }
        #endregion

        #region 通过工号月份年份查看工资记录
        public List<staffsalary> GetStaffsalariesByYearandMonthandJobID(string jobid,int year, int month)
        {
            List<staffsalary> sss = new List<staffsalary>();
            string sql = "select * from staffsalary where year=@Year and month=@Month and jobID=@JobID";
            SqlParameter[] paras =
            {
                new SqlParameter("@Year",year),
                new SqlParameter("@Month",month),
                new SqlParameter("@JobID",jobid)
            };
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(sql.ToString(), conn);
                //打开连接
                conn.Open();
                command.Parameters.AddRange(paras);
                //执行
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    staffsalary ss = new staffsalary();
                    ss.JobID = Convert.ToString(reader["jobID"]);
                    ss.Name = Convert.ToString(reader["name"]);
                    ss.Year = Convert.ToInt32(reader["year"]);
                    ss.Month = Convert.ToInt32(reader["month"]);
                    ss.Basic_salary = Convert.ToInt32(reader["basic_salary"]);
                    ss.Job_salary = Convert.ToInt32(reader["job_salary"]);
                    ss.Seniorty_salary = Convert.ToInt32(reader["seniorty_salary"]);
                    ss.Welfare_salary = Convert.ToInt32(reader["welfare_salary"]);
                    ss.Totalsalary = Convert.ToInt32(reader["totalsalary"]);
                    sss.Add(ss);
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
            return sss;

        }
        #endregion


    }
}
