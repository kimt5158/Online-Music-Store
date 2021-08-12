using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1438_Group2_Lab4.GUI
{
    public partial class AlbumGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlbumAddGUI.aspx?role=1");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if(GridView1.SelectedRow == null)
            {
                Label2.Text = "Select an album to edit";
                Label2.Visible = true;
            }
            else
            {
                int albumID = int.Parse(GridView1.SelectedRow.Cells[1].Text);
                Response.Redirect("AlbumAddGUI.aspx?role=0&albumID=" + albumID);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
           
        }

        protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                Response.Redirect("AlbumNotifycation.aspx?role=2");
            }
            else
            {
                Response.Redirect("AlbumNotifycation.aspx?role=3");
            }
        }

        protected void btnEdit_Click1(object sender, EventArgs e)
        {

        }
    }
}