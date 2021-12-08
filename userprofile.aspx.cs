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
    public partial class userprofile : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again.')</script>");
                    Response.Redirect(Server.MapPath("~/user_login.aspx"));
                }
                else
                {
                    getuserdata();
                    if (!Page.IsPostBack)
                    {
                        getuserspersonaldetails();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again')</script>");
                Response.Write("<script>alert('"+ex.Message+"')</script>");
                Response.Redirect("~/user_login.aspx");
            }
        }
        bool checkifbookexist()
        {
            try
            {

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where Member_ID='" + TextBox1.Text.Trim() + "'", con);
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
        void updatelist()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        void getuserspersonaldetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where Member_ID='" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox3.Text = dt.Rows[0]["Full_Name"].ToString();
                TextBox2.Text = dt.Rows[0]["DOB"].ToString();
                TextBox1.Text = dt.Rows[0]["Contact_No"].ToString();
                TextBox4.Text = dt.Rows[0]["Email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0].ToString().Trim();
                TextBox6.Text = dt.Rows[0]["City"].ToString();
                TextBox7.Text = dt.Rows[0]["Pincode"].ToString();
                TextBox5.Text = dt.Rows[0]["Full_Address"].ToString();
                TextBox8.Text = dt.Rows[0]["Member_ID"].ToString();
                TextBox9.Text = dt.Rows[0]["Password"].ToString();

                Label1.Text = dt.Rows[0]["Account_Status"].ToString().Trim();

                if(dt.Rows[0]["Account_Status"].ToString().Trim()=="active")
                {
                    Label1.Attributes.Add("Class", "badge badge-pill badge-success");
                }
                else if(dt.Rows[0]["Account_Status"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("Class", "badge badge-pill badge-warning");
                }

                else if (dt.Rows[0]["Account_Status"].ToString().Trim() == "deactive")
                {
                    Label1.Attributes.Add("Class", "badge badge-pill badge-danger");
                }
                else 
                {
                    Label1.Attributes.Add("Class", "badge badge-pill badge-info");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        void getuserdata()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl where Member_Id='" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        void updatemember()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update member_master_tbl set Full_Name=@Full_Name,DOB=@DOB,Contact_No=@Contact_No,Email=@Email,State=@State,City=@City,Pincode=@Pincode,Full_Address=@Full_Address,Password=@Password,Account_Status=@Account_Status where Member_ID='" + Session["username"].ToString().Trim() + "'",con);

                cmd.Parameters.AddWithValue("@Full_Name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@DOB", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact_No", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@State", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@City", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@Full_Address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@Account_Status","Pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Your details updated successfully');</script>");
                    getuserspersonaldetails();
                    getuserdata();
                }
                else
                {
                    Response.Write("<script>alert('invalid Entry');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
        //update 

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired Login Again.')</script>");
                    Response.Redirect(Server.MapPath("~/user_login.aspx"));
                }
                else
                {
                    updatemember();
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Invalid Credentials');</script>");
            }
        }
    }
}