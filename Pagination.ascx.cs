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
using System.Text;

public partial class Pagination : System.Web.UI.UserControl
{
    private int _pageCount;
    private int _currentPage;
    private string _pageUrl;
    private string _paramName;

    public int pageCount
    {
        set { this._pageCount = value; }
    }
    public int currentPage
    {
        set { this._currentPage = value; }
    }
    public string pageUrl
    {
        set
        {
            if (value.IndexOf("?") > 0)
            {
                this._pageUrl = value + "&";
            }
            else
            {
                this._pageUrl = value + "?";
            }
        }
    }
    public string paramName
    {
        set { this._paramName = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder pageInfo = new StringBuilder();
        int i;
        if (_currentPage > 5 && _pageCount > 10)
        {
            if (_currentPage > _pageCount - 9)
            {
                i = _pageCount - 9;
            }

            else
            {
                i = _currentPage - 5;
            }
            pageInfo.Append("<a href='" + _pageUrl + _paramName + "=" + 1);
            pageInfo.Append("'class='p_num'>&laquo;</a>");
            int lastNext = i - 1;
            pageInfo.Append("<a href='" + _pageUrl + _paramName + "=" + lastNext);
            pageInfo.Append("'class='p_num'>&#8249;</a>");
        }
        else
        {
            i = 1;
        }
        for (int j = 1; i < _pageCount + 1 && j <= 10; i++, j++)
        {
            pageInfo.Append("<a href='" + _pageUrl + _paramName + "=" + i);
            if (i == _currentPage)
            {
                pageInfo.Append("'class='p_curpage'>" + i + "</a>");
            }
            else
            {
                pageInfo.Append("'class='p_num'>" + i + "</a>");
            }
        }
        if (_pageCount > 10 && _currentPage <= _pageCount - 9)
        {
            pageInfo.Append("<a href='" + _pageUrl + _paramName + "=" + i);
            pageInfo.Append("'class='p_num'>&#8250;</a>");
            pageInfo.Append("<a href='" + _pageUrl + _paramName + "=" + _pageCount);
            pageInfo.Append("'class='p_num'>&raquo;</a>");
        }
        this.lblCount.Text = this.lblCount.Text + _pageCount.ToString();
        this.lblPageInfo.Text = pageInfo.ToString();
    }
}
