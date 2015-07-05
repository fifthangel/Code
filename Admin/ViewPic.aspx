<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPic.aspx.cs" Inherits="Admin_ViewPic" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:FormView ID="FormView1" runat="server" BorderStyle="None" BorderWidth="0px" CellPadding="0" CssClass="view" DataSourceID="ObjectDataSource1" EnableViewState="False" AllowPaging="True">
        <ItemTemplate>
            <p>
                <%# Server.HtmlEncode(Eval("Caption").ToString()) %>
            </p>
          
                        <img alt='照片编号 <%# Eval("PhotoID") %>'  src="../Handler.ashx?PhotoID=<%# Eval("PhotoID") %>&Size=L"
                            style="border: 4px solid white" /></a>
        </ItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ObjectDataSource1" Runat="server" TypeName="PhotoManager" 
		SelectMethod="GetPhotos">
		<SelectParameters>
			<asp:QueryStringParameter Name="AlbumID" Type="Int32" QueryStringField="AlbumID" DefaultValue="0"/>
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>

