using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Login2 : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // GoDaddy ConnectionString
            //SqlConnection con = new SqlConnection(@"Data Source=148.72.232.167 ;Database=techelpDB;Integrated Security=False;user ID=Reem; password=Manal1908 ;Connect Timeout=15;Encrypt=False;Packet Size=4096;");

            // Local ConnectionString
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\apple\Desktop\TecHelpDB.mdf;Integrated Security=True;Connect Timeout=30");
          

            SqlDataReader dataReader;
            SqlCommand cmdCustomer;
            SqlCommand cmdEmployee;
            SqlCommand cmdEmpType;


            con.Open();

            //Queries
            cmdEmployee = new SqlCommand("select COUNT(*) from EmployeeLogin where Email= @Email and Password= @Password", con);
            cmdCustomer = new SqlCommand("select COUNT(*) from Customer where Email= @Email and Password= @Password", con);

            //username and password frpm textbox
            cmdEmployee.Parameters.AddWithValue("@Email", this.TextBox_username.Text);
            cmdEmployee.Parameters.AddWithValue("@Password", this.TextBox_password.Text);
            cmdCustomer.Parameters.AddWithValue("@Email", this.TextBox_username.Text);
            cmdCustomer.Parameters.AddWithValue("@Password", this.TextBox_password.Text);
            int CustExist = (int)cmdCustomer.ExecuteScalar();
            int EmpExist = (int)cmdEmployee.ExecuteScalar();



            if (EmpExist>0)
            {


                cmdEmpType = new SqlCommand("SELECT Type FROM EmployeeLogin WHERE Email ='" + TextBox_username.Text + "'", con);

                    dataReader = cmdEmpType.ExecuteReader();
                    
                  while (dataReader.Read())
                    {
                    string type = dataReader.GetString(0);

                    if (type.Equals("employee"))
                    {
                        //Label1.Text = "emp";
                        Session["Email"] = TextBox_username.Text.ToString();
                        Response.Redirect("EmpMainPage.aspx");
                    }
                    else if (type.Equals("admin"))
                    {
                        Session["email"] = TextBox_username.Text;
                        Session["pwd"] = TextBox_password.Text;
                        Response.Redirect("AdminMainPage.aspx");
                        //Response.Redirect("ImapClientProtocolAll.aspx");
                        //Response.Redirect("ImapClientProtocolUnseen.aspx");
                        //Label1.Text = "admin";
                     
                  }
                    else
                    {
                        Session["email"] = TextBox_username.Text;
                        Session["pwd"] = TextBox_password.Text;
                        Response.Redirect("mainreception.aspx");
                    }
                }

                  dataReader.Close();
                
                
            }

            else if (CustExist > 0)
            {
                dataReader = cmdCustomer.ExecuteReader();
                while (dataReader.Read())
                {
                    Session["Email"] = TextBox_username.Text.ToString();
                    Response.Redirect("CustMainPage.aspx");
                    //Label1.Text = "customer";
                }
                  dataReader.Close();
                }

                else Label1.Text="Wrong username or password";

                
                con.Close();

                

            }
        }
