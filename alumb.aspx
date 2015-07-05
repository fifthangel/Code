<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="alumb.aspx.cs" Inherits="alumb" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>

<a href="admin/mangeralumb.aspx">管理相册</a>
        </LoggedInTemplate>
    </asp:LoginView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAlbums"
        TypeName="PhotoManager"></asp:ObjectDataSource>
        
      
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="3"
        RepeatDirection="Horizontal" Width="100%">
        <ItemTemplate>
              <img src="Handler.ashx?AlbumID=<%# Eval("AlbumID") %>&Size=M" style="border:4px solid white" /><br/>         
                <a href="TheAlumbPhotos.aspx?AlbumID=<%# Eval("AlbumID") %>"><%# Eval("Caption") %> </a>(共<%# Eval("Count") %>张)<br />
     <asp:LoginView ID="LoginView2" runat="server">
        <LoggedInTemplate>
            <a href="admin/Managerphoto.aspx?Albumid=<%# Eval("AlbumID") %>"> 编辑/上传照片</a>
        </LoggedInTemplate>
    </asp:LoginView>
         <br />
           
        </ItemTemplate>
    </asp:DataList>

</asp:Content>

