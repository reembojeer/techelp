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


public partial class AdminTicketReq : System.Web.UI.Page
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
                TextBox_Ticket_No.Text = val.ToString();

            }

            con.Close();

            DropDownList_Employee.Items.Insert(0, " No employee Available ");
        }

    }


    private void Getticket()
    {
        try
        {
            query = "Select * from Departement";
        da = new SqlDataAdapter(query, con);

        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DropDownList_Department.DataSource = ds;
            DropDownList_Department.DataTextField = "DepartementName";
            DropDownList_Department.DataValueField = "DepartementNo";
            DropDownList_Department.DataBind();
            DropDownList_Department.Items.Insert(0, new ListItem(" Choose  Departement Name", "0"));
            DropDownList_Department.SelectedIndex = 0;
           
        }
    }
         catch {

         }




    }



    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds.Clear();
        string get_department, DepartementName;
        DepartementName = DropDownList_Department.SelectedItem.Text;
        get_department = DropDownList_Department.SelectedValue.ToString();

        if (get_department != "0")
        {
            query = "Select Email, Fname from Employee where DepartementNo='" + get_department.ToString() + "'";
            da = new SqlDataAdapter(query, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList_Employee.DataSource = ds;
                DropDownList_Employee.DataTextField = "Fname";
                DropDownList_Employee.DataValueField = "Email";
                DropDownList_Employee.DataBind();
                DropDownList_Employee.Items.Insert(0, new ListItem("Choose " + DepartementName.ToString() + " Employee ", "0"));
                DropDownList_Employee.SelectedIndex = 0;
            }
        }
        else
        {
            DropDownList_Employee.Items.Insert(0, " No Department Available ");
            DropDownList_Employee.DataBind();
        }

    }













    protected void Button2_Click(object sender, EventArgs e)
    {
        // GoDaddy ConnectionString
        //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

        // Local ConnectionString
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");

        con.Open();



        SqlCommand cmd2 = new SqlCommand("insert into Ticket(Title,Date,Content,EmployeeEmail,Status,DepartementNo) values (@Title,@Date,@Content,@EmployeeEmail,@Status,@DepartementNo)", con);
        cmd2.Parameters.AddWithValue("Title", Session["Title"].ToString());
        cmd2.Parameters.AddWithValue("@Date", DateTime.Now);
        cmd2.Parameters.AddWithValue("Content", Session["Description"].ToString());
        cmd2.Parameters.AddWithValue("EmployeeEmail", DropDownList_Employee.Text);

        cmd2.Parameters.AddWithValue("Status", "new");
        cmd2.Parameters.AddWithValue("DepartementNo", DropDownList_Department.Text);

        int ii = cmd2.ExecuteNonQuery();


        con.Close();

    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='AdminMainPage.aspx';", true);

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Response.Redirect("AdminMainPage.aspx");
        }

        if (!Page.IsValid)
        {
            Response.Redirect("AdminMainPage.aspx");
        }
       
    }
}