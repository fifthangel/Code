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

public partial class Admin_deletegentie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            string id = Request.QueryString["artid"].ToString();
            string Sid = Request.QueryString["id"].ToString();
            Article ar = new Article();
            ArticleOperate ao = new ArticleOperate();
            ar = ao.getByAid(id);
            ar.gentieCount--;
            ao.update(ar);
            CommentOperate co = new CommentOperate();
            bool b = co.delete(Sid);
            
            if (b)
            {
                Response.Redirect("~/newsarticle.aspx?id="+id);
            }
        }
        catch
        { }

    }
}
