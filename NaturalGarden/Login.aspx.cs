using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NaturalGarden
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["NaturalGardenConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select * from Suppliers where Email=@Email and Password=@Password", con);
            cmd.Parameters.AddWithValue("@Email", txtUserName.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Session["SupplierId"] = reader["Id"].ToString();
                    Response.Redirect("AddEditFlowers.aspx");
                }
            }
            else
            {
                Label1.Text = "Your username and Password is incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            reader.Close();
            con.Close();
        }
    }
}