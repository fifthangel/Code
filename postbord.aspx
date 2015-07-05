<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="postbord.aspx.cs" Inherits="postbord" Title="Untitled Page" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
        <table style="width: 100%;">
            <tr>
                <td style=" font-size:14px; font-weight:bold; width: 48px;" align="left" valign="middle">
                    <asp:Label ID="Label1" runat="server" Text="标题" Width="37px"></asp:Label>：</td>
                <td >
                    <asp:TextBox ID="Tit_tbx" runat="server" Width="496px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2"  align="left" valign=top>
                    &nbsp;<FCKeditorV2:FCKeditor ID="FCKeditor_content" runat="server" Height="500px" Width="620px">
                    </FCKeditorV2:FCKeditor>
                </td>
            </tr>
             <tr>
                <td colspan="2"  align="left">
                    <asp:DropDownList ID="DropDownList_liebie" runat="server" DataSourceID="SqlDataSource_leibie" DataTextField="LeiBie" DataValueField="ID" Width="160px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="Submit_btn" runat="server" Text="提交" OnClick="Submit_btn_Click" />
                    </td>
            </tr>
           
        </table>
    </div>
        <asp:SqlDataSource ID="SqlDataSource_leibie" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [LeiBie], [ID] FROM [LeiBieTable]"></asp:SqlDataSource>
    
</asp:Content>

