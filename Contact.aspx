<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LogIn" Runat="Server">
       <li><a href="#"><span class="glyphicon glyphicon-log-in"></span>Login</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body1" Runat="Server">
    <div class="container-fluid center-block" style="margin-bottom:100px; margin-top:60px">


     

        <img src="img/contact.png" style="height:100%; width:100%"/>
    

         <div style="text-align:center">
             <i class="fa" style="font-size:250%; text-align:center; margin-top:-30%">    techelp.contact@gmail.com  </i>
             <br /><br />
              <i class="fa" style="font-size:250%; text-align:center">    +966 594011824  </i>

         </div>
         <br />
         <br />
        <hr />
        <br />
     <br /> 
        
        <div style="text-align:center">
        <i class="fa" style="font-size:250%; text-align:center">   And on Social Media:  </i>
        <%--<div><h2 class="center-block" style="text-align:center">And on Social Media</h2> --%>
            <br /><br />
           <a href="https://www.instagram.com/techelp_care"><img src="img/insta2.png" style="width:35px; height:35px"/></a> 
            <a href="https://twitter.com/tecHelp_care"><img src="img/twitter2.png" style="width:35px; height:35px; margin-left:3%"/></a>
            
        </div>
        
        </div>

</asp:Content>

