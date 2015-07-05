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
/// LeibieOperater 的摘要说明
/// </summary>
public class LeibieOperater
{
    private SqlConnection con = null;
    private SqlCommand cmd = null;
	public LeibieOperater()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
        this.con = ConDB.getConnection();//在构造函数中连接数据库！
	}
    public Leibie getbyid(int aid)
    {
        con.Open();
        cmd = new SqlCommand("select * from leibietable where id=" + aid, con);
        SqlDataReader dr = cmd.ExecuteReader();
        Leibie lb = null;
        while (dr.Read())
        {
            lb = new Leibie(dr);
        }
        con.Close();
        return lb;
    }
}
