using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssignDetails : System.Web.UI.Page
{
    int TicketNo = 0;

    // GoDaddy ConnectionString
    //public SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

    // Local ConnectionString
    public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");


    SqlDataAdapter da;
    DataSet ds = new DataSet();
    DataSet ds2 = new DataSet();
    string query;
    string query2; 
    int depNum = 0;

    protected void Page_Load(object sender, EventArgs e)
    { 
        if (IsPostBack == false)
        {


             TicketNo = int.Parse(Request.QueryString["TicketNo"]);
           

           
            con.Open();
            SqlCommand command = new SqlCommand("SELECT Title, Status, Content, DepartementNo from Ticket WHERE TicketNo =" + TicketNo + "", con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {


                title.Text = reader["Title"].ToString();
                Body.Text = reader["Content"].ToString();
                Statue.Text = reader["Status"].ToString();
                depNum = Convert.ToInt32(reader["DepartementNo"]);
                    

            }

            Body_lbl.Text = "Ticket Details:";
            Title_lbl.Text = "Title:";
            Status_lbl.Text = "Statue:";
            Dept_lbl.Text = "Departement:";
           
            reader.Close();

            GetEmp();
            GetDEPT(depNum);





            con.Close();

        }

        
    }
    protected void GetDEPT(int num)
    {
        String deptname = Session["DepNo"].ToString();
        int deptNO2 = int.Parse(deptname);
        DataSet ds2 = new DataSet();
        SqlDataAdapter da2 = new SqlDataAdapter("select DepartementName from departement where departementNo=" + deptNO2, con);
        da2.Fill(ds2);
        Dept.Text = ds2.Tables[0].Rows[0]["DepartementName"].ToString();

            
    }
    protected void GetEmp()
    {
        query = "select Fname + ' ' + Lname AS FullName, Email from Employee where DepartementNo=" + depNum;
        da = new SqlDataAdapter(query, con);
        da.Fill(ds);


        EmployeeList.DataSource = ds;
        EmployeeList.DataTextField = "FullName";
        EmployeeList.DataValueField = "Email";
        EmployeeList.DataBind();
        EmployeeList.Items.Insert(0, new ListItem("Select an Employee to Assign", "NA"));
           
        
    }



    protected void EmployeeList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Assign_btn_Click(object sender, EventArgs e)
    {
        TicketNo = int.Parse(Request.QueryString["TicketNo"]);

        // GoDaddy ConnectionString
        //SqlConnection con2 = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

        // Local ConnectionString
        SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
        
        try {
        con2.Open();
        query = "Update Ticket set EmployeeEmail = '" + EmployeeList.SelectedValue + "' WHERE TicketNo=" + TicketNo;
        SqlCommand command2 = new SqlCommand(query, con2);
        int updated = command2.ExecuteNonQuery();
        if (updated > 0) {
        Response.Write("<script>alert('The Employee Has been Assigned Successfully');</script>");
        }
        }

        finally { con2.Close(); }
       
    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AssignEmployee.aspx");
      
    }

    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }
}
