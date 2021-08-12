using Lab3_Template.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1438_Group2_Lab4.GUI
{
    public partial class LoginGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var user = UserDAO.GetUsers()
                .Where(u => u.UserName == txtUser.Text && u.Password == txtPass.Text)
                .FirstOrDefault();
            if(user == null)
            {
                Label2.Text = "Wrong username or password! Please enter again!";
                Label2.Visible = true;
            }
            else
            {
                Session["user"] = user.UserName;
                Session["role"] = user.Role;
                var cart = ShoppingCartDAO.GetCart(HttpContext.Current);
                cart.MigrateCart(HttpContext.Current);
                Response.Redirect("ShoppingGUI.aspx");
            }
        }
    }
}