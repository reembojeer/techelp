using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CustReqDetails : System.Web.UI.Page
{
    string StatueValue = "";

    public string[] statusArray2 = new string[7];
    public string[] statusArray = { "New", "10%", "30%", "50%", "70%", "90%", "Done" };
    public string statue;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            int TicketNo = int.Parse(Request.QueryString["TicketNo"]);

            // GoDaddy ConnectionString
            //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

            // Local ConnectionString
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
          
            con.Open();
            SqlCommand command = new SqlCommand("SELECT Title, Content, Status from Ticket WHERE TicketNo =" + TicketNo + "", con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {


                title.Text = reader["Title"].ToString();
                Body.Text = reader["Content"].ToString();
                statue = reader["Status"].ToString();


            }

            Body_lbl.Text = "Ticket Details:";
            Title_lbl.Text = "Title:";
            Status_lbl.Text = "Statue:";
            Label1.Text = statue; 
            //Update_btn.Text = "Update";




            //for (int i = 0; i < statusArray.Length; i++)
            //{
            //    if (!statusArray[i].Equals(statue, StringComparison.OrdinalIgnoreCase))
            //    {
            //        StausList.Items.Add(statusArray[i]);
            //    }

            //}


            //StausList.Items.Insert(0, new ListItem(statue, "NA"));



            con.Close();




        }
    }





    //protected void StausList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    StatueValue = StausList.SelectedItem.Text;

    //}


    //protected void Update_btn_Click(object sender, EventArgs e)
    //{
    //    int TicketNo = int.Parse(Request.QueryString["TicketNo"]);
    //    SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\1507767\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
    //    con2.Open();
    //    SqlCommand command2 = new SqlCommand("Update Ticket set Status = '" + StatueValue + "' where TicketNo =" + TicketNo + "", con2);
    //    SqlDataReader reader2 = command2.ExecuteReader();
    //    con2.Close();

    //    if (reader2.RecordsAffected > 0)
    //    {
    //        Response.Write("<script>alert('The Ticket Statue Has been Updated Successfully');</script>");

    //    }

    //}
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustStatus.aspx");
    }
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //    int messageNumber = int.Parse(Request.QueryString["TicketNo"]);
    //    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Administrator.DESKTOP-AFON4RM\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
    //    //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\1507767\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("select Title, Date, Content from Ticket where TicketNo =" + messageNumber + "", con);
    //    SqlDataReader dataReader = cmd.ExecuteReader();
    //    RequestDetails.DataSource = dataReader;
    //    RequestDetails.DataBind();

    //    con.Close();


    //}

    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //} 

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
}