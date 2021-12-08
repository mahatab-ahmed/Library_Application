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
    public partial class issuingpage : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Isssue Book button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ifbookexist() && checkifmemberexist())
            {
                if (checkifissueentryexist())
                {
                    Response.Write("<script>alert('The Member Already take this book ago.')</script>");
                }
                else
                {
                    addbook();
                }
                GridView1.DataBind();
            }
            else
            {
                Response.Write("Wrong Book Id or Wrong Book Name");
            }
        }

        //Return Book Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ifbookexist() && checkifmemberexist())
                {
                    if (checkifissueentryexist())
                    {
                        returnbook();
                    }
                    else
                    {
                        Response.Write("<script>alert('This Member Or book does'nt exist')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("'" + ex.Message + "'");
            }
        }


        //Go Button
        protected void Button5_Click(object sender, EventArgs e)
        {
            getbookbyname();
        }

        //user defined
        void getbookbyname()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select Book_Name from book_master_tbl where Book_Id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["Book_Name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert(' Wrong Book Id')</script>");
                }

                cmd = new SqlCommand("select Full_Name from member_master_tbl where Member_ID='" + TextBox3.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0]["Full_Name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert(' Wrong User Id')</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        bool ifbookexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where Book_Id='" + TextBox2.Text.Trim() + "'and Current_Stock>0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;

                }
                else
                {
                    Response.Write("<script>alert('Wrong Book ID')</script>");
                    return (false);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
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
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where Member_ID='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;

                }
                else
                {
                    Response.Write("<script>alert('Wrong Member ID')</script>");
                    return (false);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }
        void addbook()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into book_issue_tbl(Member_Id,Member_Name,Book_Id,Book_Name,Issue_Date,Due_Date)values(@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update book_master_tbl set Current_Stock=Current_Stock-1 where Book_Id='" + TextBox2.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>'Book Issued Successfully'</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
            }
        }

        bool checkifissueentryexist()
        {

            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl where Member_Id='" + TextBox3.Text.Trim() + "' and Book_Id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {

                    return true;

                }
                else
                {
                    return (false);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                return false;
            }
        }

        void returnbook()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Delete from book_issue_tbl where Member_Id='" + TextBox3.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update book_master_tbl set Current_Stock=Current_Stock + 1 where Book_Id='" + TextBox2.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("'" + ex.Message + "'");
            }

        }

        

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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
