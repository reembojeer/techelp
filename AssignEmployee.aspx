<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssignEmployee.aspx.cs" Inherits="AssignEmployee" %>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="AdminMainPage.aspx">Account</a></li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="LogIn" runat="Server">
    <li><a href="Login2.aspx" runat="server" onserverclick="LoginLink_Click" id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span>Logout</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body1" runat="Server">


    <div class="container-fluid" style="height: auto" id="EmpMenue">


        <br />
        <br />
        <br />
        <br />

        <div class="row">
            <div class="col-xs-3" style="height: 607px; margin-left: -14px; margin-top: -107px; background-color: #eaeaea; text-align: center">

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



            <div class="col-xs-9" style="height: 607px; margin-top: -107px; float: right">
                <div style="margin-top: 200px; text-align: center; margin-left: 30px; font-size: 17px; align-content: center">




                    <asp:Label ID="meassge_lbl" runat="server" Font-Size="20px"></asp:Label>
                    
                    <asp:GridView ID="NewTicket" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" OnPageIndexChanging="NewTicket_PageIndexChanging1">
                        <Columns>
                            <asp:HyperLinkField DataTextField="TicketNo" DataNavigateUrlFields="TicketNo" DataNavigateUrlFormatString="~/AssignDetails.aspx?TicketNo={0}" HeaderText="Ticket Number" />
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

