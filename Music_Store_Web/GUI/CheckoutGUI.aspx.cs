using Lab3_Template.DAL;
using Lab3_Template.DTL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1438_Group2_Lab4.GUI
{
    public partial class CheckoutGUI : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /*int cartID = int.Parse(Session["cartID"].ToString());*/
            setInfor();
        }
        
        protected void setInfor()
        {
            var user = UserDAO.GetUsers()
                .Where(u => u.UserName == Session["user"].ToString())
                .FirstOrDefault();
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtUSer.Text = user.UserName;
            txtFName.Text = user.FirstName;
            txtLName.Text = user.LastName;
            txtAddress.Text = user.Address;
            txtCity.Text = user.City;
            txtState.Text = user.State;
            txtCountry.Text = user.Country;
            txtPhone.Text = user.Phone;
            txtEmail.Text = user.Email;
            if(Request.QueryString[0] != null)
            {
                txtTotal.Text = Request.QueryString[0];
            }
            txtPro.Text = "FREE";
            
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            o.OrderID = OrderDAO.GetMaxID();
            o.UserName = Session["user"].ToString();
            o.OrderDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            o.FirstName = txtFName.Text;
            o.LastName = txtLName.Text;
            o.Address = txtAddress.Text;
            o.City = txtCity.Text;
            o.State = txtState.Text;
            o.Country = txtCountry.Text;
            o.Phone = txtPhone.Text;
            o.Email = txtEmail.Text;
            o.Total = double.Parse(txtTotal.Text);
            o.PromoCode = "FREE";

            List<OrderDetail> ods = new List<OrderDetail>();
            var cart = ShoppingCartDAO.GetCart(HttpContext.Current);
            var cartItems = cart.GetCartItems();
            for (int i = 0; i < cartItems.Count; i++)
            {
                OrderDetail od = new OrderDetail();
                od.AlbumID = cartItems[i].AlbumID;
                od.Quantity = cartItems[i].Count;
                od.UnitPrice = AlbumDAO.GetAlbumByID(od.AlbumID).Price;

                ods.Add(od);
            }
            if (OrderDAO.Insert(o))
            {
                int orderID = OrderDAO.GetMaxID();
                foreach (OrderDetail ot in ods)
                {
                    ot.OrderID = orderID;
                    OrderDetailDAO.Insert(ot);
                }
                var cart1 = ShoppingCartDAO.GetCart(HttpContext.Current);
                cart1.EmptyCart();
                Response.Redirect("AlbumNotifycation.aspx?role=4&orderID="+orderID);
                
            }
            else
            {
                Label1.Text = "Something wrong! Can not add";
                Label1.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CartGUI.aspx");
        }
    }
}