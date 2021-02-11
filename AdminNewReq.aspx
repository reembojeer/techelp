<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminNewReq.aspx.cs" Inherits="AdminNewReq" %>
<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="AdminMainPage.aspx">Account</a></li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LogIn" Runat="Server">
     <li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body1" Runat="Server">

    <div class="container-fluid" style="height:auto" id="CustReport" >

      
        <div class="container-fluid" style="height:auto">
        <div class="row">


           <div class="col-xs-3" style=" height:860px; margin-left:-30px;margin-top:-20px;  background-color:#eaeaea; text-align:center"> 
               
             
                <div  style=" margin-top:300px">
               
             
             <a href="AdminNewReq.aspx">New Request</a>
               <br />  <br />
                  
               <a href="AssignEmployee.aspx">Assign Employee</a> 
          

            <br />  <br />
                   
                <a href="AdminReport.aspx">Generate Report</a> 
      </div>
           </div>

           

            <div class="col-xs-9" style="height:860px; margin-top:-107px; float:right " >
                <div style="margin-top:200px;text-align:left; margin-left: 10%; font-size:17px">

                    <h2 style="text-align: center">New Request</h2>

                    <div class="Formcontainer center-block" style="width:80%">
                      

                                 <div style="margin-top: 2%"></div>
                            <div  style="float: left">
                                <label >Title:&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp</label></div>
                            <div class="text-center">
                                <asp:TextBox ID="TextBox_title" runat="server" placeholder="Enter Your Title" Width="80%"></asp:TextBox>

                            </div>

                            <br />
                            <br />
                            <div  style="float: left">
                                <label>Descreption:</label>
                            </div>
                            <div class="text-center">
                                <asp:TextBox ID="TextBox_descreption" runat="server" placeholder="Enter Your Descreption" Width="80%" TextMode="MultiLine" Rows="10"></asp:TextBox></div>

                            <div style="margin-bottom: 10%"></div>
                            <div class="center-block" style="margin-left: 45%">
                                <asp:Button ID="Button1" runat="server" Text="CreatTicket" OnClick="Button1_Click" />
                            </div>

                       

                    </div>
                </div>
               

  

   
           </div>
       
             </div>
            </div>
           </div>


</asp:Content>

