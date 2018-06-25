using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyBlogModels;

namespace MyBlogDAL
{
    public static class ArticleService
    {
        /// <summary>
        /// 添加新文章
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static Article AddArticle(Article article)
        {
            string sql =
                "INSERT Articles (AuthorId, Title, Contents, PubDate, Clicks)" +
                "VALUES (@AuthorId, @Title, @Contents, @PubDate, @Clicks)";
            sql += " ; SELECT @@IDENTITY";

            SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@AuthorId", article.Author.Id), //FK
					new SqlParameter("@Title", article.Title),
					new SqlParameter("@Contents", article.Contents),
					new SqlParameter("@PubDate", article.PubDate),
					new SqlParameter("@Clicks", article.Clicks)
				};

            int newId = DBHelper.GetScalar(sql, para);
            return GetArticleById(newId);
        }
        /// <summary>
        /// 通过id删除文章
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteArticleById(int id)
        {
            string sql = "DELETE Articles WHERE Id = @Id";
            try
            {
                SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", id)
				};

                DBHelper.ExecuteCommand(sql, para);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        /// <summary>
        /// 通过id获得文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Article GetArticleById(int id)
        {
            string sql = "SELECT * FROM Articles WHERE Id = @Id";
            int authorId;
            SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
            if (reader.Read())
            {
                Article article = new Article();
                article.Id = (int)reader["Id"];
                article.Title = (string)reader["Title"];
                article.Contents = (string)reader["Contents"];
                article.PubDate = (DateTime)reader["PubDate"];
                article.Clicks = (int)reader["Clicks"];
                authorId = (int)reader["AuthorId"];
                reader.Close();
                article.Author = UserService.GetUserById(authorId);
                return article;
            }
            else
            {
                reader.Close();
                return null;
            }

        }
        /// <summary>
        /// 通过用户id获得文章列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IList<Article> GetUserAllArticles(int userId)
        {
            string sqlAll = "SELECT * FROM Articles where AuthorId=@author";


            return GetArticlesBySql(sqlAll, new SqlParameter("@author", userId));
        }
        /// <summary>
        /// 通过sql语句获得文章列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private static IList<Article> GetArticlesBySql(string sql, params SqlParameter[] values)
        {
            List<Article> list = new List<Article>();
            DataTable table = DBHelper.GetDataSet(sql, values);
            foreach (DataRow row in table.Rows)
            {
                Article article = new Article();

                article.Id = (int)row["Id"];
                article.Title = (string)row["Title"];
                article.Contents = (string)row["Contents"];
                article.PubDate = (DateTime)row["PubDate"];
                article.Clicks = (int)row["Clicks"];
                article.Author = UserService.GetUserById((int)row["AuthorId"]); //FK
                list.Add(article);
            }
            return list;
        }
        /// <summary>
        /// 修改文章信息
        /// </summary>
        /// <param name="article"></param>
        public static void ModifyArticle(Article article)
        {
            string sql =
                "UPDATE Articles " +
                "SET " +
                    "AuthorId = @AuthorId, " + //FK
                    "Title = @Title, " +
                    "Contents = @Contents, " +
                    "PubDate = @PubDate, " +
                    "Clicks = @Clicks " +
                "WHERE Id = @Id";

            SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@Id", article.Id),
					new SqlParameter("@AuthorId", article.Author.Id), //FK
					new SqlParameter("@Title", article.Title),
					new SqlParameter("@Contents", article.Contents),
					new SqlParameter("@PubDate", article.PubDate),
					new SqlParameter("@Clicks", article.Clicks)
				};

            DBHelper.ExecuteCommand(sql, para);
        }
     
        /// <summary>
        /// 获得所有文章
        /// </summary>
        /// <returns></returns>
        public static IList<Article> GetAllArticles()
        {
            string sqlAll = "SELECT * FROM Articles order by PubDate DESC";
            return GetArticlesBySql(sqlAll);
        }
        /// <summary>
        /// 通过sql语句获得文章列表
        /// </summary>
        /// <param name="safeSql"></param>
        /// <returns></returns>
        private static IList<Article> GetArticlesBySql(string safeSql)
        {
            List<Article> list = new List<Article>();
            DataTable table = DBHelper.GetDataSet(safeSql);
            foreach (DataRow row in table.Rows)
            {
                Article article = new Article();
                article.Id = (int)row["Id"];
                article.Title = (string)row["Title"];
                article.Contents = (string)row["Contents"];
                article.PubDate = (DateTime)row["PubDate"];
                article.Clicks = (int)row["Clicks"];
                article.Author = UserService.GetUserById((int)row["AuthorId"]); //FK
                list.Add(article);
            }
            return list;
        }
    }
}
