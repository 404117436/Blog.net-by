<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserList.ascx.cs" Inherits="UserList" %>
<div class=sambar>
<h2>用户列表┊Usure Line</h2>

    <ul>
        <asp:ObjectDataSource ID="odsUserList" runat="server" SelectMethod="GetAllUsers"
            TypeName="MyBlogBLL.UserManager"></asp:ObjectDataSource>
        <asp:DataList ID="dlUserList" runat="server" RepeatColumns="1" DataSourceID="odsUserList">
            <ItemTemplate>
                <li><a href="UserDefault.aspx?id=<%# Eval("Id") %>" target="_blank">
                    <%# Eval("Name") %>
                </a></li>
            </ItemTemplate>
        </asp:DataList>
    </ul>
</div>


