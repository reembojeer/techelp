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
using AE.Net.Mail;

public partial class DisplayUnseen : System.Web.UI.Page
{
    public const string Host = "Imap.gmail.com";
    public const int Port = 993;
    public string Email;
    public string Password;
    protected static Regex CharsetRegex = new Regex("charset=\"?(?<charset>[^\\s\"]+)\"?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    protected static Regex QuotedPrintableRegex = new Regex("=(?<hexchars>[0-9a-fA-F]{2,2})", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    protected static Regex UrlRegex = new Regex("(?<url>https?://[^\\s\"]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    protected static Regex FilenameRegex = new Regex("filename=\"?(?<filename>[^\\s\"]+)\"?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    protected static Regex NameRegex = new Regex("name=\"?(?<filename>[^\\s\"]+)\"?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    protected void Page_Load(object sender, EventArgs e)
    {
        int emailId = 0;
        if (Request.QueryString["emailId"] == null)
        {
            //Response.Redirect("ImapClientProtocolAll.aspx");
            Response.Redirect("ImapClientProtocolUnseen.aspx");

            Response.Flush();
            Response.End();
        }
        else
        Email = Session["email"].ToString();
        Password = Session["pwd"].ToString();
        emailId = Convert.ToInt32(Request.QueryString["emailId"]);

        ImapClient ic = new ImapClient(Host, Email, Password, AuthMethods.Login, Convert.ToInt32(Port), true);
        MailMessage email = new MailMessage();
        var message = ic.GetMessage(emailId - 1);
        email.Body = message.Body;
        Session["body"] = email.Body;

        email.Subject = message.Subject;
        Session["subject"] = email.Subject;

        email.Date = message.Date;
        Session["Date"] = email.Date;

        email.Sender = message.Sender;

        email.From = message.From;
        Session["from"] = email.From;



        EmailIdLiteral.Text = Convert.ToString(emailId);
        DateLiteral.Text = email.Date.ToString();
        if (email.Sender != null)

            FromLiteral.Text = email.Sender.ToString();
        //??

        else
            FromLiteral.Text = email.From.ToString();


        SubjectLiteral.Text = email.Subject;
        BodyLiteral.Text = email.Body;


    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        //Response.Redirect("Ticket.aspx");

        Response.Redirect("Receptionist.aspx");
    }



    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }



}
