<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ImapClientProtocolAll.aspx.cs" Inherits="ImapClientProtocolAll" %>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="mainreception.aspx">Account</a></li>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LogIn" Runat="Server">
<li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Body1" Runat="Server">


    
    <div class="form-group" style="text-align: center">
        
        <asp:Label runat="server"></asp:Label>
        <div style="text-align:center; margin-left:25%; margin-top:50px">
            <asp:Table ID="EmailsTable" CssClass="emails-table" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="emails-table-header"
                        ColumnSpan="4">
                        Listing emails 
			<asp:Literal ID="EmailFromLiteral" runat="server" />-
			<asp:Literal ID="EmailToLiteral" runat="server" />
                        of 
			<asp:Literal ID="EmailTotalLiteral" runat="server" />
                        for 
			<asp:Literal ID="EmailLiteral" runat="server" />
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell CssClass="emails-table-header-cell">
				#</asp:TableCell><asp:TableCell CssClass="emails-table-header-cell">
				From</asp:TableCell><asp:TableCell CssClass="emails-table-header-cell">
				Subject</asp:TableCell><asp:TableCell CssClass="emails-table-header-cell">
				Date &amp; Time</asp:TableCell>
                </asp:TableRow>
                <asp:TableFooterRow>
                    <asp:TableCell CssClass="emails-table-footer" ColumnSpan="4">
                        <asp:Table ID="FooterTable" Width="100%"
                            BorderWidth="0" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Literal ID="PreviousPageLiteral" runat="server" />
                                </asp:TableCell>
                                <asp:TableCell HorizontalAlign="Right">
                                    <asp:Literal ID="NextPageLiteral" runat="server" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                </asp:TableFooterRow>
            </asp:Table>
        </div>
    </div></asp:Content>