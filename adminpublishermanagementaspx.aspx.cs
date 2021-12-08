using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Web_devlopment
{
    public partial class adminpublishermanagementaspx : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataAdapter da = new SqlDataAdapter("select * from publisher_master_tbl", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }


        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkifauthorexist())
            {
                Response.Write("<script>alert('Please enter the another Name or ID')</script>");
            }
            else
            {
                addnewauthor();
            }
        }


        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkifauthorexist())
            {
                updateauthor();
            }
            else
            {
                Response.Write("<script>alert('Please enter the another Name or ID')</script>");
            }
        }

        //Delete Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkifauthorexist())
            {
                try
                {
                    deleteauthor();
                }
                catch
                {
                    Response.Write("<script>alert('Please enter the another Name or ID')</script>");
                }
            }
        }

        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkifauthorexist())
                {
                    getauthorbyid();
                }

            }
            catch
            {
                Response.Write("<script>alert('Please enter the another Name or ID')</script>");
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
                SqlCommand cmd = new SqlCommand("insert into publisher_master_tbl(Publisher_Id ,Publisher_Name) values(@publisher_id,@publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Author id and name is saved successfully so go and enjoy it');</script>");
                clearform();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
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
                SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where Publisher_Id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Publisher_ID is not valid');</script>");
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
                SqlCommand cmd = new SqlCommand("update publisher_master_tbl set Publisher_Name = @author_name where Publisher_Id ='" + TextBox3.Text.Trim() + "'", con);


                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Publisher updated successfully');</script>");
                clearform();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        bool checkifauthorexist()
        {
            try
            {

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where Publisher_Id ='" + TextBox3.Text.Trim() + "'", con);
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
        void deleteauthor()
        {
            SqlConnection con = new SqlConnection(cs);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("delete publisher_master_tbl where Publisher_Id='" + TextBox3.Text.Trim() + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<alert>'Deleted Account Successfully '</alert>");
            clearform();
            GridView1.DataBind();
        }
        void clearform()
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
    }
}