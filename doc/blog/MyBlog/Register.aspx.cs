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

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, ImageClickEventArgs e)
    {
        User user = new User();
        user.LoginId = this.txtLoginId.Text;
        user.LoginPwd = this.txtLoginPwd.Text;
        user.Name = this.txtName.Text;
        
        user.QQ = this.txtQQ.Text;
        user.Mail = this.txtEmail.Text;

        if (!UserManager.Register(user))
        {
            this.ltMain.Text = "<script>alert('用户名已使用！请重新选择！')</script>";
        }
        else
        {
            this.ltMain.Text = "<script>alert('注册成功！');window.location='Default.aspx'</script>";
        }

    }
   
}
