using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
//using System.Data.OleDb;
//留言类
public class Comment
{
    private string _id;
    private string _gid;
    private string _gcontent;
    private string _gauthor;
    private DateTime _gtime;

    public string id
    {
        get { return this._id; }
        set { this._id = value; }
    }
    public string gid
    {
        get { return this._gid; }
        set { this._gid = value; }
    }
    public string gcontent
    {
        get { return this._gcontent; }
        set { this._gcontent = value; }
    }
    public string gauthor
    {
        get { return this._gauthor; }
        set { this._gauthor = value; }
    }
    public DateTime gtime
    {
        get { return this._gtime; }
        set { this._gtime = value; }
    }


	public Comment()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public Comment(string aid,string comment)
    {
        this._id = aid;
        this._gcontent =comment;
    }
    public Comment(SqlDataReader dr)
    {
        this._id =dr["id"].ToString();
        this._gid = dr["g_ID"].ToString();
        this._gcontent = dr["g_content"].ToString();
        this._gauthor = dr["g_author"].ToString();
        this._gtime =Convert.ToDateTime(dr["g_time"]);
    }
}
