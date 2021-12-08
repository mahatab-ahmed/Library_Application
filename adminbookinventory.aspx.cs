using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace Web_devlopment
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stocks, glboal_issued_books;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            fillauthorpublisherdata();
            }
            GridView1.DataBind();
        }

        //add button click
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkifbookexist())
                {
                    Response.Write("<script>'The book is already exist.'</script>");
                }
                else
                {
                    addnewbook();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>'" + ex.Message + "'</script>");
            }
        }

        //update button click
        protected void Button4_Click(object sender, EventArgs e)
        {
            updatebookbyid();
        }


        //Delete Button Click
        protected void Button2_Click(object sender, EventArgs e)
        {
            deletebyid();
        }

        //Go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            gothroughbutton();
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
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where Book_Id='" + TextBox1.Text.Trim() + "'", con);
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

        void fillauthorpublisherdata()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select Author_Name from author_master_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "Author_Name";
                DropDownList2.DataBind();

                cmd = new SqlCommand("select Publisher_Name from publisher_master_tbl", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "Publisher_Name";
                DropDownList3.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>'" + ex.Message + "'</script>");
            }
        }

        void addnewbook()
        {
            try
            {
                string genre = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genre = genre + ListBox1.Items[i] + ",";
                }

                genre = genre.Remove(genre.Length - 1);

                string filepath = "~/Bookinventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Bookinventory/" + filename));
                filepath = "~/Bookinventory/" + filename;

                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into book_master_tbl(Book_Id,Book_Name,Genre,Author_Name,Publisher_Name,Publish_Date,Language,Edition,Book_Cost,No_Of_Pages,Book_Description,Actual_Stock,Current_Stock,Book_Img_Link)" +
                                                              " values(@Book_Id,@Book_Name,@Genre,@Author_Name,@Publisher_Name,@Publish_Date,@Language,@Edition,@Book_Cost,@No_Of_Pages,@Book_Description,@Actual_Stock,@Current_Stock,@Book_Img_Link)", con);
                cmd.Parameters.AddWithValue("@Book_Id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@Author_Name", DropDownList2.SelectedValue);
                cmd.Parameters.AddWithValue("@Publisher_Name", DropDownList3.SelectedValue);
                cmd.Parameters.AddWithValue("@Publish_Date", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Language", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@Edition", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Cost", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@No_Of_Pages", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Description", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@Actual_Stock", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@Current_Stock", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Img_Link", filepath);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>('The book is added successfully.');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>'" + ex.Message + "'</script>");
            }
        }

        void deletebyid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("delete * from book_master_tbl where Book_Id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book deleted successfully')</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        void gothroughbutton()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where Book_Id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["Book_Name"].ToString().Trim();

                    DropDownList3.SelectedValue = dt.Rows[0]["Publisher_Name"].ToString().Trim();
                    //ListBox1.SelectedValue = dt.Rows[0]["Genre"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["Author_Name"].ToString().Trim();

                    TextBox6.Text = dt.Rows[0]["Publish_Date"].ToString().Trim();
                    DropDownList1.SelectedValue = dt.Rows[0]["Language"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["Edition"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["Book_Cost"].ToString().Trim();
                    TextBox9.Text = dt.Rows[0]["No_Of_Pages"].ToString().Trim();
                    TextBox13.Text = dt.Rows[0]["Book_Description"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["Actual_Stock"].ToString().Trim();
                    TextBox11.Text = dt.Rows[0]["Current_Stock"].ToString().Trim();
                    TextBox12.Text = "" + (Convert.ToInt32(dt.Rows[0]["Actual_Stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["Current_Stock"].ToString()));

                    TextBox2.Text = dt.Rows[0]["Book_Img_Link"].ToString().Trim();
                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["Genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["Actual_Stock"].ToString().Trim());
                    global_current_stocks = Convert.ToInt32(dt.Rows[0]["Current_Stock"].ToString().Trim());

                    glboal_issued_books = global_actual_stock - global_current_stocks;
                    global_filepath = dt.Rows[0]["Book_Img_Link"].ToString();


                }



            }

            catch (Exception ex)
            {
                Response.Write("<script>'" + ex.Message + "'</script>");

            }
        }

        void updatebookbyid()
        {
            if (checkifbookexist())
            {
                try
                {
                    int actualstock = Convert.ToInt32(TextBox10.Text.Trim());
                    int currentstock = Convert.ToInt32(TextBox11.Text.Trim());
                    if (global_actual_stock == actualstock)
                    {

                    }
                    else
                    {
                        if (actualstock == global_actual_stock)
                        {
                            Response.Write("<script>alert('Actual stock value can't be less than global actual stock value.')</script>");
                            return;
                        }
                        else
                        {
                            currentstock = actualstock - glboal_issued_books;
                            TextBox11.Text = "" + currentstock;
                        }
                    }



                    string genre = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genre = genre + ListBox1.Items[i] + ",";
                    }
                    genre = genre.Remove(genre.Length - 1);

                    string filepath = "~/Bookinventory/books1.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("Bookinventory/" + filename));
                        filepath = "~/Bookinventory/" + filename;
                    }


                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update book_master_tbl set Book_Name=@bookname,Genre=@genre,Author_Name=@authorname,Publisher_Name = @publishername, Publish_Date = @publishdate, Language = @language, Edition = @edition,Book_Cost = @bookcost, No_Of_Pages = @noofpages, Book_Description = @bookdescription, Actual_Stock =@actualstock, Current_Stock = @currentstock, Book_Img_Link = @bookimglink where Book_Id ='" + TextBox1.Text.Trim() + "' ", con);
                    cmd.Parameters.AddWithValue("@bookname", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", ListBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@authorname", DropDownList2.SelectedValue);
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@publishername", DropDownList3.SelectedValue);
                    cmd.Parameters.AddWithValue("@publishdate", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@edition", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@bookcost", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@noofpages", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@actualstock", actualstock.ToString());
                    cmd.Parameters.AddWithValue("@currentstock", currentstock.ToString());
                    cmd.Parameters.AddWithValue("@bookdescription", TextBox13.Text.Trim());
                    cmd.Parameters.AddWithValue("@bookimglink", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book data Updated successfully')</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Credentials');</script>");
            }

        }
    }
}