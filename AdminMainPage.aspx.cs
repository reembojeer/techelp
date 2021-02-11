using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GoToRepo_Click(object sender, EventArgs e)
    {

        Response.Redirect("AdminReport.aspx");
    }

    protected void GoToNewReq_Click(object sender, EventArgs e)
    {

        Response.Redirect("AdminNewReq.aspx");
        //Response.Redirect("AssignEmployee.aspx");
    }

    protected void GoToAssignEmp(object sender, EventArgs e)
    {
        Response.Redirect("AssignEmployee.aspx");
    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
}