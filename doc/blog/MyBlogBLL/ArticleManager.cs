using System;
using System.Collections.Generic;
using System.Text;
using MyBlogModels;
using MyBlogDAL;
namespace MyBlogBLL
{
   public static class ArticleManager
    {
       /// <summary>
       /// 添加新文章
       /// </summary>
       /// <param name="article"></param>
       /// <returns></returns>
       public static Article AddArticle(Article article)
       {
           return ArticleService.AddArticle(article);
       }
       /// <summary>
       /// 通过用户id获得该用户的所有文章列表
       /// </summary>
       /// <param name="userid"></param>
       /// <returns></returns>
       public static IList<Article> GetArticleByUserId(int userid)
       {
           return ArticleService.GetUserAllArticles(userid);
       }
       /// <summary>
       /// 根据文章id删除文章
       /// </summary>
       /// <param name="id"></param>
       public static void DeleteArticleById(int id)
       {
           ArticleService.DeleteArticleById(id);
       }
       /// <summary>
       /// 通过id获得文章
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static Article GetArticleById(int id)
       {
           return ArticleService.GetArticleById(id);
       }

       /// <summary>
       /// 更新文章信息
       /// </summary>
       /// <param name="article"></param>
       public static void ModifyArticle(Article article)
       {
           ArticleService.ModifyArticle(article);
       }
       /// <summary>
       /// 根据文章id修改文章的标题和内容
       /// </summary>
       /// <param name="title"></param>
       /// <param name="contents"></param>
       /// <param name="Id"></param>      
       public static void ModifyArticle(string title,string contents,int Id)
       {
          
           Article article = ArticleService.GetArticleById(Id);

           article.Title = title;
           article.Contents = contents;
           article.PubDate = DateTime.Now;           
           ArticleService.ModifyArticle(article);
       }
       /// <summary>
       /// 获得文章列表
       /// </summary>
       /// <returns></returns>
       public static IList<Article> GetAllArticles()
       {
           return ArticleService.GetAllArticles();
       }











    }
}
