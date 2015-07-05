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

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Sid = Request.QueryString["id"].ToString() ;
        ArticleOperate ap = new ArticleOperate();
        bool b=ap.delete(Sid);
        CommentOperate co=new CommentOperate();
        bool bb = co.deletebyarticle(Sid);
        if (b)
        {
            Response.Redirect("~/Blog.aspx");
        }

    }
}
