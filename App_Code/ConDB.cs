using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
//该源码下载自www.51aspx.com(５１aｓpｘ．ｃｏｍ)

//数据库链接类
public class ConDB
{
    public ConDB()
	{
		
		// TODO: 在此处添加构造函数逻辑
		//
	}

    //public static SqlConnection getConnection(int i)
    //{
    //    return new SqlConnection(ConfigurationManager.ConnectionStrings["blogConnectionString"].ConnectionString);
    //}

    public static SqlConnection getConnection()//定义成静态的，很重要！
    {
        return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    }
}
