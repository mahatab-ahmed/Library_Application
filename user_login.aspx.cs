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
    public partial class user_login : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where Member_ID = '" + TextBox1.Text.Trim() + "' and Password = '" + TextBox2.Text.Trim() + "' ", con);

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        //Response.Write("<script>alert('Login Successfull');</script>");
                        Session["username"] = rdr.GetValue(8).ToString();
                        Session["fullname"] = rdr.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = rdr.GetValue(10).ToString();
                    }
                    Response.Redirect("~/Hompage.aspx");
                }

                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");
                }
            }

            catch (Exception ex)

            {
                Response.Write(ex.Message);
            }
        }
        
    }
}