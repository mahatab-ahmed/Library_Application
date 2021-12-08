<%@ Page Title="" Language="C#" MasterPageFile="~/webdevlopment.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="Web_devlopment.adminpublishermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 ">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                          <h4> Member Details</h4>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                     <img width="100" src="images/images/generaluser.png" />
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
                             <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox7" placeholder="Member ID" runat="server"></asp:TextBox>
                                         <asp:Button ID="Button5" CssClass="btn btn-primary" runat="server" Text="GO" OnClick="Button5_Click" />
                                    </div>

                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" placeholder="Full Name" runat="server"></asp:TextBox>
                                        
                                    </div>

                                </div>
                            </div>

                           


                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control mr-1" ID="TextBox2" placeholder="Account Status" runat="server" ReadOnly="true"></asp:TextBox>
                                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-success mr-1" runat="server" Text="Active" OnClick="LinkButton1_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" CssClass="btn btn-warning mr-1" runat="server" OnClick="LinkButton2_Click" style="width: 6px" ><i class="fas fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-danger mr-1" runat="server" OnClick="LinkButton3_Click" style="width: 6px" ><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    
                                </div>
                              </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                <label>D.O.B</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" placeholder="DOB" runat="server" TextMode="Date"></asp:TextBox>
                                       
                                    </div>

                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>Contact Number</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox8" placeholder="Contact Number" runat="server" TextMode="Number"></asp:TextBox>
                                       
                                    </div>

                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" placeholder="Email ID" runat="server" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox5" placeholder="State" runat="server" ></asp:TextBox>
                                       
                                    </div>

                                </div>
                            </div>


                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" placeholder="City" runat="server" ></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" placeholder="Pincode" runat="server" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <label>Full Portal Address</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox10" placeholder="My Home" runat="server" TextMode="MultiLine"></asp:TextBox>
                                       
                                    </div>

                                </div>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col">
                                <asp:Button ID="Button2" CssClass="btn btn-lg btn-danger btn-block" runat="server" Text="Delete User Permanently" OnClick="Button2_Click" />
                            </div>
                           
                           
                        </div>
                    </div>
                </div>

                <a href="Homepage.aspx"><< Back to Home</a><br />
                <br />
            </div>

            <div class="col-md-7 ">
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ELIBDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]" ></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Full_Name" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Member_ID" HeaderText="Member ID" SortExpression="Member_ID" />
                                        <asp:BoundField DataField="Full_Name" HeaderText="Name" ReadOnly="True" SortExpression="Full_Name" />
                                        <asp:BoundField DataField="Account_Status" HeaderText="Account_Status" SortExpression="Account_Status" />
                                        <asp:BoundField DataField="Contact_No" HeaderText="Contact" SortExpression="Contact_No" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                        <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
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
