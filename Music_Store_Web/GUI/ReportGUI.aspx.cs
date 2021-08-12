using Lab3_Template.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Lab4_template.GUI
{
    public partial class ReportGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblNoOrders.Text = OrderDAO.GetDataTable().Rows.Count.ToString();
                lblNoOrderDetails.Text = "0";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.SelectedIndex = -1;
            GridView2.Visible = false;
            string dateFrom = txtFrom.Text.Trim();
            string dateTo = txtTo.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string country = txtCountry.Text.Trim();
            DateTime dateF = DateTime.ParseExact(dateFrom,"dd/MM/yyyy",CultureInfo.InvariantCulture), 
                dateT = DateTime.ParseExact(dateTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                       
            
            GridView1.DataSource = null;
            GridView1.DataSourceID = "";
            DataTable dt = OrderDAO.GetOrdersByKeys1(dateF, dateT, firstName, country);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            lblNoOrders.Text = dt.Rows.Count.ToString();
            lblNoOrderDetails.Text = "0";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            GridView2.DataSource = null;
            GridView2.DataSourceID = "";
            int orderID = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            txtFrom.Text = GridView1.SelectedRow.Cells[2].Text;
            txtTo.Text = GridView1.SelectedRow.Cells[2].Text;
            txtFirstName.Text = GridView1.SelectedRow.Cells[5].Text;
            txtCountry.Text = Server.HtmlDecode(GridView1.SelectedRow.Cells[10].Text);    
            DataTable dt = OrderDetailDAO.GetDataTableByOrderID(orderID);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            lblNoOrderDetails.Text = dt.Rows.Count.ToString();

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            SelectedDatesCollection sdc;
            sdc = Calendar1.SelectedDates;
            txtFrom.Text = sdc[0].ToString("dd/MM/yyyy");
            txtTo.Text = sdc[sdc.Count - 1].ToString("dd/MM/yyyy");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[2].Text = DateTime.Parse(e.Row.Cells[2].Text).ToString("dd/MM/yyyy");
            }
            catch { }
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.SelectedIndex = -1;
            if(txtFrom.Text.Trim() != "" && txtTo.Text.Trim() != "" && txtFrom.Text.Trim() != txtTo.Text.Trim())
            {
                string dateFrom = txtFrom.Text.Trim();
                string dateTo = txtTo.Text.Trim();
                string firstName = txtFirstName.Text.Trim();
                string country = txtCountry.Text.Trim();
                DateTime dateF = DateTime.ParseExact(dateFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    dateT = DateTime.ParseExact(dateTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataSource = null;
                GridView1.DataSourceID = "";
                DataTable dt = OrderDAO.GetOrdersByKeys1(dateF, dateT, firstName, country);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataSourceID = "";
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataSource = OrderDAO.GetDataTable();
                GridView1.DataBind();
            }
            
        }
    }
}
