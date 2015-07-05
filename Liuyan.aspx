<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Liuyan.aspx.cs" Inherits="Liuyan" Title="留言本" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
       
               <div class="line">&nbsp;</div>
            <asp:DataList ID="Data_list_liuyan" runat="server" Width="100%">
                <ItemTemplate>
                    <table width="100%" cellpadding=0 cellspacing=0 style="margin:0px 0px 0px 0px;">
                        <tr>
                            <td rowspan="3" class="y" width="20%">
                            <%# Eval("author") %>
                            </td>
                            <td colspan="2" class="yx">
                            <%#Eval("time") %>|<a href="admin/deleteliuyan.aspx?id=<%#Eval("ID")%>">删除</a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="yx"><%#Eval("content") %>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="y">
                                omycle回复：<FONT color="RED"><%#Eval("huifu") %></FONT>
                                <asp:LoginView ID="LoginView1" runat="server">
                                 <LoggedInTemplate>
                                 <a href="admin/EditHuifu.aspx?id=<%# Eval("ID") %>">编辑回复</A>
                                  </LoggedInTemplate>
                                </asp:LoginView>
                                </td>
                        </tr>
                    </table>
                    <div class="line3">&nbsp;</div>
                </ItemTemplate>
               
            </asp:DataList>
            <br />
            <uc1:Pagination ID="Pagination1" runat="server" />
                   <div class="line">&nbsp;</div>
            <br />
            <strong> 姓名</strong>：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不要空!" ControlToValidate="TextBox1" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
        <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="Btn_summit" runat="server" OnClick="Btn_summit_Click" Text="提交留言" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FCKeditor1"
        ErrorMessage="内容不要为空"></asp:RequiredFieldValidator></div>
</asp:Content>

