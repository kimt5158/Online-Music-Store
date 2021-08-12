using Lab3_Template.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1438_Group2_Lab4.GUI
{
    public partial class CartGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

        private void bindData()
        {
            ShoppingCartDAO cart = ShoppingCartDAO.GetCart(HttpContext.Current);
            ListView1.DataSource = cart.GetCartItems();
            Session["cartCount"] = cart.GetCount();
            lblTotal.Text = string.Format("{0:0.00}",cart.GetTotal());
            ListView1.DataBind();
        }

        protected void RemoveLink_Click(object sender, CommandEventArgs e)
        {
            int albumID = int.Parse(e.CommandArgument.ToString());
            ShoppingCartDAO cart = ShoppingCartDAO.GetCart(HttpContext.Current);
            cart.RemoveFromCart(albumID);
            bindData();
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Session["user"].ToString() == "" || Session["user"] == null)
            {
                Response.Redirect("LoginGUI.aspx");
            }
            else
            {
                double total = double.Parse(lblTotal.Text);
                Response.Redirect("CheckoutGUI.aspx?total="+total);
            }
        }
    }
}