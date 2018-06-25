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

public partial class UserDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CurrentUser"] != null)
        {
            User user = new User();
            user = (User)Session["CurrentUser"];
            Session["userid"] = user.Id;
        }
        else
        {
            Session["userid"] = Convert.ToInt32(Request.QueryString["id"]); 
        }
    }
    /// <summary>
    /// 截断字符串
    /// </summary>
    /// <param name="contents"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public string GetCut(object content, int num)
    {
        return Common.CutString(content,num);
    }




















}
