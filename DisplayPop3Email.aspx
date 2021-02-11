<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayPop3Email.aspx.cs" Inherits="DisplayPop3Email" %>

<asp:Content ID="Content3" ContentPlaceHolderID="LogIn" Runat="Server">
<li><a  href="Login2.aspx" runat="server" onserverclick="LoginLink_Click"  id="LoginLink" mode="hold"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
</asp:Content>

<asp:Content ID="AccountContent" ContentPlaceHolderID="Account" runat="server">
    <li class="active"><a href="mainreception.aspx">Account</a></li>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Body1" Runat="Server">



     

 <div class="form-group">
     <div style="text-align:center; margin-left:25%; margin-top:50px">
         <asp:Label runat="server" ></asp:Label>
    <asp:Literal ID="DebugLiteral" runat="server" />
    
    <table class="emails-table">
    <tr>
		<td class="emails-table-header" colspan="2">
		Email #<asp:Literal ID="EmailIdLiteral" runat="server" /></td>
    </tr>
    <tr>
		<td class="emails-table-header-cell">Date &amp; Time</td>
		<td class="emails-table-cell">
			<asp:Literal ID="DateLiteral" runat="server" /></td>
    </tr>
    <tr>
		<td class="emails-table-header-cell">From</td>
		<td class="emails-table-cell">
			<asp:Literal ID="FromLiteral" runat="server" /></td>
    </tr>
    <tr>
		<td class="emails-table-header-cell">Subject</td>
		<td class="emails-table-cell">
			<asp:Literal ID="SubjectLiteral" runat="server" /></td>
    </tr>
    
     <tr>
		<td class="emails-table-cell" colspan="2">
			<asp:Literal ID="HeadersLiteral" runat="server" /></td>
    </tr>
    <tr>
		<td class="emails-table-cell" colspan="2">
			<asp:Literal ID="BodyLiteral" runat="server" /></td>
    </tr>
        </table>

       <div  style="text-align:center; margin-right:30%; margin-top:50px; margin-bottom:100px">
                <asp:Button runat="server" OnClick="Button1_Click" Text="Create Ticket" CssClass="btn btn-default" />
         
       </div> 
         </div>      
</div>



</asp:Content>

