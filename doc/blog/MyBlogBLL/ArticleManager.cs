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
       /// ���������
       /// </summary>
       /// <param name="article"></param>
       /// <returns></returns>
       public static Article AddArticle(Article article)
       {
           return ArticleService.AddArticle(article);
       }
       /// <summary>
       /// ͨ���û�id��ø��û������������б�
       /// </summary>
       /// <param name="userid"></param>
       /// <returns></returns>
       public static IList<Article> GetArticleByUserId(int userid)
       {
           return ArticleService.GetUserAllArticles(userid);
       }
       /// <summary>
       /// ��������idɾ������
       /// </summary>
       /// <param name="id"></param>
       public static void DeleteArticleById(int id)
       {
           ArticleService.DeleteArticleById(id);
       }
       /// <summary>
       /// ͨ��id�������
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public static Article GetArticleById(int id)
       {
           return ArticleService.GetArticleById(id);
       }

       /// <summary>
       /// ����������Ϣ
       /// </summary>
       /// <param name="article"></param>
       public static void ModifyArticle(Article article)
       {
           ArticleService.ModifyArticle(article);
       }
       /// <summary>
       /// ��������id�޸����µı��������
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
       /// ��������б�
       /// </summary>
       /// <returns></returns>
       public static IList<Article> GetAllArticles()
       {
           return ArticleService.GetAllArticles();
       }











    }
}
