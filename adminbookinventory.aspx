<%@ Page Title="" Language="C#" MasterPageFile="~/webdevlopment.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="Web_devlopment.adminbookinventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new fileReader();
                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })
    </script>
    <style type="text/css">
        .auto-style2 {
            position: relative;
            display: -ms-flexbox;
            display: flex;
            -ms-flex-wrap: wrap;
            flex-wrap: wrap;
            -ms-flex-align: stretch;
            align-items: stretch;
            width: 100%;
            left: 0px;
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                    <div class="card">
                        <div class="card-body">

                            <div class="row">
                                <div class="col">
                                    <center>
                          <h4>  Book Details</h4>
                          <img width="100px" height="150px" id="imgview" src="images/images/books1.png" />
                        </center>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col">

                                    <hr />

                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:FileUpload ID="FileUpload1" onchange="readURL(this);" CssClass="form-control" runat="server" />

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>Book ID</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Member_Id"></asp:TextBox>
                                            <asp:Button ID="Button1" CssClass="form-control btn btn-primary" runat="server" Text="Go" OnClick="Button1_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <label>Book Name</label>
                                    <div class="form-group">
                                        <div class="auto-style2">
                                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Book Name" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>Language</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                                <asp:ListItem Text="English" Value="English"></asp:ListItem>
                                                <asp:ListItem Text="Hindi" Value="Hindi"></asp:ListItem>
                                                <asp:ListItem Text="Japnese" Value="Japnese"></asp:ListItem>
                                                <asp:ListItem Text="Kannad" Value="Kannad"></asp:ListItem>
                                                <asp:ListItem Text="Chinese" Value="Chinese"></asp:ListItem>
                                                <asp:ListItem Text="Portuguese" Value="Portuguese"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label>Author Name</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label>Gnere</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:ListBox ID="ListBox1" CssClass="form-control" runat="server" SelectionMode="Multiple">
                                                <asp:ListItem Text="Action" Value="Action"> </asp:ListItem>
                                                <asp:ListItem Text="Adventure" Value="Adventure"> </asp:ListItem>
                                                <asp:ListItem Text="Thriller" Value="Thriller"> </asp:ListItem>
                                                <asp:ListItem Text="Comic Book" Value="Comic Book"> </asp:ListItem>
                                                <asp:ListItem Text="Super Hero Book" Value="Super Hero Book"> </asp:ListItem>
                                                <asp:ListItem Text="Psycho Book" Value="Psycho Book"> </asp:ListItem>
                                                <asp:ListItem Text="Healthy living" Value="Healthy living"> </asp:ListItem>
                                                <asp:ListItem Text="Travel" Value="Travel"> </asp:ListItem>
                                                <asp:ListItem Text="Fantasy" Value="Fantasy"> </asp:ListItem>
                                                <asp:ListItem Text="Science Fiction" Value="Science Fiction"> </asp:ListItem>
                                                <asp:ListItem Text="Suspense" Value="Suspense"> </asp:ListItem>
                                                <asp:ListItem Text="Romance" Value="Romance"> </asp:ListItem>
                                                <asp:ListItem Text="Motivation" Value="Motivation"> </asp:ListItem>
                                                <asp:ListItem Text="Self Help" Value="Self Help"> </asp:ListItem>
                                                <asp:ListItem Text="Encyclopedia" Value="Encyclopedia"> </asp:ListItem>
                                                <asp:ListItem Text="Blog" Value="Blog"> </asp:ListItem>
                                                <asp:ListItem Text="Geographical Nature" Value="Geographical Nature"> </asp:ListItem>
                                            </asp:ListBox>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>Publisher Name</label>
                                    <div class="form-group">
                                        <div class="input-group">

                                            <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label>Publish Date</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox ID="TextBox6" CssClass="form-control" placeholder="Publish Date" runat="server" TextMode="Date"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label>Edition</label>
                                    <div class="form-group">
                                        <div class="input-group">

                                            <asp:TextBox ID="TextBox7" CssClass="form-control" placeholder="Edition" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>Book Cost(per unit)</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox ID="TextBox8" CssClass="form-control" placeholder="Book Cost(per unit)" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label>Pages</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="Pages" runat="server" TextMode="Number"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label>Actual Stock</label>
                                    <div class="form-group">
                                        <div class="input-group">

                                            <asp:TextBox ID="TextBox10" CssClass="form-control" placeholder="Actual Stock" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Current Stock</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox ID="TextBox11" CssClass="form-control" placeholder="Current Stock" runat="server" ReadOnly="True"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Issued Books</label>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox ID="TextBox12" runat="server" placeholder="Issued books" placeholdser="Issued Books" CssClass="form-control" ReadOnly="True" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12">
                                    <label>Book Description </label>
                                    <div class="form-group">

                                        <asp:TextBox ID="TextBox13" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" Rows="2" runat="server" Text="If you wanted to do somerthing new ! Never hesitate to do it because if you are not doing anything new than you can't find the way of success "></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">

                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:Button ID="Button3" CssClass="btn btn-block btn-success" runat="server" Text="Add" OnClick="Button3_Click" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">

                                    <div class="form-group">
                                        <div class="input-group">

                                            <asp:Button ID="Button4" CssClass="btn btn-block btn-primary" runat="server" Text="Update" OnClick="Button4_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">

                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:Button ID="Button2" CssClass="btn btn-block btn-danger" runat="server" Text="Delete" OnClick="Button2_Click" />

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-md-7">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                                    <h4>
                                        Book Inventory List
                                    </h4>
                                </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ELIBDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                                <div class="col">
                                    <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:BoundField DataField="Book_Id" HeaderText="ID" SortExpression="Book_Id" />

                                            <asp:TemplateField>

                                                <ItemTemplate>
                                                    <div class="container-fluid">
                                                        <div class="row">
                                                            <div class="col-lg-10">
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Book_Name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        Author-<asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Author_Name") %>'></asp:Label>
                                                                        &nbsp;Genre-<asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Genre") %>'></asp:Label>
                                                                        &nbsp;| Language-<asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("Language") %>'></asp:Label>

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        Publisher-<asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("Publisher_Name") %>'></asp:Label>
                                                                        &nbsp;| Publish Date-<asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("Publish_Date") %>'></asp:Label>
                                                                        &nbsp;| Pages-<asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("No_Of_Pages") %>'></asp:Label>
                                                                        &nbsp;| Edition-<asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("Edition") %>'></asp:Label>

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        cost-<asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("Book_Cost") %>'></asp:Label>
                                                                        &nbsp;| Actual Stock-<asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("Actual_Stock") %>'></asp:Label>
                                                                        &nbsp;| Aviliable-<asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("Current_Stock") %>'></asp:Label>

                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-12">
                                                                        Book Description-<asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" Text='<%# Eval("Book_Description") %>'></asp:Label>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <asp:Image CssClass="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("Book_Img_Link") %>' />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>

                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
