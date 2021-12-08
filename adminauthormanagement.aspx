<%@ Page Title="" Language="C#" MasterPageFile="~/webdevlopment.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="Web_devlopment.adminauthormanagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5 ">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                          <h4> Author Details</h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                       <img width="100px" src="images/images/writer.png" />
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
                            <div class="col-md-4">
                                <label>Author ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" placeholder="ID" runat="server"></asp:TextBox>
                                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="GO" OnClick="Button1_Click" />
                                    </div>

                                </div>
                            </div>


                            <div class="col-md-8">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" placeholder="Author Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" CssClass="btn btn-lg btn-success btn-block" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" CssClass="btn btn-lg btn-warning btn-block" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" CssClass="btn btn-lg btn-danger btn-block" runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                </div>





            </div>
        </div>

        <a href="Hompage.aspx"><< Back to Home</a><br />
        <br />
    </div>

    <div class="col-md-7 ">
        <div class="card">
            <div class="card-body">
               

                <div class="row">
                    <div class="col">
                        <center>
                          <h4> Author List</h4>                 
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <hr>
                    </div>
                </div>


                <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ELIBDBConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                    <div class="col">
                        <asp:GridView CssClass="table table-striped table-bordered " ID="GridView1" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
                    </div>
                </div>


            </div>
        </div>


    </div>
    </div>
    </div>

</asp:Content>
