<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="refresh.aspx.cs" Inherits="refresh" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">

<h2 class="title" style="left: 0px; top: 5px">
    提示信息</h2>
<p></p>
<p></p>
<p></p>
<p>
    <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label></p>
      <meta http-equiv="refresh"  content="2;URL=Default.aspx"/>

</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>

