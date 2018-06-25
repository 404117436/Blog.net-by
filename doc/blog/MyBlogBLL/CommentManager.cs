using System;
using System.Collections.Generic;
using System.Text;
using MyBlogModels;
using MyBlogDAL;
namespace MyBlogBLL
{
    public static class CommentManager
    {
        /// <summary>
        /// ��������id��ø����µ���������
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        public static int  GetCommentNumber(int ArticleId)
        {
            return CommentService.GetCommentNumber(ArticleId);
        }
        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static Comment AddComment(Comment comment)
        {
            return CommentService.AddComment(comment);
        }
        /// <summary>
        /// ͨ������id�������
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public static IList<Comment> GetCommentByArticleId(int articleId)
        {
            return CommentService.GetCommentByArticleId(articleId);
        }
    }
}
