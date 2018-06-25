using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBlogModels;


namespace MyBlogDAL
{
    public static class UserService
    {
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User AddUser(User user)
        {
            string sql =
                "INSERT Users (LoginId, LoginPwd, Name, QQ, Mail)" +
                "VALUES (@LoginId, @LoginPwd, @Name, @QQ, @Mail)";

            sql += " ; SELECT @@IDENTITY";
            SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@LoginId", user.LoginId),
                    new SqlParameter("@LoginPwd", user.LoginPwd),
                    new SqlParameter("@Name", user.Name),
                    new SqlParameter("@QQ", user.QQ),
                    new SqlParameter("@Mail", user.Mail)
                };

            int newId = DBHelper.GetScalar(sql, para);
            return GetUserById(newId);
        }
        /// <summary>
        /// 通过id获得用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetUserById(int id)
        {
            string sql = "SELECT * FROM Users WHERE Id = @Id";
            SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
            if (reader.Read())
            {
                User user = new User();

                user.Id = (int)reader["Id"];
                user.LoginId = (string)reader["LoginId"];
                user.LoginPwd = (string)reader["LoginPwd"];
                user.Name = (string)reader["Name"];
                user.QQ = (string)reader["QQ"];
                user.Mail = (string)reader["Mail"];

                reader.Close();

                return user;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 通过登录名获得用户
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static User GetUserByLoginId(string loginId)
        {
            string sql = "SELECT * FROM Users WHERE LoginId = @loginId";


            SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@LoginId", loginId));
            if (reader.Read())
            {
                User user = new User();

                user.Id = (int)reader["Id"];
                user.LoginId = (string)reader["LoginId"];
                user.LoginPwd = (string)reader["LoginPwd"];
                user.Name = (string)reader["Name"];
                user.QQ = (string)reader["QQ"];
                user.Mail = (string)reader["Mail"];

                reader.Close();

                return user;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 检测登录名是否存在
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public static bool LoginIdExists(string loginId)
        {
            if (GetUserByLoginId(loginId) != null)
                return true; 
            else
                return false; 
        }
        /// <summary>
        /// 获得所有用户的列表
        /// </summary>
        /// <returns></returns>
        public static IList<User> GetAllUsers()
        {
            string sqlAll = "SELECT * FROM Users";
            return GetUsersBySql(sqlAll);
        }
        /// <summary>
        /// 通过sql语句获得用户列表
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        private static IList<User> GetUsersBySql(string safeSql)
        {
            List<User> list = new List<User>();
            DataTable table = DBHelper.GetDataSet(safeSql);
            foreach (DataRow row in table.Rows)
            {
                User user = new User();
                user.Id = (int)row["Id"];
                user.LoginId = (string)row["LoginId"];
                user.LoginPwd = (string)row["LoginPwd"];
                user.Name = (string)row["Name"];
                user.QQ = (string)row["QQ"];
                user.Mail = (string)row["Mail"];

                list.Add(user);
            }
            return list;
        }
    }
}
