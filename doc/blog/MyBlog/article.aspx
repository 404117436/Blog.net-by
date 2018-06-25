<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="article.aspx.cs" Inherits="article" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">


<div id="top">
        <span></span><strong style="font-size: large">文章内容</strong></div>
    <h2 class="title">
        <asp:Label ID="lbltitle" runat="server"></asp:Label>
    </h2>
    <p class="postdate">
        <asp:Label ID="lblposttime" runat="server"></asp:Label>
       
    </p>
    <div class="content">
        <p>
            <asp:Label ID="lblcontent" runat="server"></asp:Label>
        </p>
    </div>


<h2 class="title">
    <asp:ObjectDataSource ID="odsComments" runat="server" SelectMethod="GetCommentByArticleId" TypeName="MyBlogBLL.CommentManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="articleId" QueryStringField="aid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <span style="float: right; padding-bottom: 2px; font-size: 12px;font-size: large">
            </span>访客评论</h2>
            <asp:DataList ID="dlAllComment" runat="server" DataSourceID="odsComments">
                <ItemTemplate>
                    <p class="lesscontent">
                        <%# Eval("contents") %>
                    </p>
                    <p class="lessdate">
                        <%# Eval("PubDate", "{0:R}")%><span >昵称：<%# Eval("AuthorName")%></span>
                    </p>
                </ItemTemplate>
            </asp:DataList>

            <h2 class="title">
                发表评论(请不要超过200字)</h2>
            <div class="formbox">
                
                    <table style="position: relative; width: 571px;">
                        <tr>
                            <td style="width: 70px">
                                昵称：</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtCommentName" runat="server" Style="position: relative"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 70px">
                                评论内容：</td>
                            <td style="width: 100px"><asp:TextBox ID="txtComment" TextMode="MultiLine" runat="server" Columns="95"
                        Rows="8" TabIndex="4" Text="" Width="471px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>                
             
                &nbsp;<input id="btnCommit" type="button" value="提  交" class="formbutton" 
                    runat="server" onserverclick="btnCommit_ServerClick" />
                &nbsp; &nbsp;
                <input id="btnReset" type="reset" value="重  置" class="formbutton" runat="server" />
                &nbsp;
                <asp:Label ID="lblErrorComment" runat="server" Visible="False" Width="148px"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvComment" runat="server" ControlToValidate="txtComment"
                    ErrorMessage="*"></asp:RequiredFieldValidator></div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>

