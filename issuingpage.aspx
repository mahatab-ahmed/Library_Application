<%@ Page Title="" Language="C#" MasterPageFile="~/webdevlopment.Master" AutoEventWireup="true" CodeBehind="issuingpage.aspx.cs" Inherits="Web_devlopment.issuingpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
       $(document).ready(function () {
           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       });
   </script>
    <style type="text/css">
        .auto-style2 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 50%;
            flex: 0 0 50%;
            max-width: 50%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 ">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                          <h4> Book Issuing</h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                      <img width="100px" src="images/images/books.png" />
                        </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                          <hr />
                        </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" placeholder="Member ID" runat="server"></asp:TextBox>
                                        
                                    </div>

                                </div>
                            </div>


                            <div class="col-md-6">
                                <label>Book Id</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" placeholder="Book ID" runat="server"></asp:TextBox>
                                     <asp:Button ID="Button5" CssClass="btn btn-warning" runat="server" Text="GO" OnClick="Button5_Click" />
                                </div>
                              </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="auto-style2">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" placeholder="Member Name" runat="server" ReadOnly="True"></asp:TextBox>
                                       
                                    </div>

                                </div>
                            </div>


                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" placeholder="Book Name" runat="server" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                <label>start Date</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox5" placeholder="Member ID" runat="server" TextMode="Date"></asp:TextBox>
                                       
                                    </div>

                                </div>
                            </div>


                            <div class="col-md-6">
                                <label>End Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" placeholder="Member Name" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="Button2" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Issue" OnClick="Button2_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="Button3" CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Return" OnClick="Button3_Click" />
                            </div>
                           
                        </div>





                    </div>
                </div>

                <a href="Homepage.aspx"><< Back to Home</a><br />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ELIBDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                <br />
            </div>

            <div class="col-md-6 ">
                <div class="card">
                    <div class="card-body">


                        <div class="row">
                            <div class="col">
                                <center>
                          <h4> issued Book List</h4>                 
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>




                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered " ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="Member_Id" HeaderText="Member ID" SortExpression="Member_Id" />
                                        <asp:BoundField DataField="Member_Name" HeaderText="Member Name" SortExpression="Member_Name" />
                                        <asp:BoundField DataField="Book_Id" HeaderText="Book ID" SortExpression="Book_Id" />
                                        <asp:BoundField DataField="Book_Name" HeaderText="Book Name" SortExpression="Book_Name" />
                                        <asp:BoundField DataField="Issue_Date" HeaderText="Issue Date" SortExpression="Issue_Date" />
                                        <asp:BoundField DataField="Due_Date" HeaderText="Due Date" SortExpression="Due_Date" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                    </div>
                </div>


            </div>
        </div>
    </div>

</asp:Content>
