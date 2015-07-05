<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Blog.aspx.cs" Inherits="Blog" Title="Untitled Page" %>
<%@ Register Src="Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <div align="right">
     <asp:LoginView ID="LoginView1" runat="server">
                        <LoggedInTemplate>
                        
                            <a href="postbord.aspx">
                                <img src="images/ico_postnew.gif" />发表文章</a>
                        </LoggedInTemplate>
                    </asp:LoginView>
   </div>
        <asp:DataList ID="DataListViewAll" runat="server" Width="100%" >
            <ItemTemplate>
                <div class="tit"><a href="newsarticle.aspx?id=<%# Eval("id") %>"><%# Eval("title") %></a></div><br />
                <div class="date">作者：<%# Eval("author") %>              
                &nbsp; &nbsp; &nbsp; 文章类别：<%# Eval("leibiestr") %>
                &nbsp; &nbsp; &nbsp; &nbsp; 阅读次数：<%# Eval("readcount") %>
                &nbsp; &nbsp; &nbsp; 跟帖次数：<%#Eval("gentiecount")%>
                    <asp:LoginView ID="LoginView1" runat="server">
                        <LoggedInTemplate>
                            <a href="admin/editpage.aspx?id=<%# Eval("id") %>">编辑</a>&nbsp;
                            <a href="admin/deletepage.aspx?id=<%# Eval("id")%>">删除</a>                           
                        </LoggedInTemplate>
                    </asp:LoginView>
                </div><br />              
                <%#Eval("content")%>
                
                <div class="line">&nbsp;</div>
            </ItemTemplate>
        </asp:DataList><br />
        &nbsp;<uc1:Pagination ID="Pagination1" runat="server" />
    </div>
</asp:Content>


