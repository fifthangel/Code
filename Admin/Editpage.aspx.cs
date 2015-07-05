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

public partial class Admin_Editpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {     
            try
            {
                string aid = Request.QueryString["id"].ToString();
                Article at = (new ArticleOperate()).getByAid(aid);

                this.TextBox1.Text = at.title;
                Page.Title = at.title;
                this.DropDownListclass.SelectedValue = at.liebie.ToString();
              
                this.FCKeditor1.Value = at.content;
                          
            }
            catch
            {
               
            }
        }
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string aid = Request.QueryString["id"].ToString();
         string title = this.TextBox1.Text.ToString();
         int cid = Convert.ToInt32(this.DropDownListclass.SelectedValue);
        string content = this.FCKeditor1.Value.ToString();
        ArticleOperate aop = new ArticleOperate();
        Article ac = new Article(aid,cid,title,content);
        bool b = aop.update(ac);
        if (b)
        {
            Response.Redirect("~/newsarticle.aspx?id="+aid);
        }
       

    }
  
}
