using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// liuyan 的摘要说明
/// </summary>
public class liuyan
{
	private string _id;//ID
    private string _Author;//作者
    private string _content;//留言内容
    private string _huifu;//回复
    private DateTime _time;//发表时间
    private DateTime _huifutime;//回复时间
 　public string id
   {
      get{return this._id;}
      set{this._id=value;}
   }
    public  string  author
    {
        get{return this._Author;}
        set{this._Author=value;}
    }
    public string content
    {
        get{return this._content;}
        set{this._content=value;}
    }
    public DateTime time
    {
        get{return this._time;}
        set{this._time=value;}
    }
    public DateTime huifutime
    {
        get{return this._huifutime;}
        set{this._huifutime=value;}
    }
    public string huifu
    {
        get { return this._huifu; }
        set { this._huifu = value; }
    }
    public liuyan()
    { }
    public liuyan(SqlDataReader dr)
    {
        this._id = dr["ID"].ToString();
        this._Author = dr["CNAME"].ToString();
        this._content = dr["LIUYAN_Content"].ToString();
        this._huifu = dr["LIUYAN_HUIFU"].ToString();
        this._huifutime = Convert.ToDateTime(dr["LIUYAN_HUIFU_TIME"]);        
        this._time = Convert.ToDateTime(dr["LIUYAN_TIME"]);     
    }

}
