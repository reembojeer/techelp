<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminMainPage.aspx.cs" Inherits="AdminMainPage" %>
<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="AdminMainPage.aspx">Account</a></li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LogIn" Runat="Server">
    <li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Body1" Runat="Server">

   

    


        <div class="container-fluid" style="height:auto" id="EmpMain"> 
           <div class="container-fluid" style="height:600px">
               <div style="text-align:center; margin-top:100px">
               <asp:Label ID="WelcomeLabel" runat="server">


               </asp:Label>
                   </div>
            
            
             <div class="row" style="margin-bottom:30px; margin-top:50px">
       <div class="col-sm-6">
                    <div class="MyShadow" style="background-color: #eaeaea">

                        <i class="fa fa-user-o" style="font-size: 30px; margin-top: 30px"></i>
                        <hr />
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="GoToAssignEmp">
                          Assign Employee
                        </asp:LinkButton>

                    </div>
                </div>

          <div class="col-sm-6">
                    <div class="MyShadow" style="background-color: #eaeaea">

                        <i class="fa fa-file-text-o" style="font-size: 30px; margin-top: 30px"></i>
                        <hr />
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="GoToRepo_Click">
                          Generate Report
                        </asp:LinkButton>

                    </div>
                </div>

                 


         
      </div>

               <div class="row" style="margin-bottom:100px">
                    <div class="col-sm-3"></div>
                   <div class="col-sm-6">
                    <div class="MyShadow" style="background-color: #eaeaea">

                        <i class="fa fa-send-o" style="font-size: 30px; margin-top: 30px"></i>
                        <hr />
                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="GoToNewReq_Click">
                          New Request
                        </asp:LinkButton>

                    </div>
                </div>
                        <div class="col-sm-3"></div>
               </div>
  </div>

        </div>


    



    </asp:Content>



































