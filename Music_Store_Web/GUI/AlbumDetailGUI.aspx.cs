using Lab3_Template.DAL;
using Lab3_Template.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE1438_Group2_Lab4.GUI
{
    public partial class AlbumDetailGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["albumID"] != null)
                {
                    int albumID =int.Parse(Request.QueryString["albumID"]);
                    lblAlbumID.Text = albumID.ToString();
                    Album album = AlbumDAO.GetAlbumByID(albumID);
                    Label1.Text = album.Title;
                    Image2.ImageUrl = album.AlbumUrl;
                    txtArtist.Text = ArtistDAO.GetArtistByID(album.ArtistID).Name;
                    txtGenre.Text = GenreDAO.GetGenreByID(album.GenreID).Name;
                    txtPrice.Text = album.Price.ToString();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingGUI.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ShoppingCartDAO cart = ShoppingCartDAO.GetCart(HttpContext.Current);
            cart.AddToCart(int.Parse(lblAlbumID.Text));
            Response.Redirect("CartGUI.aspx");
        }
    }
}