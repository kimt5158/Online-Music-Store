using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1438_Group2_Lab4.GUI
{
    public partial class AlbumNotifycation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString[0] != null)
                {
                    
                    if (Request.QueryString[0] == "0")
                    {
                        Label1.Text = "Album add successfully!";
                    }
                    else if (Request.QueryString[0] == "1")
                    {
                        int albumID = int.Parse(Request.QueryString[1]);
                        Label1.Text = "Album " + albumID + " is changed";
                    }
                    else if (Request.QueryString[0] == "2")
                    {
                        Label1.Text = "Can not delete this album";
                    }
                    else if (Request.QueryString[0] == "3")
                    {
                        Label1.Text = "Album delete successfully!";
                    }
                    else
                    {
                        int orderID = int.Parse(Request.QueryString[1]);
                        Label1.Text = "Order " + orderID + " is saved";
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Request.QueryString[0] == "4")
            {
                Response.Redirect("ShoppingGUI.aspx");
            }
            else
            {
                Response.Redirect("AlbumGUI.aspx");
            }           
        }
    }
}