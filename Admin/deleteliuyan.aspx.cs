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

public partial class Admin_deleteliuyan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string id = Request.QueryString["id"].ToString();
                LiuyanOperation lo = new LiuyanOperation();
                if (lo.delete(id))
                {
                    Response.Write("删除成功！");
                    Response.Redirect("../Liuyan.aspx");
                };
            }
            catch
            { }
            
        }
    }
}
