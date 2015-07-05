using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.OleDb;

public class ArticleOperate
{
    private SqlConnection con = null;
    private SqlCommand cmd = null;

    public ArticleOperate()
    {
        this.con = ConDB.getConnection();//在构造函数中连接数据库！
    }

    public bool insert(Article at)//插入函数！
    {
        
        con.Open();
        cmd = new SqlCommand("insert into newstable(title,leibie,content,author) values(@title,@leibie,@content,@author)", con);
        cmd.Parameters.Add(new SqlParameter("@title", at.title));
        cmd.Parameters.Add(new SqlParameter("@content", at.content));
        cmd.Parameters.Add(new SqlParameter("@leibie", at.liebie));
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

    public Article getByAid(string aid)//获取文章内容
    {
        con.Open();
        cmd = new SqlCommand("select * from newstable where id='"+aid+"'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        Article ac = null;
        while (dr.Read())
        {
            ac = new Article(dr);
        }
        con.Close();
        return ac;
    }

    public bool delete(string aid)
    {
        con.Open();
        cmd = new SqlCommand("delete from newstable where id='"+aid+"'", con);
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


    public List<Article> viewAll()
    {
        List<Article> list = new List<Article>();
        con.Open();
        cmd = new SqlCommand("select * from newstable order by time desc", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        Article ac;
        Leibie lb = null;
        LeibieOperater lbo = null;
        while (sdr.Read())
        {
            lb = new Leibie();
            lbo = new LeibieOperater();
            ac = new Article();
            ac.id= sdr["id"].ToString();
            ac.liebie =Convert.ToInt32(sdr["leibie"]);
            int i = ac.liebie;
            lb = lbo.getbyid(i);
            ac.leibiestr = lb.leibie.ToString();
            ac.title = sdr["title"].ToString();
            ac.content = sdr["content"].ToString();
            if (ac.content.Length > 200)
            {
                ac.content = ac.content.Substring(0, 200);
            }
            ac.postdatetime = Convert.ToDateTime(sdr["time"]);
            ac.gentieCount = Convert.ToInt32(sdr["GentieCount"]);
            ac.readcount = Convert.ToInt32(sdr["times"]);//读了多少次
            ac.author = sdr["author"].ToString();
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }
   
    public List<Article> viewAllByleibie(int leibie)
    {
       List<Article> list = new List<Article>();
        con.Open();
        cmd = new SqlCommand("select * from newstable where [leibie]="+leibie+"order by time desc", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        Article ac;
        Leibie lb = null;
        LeibieOperater lbo = null;
        while (sdr.Read())
        {
            lb = new Leibie();
            lbo = new LeibieOperater();
            ac = new Article();
            ac.id = sdr["id"].ToString();
            ac.liebie = Convert.ToInt32(sdr["leibie"]);
            int i = ac.liebie;
            lb = lbo.getbyid(i);
            ac.leibiestr = lb.leibie.ToString();
            ac.title = sdr["title"].ToString();
            ac.content = sdr["content"].ToString();
            if (ac.content.Length > 200)
            {
                ac.content = ac.content.Substring(0, 200);
            }
            ac.postdatetime = Convert.ToDateTime(sdr["time"]);
            ac.gentieCount = Convert.ToInt32(sdr["GentieCount"]);
            ac.readcount = Convert.ToInt32(sdr["times"]);//读了多少次
            ac.author = sdr["author"].ToString();
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }
 /*
    public List<Article> viewList()
    {
        List<Article> list = new List<Article>();
        con.Open();
        cmd = new SqlCommand("select aid,title,posttime,countcomment from bob_article_view order by posttime desc", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        Article ac;
        while (sdr.Read())
        {
            ac = new Article();
            ac.aid = Convert.ToInt32(sdr["aid"]);
            ac.title = sdr["title"].ToString();
            ac.posttime = Convert.ToDateTime(sdr["posttime"]);
            ac.countcomment = Convert.ToInt32(sdr["countcomment"]);
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }
*/
    //查询！
    public List<Article> search(string s)
    {
        List<Article> list = new List<Article>();
        con.Open();
        cmd = new SqlCommand("select * from newstable where title like '%"+s+"%' order by time desc", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        Article ac;
        while (sdr.Read())
        {
            ac = new Article();
             ac.id = sdr["id"].ToString();
            ac.liebie =Convert.ToInt32(sdr["leibie"]);
            ac.title = sdr["title"].ToString();
            ac.postdatetime = Convert.ToDateTime(sdr["time"]);
            ac.gentieCount = Convert.ToInt32(sdr["GentieCount"]);
            ac.readcount = Convert.ToInt32(sdr["times"]);//读了多少次
            ac.author = sdr["author"].ToString();
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }
    //更新，包括 标题，内容，类别，
    public bool update(Article ac)
    {
        con.Open();
        cmd = new SqlCommand("update newstable set title=@title,content=@content,leibie=@leibie,times=@readcount ,gentiecount=@gentiecount where id=@aid", con);
        cmd.Parameters.Add(new SqlParameter("@leibie", ac.liebie));
        cmd.Parameters.Add(new SqlParameter("@title", ac.title));
        cmd.Parameters.Add(new SqlParameter("@content", ac.content));
        cmd.Parameters.Add(new SqlParameter("@aid", ac.id));
        cmd.Parameters.Add(new SqlParameter("@readcount", ac.readcount));
        cmd.Parameters.Add(new SqlParameter("@gentiecount", ac.gentieCount));
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
