<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Editpage.aspx.cs" Inherits="Admin_Editpage" Title="Untitled Page" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    标题：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <fckeditorv2:fckeditor id="FCKeditor1" runat="server"></fckeditorv2:fckeditor>
    <br />
    分类：<asp:DropDownList ID="DropDownListclass" runat="server" DataSourceID="SqlDataSource1"
        DataTextField="LeiBie" DataValueField="ID">
    </asp:DropDownList>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT [LeiBie], [ID] FROM [LeiBieTable]"></asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="更新" />

</asp:Content>

