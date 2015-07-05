<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TheAlumbPhotos.aspx.cs" Inherits="TheAlumbPhotos" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetPhotos"
        TypeName="PhotoManager">
        <SelectParameters>
            <asp:QueryStringParameter Name="AlbumID" QueryStringField="AlbumID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" RepeatColumns="4"
        RepeatDirection="Horizontal" Width="100%">
        <ItemTemplate>
            Caption:
            <asp:Label ID="CaptionLabel" runat="server" Text='<%# Eval("Caption") %>'></asp:Label><br />
            PhotoID:
            <a href='Viewphoto.aspx?AlbumID=<%# Eval("AlbumID") %>&Page=<%# Container.ItemIndex %>'><img src="Handler.ashx?PhotoID=<%# Eval("PhotoID") %>&Size=S" class="photo_198" style="border:4px solid white"  /></a><br />
            AlbumID:
            <asp:Label ID="AlbumIDLabel" runat="server" Text='<%# Eval("AlbumID") %>'></asp:Label><br />
            <br />
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

