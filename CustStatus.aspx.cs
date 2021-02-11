using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CustStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {


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
        SqlCommand command = new SqlCommand("SELECT TicketNo, Title, Date,Status, Content from Ticket WHERE Email = '" 
            + Session["Email"].ToString() + "' ", con);
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
//    protected void Page_Load(object sender, EventArgs e)
//    {
//        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\1507767\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

//        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator.DESKTOP-AFON4RM\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
//        con.Open();
//        //string CustomerEmail =  Request.QueryString["Username"];
//        if (Session["Email"] != null)
//        {

//            //string CustEmail = Session["Email"].ToString();



//            SqlCommand cmd = new SqlCommand("SELECT TicketNo, Date, Status FROM Ticket WHERE Email = '" + Session["Email"].ToString() + "'", con);

//            SqlDataReader dataReader = cmd.ExecuteReader();
//            GetTicket.DataSource = dataReader;
//            GetTicket.DataBind();




//            //if (!this.IsPostBack)
//            //{
//            //    string sql = "SELECT TicketNo, Date, Status FROM Ticket WHERE Email = '" + CustEmail + "'";
//            //    GridView1.DataSource = this.GetData(sql);
//            //    GridView1.DataBind();
//            //}


//        }


//        con.Close();

//    }


//    //private DataTable GetData(string sql)
//    //{
//    //    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\1507767\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30"))
//    //    {
//    //        using (SqlCommand cmd = new SqlCommand(sql))
//    //        {
//    //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
//    //            {
//    //                cmd.Connection = con;
//    //                DataTable dt = new DataTable();
//    //                sda.Fill(dt);
//    //                return dt;
//    //            }
//    //        }
//    //    }
//    //} 

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
}