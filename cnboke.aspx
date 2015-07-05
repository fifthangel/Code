<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cnboke.aspx.cs" Inherits="cnboke" Title="Untitled Page" %>

<%@ Register Assembly="RssToolkit" Namespace="RssToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:RssDataSource ID="RssDataSource1" runat="server" Url="http://www.cnblogs.com/rss">
    </cc1:RssDataSource>
    <table id="main" >
    <tr><td>
    <asp:DataList ID="DataList1" runat="server" DataSourceID="RssDataSource1" >
    
        <ItemTemplate>
          <div class="tit"><a href="<%# Eval("link") %>"><%# Eval("title") %></a></div><br />
                <div class="date">
                发表时间：<%# Eval("pubDate") %>
                
                </div><br />              
               <%# Eval("description") %>
                
                <div class="line">&nbsp;</div>
         
        </ItemTemplate>
    </asp:DataList>
    </td></tr></table>
 
</asp:Content>

