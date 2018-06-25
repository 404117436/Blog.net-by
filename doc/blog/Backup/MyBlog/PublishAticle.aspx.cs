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
public partial class PostAticle : System.Web.UI.Page
{
    User user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentUser"] != null)
        {
            user = (User)Session["CurrentUser"];
        }
        else
        {
            Response.Redirect("~/refresh.aspx?msg=" + "对不起,只有管理员才能登陆发表文章!");
            return;
        }
    }
    protected void imgCancel_Click(object sender, ImageClickEventArgs e)
    {
        this.txtTitle.Text = null;
        this.ftbContent.Text = null;
    }
    protected void imgPublish_Click(object sender, ImageClickEventArgs e)
    {
        Article article = new Article();
        article.Title = this.txtTitle.Text.ToString();
        article.Contents = this.ftbContent.Text.ToString();
        article.Author = user;
        article.Clicks = 0;
        article.PubDate = DateTime.Now;
        if (ArticleManager.AddArticle(article) != null)
        {
            Response.Redirect("~/refresh.aspx?msg=" + "发表文章成功！");
        }
        else 
        {
            this.lblMsg.Text = "很遗憾,发表失败,请重新尝试！";
        }
    }
}
