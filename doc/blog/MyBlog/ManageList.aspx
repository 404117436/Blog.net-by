<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"    CodeFile="ManageList.aspx.cs" Inherits="ManageList" Title="管理博客" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">

    <asp:GridView ID="gvArticleList" runat="server" AutoGenerateColumns="False" DataSourceID="oodsArticleList" AllowPaging="True"  Width="600px" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id" OnRowCommand="gvArticleList_RowCommand">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="文章标题" SortExpression="Title" />
            <asp:BoundField DataField="PubDate" HeaderText="发表日期" SortExpression="PubDate" DataFormatString="{0:D}" />
            <asp:BoundField DataField="Clicks" HeaderText="文章点击率" SortExpression="Clicks" />
            <asp:TemplateField HeaderText="评论数">
                <ItemTemplate>
                    <asp:Label ID="lblMessage" runat="server" Style="position: relative" Text='<%# Common.GetCommentNumber( int.Parse(Eval("Id").ToString())) %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkbtnDetail" runat="server" CommandName="view" CommandArgument='<%#Eval("Id") %>'>详 细</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <EditRowStyle BackColor="#2461BF" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="oodsArticleList" runat="server" SelectMethod="GetArticleByUserId"
        TypeName="MyBlogBLL.ArticleManager" DeleteMethod="DeleteArticleById">
        <SelectParameters>
            <asp:SessionParameter Name="userid" SessionField="userid" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>

