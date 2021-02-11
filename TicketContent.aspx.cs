using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;



public partial class TicketContent : System.Web.UI.Page
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



            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\1507767\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\1507767\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

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
            //Update_btn.Text = "Update";




            for (int i = 0; i < statusArray.Length; i++)
            {
                if (!statusArray[i].Equals(statue, StringComparison.OrdinalIgnoreCase))
                {
                    StausList.Items.Add(statusArray[i]);
                }

            }


            StausList.Items.Insert(0, new ListItem(statue, "NA"));



            con.Close();




        }
    }





    protected void StausList_SelectedIndexChanged(object sender, EventArgs e)
    {
        StatueValue = StausList.SelectedItem.Text;

    }


    protected void Update_btn_Click(object sender, EventArgs e)
    {
        int TicketNo = int.Parse(Request.QueryString["TicketNo"]);
        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

        //SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\1507767\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\1507767\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

        con2.Open();
        SqlCommand command2 = new SqlCommand("Update Ticket set Status = '" + StatueValue + "' where TicketNo =" + TicketNo + "", con2);
        SqlDataReader reader2 = command2.ExecuteReader();
        con2.Close();

        if (reader2.RecordsAffected > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('The Ticket Statue Has been Updated Successfully');window.location.href='EmployeeReq.aspx';", true);
            //Response.Write("<script>alert('The Ticket Statue Has been Updated Successfully');</script>");



           
            SqlCommand cmd44 = new SqlCommand("Select Email from Ticket where TicketNo = '" + TicketNo + "'", con2);

            con2.Open();

            SqlDataReader read = cmd44.ExecuteReader();

            while (read.Read())
            {
                string s = read.GetValue(0).ToString();
               
                var fromAddress = new MailAddress("techelp.care@gmail.com");
                var toAddress = new MailAddress(s);
                using (var mes = new MailMessage(fromAddress, toAddress))
                {



                  

                    StringBuilder sb = new StringBuilder();
                    mes.Subject = ("Ticket " + TicketNo);
                    sb.AppendLine("Techelp team Would like to afform you that your ticket with the number " + TicketNo + " has been updated to" + StausList.SelectedValue.ToString());
                    mes.Body = sb.ToString();




                    mes.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("techelp.care@gmail.com", "*TECHsupport*");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mes);
                    //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                }




               

            }

            con2.Close();




          


















        }

    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeReq.aspx");
    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
}