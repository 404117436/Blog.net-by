<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PostAticle.aspx.cs" Inherits="PostAticle"   ValidateRequest="false"  Title="发表文章" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">



<h2 class="title">
        发表文章</h2>
    <div class="formbox">
        <p>
            文章标题:
            <asp:TextBox ID="txtTitle" runat="server" Text="" CssClass="formfield" Width="315px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfdTitle" runat="server" ControlToValidate="txtTitle"
                Display="Dynamic" ErrorMessage="*" ValidationGroup="content"></asp:RequiredFieldValidator></p>
       
        <p>
            文章内容:</p>
        <p>
            &nbsp;<FTB:FreeTextBox ID="ftbContent" runat="server" Width="500px" BackColor="WhiteSmoke" GutterBackColor="224, 224, 224">
            </FTB:FreeTextBox>
        </p>
        <p>
            &nbsp;
            <asp:ImageButton ID="imgPost" runat="server" ImageUrl="~/images/post.jpg" OnClick="imgPost_Click"
                Style="position: relative" />
            <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="~/images/cancel.jpg" OnClick="imgCancel_Click"
                Style="position: relative" />
            <asp:RequiredFieldValidator ID="rfdContent" runat="server" ControlToValidate="ftbContent"
                Display="Dynamic" ErrorMessage="*" ValidationGroup="content"></asp:RequiredFieldValidator>
            <asp:Label ID="lblMsg" runat="server" Width="106px"></asp:Label></p>
    </div>







</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>

