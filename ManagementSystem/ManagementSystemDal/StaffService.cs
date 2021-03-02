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
    public class StaffService
    {
        #region 常量,变量的定义
        private readonly string connstring = ConfigurationManager.ConnectionStrings["ManagementSystem"].ConnectionString;
        #endregion

        #region 通过姓名密码获取工号
        public staffmessage GetJobIDByNameAndPassword(string name,string password)
        {
            staffmessage staff = new staffmessage();
            string sql = "select jobID from staffmessage where name=@Name and password=@Password";
            SqlParameter[] paras =
            {
                new SqlParameter("@Name",name),
                new SqlParameter("@Password",password)
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
                    staff.JobID = Convert.ToString(reader["jobID"]);
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
            return staff;
        }
        #endregion

        #region 通过工号姓名检查员工是否存在
        public bool CheckStaffIsExistsByJobIDandName(string jobID,string name)
        {
            bool flag = false;
            //sql语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select COUNT(*) from staffmessage");
            stringBuilder.AppendLine("where jobID=@JobID and name=@Name");
            //参数
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",jobID),
                new SqlParameter("@Name",name)
            };
            //连接对象
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), conn);
                //打开数据库
                conn.Open();
                //创建执行工具的参数
                command.Parameters.AddRange(paras);
                //执行
                int result = Convert.ToInt32(command.ExecuteScalar());
                //判断
                if (result > 0)
                {
                    flag = true;
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
            return flag;
        }

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
            bool flag = false;
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select * from staffmessage");
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

        #region 工号获取员工信息
        /// <summary>
        /// 根据工号获取员工信息
        /// </summary>
        /// <param name="jobID">工号</param>
        /// <returns>员工个体</returns>
        public staffmessage GetStaffmessageByJobID(string jobID)
        {
            staffmessage staff = null;
            //sql语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select * from staffmessage");
            stringBuilder.AppendLine("where jobID=@JobID");
            //参数
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",jobID)
            };
            //连接对象
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
                    staff = new staffmessage();
                    staff.JobID = jobID;
                    staff.Name = Convert.ToString(reader["name"]);
                    staff.Gender = Convert.ToString(reader["gender"]);
                    staff.Password = Convert.ToString(reader["password"]);
                    staff.Age = Convert.ToInt32(reader["age"]);
                    staff.Hireyear = Convert.ToInt32(reader["hireyear"]);
                    staff.Post = Convert.ToString(reader["post"]);
                    staff.Postnumber = Convert.ToInt32(reader["postnumber"]);
                    staff.Seniorty = Convert.ToInt32(reader["seniorty"]);
                    staff.Pic_url = Convert.ToString(reader["pic_url"]);
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
            return staff;
        }
        #endregion

        #region 通过工号获取员工姓名
        public staffmessage GetNameByJobID(string jobID)
        {
            staffmessage staff = new staffmessage();
            string sql = "select name,pic_url from staffmessage where jobID=@JobID";
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",jobID)
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
                    staff.Name = Convert.ToString(reader["name"]);
                    staff.Pic_url = Convert.ToString(reader["pic_url"]);
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
            return staff;
        }
        #endregion

        #region 获取全部员工信息
        /// <summary>
        /// 获取全部员工信息
        /// </summary>
        /// <returns>返回所有员工的信息</returns>
        public List<staffmessage> GetStaffData()
        {
            List<staffmessage> staffs = new List<staffmessage>();
            string sql = "select * from staffmessage";
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
                    staffmessage staff = new staffmessage();
                    staff.JobID = Convert.ToString(reader["jobID"]);
                    staff.Name = Convert.ToString(reader["name"]);
                    staff.Gender = Convert.ToString(reader["gender"]);
                    staff.Password = Convert.ToString(reader["password"]);
                    staff.Age = Convert.ToInt32(reader["age"]);
                    staff.Hireyear = Convert.ToInt32(reader["hireyear"]);
                    staff.Post = Convert.ToString(reader["post"]);
                    staff.Postnumber = Convert.ToInt32(reader["postnumber"]);
                    staff.Seniorty = Convert.ToInt32(reader["seniorty"]);
                    staff.Pic_url = Convert.ToString(reader["pic_url"]);
                    staffs.Add(staff);
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
            return staffs;
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
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("insert into staffmessage");
            stringBuilder.AppendLine("values(@JobID,@Name,@Gender,@Age,@Hireyear,@Post,@Seniorty,@Password,@Postnumber)");
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",staff.JobID),
                new SqlParameter("@Name",staff.Name),
                new SqlParameter("@Gender",staff.Gender),
                new SqlParameter("@Age",staff.Age),
                new SqlParameter("@Hireyear",staff.Hireyear),
                new SqlParameter("@Post",staff.Post),
                new SqlParameter("@Seniorty",staff.Seniorty),
                new SqlParameter("@Password",staff.Password),
                new SqlParameter("@Postnumber",staff.Postnumber)
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

        #region 修改员工信息
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="staff">员工个体</param>
        /// <returns>返回受影响行数</returns>
        public int UpdateStaff(staffmessage staff)
        {
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("update staffmessage");
            stringBuilder.AppendLine("set jobID=@JobID,name=@Name,gender=@Gender,age=@Age,hireyear=@Hireyear," +
                "post=@Post,seniorty=@Seniorty,password=@Password,postnumber=@Postnumber");
            stringBuilder.AppendLine("where jobID=@JobID and name=@Name");
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",staff.JobID),
                new SqlParameter("@Name",staff.Name),
                new SqlParameter("@Gender",staff.Gender),
                new SqlParameter("@Age",staff.Age),
                new SqlParameter("@Hireyear",staff.Hireyear),
                new SqlParameter("@Post",staff.Post),
                new SqlParameter("@Seniorty",staff.Seniorty),
                new SqlParameter("@Password",staff.Password),
                new SqlParameter("@Postnumber",staff.Postnumber)
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

        #region 通过工号删除员工信息
        public int DeleteStaffmessageByJobID(string jobID)
        {
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("delete from staffsalary where jobID=@JobID");
            stringBuilder.AppendLine("delete from financial_admin where jobID=@JobID");
            stringBuilder.AppendLine("delete from personel_admin where jobID=@JobID");
            stringBuilder.AppendLine("delete from staffmessage where jobID=@JobID");
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

        #region 修改密码
        public int ChangePassword(string jobid,string password)
        {
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("update staffmessage");
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

        #region 添加员工照片路径
        /// <summary>
        /// 新增员工照片路径
        /// </summary>
        /// <param name="staff">员工个体</param>
        /// <returns>返回受影响行数</returns>
        public int AddStaffPic_url(string pic_url,string jobid)
        {
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("update staffmessage");
            stringBuilder.AppendLine("set pic_url=@Pic_url where jobID=@JobID");
            SqlParameter[] paras =
            {
                new SqlParameter("@Pic_url",pic_url),
                new SqlParameter("@JobID",jobid)
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

        #region 个人修改员工信息
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="staff">员工个体</param>
        /// <returns>返回受影响行数</returns>
        public int UpdateStaffPersonally(staffmessage staff)
        {
            //创建SQL语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("update staffmessage");
            stringBuilder.AppendLine("set name=@Name,gender=@Gender,age=@Age");
            stringBuilder.AppendLine("where jobID=@JobID");
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",staff.JobID),
                new SqlParameter("@Name",staff.Name),
                new SqlParameter("@Gender",staff.Gender),
                new SqlParameter("@Age",staff.Age)
               
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

        #region 通过工号姓名检查员工是否存在
        public bool CheckStaffIsExistsByJobIDandPassword(string jobID, string password)
        {
            bool flag = false;
            //sql语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("select COUNT(*) from staffmessage");
            stringBuilder.AppendLine("where jobID=@JobID and password=@Password");
            //参数
            SqlParameter[] paras =
            {
                new SqlParameter("@JobID",jobID),
                new SqlParameter("@Password",password)
            };
            //连接对象
            SqlConnection conn = new SqlConnection(connstring);
            try
            {
                //创建执行工具
                SqlCommand command = new SqlCommand(stringBuilder.ToString(), conn);
                //打开数据库
                conn.Open();
                //创建执行工具的参数
                command.Parameters.AddRange(paras);
                //执行
                int result = Convert.ToInt32(command.ExecuteScalar());
                //判断
                if (result > 0)
                {
                    flag = true;
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
            return flag;
        }

        #endregion
    }
}
