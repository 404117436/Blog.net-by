using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyBlogModels;
using MyBlogBLL;

/// <summary>
/// 常用的处理方法的摘要说明
/// </summary>
public static class CommonHandler
{
    /// <summary>
    /// 截断字符串
    /// </summary>
    /// <param name="content"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string CutString(object content, int num)
    {
        if (content.ToString().Length > num - 2)
            return content.ToString().Substring(0, num - 2) + "...";
        else
            return content.ToString();
    }
    /// <summary>
    /// 获得评论总数
    /// </summary>
    /// <param name="ArticleId"></param>
    /// <returns></returns>
    public static int GetCommentNumber(int ArticleId)
    {
        return CommentManager.GetCommentNumber(ArticleId);
    }

}
