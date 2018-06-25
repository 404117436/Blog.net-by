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
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User user;
        if (Session["CurrentUser"] != null)
        {           
            this.pnlLogin.Visible = false;
            this.lblMessage.Visible = true;
            user = (User)Session["CurrentUser"];            
            lblMessage.Text = user.Name.ToString() + "欢迎您！";
            this.pnLogin.Visible = true;
        }
    }
    protected void imgbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        User user;
        if (UserManager.Login(this.txtLoginId.Text, this.txtLoginPwd.Text, out user))
        {
            this.pnlLogin.Visible = false;
            Session["CurrentUser"] = user;
            lblMessage.Text = user.Name.ToString() + "欢迎您！";
            this.pnLogin.Visible = true;
            Response.Redirect("~/UserDefault.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或密码不正确，请重新填写')</script>");
        }
    }
    protected void imgbtnExit_Click(object sender, ImageClickEventArgs e)
    {
        Session["CurrentUser"] = null;
        this.pnLogin.Visible = false;
        
        this.lblMessage.Visible = false;
        this.pnlLogin.Visible = true;
    }
}
