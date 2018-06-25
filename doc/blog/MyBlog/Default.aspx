<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="首页" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    
    <asp:Repeater ID="rpArticle" runat="server"  >
   <HeaderTemplate> <div id="top1" >
        <span></span><strong style="font-size: large">全部文章</strong></div><br />  <br /></HeaderTemplate>
    <ItemTemplate >
            <ul class="title_ul">
                <li class="title_list0" ><a href="article.aspx?aid=<%# Eval("Id")%>"><%#Eval("Title") %></a></li>  
                <li class="title_list1"><%#Eval("author.Name")%></li> 
                        
            </ul>
            </ItemTemplate>  
    

    
    </asp:Repeater>

     <br />
    
    <webdiyer:AspNetPager ID="anpPager" runat="server" 
        OnPageChanged="anpPager_PageChanged" CustomInfoSectionWidth="38%"  style="font-size: large">
    </webdiyer:AspNetPager>
    <br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>

