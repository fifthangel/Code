<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Viewphoto.aspx.cs" Inherits="Viewphoto" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<asp:FormView ID="FormView1" runat="server" BorderStyle="None" BorderWidth="0px"
        CellPadding="0" CssClass="view" DataSourceID="ObjectDataSource1"
        EnableViewState="False" AllowPaging="True">
        <ItemTemplate>
            <p>
                <%# Server.HtmlEncode(Eval("Caption").ToString()) %>
            </p>
            <img alt='照片编号 <%# Eval("PhotoID") %>' src="Handler.ashx?PhotoID=<%# Eval("PhotoID") %>&Size=L"
                style="border: 4px solid white" /></a>
        </ItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetPhotos"
        TypeName="PhotoManager">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="AlbumID" QueryStringField="AlbumID"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

