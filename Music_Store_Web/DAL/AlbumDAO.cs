using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Lab3_Template.DTL;

namespace Lab3_Template.DAL
{
    public class AlbumDAO
    {
        public static IEnumerable<Album> GetAlbums()
        {
            var albums = new List<Album>();

            try
            {
                DataTable dt = GetDataTable();
                foreach (DataRow row in dt.Rows)
                {
                    var album = new Album
                    {
                        AlbumID = int.Parse(row["AlbumId"].ToString()),
                        Title = row["Title"].ToString(),
                        ArtistID = int.Parse(row["ArtistID"].ToString()),
                        GenreID = int.Parse(row["GenreID"].ToString()),
                        Price = double.Parse(row["Price"].ToString()),
                        AlbumUrl = row["AlbumUrl"].ToString()

                    };
                    albums.Add(album);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return albums.AsEnumerable();

        }
        public static DataTable GetDataTable()
        {
            string sql = "select * from Albums";
            return DAO.GetDataTable(sql);

        }

        public static bool Insert(Album a)
        {
            SqlCommand cmd = new SqlCommand("Insert into Albums(GenreID, ArtistID, Title, Price, AlbumURL) " +
                "Values(@GenreID, @ArtistID, @Title, @Price, @AlbumURL)");
            cmd.Parameters.AddWithValue("@GenreID", a.GenreID);
            cmd.Parameters.AddWithValue("ArtistID", a.ArtistID);
            cmd.Parameters.AddWithValue("@Title", a.Title);
            cmd.Parameters.AddWithValue("@Price", a.Price);
            cmd.Parameters.AddWithValue("@AlbumURL", a.AlbumUrl);
            return DAO.UpdateTable(cmd);

        }

        public static bool Update(Album a)
        {
            SqlCommand cmd = new SqlCommand("Update Albums set GenreID=@GenreID, " +
                "ArtistID=@ArtistID,Title=@Title,Price=@Price, AlbumURL=@AlbumURL " +
                "WHERE AlbumID=@AlbumID");
            cmd.Parameters.AddWithValue("@AlbumID", a.AlbumID);
            cmd.Parameters.AddWithValue("@GenreID", a.GenreID);
            cmd.Parameters.AddWithValue("@ArtistID", a.ArtistID);
            cmd.Parameters.AddWithValue("@Title", a.Title);
            cmd.Parameters.AddWithValue("@Price", a.Price);
            cmd.Parameters.AddWithValue("@AlbumURL", a.AlbumUrl);

            return DAO.UpdateTable(cmd);

        }

        public static bool Delete(Album album)
        {
                SqlCommand cmd = new SqlCommand("Delete from Albums where AlbumID=@AlbumID");
                cmd.Parameters.AddWithValue("@AlbumID", album.AlbumID);
                return DAO.UpdateTable(cmd);
            
        }

        public static Album GetAlbumByID(int id)
        {
            Album album = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Albums WHERE albumID = @ID");
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dt = DAO.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    album = new Album
                    {
                        AlbumID = int.Parse(row["AlbumId"].ToString()),
                        Title = row["Title"].ToString(),
                        ArtistID = int.Parse(row["ArtistID"].ToString()),
                        GenreID= int.Parse(row["GenreID"].ToString()),
                        Price = double.Parse(row["Price"].ToString()),
                        AlbumUrl = row["AlbumUrl"].ToString()

                    };

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return album;
        }


    }
}
