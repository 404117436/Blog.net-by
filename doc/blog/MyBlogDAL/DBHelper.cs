using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace MyBlogDAL
{
    public static class DBHelper
    {

        private static SqlConnection connection;
        /// <summary>
        /// 
        /// </summary>
        public static SqlConnection Connection
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyBlog"].ConnectionString;
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        /// <summary>
        /// ִ�в�����Ӱ������
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        /// <summary>
        /// ִ�в�����Ӱ������
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// ִ�в�����ִ�н���еĵ�һ��
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static int GetScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// ִ�в�����ִ�н���еĵ�һ��
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        /// <summary>
        /// ����sql�����sqldatareader
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// ����sql�����sqldatareader
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// ����sql�����DataTable
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// ����sql�����DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}

