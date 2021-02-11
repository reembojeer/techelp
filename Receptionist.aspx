<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Receptionist.aspx.cs" Inherits="Receptionist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LogIn" Runat="Server">
    <li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="mainreception.aspx">Account</a></li>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Body1" Runat="Server">

   
 <div class="container-fluid" style="height:auto">
        <div class="row">
           <div class="col-xs-3" style=" height:700px; margin-left:-14px;margin-top:-20px;  background-color:#eaeaea; text-align:center"> 
                <div  style=" margin-top:350px">
      <a href="select.aspx" >Inbox</a>
               
                    <br /><br />
        
       

          
        
      
   
    </div>
               </div>


            <div class="col-xs-9" style="height:700px; margin-top:-107px; float:right " >
                <div style="margin-top: 180px; text-align: left; margin-left: 10%; font-size: 17px">

             <h2 style="text-align:center">Ticket Request:</h2>
       <div class="Formcontainer center-block">

    <div>


          
    


        <label style="margin-right:5%">Ticket No.</label>
        <br />
          <asp:TextBox ID="TextBox_TicketNo" runat="server" Height="40px" placeholder="Ticket Number" Width="150px"></asp:TextBox>
        <br />
          <br />
        <div style="margin-left">
         <label> Department</label><br />
        <asp:DropDownList ID="Department" runat="server" AppendDataBoundItems="false"  AutoPostBack="True"  DataValueField="AutoId" DataTextField="firstName" Height="42px" Width="202px">
        </asp:DropDownList>
            </div>
        <div style="float:left">
                                <asp:RangeValidator ID="validate1" runat="server" ErrorMessage="* Choose a Departement" ControlToValidate="Department" MaximumValue="10000" MinimumValue="1" Type="Integer" ValidationGroup="group1" ForeColor="Red"></asp:RangeValidator>
                                    </div>
                                
        
          <br />
          <br />
        <br />
      <div style="text-align:center">
          <asp:Button ID="Button3" runat="server" Text="Cancel" Width="150px" OnClick="Button3_Click1" />

        <asp:Button ID="Button2" runat="server" Text="Send" OnClick="Button2_Click" Width="150px" ValidationGroup="group1" />

        </div>

        <br />



   
    </div>
 
           </div>
        </div>
                </div>
  

   
           </div>
       

             </div>
        


</asp:Content>

