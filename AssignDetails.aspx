<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssignDetails.aspx.cs" Inherits="AssignDetails" %>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="AdminMainPage.aspx">Account</a></li>
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
           <div class="col-xs-3" style=" height:700px; margin-left:-14px;margin-top:-107px;  background-color:#eaeaea; text-align:center"> 
               
                <div  style=" margin-top:300px">
               
             
             <a href="AdminNewReq.aspx">New Request</a>
               <br />  <br />
                  
               <a href="AssignEmployee.aspx">Assign Employee</a> 
          

            <br />  <br />
                   
                <a href="AdminReport.aspx">Generate Report</a> 
      </div>
           </div>

           

            <div class="col-xs-9" style="height:auto; margin-top:-107px; float:right " >
                <div style="margin-top:200px;text-align:left; margin-left:30px; font-size:17px">

                   
                    
                   
                       
                     <asp:Label ID="Title_lbl" runat="server" Style="background-color:#808080; color:white; margin-right:10px">

                    </asp:Label> 

                     <asp:Label ID="title" runat="server">

                    </asp:Label> 

                        <br />
                         <asp:label ID="Body_lbl" runat="server" Style="background-color:#808080; color:white; margin-right:10px;"></asp:label>
                            
                        <asp:label ID ="Body" runat="server" Style=" word-break:break-all; width:200px;"></asp:label>
                         <asp:label ID="Status_lbl" runat="server" Style="margin-left:10px; background-color:#808080; color:white" ></asp:label>
                            <asp:label ID="Statue" runat="server" Style="margin-left:5px"></asp:label>
                            <br />
                           <div style="margin-bottom:70px"></div>
                         <asp:Label ID="Dept_lbl" runat="server" Style="background-color:#808080; color:white; margin-right:10px">

                          </asp:Label>
                            <asp:label ID="Dept" runat="server" Style="margin-left:5px" ></asp:label>
                        


                        
                            <br />
                       <asp:DropDownList ID="EmployeeList" runat="server" OnSelectedIndexChanged="EmployeeList_SelectedIndexChanged"></asp:DropDownList>
                           

                    <div>

                        <div style="float:left">
                                <asp:RangeValidator ID="validate1" runat="server" ErrorMessage="* Choose an Emoloyee" ControlToValidate="EmployeeList" MaximumValue="zzzzzzzzzzzzzzzzzzzzz" MinimumValue="a" Type="String" ValidationGroup="group1" ForeColor="Red"></asp:RangeValidator>
                                    </div>

                    </div>

                     <div style="margin-bottom:70px"></div>

                    

                       <asp:Button ID="Assign_btn" ValidationGroup="group1" runat="server" Style="text-align: center; align-self: center; margin-left:230px; margin-top:60px" Text="Assign" OnClick="Assign_btn_Click" />
                        <asp:button id="backButton" runat="server" text="Back" OnClick="backButton_Click"></asp:button>
                        <br />
                       
                        <div>
                          
                          <%-- <asp:Button ID="Update_btn" runat="server" Style="text-align: center; align-self: center; margin-left:230px; margin-top:60px" Text="Update" OnClick="Update_btn_Click" />
                        


                             <asp:button id="backButton" runat="server" text="Back" OnClick="backButton_Click"></asp:button>--%>
                        </div>
                         
                
                    </div>
                    

                   
                    </div>
                </div>
            </div>
        
</asp:Content>

