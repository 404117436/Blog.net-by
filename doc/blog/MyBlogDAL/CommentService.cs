using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using MyBlogModels;
namespace MyBlogDAL
{
    public static class CommentService
    {
        /// <summary>
        /// 添加新评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static Comment AddComment(Comment comment)
        {
            string sql =
                "INSERT Comments (ArticleId, AuthorName, Contents, PubDate)" +
                "VALUES (@ArticleId, @AuthorName, @Contents, @PubDate)";

            sql += " ; SELECT @@IDENTITY";
            SqlParameter[] para = new SqlParameter[]
				{
					new SqlParameter("@ArticleId", comment.Article.Id), //FK
					new SqlParameter("@AuthorName", comment.AuthorName),
					new SqlParameter("@Contents", comment.Contents),
					new SqlParameter("@PubDate", comment.PubDate)
				};
            int newId = DBHelper.GetScalar(sql, para);
            return GetCommentById(newId);
        }

        /// <summary>
        /// 通过id获得评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Comment GetCommentById(int id)
        {
            string sql = "SELECT * FROM Comments WHERE Id = @Id";
            int articleId;
            SqlDataReader reader = DBHelper.GetReader(sql, new SqlParameter("@Id", id));
            if (reader.Read())
            {
                Comment comment = new Comment();

                comment.Id = (int)reader["Id"];
                comment.AuthorName = (string)reader["AuthorName"];
                comment.Contents = (string)reader["Contents"];
                comment.PubDate = (DateTime)reader["PubDate"];
                articleId = (int)reader["ArticleId"]; //FK
                reader.Close();
                comment.Article = ArticleService.GetArticleById(articleId);
                return comment;
            }
            else
            {
                reader.Close();
                return null;
            }
        }
        /// <summary>
        /// 通过文章id获得评论
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public static IList<Comment> GetCommentByArticleId(int articleId)
        {
            string sqlAll = "SELECT * FROM Comments WHERE ArticleId = @articleId";
            return GetCommentsBySql(sqlAll, new SqlParameter("@articleId", articleId));
        }
        /// <summary>
        /// 通过sql语句获得评论列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        private static IList<Comment> GetCommentsBySql(string sql, params SqlParameter[] values)
        {
            List<Comment> list = new List<Comment>();
            DataTable table = DBHelper.GetDataSet(sql, values);
            foreach (DataRow row in table.Rows)
            {
                Comment comment = new Comment();
                comment.Id = (int)row["Id"];
                comment.AuthorName = (string)row["AuthorName"];
                comment.Contents = (string)row["Contents"];
                comment.PubDate = (DateTime)row["PubDate"];
                comment.Article = ArticleService.GetArticleById((int)row["ArticleId"]); //FK
                list.Add(comment);
            }
            return list;
        }
        /// <summary>
        /// 通过文章id获得评论数量
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public static int GetCommentNumber(int articleId)
        {
            string sql = "SELECT count(*) FROM Comments WHERE ArticleId = @articleId";
            int commentNumber;
            try
            {
                commentNumber = DBHelper.GetScalar(sql, new SqlParameter("@articleId", articleId));
                return commentNumber;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
