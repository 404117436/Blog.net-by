<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"    CodeFile="ManageDetail.aspx.cs" Inherits="manageDetail"   ValidateRequest="false"     Title="Untitled Page" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="odsArticle"
        Height="100px"  Width="600px" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" DataKeyNames="Id">
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="文章Id" SortExpression="Id" ReadOnly="True" />
            <asp:BoundField DataField="Title" HeaderText="文章题目" SortExpression="Title" />
            <asp:TemplateField HeaderText="文章内容" SortExpression="Contents">
                <EditItemTemplate>
                   <ftb:freetextbox id="FreeTextBox1" runat="server"   Text='<%# Bind("Contents") %>'     width="500px"></ftb:freetextbox>
                </EditItemTemplate>
               
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Contents") %>' width="500px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PubDate" HeaderText="出版日期" SortExpression="PubDate" ReadOnly="True" />
            <asp:BoundField DataField="Clicks" HeaderText="点击率" SortExpression="Clicks" ReadOnly="True" />
            <asp:CommandField ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="odsArticle" runat="server" SelectMethod="GetArticleById"
        TypeName="MyBlogBLL.ArticleManager" UpdateMethod="ModifyArticle">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="Id" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="title" Type="String" />
            <asp:Parameter Name="contents" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>

