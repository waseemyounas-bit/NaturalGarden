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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SaveRecord()
        {
            string constr = ConfigurationManager.ConnectionStrings["NaturalGardenConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("insert into Suppliers(Id,FirstName,LastName,Email,Password,ConfirmPassword,CreatedOn,IsActive)values(@Id,@FirstName,@LastName,@Email,@Password,@ConfirmPassword,GETDATE(),1)", con);
            cmd.CommandType = CommandType.Text;
            Guid guid = Guid.NewGuid();
            cmd.Parameters.AddWithValue("@Id", guid);
            cmd.Parameters.AddWithValue("@FirstName",txtbxFirstName.Text.Trim());
            cmd.Parameters.AddWithValue("@LastName", txtbxLastName.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
            cmd.Parameters.AddWithValue("@ConfirmPassword", txtConfirmPassword.Text.Trim());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Login.aspx");
        }

        protected void btn_SignUp_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text.Trim()== txtConfirmPassword.Text.Trim())
            {
                SaveRecord();
            }
            else
            {
                lblmsg.Text = "Password And Confirm Password Are Not Same";
            }
           
        }
    }
}