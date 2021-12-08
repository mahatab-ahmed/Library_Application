<%@ Page Title="" Language="C#" MasterPageFile="~/webdevlopment.Master" AutoEventWireup="true"
    CodeBehind="user_login.aspx.cs" Inherits="Web_devlopment.user_login" %>

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
                          <img width="150px" src="images/images/generaluser.png" />
                        </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                          <h3> Member Login</h3>
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
                                <label>Member's ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" placeholder="Member ID" runat="server"></asp:TextBox>
                                </div>

                                <label>User's Password</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" TextMode="Password" placeholder="Users Password" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Log-In" OnClick="Button1_Click" />

                                </div>

                                <div class="form-group">
                                    <a href="UserSignUp.aspx">
                                        <input id="Button2" class="btn btn-info btn-block btn-lg" type="button" value="Sign-Up" /></a>

                                </div>

                            </div>
                        </div>

                    </div>
                </div>

                <a href="Homepage.aspx"><< Back to Home</a><br />
                <br />
            </div>
        </div>
    </div>

</asp:Content>
