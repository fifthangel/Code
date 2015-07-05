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

public partial class Blog : System.Web.UI.Page
{
    //string lb = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //  DataListViewAll.
            // DataListViewAll.
            datasetbind();
        }

    }
    protected void datasetbind()
    {
        int currentPage;
        int leibie;
        try
        {
            leibie = Convert.ToInt32(Request.QueryString["Leibie"]);
            currentPage = Convert.ToInt32(Request.QueryString["page"]);
        }
        catch
        {
            leibie = 0;
            currentPage = 1;
        }
        if (currentPage == 0)
        {
            currentPage = 1;
        }
        ArticleOperate aop = new ArticleOperate();
        PagedDataSource ps = new PagedDataSource();
        if (leibie != 0)
        {
            ps.DataSource = aop.viewAllByleibie(leibie);
            
        }
        else
        {
            ps.DataSource = aop.viewAll();//数据源为一个链表！，如此之棒，赞~！
        }

        ps.AllowPaging = true;
        ps.PageSize = 5;
        ps.CurrentPageIndex = currentPage - 1;
        this.Pagination1.pageCount = ps.PageCount;
        this.Pagination1.currentPage = currentPage;
        this.Pagination1.pageUrl = "Blog.aspx?Leibie=" + leibie;
        this.Pagination1.paramName = "page";
        this.DataListViewAll.DataSource = ps;
        this.DataListViewAll.DataBind();
    //    this.DataListViewAll.DataKeyField = "ID";
      
     
    }
    

  


  
}
