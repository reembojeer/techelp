using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerReport : System.Web.UI.Page
{
    public string[] statusArray = { "New", "10%", "30%", "50%", "70%", "90%", "Done" };
    public int[] TickeNoArray;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack == false)
        {

            Title_lbl.Text = "Generate Report By: ";
            report.Items.Add("Generate All Tickets");
            report.Items.Add("Generate By Statue");
            report.Items.Add("Generate By Date");
            report.Items.Insert(0, new ListItem("Select a Method", "NA"));

            for (int i = 0; i < statusArray.Length; i++)
            {

                Status_list.Items.Add(statusArray[i]);

            }

        }

        TicketReport.Visible = false;
        ticketNO_list.Visible = false;
        Status_list.Visible = false;
        Meassage_lbl.Visible = false;
       

    }






    protected void report_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (report.SelectedValue.Equals("Generate All Tickets"))
        {

            LoadAllTickets();

        }

        else if (report.SelectedValue.Equals("Generate By Statue"))
        {


            LoadTicketsStatue();


        }



        else if (report.SelectedValue.Equals("Generate By Date"))
        {
            DateBox.Visible = true;
            Status_list.Visible = false;
            Meassage_lbl.Visible = false;


        }



        else
        {

            TicketReport.Visible = false;
            ticketNO_list.Visible = false;
            Status_list.Visible = false;
            Meassage_lbl.Visible = false;
            DateBox.Visible = false;

        }
    }
    protected void TicketDate_SelectionChanged(object sender, EventArgs e)
    {

    }



    protected void Date_TextChanged(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

        try
        {

            DateTime dt = DateTime.ParseExact(DateBox.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);

            // GoDaddy ConnectionString
            //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

            // Local ConnectionString

            con.Open();
            SqlCommand command = new SqlCommand("SELECT TicketNo, Title, Date,Status, Content from Ticket WHERE Email = '" + Session["Email"].ToString() + "' AND DATE ='" + dt.Date + "'", con);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TicketReport.Visible = true;
                TicketReport.DataSource = ds;
                TicketReport.DataBind();
                con.Close();
            }
            else
            {
                Meassage_lbl.Text = "There is No Tickets To Display";
                TicketReport.Visible = false;
                Meassage_lbl.Visible = true;
                DateBox.Visible = true;
            }
        }
        catch
        {
            Meassage_lbl.Text = "Incorrect Date Syntax";
            Meassage_lbl.Visible = true;
            con.Close();
        }

    }
    protected void TicketReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (report.SelectedValue.Equals("Generate All Tickets"))
        {

            TicketReport.PageIndex = e.NewPageIndex;
            LoadAllTickets();
        }
        else if (report.SelectedValue.Equals("Generate By Statue"))
        {

            TicketReport.PageIndex = e.NewPageIndex;
            LoadTicketsStatue();
        }

        else if (report.SelectedValue.Equals("Generate By Date"))
        {

            TicketReport.PageIndex = e.NewPageIndex;
            LoadTicketsDate();
        }
    }

    protected void LoadAllTickets()
    {

        // GoDaddy ConnectionString
        //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

        // Local ConnectionString
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

        con.Open();
        SqlCommand command = new SqlCommand("SELECT TicketNo, Title, Date,Status, Content from Ticket WHERE Email = '" + Session["Email"].ToString() + "' ", con);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            TicketReport.Visible = true;
            TicketReport.DataSource = ds;
            TicketReport.DataBind();
            con.Close();
        }
        else
        {
            Meassage_lbl.Text = "There is No Tickets To Display";
            TicketReport.Visible = false;
            Meassage_lbl.Visible = true;
            DateBox.Visible = false;
        }

    }

    protected void LoadTicketsStatue()
    {
        Status_list.Visible = true;

        // GoDaddy ConnectionString
        //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

        // Local ConnectionString
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

        con.Open();
        SqlCommand command = new SqlCommand("SELECT TicketNo, Title, Date,Status, Content from Ticket WHERE Email = '" + Session["Email"].ToString() + "' AND STATUS='" + Status_list.SelectedValue + "'", con);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);
        Status_list.Visible = true;
        TicketReport.Visible = true;
        Meassage_lbl.Visible = false;
        ticketNO_list.Visible = false;
        DateBox.Visible = false;

        if (ds.Tables[0].Rows.Count > 0)
        {
            TicketReport.DataSource = ds;
            TicketReport.DataBind();
            con.Close();
        }
        else
        {

            Meassage_lbl.Text = "There is No Tickets With this statue";
            TicketReport.Visible = false;
            Meassage_lbl.Visible = true;
            ticketNO_list.Visible = false;
            DateBox.Visible = false;
        }


    }




    // GoDaddy ConnectionString
    //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

    // Local ConnectionString









    protected void LoadTicketsDate()
    {
        DateBox.Visible = true;
        Status_list.Visible = false;
        Meassage_lbl.Visible = false;

        // GoDaddy ConnectionString
        //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

        // Local ConnectionString
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

        con.Open();
        SqlCommand command = new SqlCommand("SELECT TicketNo, Title, Date,Status, Content from Ticket WHERE Email = '" + Session["Email"].ToString() + "' ", con);
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(command);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            TicketReport.Visible = true;
            TicketReport.DataSource = ds;
            TicketReport.DataBind();
            con.Close();
        }
        else
        {
            Meassage_lbl.Text = "There is No Tickets To Display";
            TicketReport.Visible = false;
            Meassage_lbl.Visible = true;
            DateBox.Visible = true;
        }

    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
}