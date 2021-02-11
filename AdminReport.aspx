<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminReport.aspx.cs" Inherits="AdminReport" %>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="AdminMainPage.aspx">Account</a></li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LogIn" Runat="Server">
        <li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body1" Runat="Server">
   
 <div class="container-fluid" style="height:auto" id="EmpReport" >
     
        <%-- <nav class="navbar navbar-default">
        
             <ul class="nav navbar-nav">
                 <li class="active"><a href="AdminReport.aspx">Report</a></li>
                 <li><a href="Login2.aspx">Login</a></li>
                 <li><a href="AdminMainPage.aspx">Admin Main Page</a></li>
             </ul>
     </nav>--%>
        <br />
        <br />
        <br />
        <br />
        
        <div class="row">
            
           <div class="col-xs-3" style=" height:607px; margin-left:-14px;margin-top:-107px;  background-color:#eaeaea; text-align:center"> 
               
                <div  style=" margin-top:300px">
               
             
             <a href="AdminNewReq.aspx">New Request</a>
               <br />  <br />
                  
               <a href="AssignEmployee.aspx">Assign Employee</a> 
          

            <br />  <br />
                   
                <a href="AdminReport.aspx">Generate Report</a> 
      </div>
              
           </div>
     

             
     

            <div class="col-xs-9" style="height:607px; margin-top:-107px; float:right " >
                <div style="margin-top:200px;text-align:left; margin-left: 10%; font-size:17px">

                   
                    
                
                        <div>
                     <asp:Label ID="Title_lbl" runat="server" Style="background-color:#808080; color:white; margin-right:10px">

                    </asp:Label> 

                     

                        
                        <asp:DropDownList ID="report" runat="server" Style="margin-left:10px" OnSelectedIndexChanged="report_SelectedIndexChanged" AutoPostBack="true" Width="260px">
                            
                        </asp:DropDownList>
                              
                         <asp:DropDownList ID="Status_list" runat="server" Style="margin-left:10px" OnSelectedIndexChanged="report_SelectedIndexChanged" AutoPostBack="true" Width="100px">
                            
                        </asp:DropDownList> 

                        <asp:DropDownList ID="ticketNO_list" runat="server" Style="margin-left:10px" OnSelectedIndexChanged="report_SelectedIndexChanged" AutoPostBack="true" Width="100px">
                            
                        </asp:DropDownList> 
                            
                            <asp:textbox ID="DateBox" runat="server" Width="15%" Height="30%" placeholder="dd/mm/yyyy" OnTextChanged="Date_TextChanged" AutoPostBack="true">

                            </asp:textbox>
 
                              

                        </div> 

                        <br />

                       <div>
                           <asp:GridView ID="TicketReport" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="2" OnPageIndexChanging="TicketReport_PageIndexChanging">
                               <Columns>
                                   <asp:BoundField DataField="TicketNo" HeaderText="Ticket Number"  />
                                   <asp:BoundField DataField="Title" HeaderText="Title " />
                                   <asp:BoundField DataField="Date" HeaderText="Date " />
                                   <asp:BoundField DataField="Status" HeaderText="Status " />
                                   <asp:BoundField DataField="FullName" HeaderText="Employee " />



                               </Columns>


                           </asp:GridView> 

                           <br />
                         
                           <asp:Label ID="Meassage_lbl" runat="server">

                           </asp:Label> 
                           
                           
                           

                       </div>

                        <div>
                          

                          
                        </div>
                         
                 
                   
                    

                   
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
