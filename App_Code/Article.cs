using System;
using System.Data.SqlClient;
//using System.Data.OleDb;

//文章的各个字段
//该源码下载自www.51aspx.com(５1ａｓｐｘ．ｃｏｍ)

public class Article
{
    private string _id;//ID
    private string _title;//题目
    private int _leibie;//类别
    private string _content;//文章内容能够
    private DateTime _time;//发表时间
    private string _Author;//作者
    private int _times;//阅读次数
    private int _gentieCount;//跟帖次数
    private string _leibiestr;
    
   
    public  Article()
    {}
    public Article(string id, string title, string content)
    {
        this._id=id;
        this._title=title;
        this._content=content;
     
    }
    public Article(string id, int leibie, string title, string content)
    {
        this._id = id;
        this._leibie = leibie;
        this._title = title;
        this._content = content;
    }
    public string leibiestr
    {
        get { return this._leibiestr; }
        set { this._leibiestr = value; }
 
    }
    public string id  //获取文章id
    {
        get { return this._id;}
        set { this._id = value; }
    }
    public string title  //获取文章标题
    {
        get { return this._title; }
        set { this._title = value; } 
    }
    public int liebie  //获取文章类别
    {
        get { return this._leibie; }
        set { this._leibie = value; }
    }
    public string content  //获取文章内容
    {
        get { return this._content; }
        set { this._content = value; }
    }
    public DateTime postdatetime//发表文章时间
    {
        get {return this._time;}
        set {this._time=value;}
    }
    public string author
    {
        get {return this._Author;}
        set {this._Author=value;}
    }
    public int readcount
    {
        get{return this._times;}
        set {this._times=value;}
    }
    public int gentieCount
    {
        get { return this._gentieCount;}
        set {   this._gentieCount=value;}
    }
    public Article(SqlDataReader dr)
    {
        this._Author = dr["Author"].ToString();
        this._content = dr["Content"].ToString();
        this._gentieCount = Convert.ToInt32(dr["GentieCount"]);
        this._id = dr["ID"].ToString();
        this._leibie = Convert.ToInt32(dr["LeiBie"]);
        this._time = Convert.ToDateTime(dr["Time"]);
        this._times = Convert.ToInt32(dr["Times"]);
        this._title = dr["Title"].ToString();
    }

}
