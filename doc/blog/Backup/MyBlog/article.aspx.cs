using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyBlogModels;
using MyBlogBLL;
public partial class article : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            try
            {
                int id = Convert.ToInt32(Request.QueryString["aid"]);
                Article article = ArticleManager.GetArticleById(id);
                article.Clicks += 1;

                if (article == null || article.Equals(null))
                {
                    this.Page.Title = "此文章不存在,或被管理员删除,请见谅" ;
                    this.lblcontent.Text = "此文章不存在,或被管理员删除,请见谅!";
                }
                else
                {
                    this.lbltitle.Text = article.Title;
                    this.Page.Title = article.Title;
                    this.lblposttime.Text = article.PubDate.ToString();
                    this.lblcontent.Text = article.Contents;
                    article.Clicks += 1;
                    ArticleManager.ModifyArticle(article);
                }
            }
            catch
            {
                Response.Redirect("refresh.aspx?msg=" + "此文章不存在,或被管理员删除,请见谅!");
            }
        }
    }
    protected void btnCommit_ServerClick(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["aid"]);
        Article article = ArticleManager.GetArticleById(id);        
  
       string commentContent = Server.HtmlEncode(this.txtComment.Text.ToString());
       if (commentContent.Length > 250)
        {
            commentContent = commentContent.Substring(0, 250);
        }        
        Comment comment = new  Comment();
        comment.Article = article;
        comment.AuthorName = this.txtCommentName.Text.ToString();
        comment.Contents = commentContent;
        comment.PubDate = DateTime.Now;
        if (CommentManager.AddComment(comment) != null)
        {
            Response.Redirect("article.aspx?aid=" + id);
            Response.Write("alert(\"恭喜您，评论发表成功！\")");
        }
        else
        {
            this.lblErrorComment.Text = "很抱歉,你的评论发表失败,请重新尝试!";
        }
    }
}
