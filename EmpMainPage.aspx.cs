using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmpMainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GoToReq_Click(object sender1, EventArgs e1)
    {


        Response.Redirect("EmployeeReq.aspx");



    }

    protected void GoToRep_Click(object sender1, EventArgs e1)
    {


        Response.Redirect("EmployeeReport.aspx");



    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
}