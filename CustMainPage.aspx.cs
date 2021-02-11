using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GoToStatus_Click(object sender, EventArgs e)
    {

        Response.Redirect("CustStatus.aspx");
    }



    protected void GoToReport_Click(object sender, EventArgs e)
    {

        Response.Redirect("CustomerReport.aspx");
    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
}