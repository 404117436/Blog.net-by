<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="首页" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    
    <asp:Repeater ID="rpArticle" runat="server"  >
   <HeaderTemplate> <div id="top1" >
        <span></span><strong>全部文章</strong></div><br />  <br /></HeaderTemplate>
    <ItemTemplate >
            <ul class="title_ul">
                <li class="title_list0" ><a href="article.aspx?aid=<%# Eval("Id")%>"><%#Eval("Title") %></a></li>  
                <li class="title_list1"><%#Eval("author.Name")%></li> 
                <li class="title_list2"><%#Eval("PubDate")%> </li>             
            </ul>
            </ItemTemplate>  
    

    
    </asp:Repeater>

    
    
    <webdiyer:AspNetPager ID="anpPager" runat="server" OnPageChanged="anpPager_PageChanged">
    </webdiyer:AspNetPager>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>

