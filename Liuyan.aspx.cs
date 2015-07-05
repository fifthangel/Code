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

public partial class Liuyan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            datasetbind();
        }

    }
    protected void datasetbind()
    {
        int currentPage;

        try
        {

            currentPage = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch
        {

            currentPage = 1;
        }
        if (currentPage == 0)
        {
            currentPage = 1;
        }
        LiuyanOperation aop = new LiuyanOperation();

        PagedDataSource ps = new PagedDataSource();

        //ps.DataSource=aop.
        ps.DataSource = aop.viewAll();//数据源为一个链表！，如此之棒，赞~！


        ps.AllowPaging = true;
        ps.PageSize = 10;
        ps.CurrentPageIndex = currentPage - 1;
        this.Pagination1.pageCount = ps.PageCount;
        this.Pagination1.currentPage = currentPage;
        this.Pagination1.pageUrl = "Liuyan.aspx";
        this.Pagination1.paramName = "page";
        this.Data_list_liuyan.DataSource = ps;
        this.Data_list_liuyan.DataBind();
    }
    protected void Btn_summit_Click(object sender, EventArgs e)
    {
        liuyan ly = new liuyan();
        LiuyanOperation lyop = new LiuyanOperation();
        ly.author = TextBox1.Text.ToString();
        ly.content = FCKeditor1.Value.ToString();
        lyop.insert_ly(ly);
        this.Data_list_liuyan.DataBind();
        Response.Redirect("liuyan.aspx");
    }
}
