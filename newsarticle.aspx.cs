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

public partial class newsarticle : System.Web.UI.Page
{
    string _ii=null;
    protected string id = null;
    protected ArticleOperate aot = null;
    protected Article at = null;
    protected string url = null;
    protected string durl = null;
    public newsarticle()
    {

        aot = new ArticleOperate();

    }
    public string ii
    {
        get { return this._ii; }
        set { this._ii = value; }
    }
    public string Url
    {
        get { return this.url; }
        set { this.url = value; }
    }
    public string Durl
    {
        get { return this.durl; }
        set { this.durl = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //url = "admin/editpage.aspx?id=" + Request.QueryString["id"].ToString();
        if (!IsPostBack)
        {
            try
            {
                id = Request.QueryString["id"].ToString();
                ii = id;
                Url = "admin/editpage.aspx?id=" + id;
                Durl = "admin/deletepage.aspx?id=" + id;
                at = aot.getByAid(id);
                
                if (at == null || at.Equals(null))
                {
                    this.Page.Title = "此文章不存在" + " " + Title;
                    this.lblcontent.Text = "此文章不存在!";
                }
                else
                {
                    this.lbltitle.Text = at.title;
                    this.Page.Title = at.title + " " + Title;
                    this.lblposttime.Text = at.postdatetime.ToString();
                    this.Lbl_readcount.Text = at.readcount.ToString();
                    this.lblcontent.Text = at.content;
                    this.lblcname.Text = at.author;
                    this.lblCommet.Text = at.gentieCount.ToString();
                    CommentOperate cop = new CommentOperate();
                    this.DataListAllComment.DataSource = cop.viewAllbyAid(id);
                    this.DataListAllComment.DataBind();
                    at.readcount++;
                    aot.update(at);
                    

                }
            }
            catch
            {
                // Response.Write("文章不存在!");
            }
        }

    }
    protected void summit_Btn_Click(object sender, EventArgs e)
    {
        CommentOperate cop = new CommentOperate();
        Comment co = new Comment();
        co.gid = Request.QueryString["id"].ToString();
        co.gcontent = FCKeditor1.Value;
        co.gauthor = tb_author.Text;
        bool flag=cop.insert(co);
        if (flag)
        {
            id = Request.QueryString["id"].ToString();
            at = aot.getByAid(id);
            at.gentieCount++;
            aot.update(at);//跟帖次数加一后修改
            this.DataListAllComment.DataBind();
            this.Label1.Visible = false;
            Response.Redirect("newsarticle.aspx?id=" + id);

        }
        else
        {
            Label1.Text = "发贴失败！";
        }
    }
    
}
