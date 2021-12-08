<%@ Page Title="" Language="C#" MasterPageFile="~/webdevlopment.Master" AutoEventWireup="true" CodeBehind="admin-login.aspx.cs" Inherits="Web_devlopment.admin_login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                          <img width="150px" src="images/images/adminuser.png" />
                        </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                          <h3> Admin Login</h3>
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
                            <div class="col">
                               
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" placeholder="User Name" runat="server"></asp:TextBox>
                                </div>

                                
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" TextMode="Password" placeholder=" Password" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Log-In" OnClick="Button1_Click" />

                                </div>

                               

                            </div>
                        </div>

                    </div>
                </div>

                <a href="Hompage.aspx"><< Back to Home</a><br />
                <br />
            </div>
        </div>
    </div>

</asp:Content>
