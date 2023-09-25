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
    public partial class Flowers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
                txtColour.Text = "rers";
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
                using (SqlCommand cmd = new SqlCommand("select Flowers.SupplierId,Name,Flowers.Quantity,Price,Color from Flowers inner join  Suppliers on Suppliers.Id=Flowers.SupplierId"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
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

        protected void grdv_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdv.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void grdv_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            grdv.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}