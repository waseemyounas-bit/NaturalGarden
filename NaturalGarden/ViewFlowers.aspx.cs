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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
                //txtColour.Text = "rers";
            }

        }
        protected void OnSorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid(e.SortExpression);
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdv.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }
        private void BindGrid(string sortExpression = null)
        {
            string constr = ConfigurationManager.ConnectionStrings["NaturalGardenConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select Flowers.Id as Id,Flowers.SupplierId,Name,Flowers.Quantity,Price,Color from Flowers inner join  Suppliers on Suppliers.Id=Flowers.SupplierId where Suppliers.Id=@Id"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Id", Session["SupplierId"]);
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (sortExpression != null)
                            {
                                DataView dv = dt.AsDataView();
                                this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";
                                dv.Sort = sortExpression + " " + this.SortDirection;
                                grdv.DataSource = dv;
                            }
                            else
                            {
                                grdv.DataSource = dt;
                            }
                            grdv.DataBind();
                        }
                    }
                }
            }
        }





        protected void lnkbtnDetail_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            Response.Redirect("AddEditFlowers.aspx?ReqId=" + lnk.ToolTip);
        }

        protected void lnkbtndelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            string constr = ConfigurationManager.ConnectionStrings["NaturalGardenConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("delete from Flowers where Id=@Id", con);
            cmd.CommandType = CommandType.Text;
            Guid guid = new Guid(lnk.ToolTip);
            cmd.Parameters.AddWithValue("@Id", guid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("ViewFlowers.aspx");
        }
    }
}