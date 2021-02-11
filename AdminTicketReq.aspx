<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminTicketReq.aspx.cs" Inherits="AdminTicketReq" %>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="AdminMainPage.aspx">Account</a></li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LogIn" runat="Server">
    <li><a href="Login2.aspx" runat="server" onserverclick="LoginLink_Click" id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span>Logout</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body1" runat="Server">
    <%--<div class="container-fluid center-block" style="margin-bottom:100px; margin-top:60px">--%>

    <div class="container-fluid" style="height: auto">
        <div class="row">

            <div class="col-xs-3" style="height: 860px; margin-left: -15px; margin-top: -20px; background-color: #eaeaea; text-align: center">

                <div style="margin-top: 300px">


                    <a href="AdminNewReq.aspx">New Request</a>
                    <br />
                    <br />

                    <a href="AssignEmployee.aspx">Assign Employee</a>


                    <br />
                    <br />

                    <a href="AdminReport.aspx">Generate Report</a>
                </div>


            </div>






            <div class="col-xs-9" style="height: 700px; margin-top: -107px; float: right">
                <div style="margin-top: 180px; text-align: left; margin-left: 10%; font-size: 17px">

                    <h2 style="text-align: center">Ticket Request:</h2>
                    <div class="Formcontainer center-block" style="width: 80%">

                        <div>





                            <label>Ticket No.</label>
                            <br />




                            <asp:TextBox ID="TextBox_Ticket_No" runat="server" Height="40px" CssClass="form-control" Width="150px"></asp:TextBox>
                            <br />
                            <br />


                            <div style="float: left">
                                <label style="text-align: left">Department:</label>
                                <br />
                                <asp:DropDownList ID="DropDownList_Department" runat="server" AppendDataBoundItems="false" AutoPostBack="True" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" DataValueField="AutoId" DataTextField="firstName" Height="42px" Width="252px">
                               
                                     </asp:DropDownList> 
                                
                              
                            </div>




                            <div style="float: right">
                                <label style="float: left">Eployee</label><br />
                                <asp:DropDownList ID="DropDownList_Employee" runat="server" AppendDataBoundItems="false" DataValueField="AutoId" DataTextField="firstName" Height="42px" Width="252px">
                                    
                                </asp:DropDownList>
                               
                            </div>

                            <div style="margin-top:10%; margin-bottom:10%" >
                                <div style="float:left">
                                <asp:RangeValidator ID="validate1" runat="server" ErrorMessage="* Choose a Departement" ControlToValidate="DropDownList_Department" MaximumValue="10000" MinimumValue="1" Type="Integer" ValidationGroup="group1" ForeColor="Red"></asp:RangeValidator>
                                    </div>
                                <div style="float:right">
                                <asp:RangeValidator ID="validate2" runat="server" ErrorMessage="* Choose an Emoloyee" ControlToValidate="DropDownList_Employee" MaximumValue="zzzzzzzzzzzzzzzzzzzzz" MinimumValue="a" Type="String" ValidationGroup="group1" ForeColor="Red"></asp:RangeValidator>
                                    </div>
                            </div>
                               <div style="margin-bottom:170px"></div>
                            <br/>

                            <div class="text-center">
                                <asp:Button ID="Button3" runat="server" Text="Cancel" Width="104px" OnClick="Button3_Click" />
                                  
                                <asp:Button ID="Button2" runat="server" Text="Assing employee" Width="170px" OnClick="Button2_Click" ValidationGroup="group1"/>

                            </div>




                            <br />






                        </div>

                    </div>
                </div>
            </div>



        </div>


    </div>






</asp:Content>

