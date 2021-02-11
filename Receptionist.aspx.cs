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

public partial class Receptionist : System.Web.UI.Page
{
    // GoDaddy ConnectionString
    //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

    // Local ConnectionString
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
          
    SqlDataAdapter da;
    DataSet ds = new DataSet();

    string query;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Getticket();

            SqlCommand com1 = new SqlCommand("SELECT COUNT(TicketNo)FROM Ticket", con);
            con.Open();

            SqlDataReader read = com1.ExecuteReader();

            while (read.Read())
            {
                string s = read.GetValue(0).ToString();
                int val = int.Parse(s) + 100;
                TextBox_TicketNo.Text = val.ToString();

            }

            con.Close();

          
        }

    }


    private void Getticket()
    {
        query = "Select * from Departement";
        da = new SqlDataAdapter(query, con);

        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Department.DataSource = ds;
            Department.DataTextField = "DepartementName";
            Department.DataValueField = "DepartementNo";
            Department.DataBind();
            Department.Items.Insert(0, new ListItem(" Choose  Departement Name", "0"));
            Department.SelectedIndex = 0;
        }
    }





    protected void Button2_Click(object sender, EventArgs e)
    {
        // GoDaddy ConnectionString
        //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

        // Local ConnectionString 

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
          
        var fromAddress = new MailAddress("techelp.care@gmail.com");
        var toAddress = new MailAddress(Session["from"].ToString());
        using (var mes = new MailMessage(fromAddress, toAddress))
        {

            SqlCommand cmd44 = new SqlCommand("Select * from Customer where Email= '"
                + Session["from"].ToString().Split('<', '>')[1] + "'", con);

            da = new SqlDataAdapter(cmd44);
            da.Fill(ds);
            int ia = ds.Tables[0].Rows.Count;
            if (ia > 0)
            {

                SqlCommand com12 = new SqlCommand("SELECT Email,Password FROM Customer where Email='" + Session["from"].ToString().Split('<', '>')[1] + "'", con);
                con.Open();
                SqlDataReader read1 = com12.ExecuteReader();

                while (read1.Read())
                {

                    StringBuilder sb = new StringBuilder();
                    mes.Subject = "Ticket " + TextBox_TicketNo.Text;
                    sb.AppendLine("Hello , Your Ticket has been issued with the Number: " + TextBox_TicketNo.Text);
                    sb.AppendLine(" Your Password is: " + read1.GetValue(1).ToString());
                    sb.AppendLine(" And The user name is your email, You can now check the statue of your ticket at any time at techelp.care");
                    sb.AppendLine("Tnank you and have a nice day.");

                    mes.Body = sb.ToString();

                }

                con.Close();

            }
            else
            {

                SqlCommand cmd14 = new SqlCommand("insert into Customer(Email,Password) values (@Email,@Password)", con);
                con.Open();

                if (Session["from"] != null)
                {
                    string from = Session["from"].ToString().Split('<', '>')[1];
                    cmd14.Parameters.AddWithValue("Email", from);
                }
                Random r = new Random();
                int ran = r.Next(0, 100000);
                string ss = ran.ToString();
                cmd14.Parameters.AddWithValue("Password", ss);

                int i = cmd14.ExecuteNonQuery();

                con.Close();

                SqlCommand com12 = new SqlCommand("SELECT Email,Password FROM Customer where Email='"
                    + Session["from"].ToString().Split('<', '>')[1] + "'", con);

                con.Open();

                SqlDataReader read1 = com12.ExecuteReader();

                while (read1.Read())
                {

                    StringBuilder sb = new StringBuilder();
                    mes.Subject = "Ticket " + TextBox_TicketNo.Text;
                    sb.AppendLine("Hello , Your Ticket has been issued with the Number: " + TextBox_TicketNo.Text);
                    sb.AppendLine(" Your Password is: " + read1.GetValue(1).ToString());
                    sb.AppendLine(" And The user name is your email, You can now check the statue of your ticket at any time at techelp.care");
                    sb.AppendLine("Tnank you and have a nice day.");
                    mes.Body = sb.ToString();




                }

                con.Close();


            }


            mes.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential("techelp.care@gmail.com", "*TECHsupport*");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mes);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('The Ticket has been Issued Successfully and The Email is Sent To customer');window.location.href='ImapClientProtocolAll.aspx';", true);
            
        }



        ////////////////
       
        con.Open();



        SqlCommand cmd2 = new SqlCommand("insert into Ticket(Email,Title,Date,Content,Status,DepartementNo) values (@Email,@Title,@Date,@Content,@Status,@DepartementNo)", con);
        cmd2.Parameters.AddWithValue("Email", Session["from"].ToString().Split('<', '>')[1]);
        cmd2.Parameters.AddWithValue("Title", Session["subject"].ToString());
        //??
        cmd2.Parameters.AddWithValue("Date", Session["Date"]);
        cmd2.Parameters.AddWithValue("Content", Session["body"].ToString());  
        //??
        cmd2.Parameters.AddWithValue("Status", "new");
        cmd2.Parameters.AddWithValue("DepartementNo", Department.Text);
        int ii = cmd2.ExecuteNonQuery();


        con.Close();



       




    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        Response.Redirect("mainreception.aspx");
        
    }
   
}