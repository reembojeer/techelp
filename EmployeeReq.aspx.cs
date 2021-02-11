using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmployeeReq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if(IsPostBack==false){


             LoadTickets();
        
        } 
        
        }

    protected void LoadTickets()
    {
        // GoDaddy ConnectionString
        //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

        // Local ConnectionString
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
          
        con.Open();
        SqlCommand command = new SqlCommand("SELECT TicketNo, Title, Date,Status, Content from Ticket WHERE EmployeeEmail = 'nawal-ahmad@gmail.com' ", con);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);
        GetTicket.DataSource = ds;
        GetTicket.DataBind();
        con.Close();
    }

    protected void GetTicket_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       GetTicket.PageIndex = e.NewPageIndex;
       LoadTickets();
    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
}
