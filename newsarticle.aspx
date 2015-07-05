<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="newsarticle.aspx.cs" Inherits="newsarticle" Title="Untitled Page" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
    <!--download from 51aspx.com(５１ａｓｐｘ．ｃｏｍ)-->

        <table  align=center width="100%" cellpadding=0 cellspacing=2>
            <tr>
                <td align=center><asp:Label ID="lbltitle" runat="server" Text="Label" Font-Bold="True" Font-Size="14px" ForeColor="Red"></asp:Label> 
                </td>            
            </tr>
            <tr><td style="height: 42px">
            <table style="background-color: #eeeeee" width="100%"><tr>
                <td >发贴时间:<asp:Label ID="lblposttime" runat="server" Text="Label"></asp:Label>
                </td>
                <td >
                    阅读次数：<asp:Label ID="Lbl_readcount" runat="server" Text="Lbl_readcount"></asp:Label></td>
                <td >评论数:<asp:Label ID="lblCommet" runat="server" Text="Label"></asp:Label>
                </td>
                <td >发贴人:<asp:Label ID="lblcname" runat="server" Text="Label"></asp:Label>
                <td> <asp:LoginView ID="LoginView1" runat="server">
                        <LoggedInTemplate>
                            <a href=<%=Url %>>编辑</a> | <a href=<%=Durl %>>删除</a>
                           
                        </LoggedInTemplate>
                    </asp:LoginView>
                </td>
                </tr></table>
                
                </td>
            </tr>
            <tr>
                <td style="margin-top:5px; margin-left:5px" >
                <br />
                <asp:Label ID="lblcontent" runat="server" Text="Label"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td colspan=4 >
               
                </td>
                
            </tr>
        </table>  
          <table align="center"  style="border-top:2px solid #cccccc" width="100%">
          <tr><th class="wypl" align="left">网友评论:</th></tr>
          <tr><td>
        <asp:DataList ID="DataListAllComment" runat="server" Width="100%" >
            <ItemTemplate>   
             <table  align="center" style="border-bottom:1px solid #ccCCcc"  width="100%">                          
                    <tr >
                    <td width="20%">
                    <%# Eval("gauthor")%>              
                    </td>
                    <td>
                    <table><tr>
                        <td   align="left" valign=" bottom">
                        <%# Eval("gtime") %><asp:LoginView ID="LoginView2" runat="server">
                        <LoggedInTemplate>
                            <a href="admin/deletegentie.aspx?id=<%# Eval("id") %>&artid=<%=ii %>">删除</a>
                           
                        </LoggedInTemplate>
                    </asp:LoginView>
                        </td></tr><tr><td>
                        <%# Eval("gcontent") %>
                        </td></tr>
                        </table>  
                        </td>                     
                    </tr>              
             </table>
            </ItemTemplate>
        </asp:DataList> 
        </td></tr><tr><td>
        <br />
        <font class="wypl"><b>发帖区：</b></font>
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br />
        发贴人:
        <asp:TextBox ID="tb_author" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_author"
                ErrorMessage="发帖人不要为空"></asp:RequiredFieldValidator><br />
        <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" Height="300px" Width="620px">
        </FCKeditorV2:FCKeditor>
        <br />
        <asp:Button ID="summit_Btn" runat="server" OnClick="summit_Btn_Click" Text="提交" />
        </td></tr>
        </table>
        </div>
        
 
</asp:Content>

