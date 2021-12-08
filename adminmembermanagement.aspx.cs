using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Web_devlopment
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }


        //Go Button
        protected void Button5_Click(object sender, EventArgs e)
        {
            getmemberbyid();
        }

        //activating button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updatestatus("active");
            GridView1.DataBind();
        }

        //pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updatestatus("pending");
            GridView1.DataBind();
        }

        //Deactivating Button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updatestatus("deactive");
            GridView1.DataBind();
        }



        bool checkifmemberexist()
        {
            try
            {

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where Member_ID ='" + TextBox7.Text.Trim() + "'", con);
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
        void getmemberbyid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where Member_ID='" + TextBox7.Text.Trim() + "'", con);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        TextBox3.Text = rdr.GetValue(0).ToString();
                        TextBox2.Text = rdr.GetValue(11).ToString();
                        TextBox1.Text = rdr.GetValue(1).ToString();
                        TextBox8.Text = rdr.GetValue(2).ToString();
                        TextBox4.Text = rdr.GetValue(3).ToString();
                        
                        TextBox6.Text = rdr.GetValue(5).ToString();
                        TextBox9.Text = rdr.GetValue(6).ToString();
                        TextBox5.Text = rdr.GetValue(4).ToString();
                        TextBox10.Text = rdr.GetValue(7).ToString();

                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid Credintial');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deleteid()
        {
            if (checkifmemberexist())
            {
                try
                {

                    SqlConnection con = new SqlConnection(cs);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("delete from member_master_tbl where Member_ID='" + TextBox7.Text.Trim() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Deleted Account Succesfully');</script>");
                    GridView1.DataBind();
                    refreshbutton();
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('"+ex.Message+"');</script>");
                }
            }
        }
        void refreshbutton()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";

        }

        void updatestatus(string status)
        {
            if (checkifmemberexist())
            {
                try
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update member_master_tbl set Account_Status='" + status + "' where Member_ID='" + TextBox7.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Credentials');</script>");
            }
        }



        //delete the member id button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteid();
        }
    }
}