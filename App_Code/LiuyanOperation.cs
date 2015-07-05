using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
/// <summary>
/// LiuyanOperation 的摘要说明
/// </summary>
public class LiuyanOperation
{
    private SqlConnection con = null;
    private SqlCommand cmd = null;

	public LiuyanOperation()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
        this.con = ConDB.getConnection();//在构造函数中连接数据库！
	}
    public bool insert_ly(liuyan at)//插入留言函数！
    {

        con.Open();
        cmd = new SqlCommand("insert into liuyantable(CNAME,LIUYAN_CONTENT) values(@author,@content)", con);    
        cmd.Parameters.Add(new SqlParameter("@content", at.content));     
        cmd.Parameters.Add(new SqlParameter("@author", at.author));
        if (cmd.ExecuteNonQuery() > 0)
        {
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }
    }
    public bool update(liuyan ac)
    {
        con.Open();
        cmd = new SqlCommand("update liuyantable set liuyan_huifu=@huifu where id=@aid", con);
        cmd.Parameters.Add(new SqlParameter("@aid", ac.id));
        cmd.Parameters.Add(new SqlParameter("@huifu", ac.huifu));
       // cmd.Parameters.Add(new SqlParameter("@huifu_time", ac.huifutime));
        if (cmd.ExecuteNonQuery() > 0)
        {
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }
    }
    public List<liuyan> viewAll()
    {
        List<liuyan> list = new List<liuyan>();
        con.Open();
        cmd = new SqlCommand("select * from liuyantable order by liuyan_time desc", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        liuyan ac;
        while (sdr.Read())
        {
            ac = new liuyan();
            ac.id = sdr["ID"].ToString();
           
            ac.author = sdr["CNAME"].ToString();
            
            ac.content = sdr["liuyan_content"].ToString();

            ac.huifu = sdr["LIUYAN_HUIFU"].ToString();

            ac.huifutime = Convert.ToDateTime(sdr["LIUYAN_HUIFU_TIME"]);
            ac.time = Convert.ToDateTime(sdr["LIUYAN_TIME"]);
            
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }
    public liuyan getByAid(string aid)//获取文章内容
    {
        con.Open();
        cmd = new SqlCommand("select * from liuyantable where id='" + aid + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        liuyan ac = null;
        while (dr.Read())
        {
            ac = new liuyan(dr);
        }
        con.Close();
        return ac;
    }
    public bool delete(string aid)
    {
        con.Open();
        cmd = new SqlCommand("delete from liuyantable where id='" + aid + "'", con);
        if (cmd.ExecuteNonQuery() > 0)
        {
            con.Close();
            return true;
        }
        else
        {
            con.Close();
            return false;
        }

    }
   
}
