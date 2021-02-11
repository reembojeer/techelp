using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using Google.GData.Extensions;
using AE.Net.Mail;
using ReadInboxEmail.WebApplication.Models;
public partial class ImapClientProtocolAll : System.Web.UI.Page
{
    public const string Host = "imap.gmail.com";
    public const int Port = 993;
    public string Email;
    public string Password;
    public const int NoOfEmailsPerPage = 5;
    public const string SelfLink = "<a href=\"ImapClientProtocolAll.aspx?page={0}\">{1}</a>";
    public const string DisplayEmailLink = "<a href=\"DisplayPop3Email.aspx?emailId={0}\">{1}</a>";
    public String[] uids;

    protected void Page_Load(object sender, EventArgs e)
    {
        int page = -1;
        if (Request.QueryString["page"] == null)
        {
            Response.Redirect("ImapClientProtocolAll.aspx?page=1");
            Response.Flush();
            Response.End();
        }
        else
            page = Convert.ToInt32(Request.QueryString["page"]);
        try
        {
            Email = Session["email"].ToString();
            Password = Session["pwd"].ToString();
        
        int totalEmails;
        //List<EMail> emails;
        string emailAddress;
        EmailConfiguration email = new EmailConfiguration();
        email.IMAPServer = "imap.gmail.com"; // type your popserver
        email.IMAPUsername = Email; // type your username credential
        email.IMAPpassword = Password; // type your password credential
        email.IncomingPort = "993";
        email.IsIMAPssl = true;
        int success = 0;
        //int fail = 0;
        
       
            DashBoardMailBoxJob model = new DashBoardMailBoxJob();
            ImapClient ic = new ImapClient(email.IMAPServer, email.IMAPUsername, email.IMAPpassword, AuthMethods.Login, Convert.ToInt32(email.IncomingPort), (bool)email.IsIMAPssl);
            ic.SelectMailbox("INBOX");
            uids = ic.Search("ALL");
            int co = uids.Count();
            totalEmails = ic.GetMessageCount();

            emailAddress = Email;


            int totalPages;
            int mod = (co) % NoOfEmailsPerPage;
            if (mod == 0)
                totalPages = (co) / NoOfEmailsPerPage;
            else
                totalPages = ((co - mod) / NoOfEmailsPerPage) + 1;

            int i = 0;
            foreach (var uid in uids)
            {
                MailMessege obj = new MailMessege();
                var message = ic.GetMessage(uid);

                obj.sender = message.From.ToString();
                obj.sendDate = message.Date;
                obj.subject = message.Subject;
                obj.UID = message.Uid; //UID is unique identifier assigned to each message by mail server
                if (message.Attachments == null) { }
                else obj.Attachments = message.Attachments;
                //model.Inbox.Add(obj);
                success++;
                int emailId = ((page - 1) * NoOfEmailsPerPage) + i + 1;
                TableCell noCell = new TableCell();
                noCell.CssClass = "emails-table-cell";
                noCell.Text = Convert.ToString(emailId);
                TableCell fromCell = new TableCell();
                fromCell.CssClass = "emails-table-cell";
                fromCell.Text = obj.sender;
                TableCell subjectCell = new TableCell();
                subjectCell.CssClass = "emails-table-cell";
                subjectCell.Style["width"] = "300px";
                subjectCell.Text = String.Format(DisplayEmailLink, emailId, obj.subject);
                TableCell dateCell = new TableCell();
                dateCell.CssClass = "emails-table-cell";
                if (obj.sendDate != DateTime.MinValue)
                    dateCell.Text = obj.sendDate.ToString();
                TableRow emailRow = new TableRow();
                emailRow.Cells.Add(noCell);
                emailRow.Cells.Add(fromCell);
                emailRow.Cells.Add(subjectCell);
                emailRow.Cells.Add(dateCell);
                EmailsTable.Rows.AddAt(2 + i, emailRow);
                i = i + 1;
            }

            if (totalPages > 1)
            {
                if (page > 1)
                    PreviousPageLiteral.Text = String.Format(SelfLink, page - 1, "Previous Page");
                if (page > 0 && page < totalPages)
                    NextPageLiteral.Text = String.Format(SelfLink, page + 1, "Next Page");
            }
            EmailFromLiteral.Text = Convert.ToString(((page - 1) * NoOfEmailsPerPage) + 1);
            EmailToLiteral.Text = Convert.ToString(page * NoOfEmailsPerPage);
            EmailTotalLiteral.Text = Convert.ToString(totalEmails);
            EmailLiteral.Text = emailAddress;




        }

        catch (Exception ex)
        {

            Response.Redirect("Login.aspx");

        }

      

    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }

}

