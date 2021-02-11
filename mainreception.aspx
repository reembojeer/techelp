<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mainreception.aspx.cs" Inherits="mainreception" %>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="mainreception.aspx">Account</a></li>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="LogIn" Runat="Server">
<li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body1" Runat="Server">

   

    


        <div class="container-fluid" style="height:auto" id="EmpMain"> 
           <div class="container-fluid" style="height:600px">
               <div style="text-align:center; margin-top:100px">
               <asp:Label ID="WelcomeLabel" runat="server">


               </asp:Label>
                   </div>
            
            
              <div class="row" style="margin-bottom:80px; margin-top:50px">
 <div class="col-sm-3"></div>
          <div class="col-sm-6">
              

                  <div class="MyShadow" style="background-color: #eaeaea">
                      
                      <i class="fa fa-edit" style="font-size: 30px; margin-top: 30px"></i>
                      <hr />

                      <asp:LinkButton id="GoToShowrque" runat="server" OnClick="Inbox">
                         Inbox
                      </asp:LinkButton>
                      
                  </div>
             
                 <div class="col-sm-3"></div>

          </div>

         

         
               

      </div>
         
      </div>
  </div>

        

   
    


</asp:Content>
