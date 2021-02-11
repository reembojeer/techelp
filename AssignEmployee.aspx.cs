
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AssignEmployee : System.Web.UI.Page
{

    public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");



    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {

            LoadData();

        }
    }

    protected void LoadData()
    {

        con.Open();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataTable DeptNOTable = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT DepartementNo from Employee WHERE Email = '" + Session["Email"].ToString() + "'", con);
        adapter.Fill(ds);
        string getDeptNo = ds.Tables[0].Rows[0]["DepartementNo"].ToString();
        Session["DepNo"] = getDeptNo;
        int deptToNo = Int32.Parse(getDeptNo);
      

        SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT TicketNo, Title, Date,Status, Content, DepartementNo from Ticket WHERE EmployeeEmail is null and DepartementNo =" + deptToNo + "", con);
        adapter2.Fill(ds2);


        if (ds2.Tables[0].Rows.Count > 0)
        {
            NewTicket.DataSource = ds2;
            NewTicket.DataBind();
        }



        else {
            meassge_lbl.Visible = true;
            meassge_lbl.Text = "There is no new requests  to Assign"; 
        }


        con.Close();

    }



    protected void LoginLink_Click(object sender, EventArgs e)
    {
        Session.Clear();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You are now logged out, Come again soon!');window.location.href='Login2.aspx';", true);

    }

    protected void NewTicket_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {

        NewTicket.PageIndex = e.NewPageIndex;
        LoadData();

    }
}