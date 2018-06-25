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
        /// 根据文章id获得该文章的评论总数
        /// </summary>
        /// <param name="ArticleId"></param>
        /// <returns></returns>
        public static int  GetCommentNumber(int ArticleId)
        {
            return CommentService.GetCommentNumber(ArticleId);
        }
        /// <summary>
        /// 添加新评论
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static Comment AddComment(Comment comment)
        {
            return CommentService.AddComment(comment);
        }
        /// <summary>
        /// 通过文章id获得评论
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public static IList<Comment> GetCommentByArticleId(int articleId)
        {
            return CommentService.GetCommentByArticleId(articleId);
        }
    }
}
