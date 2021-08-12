using Lab3_Template.DAL;
using Lab3_Template.DTL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1438_Group2_Lab4.GUI
{
    public partial class AlbumAddGUI : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.DataSource = DAO.GetDataTable("Select * from genres");
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "GenreID";
            DropDownList1.DataBind();
            DropDownList2.DataSource = DAO.GetDataTable("SELECT * FROM Artists");
            DropDownList2.DataTextField = "Name";
            DropDownList2.DataValueField = "ArtistID";
            DropDownList2.DataBind();

            if (!IsPostBack)
            {
                if (Request.QueryString[0] != null)
                {
                    if (Request.QueryString[0] == "0")
                    {
                        try
                        {
                            Label1.Text = "Edit an album";
                            int albumID = int.Parse(Request.QueryString[1]);
                            Album al = AlbumDAO.GetAlbumByID(albumID);
                            txtTitle.Text = al.Title;
                            txtPrice.Text = al.Price.ToString();
                            txtAlbumUrl.Text = al.AlbumUrl;
                            DropDownList1.SelectedIndex = al.GenreID - 1;
                            DropDownList2.SelectedIndex = al.ArtistID - 1;
                            Image2.ImageUrl = txtAlbumUrl.Text;
                        }
                        catch (Exception ex)
                        {
                            Image2.ImageUrl = "";
                        }
                    }
                }
            }
        }

        protected void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    //Path.GetFileName Returns the file name 
                    //and extension of the specified path string.
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    string ext = filename.Substring(filename.IndexOf('.'));

                    filename = Guid.NewGuid().ToString() + ext;
                    // Server.MaPath return the physical file path 
                    //that corresponds to the specified virtual path.
                    FileUpload1.SaveAs(Server.MapPath("/Images/") + filename);

                    txtAlbumUrl.Text = "/Images/" + filename;
                    Image2.ImageUrl = txtAlbumUrl.Text;
                }
                catch (Exception ex)
                {
                    txtAlbumUrl.Text = "";
                    Image2.ImageUrl = "";
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Album album = new Album()
            {
                Title = txtTitle.Text,
                GenreID = DropDownList1.SelectedIndex + 1,
                ArtistID = DropDownList2.SelectedIndex + 1,
                Price = Double.Parse(txtPrice.Text),
                AlbumUrl = txtAlbumUrl.Text
            };
            if (Request.QueryString[0] == "1")
            {
                if (AlbumDAO.Insert(album))
                {
                    Response.Redirect("AlbumNotifycation.aspx?role=0&albumID="+album.AlbumID);
                }
            }
            else
            {
                album.AlbumID = int.Parse(Request.QueryString[1]);
                if (AlbumDAO.Update(album))
                {
                    Response.Redirect("AlbumNotifycation.aspx?role=1&albumID=" + album.AlbumID);
                }
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AlbumGUI.aspx");
        }
    }
}