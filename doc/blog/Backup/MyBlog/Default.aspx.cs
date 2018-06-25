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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            anpPager.RecordCount = 100;
            DataBinds();
        }       
    }

    private void DataBinds()
    {
        PagedDataSource pdsList = new PagedDataSource();
        //对PagedDataSource 对象的相关属性赋值        
        pdsList.DataSource = ArticleManager.GetAllArticles();
        pdsList.AllowPaging = true;
        pdsList.PageSize = anpPager.PageSize;
        pdsList.CurrentPageIndex = anpPager.CurrentPageIndex-1;
        rpArticle.DataSource = pdsList;
        rpArticle.DataBind();
    }
    protected void anpPager_PageChanged(object sender, EventArgs e)
    {
        DataBinds();
    }
}
