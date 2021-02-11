<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustReqDetails.aspx.cs" Inherits="CustReqDetails" %>


<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="CustMainPage.aspx">Account</a></li>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="LogIn" runat="server">
     <li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>
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
                <div style="margin-top: 200px; text-align: left; margin-left: 20%">

                   
                    
                 
                        <div>
                     <asp:Label ID="Title_lbl" runat="server" Style="background-color:#808080; color:white; margin-right:10px">

                    </asp:Label> 

                     <asp:Label ID="title" runat="server">

                    </asp:Label> 

                        <br />
                         <asp:label ID="Body_lbl" runat="server" Style="background-color:#808080; color:white; margin-right:10px;"></asp:label>
                        <asp:label ID="Body" runat="server" Style="word-wrap: normal; word-break:normal"></asp:label>
                         <asp:label ID="Status_lbl" runat="server" Style="margin-left:10px; background-color:#808080; color:white" ></asp:label>



                        <asp:label ID="Label1" runat="server" Style="margin-left:10px"></asp:label>
                      <%--  <asp:DropDownList ID="StausList" runat="server" Style="margin-left:10px" OnSelectedIndexChanged="StausList_SelectedIndexChanged" Width="12%">
                            
                        </asp:DropDownList>--%>
                        </div>

                        <br />
                       
                        <div class="center-block">
                          
                           <%--<asp:Button ID="Update_btn" runat="server" Style="text-align: center;  margin-top:60px ; margin-left:30%" Text="Update" OnClick="Update_btn_Click" />--%>
                             <asp:Button ID="backButton" runat="server" text="Back" OnClick="backButton_Click" Style=" margin-left:10%; margin-top:50px"></asp:Button>
                        </div>
                         
                  
                   
                    

                   
                    </div>
                </div>
            </div>
        </div>
    
</asp:Content>




<%--<asp:Content ID="Content3" ContentPlaceHolderID="Body1" runat="server">


     <div class="container-fluid" style="height:auto" id="EmpMenue" >

        
        <br />
        <br />
        <br />
        <br />
    
        <div class="row">
           <div class="col-xs-2" style=" height:607px; margin-left:-14px;margin-top:-107px;  background-color:#eaeaea"> 
               
               <div  style=" margin-top:200px; margin-left:-15px"">
      <a href="#" >View Request</a>
               
                    <br /><br />
        
          <a href="#">Generate Report</a>

          
        
      
   
    </div>
           </div>
            


    <div class="col-xs-10" style="height:607px; margin-top:-107px; float:right " >
                <div style="margin-top:200px;text-align:center; margin-left:30px; font-size:17px; align-content:center">

   <div class="container-fluid center-block" style="margin-bottom:100px; margin-top:60px">
        <h2 style="text-align:center">Request Details:</h2>
       <div class="Formcontainer center-block">
   
    <div>
    
        <asp:GridView ID="RequestDetails" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <br />
    
    </div>
   
           
           </div>

                     </div>

                   
                    </div>
                </div>
            </div>
        </div>
</asp:Content>--%>
