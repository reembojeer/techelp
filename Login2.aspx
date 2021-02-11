<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login2.aspx.cs" Inherits="Login2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="LogIn" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Body1" Runat="Server">
    <div class="container-fluid center-block" style="margin-bottom:100px; margin-top:60px">
        <h2 style="text-align:center">Login:</h2>
       <div class="Formcontainer center-block">
 
      <div style="margin-top:20%"></div>
     
     <label style="margin-right:5%">UserNmae:</label> <asp:TextBox ID="TextBox_username" runat="server" placeholder="Enter Your UserName" Width="80%"></asp:TextBox>
      <br />
      <br />
     <label style="margin-right:5%">Password:</label> <asp:TextBox ID="TextBox_password" TextMode="Password" runat="server" placeholder="  Enter Your Password" Width="80%" Height="47px"></asp:TextBox>
      <div style="margin-bottom:10%"></div>
      <div class="center-block" style="margin-left:45%">
       <asp:Button ID="login" runat="server" Text="Login"  OnClick="Button1_Click"/>
        
     </div> 
           <br />
           <div style="color:red; text-align:center; font-size:20px">
             <asp:Label ID="Label1" runat="server"></asp:Label>
               </div>
      <div style="margin-bottom:10%"></div> 

 
           
</div>
        </div>

</asp:Content>
