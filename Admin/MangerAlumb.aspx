<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MangerAlumb.aspx.cs" Inherits="Admin_MangerAlumb" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:FormView ID="FormView1" Runat="server"
				DataSourceID="ObjectDataSource1" DefaultMode="Insert"
				BorderWidth="0px" CellPadding="0">
				<InsertItemTemplate>
                    标题:
                    <asp:TextBox ID="CaptionTextBox" runat="server" Text='<%# Bind("Caption") %>'>
                    </asp:TextBox><br />
                   
                    <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                        Text="插入">
                    </asp:LinkButton>
                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="取消">
                    </asp:LinkButton>
				</InsertItemTemplate>
        <EditItemTemplate>         
          标题:
            <asp:TextBox ID="CaptionTextBox" runat="server" Text='<%# Bind("Caption") %>'>
            </asp:TextBox><br />
         
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="更新">
            </asp:LinkButton>
            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="取消">
            </asp:LinkButton>
        </EditItemTemplate>
			</asp:FormView>
    &nbsp;
    <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="False" BorderStyle="None"
        BorderWidth="0px" CellPadding="6" DataKeyNames="AlbumID" DataSourceID="ObjectDataSource1"
        ShowHeader="false" Width="420px">
        <EmptyDataTemplate>
            您当前没有相册。
        </EmptyDataTemplate>
        <EmptyDataRowStyle CssClass="emptydata" />
        <Columns>
            <asp:TemplateField>
                <ItemStyle Width="116" />
                <ItemTemplate>
             
                                <a href='Photos.aspx?AlbumID=<%# Eval("AlbumID") %>'>
                                    <img alt="示例照片，相册编号 <%# Eval("AlbumID") %>"  src="../Handler.ashx?AlbumID=<%# Eval("AlbumID") %>&Size=S"
                                        style="border: 4px solid white" /></a>
                         
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle Width="280" />
                <ItemTemplate>
                    <div style="padding: 8px 0;">
                        <b>
                            <%# Server.HtmlEncode(Eval("Caption").ToString()) %>
                        </b>
                        <br />
                        <%# Eval("Count") %>
                        张照片
                    </div>
                    <div style="width: 100%; text-align: right;">
                        <asp:Button ID="ImageButton2" runat="server" CommandName="Edit"  Text="编辑" />                 
                        <asp:Button ID="ImageButton3" runat="server" CommandName="Delete" Text="删除" />
                    </div>
                </ItemTemplate>
                <EditItemTemplate>
                    <div style="padding: 8px 0;">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="textfield" Text='<%# Bind("Caption") %>'
                            Width="160">
                        </asp:TextBox>
                        
                    </div>
                    <div style="width: 100%; text-align: right;">
                        <asp:Button ID="ImageButton4" runat="server" CommandName="Update" Text="更新"  />
                        <asp:Button ID="ImageButton5" runat="server" CommandName="Cancel"   Text="取消"/>
                    </div>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
		<asp:ObjectDataSource ID="ObjectDataSource1" Runat="server" TypeName="PhotoManager" 
		SelectMethod="GetAlbums"
		InsertMethod="AddAlbum" 
		DeleteMethod="RemoveAlbum" 
		UpdateMethod="EditAlbum" >
	</asp:ObjectDataSource>
   
</asp:Content>

