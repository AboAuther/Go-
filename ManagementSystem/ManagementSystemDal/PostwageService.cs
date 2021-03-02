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
    public class PostwageService
    {
        #region 常量,变量的定义
        private readonly string connstring = ConfigurationManager.ConnectionStrings["ManagementSystem"].ConnectionString;
        #endregion

        #region 获取全部岗位工资信息
        /// <summary>
        /// 获取全部岗位工资信息
        /// </summary>
        /// <returns>返回所有岗位工资信息</returns>
        public List<postwage> GetPostwageData()
        {
            List<postwage> wages = new List<postwage>();
            string sql = "select * from postwage";
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
                    postwage wage = new postwage();                    
                    wage.Postnumber = Convert.ToInt32(reader["postnumber"]);
                    wage.Department = Convert.ToString(reader["department"]);
                    wage.Post = Convert.ToString(reader["post"]);
                    wage.Post_wage = Convert.ToInt32(reader["post_wage"]);
                    wage.Basicsalary = Convert.ToInt32(reader["basicsalary"]);
                    wages.Add(wage);
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
            return wages;
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
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("update postwage");
            stringBuilder.AppendLine("set post_wage=@Post_wage,basicsalary=@Basicsalary");
            stringBuilder.AppendLine("where department=@Department and post=@Post");
            SqlParameter[] paras =
            {
                new SqlParameter("@Post_wage",wage.Post_wage),
                new SqlParameter("@Basicsalary",wage.Basicsalary),
                new SqlParameter("@Department",wage.Department),
                new SqlParameter("@Post",wage.Post)
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

        #region 通过岗位编号获取工资信息
        public postwage GetPostwageByPostnumber(int postnumber)
        {
            postwage wage = new postwage();
            string sql = "select basicsalary,post_wage from postwage where postnumber=@Postnumber";
            SqlParameter[] paras =
            {
                new SqlParameter("@Postnumber",postnumber)
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
                    wage.Post_wage = Convert.ToInt32(reader["post_wage"]);
                    wage.Basicsalary = Convert.ToInt32(reader["basicsalary"]);
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
            return wage;
        }
        #endregion

        #region 通过岗位获取工资信息
        public postwage GetPostwageByPost(string post)
        {
            postwage wage = new postwage();
            string sql = "select basicsalary,post_wage from postwage where post like @Post";
            SqlParameter[] paras =
            {
                new SqlParameter("@Post","%"+post)
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
                    wage.Post_wage = Convert.ToInt32(reader["post_wage"]);
                    wage.Basicsalary = Convert.ToInt32(reader["basicsalary"]);
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
            return wage;
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
            postwage wage = new postwage();
            //sql语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select postnumber from postwage");
            stringBuilder.AppendLine("where department=@Department and post like @Post");
            //参数
            SqlParameter[] paras =
            {
                new SqlParameter("@Department",department),
                new SqlParameter("@Post","%"+post)
            };
            //连接对象
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), conn);
                //创建执行工具的参数
                command.Parameters.AddRange(paras);
                //执行
                conn.Open();
                //执行
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    wage.Postnumber = Convert.ToInt32(reader["postnumber"]);
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
            return wage;
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
            postwage wage = new postwage();
            //sql语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select department from postwage");
            stringBuilder.AppendLine("where postnumber=(select postnumber from staffmessage where jobID=@JobID)");
            //参数
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",jobid)

            };
            //连接对象
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), conn);
                //创建执行工具的参数
                command.Parameters.AddRange(paras);
                //执行
                conn.Open();
                //执行
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    wage.Department = Convert.ToString(reader["department"]);
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
            return wage;
        }
        #endregion





    }



}
