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
    public partial class UserSignUp : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkmemberexist())
            {
                Response.Write("<script>alert('Members already exist');</script>");
            }
            else
            {
                signup();
            }


        }

        bool checkmemberexist()
        {

            try
            {

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where Member_ID='" + TextBox8.Text.Trim() + "'", con);
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


        void signup()
        {
            //Response.Write("<script>alert('testing'); </script>");
            try
            {

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into member_master_tbl(Full_Name,DOB,Contact_No,Email, State,City,Pincode,Full_Address,Member_ID,Password,Account_Status) values (@Full_Name,@DOB,@Contact_No,@Email,@State,@City,@Pincode,@Full_Address,@Member_ID,@Password,@Account_Status)", con);

                cmd.Parameters.AddWithValue("@Full_Name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact_No", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@State", DropDownList1.SelectedValue.Trim());
                cmd.Parameters.AddWithValue("@City", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@Full_Address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Member_ID", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@Account_Status", "Pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Sign up is successfully done. Go to the user Login To Log in.')</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}