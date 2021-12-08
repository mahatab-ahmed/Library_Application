
<%@ Page Title="" Language="C#" MasterPageFile="~/webdevlopment.Master" AutoEventWireup="true"
    CodeBehind="Hompage.aspx.cs" Inherits="Web_devlopment.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img src="images/images/home-bg.jpg" class="img-fluid" />
    </section>

    <section>

        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Features</h2>
                    <p><b>Our 3 Primary Features </b></p>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                    <img width="150px" src="images/images/digital-inventory.png" />
                    <h4>
                        Digital Book Inventory
                    </h4>
                    <p class="text-justify">here you can borrow any book from e-Library with some efficien knowledge by our guidance.</p>
                    <center>
                </div>


                <div class="col-md-4">
                    <center>
                  <a href="viewbooks.aspx"><img width="150px" src="images/images/search-online.png" /></a>
                    <h4>
                        Search Books
                    </h4>
                    <p class="text-justify">here you can borrow any book from e-Library with some efficien knowledge by our guidance.</p>
                    <center>
                </div>


                <div class="col-md-4">
                    <center>
                   <img width="150px" src="images/images/defaulters-list.png" />
                    <h4>
                        Defaulter List
                    </h4>
                    <p class="text-justify">here you can borrow any book from e-Library with some efficien knowledge by our guidance.</p>
                    </center>
                </div>
            </div>
            </div>
           
    </section>

    <section>
        <img src="images/images/in-homepage-banner.jpg" class="img-fluid" />
    </section>

    <section>

        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Process</h2>
                    <p><b>We have a simple 3 steps process </b></p>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                    <a href="UserSignUp.aspx"><img width="150px"  src="images/images/sign-up.png" /></a>
                    <h4>
                       Sign-Up
                    </h4>
                    <p class="text-justify">here you can borrow any book from e-Library with some efficien knowledge by our guidance.</p>
                    </center>
                </div>


                <div class="col-md-4">
                    <center>
                    <a href="user_login.aspx"><img width="150px" src="images/images/generaluser.png" /></a>
                    <h4>
                        User Login
                    </h4>
                    <p class="text-justify">here you can borrow any book from e-Library with some efficien knowledge by our guidance.</p>
                    </center>
                </div>


                <div class="col-md-4">
                    <center>
                   <img width="150px" src="images/images/library.png" />
                    <h4>
                        Visit Us
                    </h4>
                    <p class="text-justify">here you can borrow any book from e-Library with some efficien knowledge by our guidance.</p>
                    </center>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
