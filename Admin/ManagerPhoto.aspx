<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManagerPhoto.aspx.cs" Inherits="Admin_ManagerPhoto" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ObjectDataSource ID="ObjectDataSource1" Runat="server" TypeName="PhotoManager" 
		SelectMethod="GetPhotos"
		InsertMethod="AddPhoto" 
		DeleteMethod="RemovePhoto" 
		UpdateMethod="EditPhoto" >
		<SelectParameters>
			<asp:QueryStringParameter Name="AlbumID" Type="Int32" QueryStringField="AlbumID" />
		</SelectParameters>
		<InsertParameters>
			<asp:QueryStringParameter Name="AlbumID" Type="Int32" QueryStringField="AlbumID" />
		</InsertParameters>
	</asp:ObjectDataSource>
  <asp:FormView ID="FormView1" Runat="server" 
				DataSourceID="ObjectDataSource1" DefaultMode="insert"
				BorderWidth="0px" CellPadding="0" OnItemInserting="FormView1_ItemInserting">
				<InsertItemTemplate>
					<asp:RequiredFieldValidator	ID="RequiredFieldValidator1" Runat="server" ErrorMessage="必须选择标题。" ControlToValidate="PhotoFile" Display="Dynamic" Enabled="false" />
					<p>
						照片<br />
						<asp:FileUpload ID="PhotoFile" Runat="server" Width="416" FileBytes='<%# Bind("BytesOriginal") %>' CssClass="textfield" /><br />
						标题<br />
						<asp:TextBox ID="PhotoCaption" Runat="server" Width="326" Text='<%# Bind("Caption") %>' CssClass="textfield" />
					</p>
					<p style="text-align:right;">
					
					  <asp:Button ID="AddNewPhotoButton" CommandName="Insert" runat="server" Text="提交" />
					</p>
				</InsertItemTemplate>
			</asp:FormView>
			
			
			<asp:gridview id="GridView1" runat="server" datasourceid="ObjectDataSource1"  
				datakeynames="PhotoID" cellpadding="3" EnableViewState="False" AllowPaging=true  
				autogeneratecolumns="False" BorderStyle="None" BorderWidth="1px" width="100%" showheader="False"  BackColor="White" BorderColor="#999999" GridLines="Vertical" PageSize="6" >
				<EmptyDataTemplate>
					当前没有照片。
				</EmptyDataTemplate>
				<columns>
					<asp:TemplateField>
						<ItemTemplate>
							
									<a href='ViewPic.aspx?AlbumID=<%# Eval("AlbumID") %>&Page=<%# ((GridViewRow)Container).RowIndex %>'>
										<img src='../Handler.ashx?Size=M&PhotoID=<%# Eval("PhotoID") %>'  border=0  /></a>
									
						</ItemTemplate>
					</asp:TemplateField>
					<asp:boundfield headertext="Caption" datafield="Caption" />
					<asp:TemplateField>
						<ItemTemplate>
							<div style="width:100%;text-align:right;">
								<asp:Button ID="ImageButton2" Runat="server" CommandName="Edit"  Text="编辑" />
								<asp:Button ID="ImageButton3" Runat="server" CommandName="Delete" Text="删除"  />
							</div>
						</ItemTemplate>
						<EditItemTemplate>
							<div style="width:100%;text-align:right;">
								<asp:Button ID="ImageButton4" Runat="server" CommandName="Update" Text="更新"/>
								<asp:Button ID="ImageButton5" Runat="server" CommandName="Cancel"  Text="取消" />
							</div>
						</EditItemTemplate>
					</asp:TemplateField>
				</columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="Gainsboro" />
			</asp:gridview>
  
</asp:Content>

