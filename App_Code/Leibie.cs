using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.OleDb;

/// <summary>
/// Leibie 的摘要说明
/// </summary>
public class Leibie
{
    private int  _id;
    private string  _leibie;
   
        // This is a named argument.
    public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

    public  string leibie
    {
        get
        {
            return this._leibie;
        }
        set
        {
            this._leibie = value;
        }
    }
    
	public Leibie()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public Leibie(SqlDataReader dr)
    {
        this._id =Convert.ToInt32( dr["ID"]);
        this._leibie = dr["LEIBIE"].ToString();
    }
}
