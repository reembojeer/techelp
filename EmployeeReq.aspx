<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeReq.aspx.cs" Inherits="EmployeeReq" %>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="EmpMain.aspx">Account</a></li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LogIn" Runat="Server">
    <li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body1" Runat="Server">

     
    <div class="container-fluid" style="height:auto" id="EmpMenue" >

        
        <br />
        <br />
        <br />
        <br />
        
        <div class="row">
           <div class="col-xs-3" style=" height:607px; margin-left:-14px;margin-top:-107px;  background-color:#eaeaea; text-align:center"> 
               
               <div  style=" margin-top:200px">
      <a href="EmployeeReq.aspx" >View Request</a>
               
                    <br /><br />
        
          <a href="EmployeeReport.aspx">Generate Report</a>

          
        
      
   
    </div>
           </div>

           

            <div class="col-xs-9" style="height: 607px; margin-top: -107px">
                <div style="margin-top: 200px; text-align: center; margin-left: 20%">




                    <asp:GridView ID="GetTicket" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" OnPageIndexChanging="GetTicket_PageIndexChanging">
                        <Columns>
                            <asp:HyperLinkField DataTextField="TicketNo" DataNavigateUrlFields="TicketNo" DataNavigateUrlFormatString="~/TicketContent.aspx?TicketNo={0}" HeaderText="Ticket Number" />
                            <asp:BoundField DataField="Title" HeaderText="Title " />
                            <asp:BoundField DataField="Date" HeaderText="Date " />
                            <asp:BoundField DataField="Status" HeaderText="Statue " />



                        </Columns>


                    </asp:GridView>


                </div>
            </div>

           

        </div>


    


        </div>

  
</asp:Content>

