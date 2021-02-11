<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustStatus.aspx.cs" Inherits="CustStatus" %>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="CustMainPage.aspx">Account</a></li>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="LogIn" runat="server">
     <li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="Body1" runat="server">

     <div class="container-fluid" style="height:auto" id="CustStatus" >

        
        <br />
        <br />
        <br />
        <br />
        
        <div class="row">
           <div class="col-xs-2" style=" height:607px; margin-left:-14px;margin-top:-107px;  background-color:#eaeaea"> 
               
               <div  style=" margin-top:200px; margin-left:-15px"">


          
        
      
   
    </div>
           </div>
             <div class="col-xs-10" style="height:607px; margin-top:-107px; float:right " >
                <div style="margin-top:200px;text-align:center; margin-left:30px; font-size:17px; align-content:center">

   <div class="container-fluid center-block" style="margin-bottom:100px; margin-top:60px">
        <h2 style="text-align:center">Request Status:</h2>
       <div class="Formcontainer center-block">

   
    <div>

        <asp:GridView ID="RequestStatus" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:HyperLinkField DataTextField="TicketNo" DataNavigateUrlFields="TicketNo" DataNavigateUrlFormatString="~/CustReqDetails.aspx?TicketNo={0}" HeaderText="Ticket Number" />
                <asp:BoundField DataField="Date" HeaderText="Date " />
                <asp:BoundField DataField="Status" HeaderText="Statue " />

            </Columns>

        </asp:GridView>
        <br />
        <br />
    
    </div>
 
           </div>
                 </div>
                    </div>
                 </div>

         
</asp:Content>

--%>


<asp:Content ID="Content1" ContentPlaceHolderID="Body1" Runat="Server">

     
    <div class="container-fluid" style="height:auto" id="EmpMenue" >

        
        <br />
        <br />
        <br />
        <br />
        
        <div class="row">
           <div class="col-xs-3" style=" height:607px; margin-left:-14px;margin-top:-107px;  background-color:#eaeaea; text-align:center"> 
               
               <div  style=" margin-top:200px">
      <a href="CustStatus.aspx" >View Request</a>
               
                    <br /><br />
        
          <a href="CustomerReport.aspx">Generate Report</a>
          
        
      
   
    </div>
           </div>

           

            <div class="col-xs-9" style="height: 607px; margin-top: -107px">
                <div style="margin-top: 200px; text-align: center; margin-left: 20%">




                    <asp:GridView ID="GetTicket" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" OnPageIndexChanging="GetTicket_PageIndexChanging">
                        <Columns>
                            <asp:HyperLinkField DataTextField="TicketNo" DataNavigateUrlFields="TicketNo" DataNavigateUrlFormatString="~/CustReqDetails.aspx?TicketNo={0}" HeaderText="Ticket Number" />
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

