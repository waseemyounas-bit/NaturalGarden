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
    public partial class AddEditFlowers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["ReqId"] != null)
                {
                    Guid guid = new Guid(Request.QueryString["ReqId"]);
                    EditRecord(guid);
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["NaturalGardenConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("Usp_InsertUpdateFlowers", con);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text.Trim());
            cmd.Parameters.AddWithValue("@Price", txtbxPrice.Text.Trim());
            cmd.Parameters.AddWithValue("@Color", txtColour.Text.Trim()); 
            cmd.Parameters.AddWithValue("@SupplierId", ddlSupplier.SelectedValue);
            cmd.ExecuteNonQuery();
        }
            public void EditRecord(Guid guid)
        {
            string constr = ConfigurationManager.ConnectionStrings["NaturalGardenConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("select Id,name,Quantity,Price,Color  from Flowers where Id=@id", con);
            cmd.Parameters.AddWithValue("@id", guid);
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtname.Text = reader["name"].ToString();
                    txtQuantity.Text = reader["Quantity"].ToString();
                    txtbxPrice.Text= reader["Price"].ToString();
                    txtColour.Text = reader["Color"].ToString();
                }
             
            }
            reader.Close();
            con.Close();
        }
        protected void btn_Save_Click1(object sender, EventArgs e)
        {
          
            if (Request.QueryString["ReqId"] != null)
            {
                lblmsg.Text = Request.QueryString["ReqId"];
                UpdateRecord();
            }
            else
            {
                SaveRecord();
            }
          
        }
        public void SaveRecord()
        {
            string constr = ConfigurationManager.ConnectionStrings["NaturalGardenConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("insert into Flowers(Id,Name,Quantity,Price,Color,CreatedDate,SupplierId)values(@Id,@Name,@Quantity,@Price,@Color,GETDATE(),@SupplierId)", con);
            cmd.CommandType = CommandType.Text;
            Guid guid = Guid.NewGuid();
            cmd.Parameters.AddWithValue("@Id", guid);
            cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text.Trim());
            cmd.Parameters.AddWithValue("@Price", txtbxPrice.Text.Trim());
            cmd.Parameters.AddWithValue("@Color", txtColour.Text.Trim());
            cmd.Parameters.AddWithValue("@SupplierId", ddlSupplier.SelectedValue);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Record Save Successfully";
            ClearRecord();
        }
        public void UpdateRecord()
        {
            string constr = ConfigurationManager.ConnectionStrings["NaturalGardenConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("update Flowers set Name=@Name,Quantity=@Quantity,Price=@Price,SupplierId=@SupplierId,Color=@Color where Id=@Id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Request.QueryString["ReqId"].ToString());
            cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim());
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text.Trim());
            cmd.Parameters.AddWithValue("@Price", txtbxPrice.Text.Trim());
            cmd.Parameters.AddWithValue("@Color", txtColour.Text.Trim());
            cmd.Parameters.AddWithValue("@SupplierId", ddlSupplier.SelectedValue);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lblmsg.Text = "Record Save Successfully";
            ClearRecord();
            Response.Redirect("ViewFlowers.aspx");
        }
        public void ClearRecord()
        {
            txtname.Text = "";
            txtQuantity.Text = "";
            txtbxPrice.Text = "";
            txtColour.Text = "";
            //ddlSupplier.SelectedValue = "0";
        }
    }
}