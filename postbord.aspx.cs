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

public partial class postbord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Submit_btn_Click(object sender, EventArgs e)
    {
        Article at = new Article();
        at.liebie = Convert.ToInt32(DropDownList_liebie.SelectedValue);
        at.title = Tit_tbx.Text;
        at.content = FCKeditor_content.Value.ToString();
        at.author = "omycle";
        ArticleOperate ato = new ArticleOperate();
        ato.insert(at);
        Response.Redirect("Default.aspx");
    }
}
