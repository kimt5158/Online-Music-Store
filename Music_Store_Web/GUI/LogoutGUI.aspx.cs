using Lab3_Template.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1438_Group2_Lab4.GUI
{
    public partial class LogoutGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["user"] = "";
                Session["role"] = -1;
                Session["cartCount"] = 0;
                Session["cartID"] = null;
            }
        }
    }
}