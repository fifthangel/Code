using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_EditHuifu : System.Web.UI.Page
{
    string id = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                id = Request.QueryString["id"].ToString();
                liuyan ly = new liuyan();
                LiuyanOperation lyo = new LiuyanOperation();
                ly = lyo.getByAid(id);
                TextBox1.Text = ly.huifu;
            }
            catch
            { }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        id = Request.QueryString["id"].ToString();
        liuyan ly = new liuyan();
        LiuyanOperation lyo = new LiuyanOperation();
        ly = lyo.getByAid(id);
        string t = TextBox1.Text.ToString();
        ly.huifu = t;
        bool b=lyo.update(ly);
        if (b)
            Response.Write("回复更新成功！");
        Response.Redirect("../Liuyan.aspx");
    }
}
