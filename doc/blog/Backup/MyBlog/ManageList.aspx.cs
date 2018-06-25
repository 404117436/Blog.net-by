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
public partial class ManageList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["CurrentUser"] != null)
        {
            User user = new User();

            user = (User)Session["CurrentUser"];
            Session["userid"] = user.Id;
        }
    }

    
    protected void gvArticleList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "view")
        {
            Response.Redirect("ManageDetail.aspx?Id=" + e.CommandArgument.ToString());
        }
    }
}
