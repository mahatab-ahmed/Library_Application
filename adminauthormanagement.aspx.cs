using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Web_devlopment
{
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(cs);
            //SqlDataAdapter da = new SqlDataAdapter("select * from author_master_tbl", con);

            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //GridView1.DataSource = ds;
            GridView1.DataBind();

        }


        //add button click
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkifauthorexist())
            {
                Response.Write("<script>alert('Author with this id already exist you can't save this id with the same ID.');</script>");
            }
            else
            {
                addnewauthor();
            }
        }


        //update button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkifauthorexist())
            {
                updateauthor();
            }
            else
            {
                Response.Write("<script>alert('Author does'nt exist');</script>");
            }
        }

        //Delete Button Click
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkifauthorexist())
            {
                deleteauthor();
            }
            else
            {
                Response.Write("<script>alert('Author does'nt exist');</script>");
            }
        }


        //Go button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            getauthorbyid();
        }


        void getauthorbyid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where Author_ID='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Author_ID is not valid');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateauthor()
        {
            try
            {

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update author_master_tbl set Author_Name = @author_name where Author_ID ='" + TextBox3.Text.Trim() + "'", con);


                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Author updated successfully');</script>");
                clearform();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void addnewauthor()
        {
            try
            {

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into author_master_tbl(Author_ID ,Author_Name) values(@author_id,@author_name)", con);

                cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Author id and name is saved successfully so go and enjoy it');</script>");
                clearform();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteauthor()
        {
            SqlConnection con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delete author_master_tbl where Author_ID='" + TextBox3.Text.Trim() + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<alert>'Deleted Account Successfully '</alert>");
            clearform();
            GridView1.DataBind();
        }

        //user defined function
        bool checkifauthorexist()
        {
            try
            {

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where Author_ID ='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void clearform()
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
        }


    }
}