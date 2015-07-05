using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;




public class CommentOperate
{
    private SqlConnection con = null;
    private SqlCommand cmd = null;
    public CommentOperate()
    {
        this.con = ConDB.getConnection();
    }

    public bool insert(Comment ct)
    {
        con.Open();
        cmd = new SqlCommand("insert into gentietable(g_id,g_content,g_author) values(@gid,@comment,@author)", con);
        cmd.Parameters.Add(new SqlParameter("@gid", ct.gid));
        cmd.Parameters.Add(new SqlParameter("@comment", ct.gcontent));
        cmd.Parameters.Add(new SqlParameter("@author", ct.gauthor));
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

    public List<Comment> viewAllbyAid(string aid)
    {
        List<Comment> list = new List<Comment>();
        con.Open();
        cmd = new SqlCommand("select * from gentietable where g_id='" + aid+"'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        Comment ac;
        while (sdr.Read())
        {
            ac = new Comment(sdr);
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }
    public bool delete(string aid)
    {
        con.Open();
        cmd = new SqlCommand("delete from gentietable where id='" + aid + "'", con);
        if (cmd.ExecuteNonQuery() >= 0)
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
    public bool deletebyarticle(string aid)
    {
        con.Open();
        cmd = new SqlCommand("delete from gentietable where g_id='" + aid + "'", con);
        if (cmd.ExecuteNonQuery() >= 0)
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
