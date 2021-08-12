using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3_Template.DTL;
using System.Data.SqlClient;
using System.Data;

namespace Lab3_Template.DAL
{
    class ArtistDAO
    {
        public static IEnumerable<Artist> GetArtists()
        {
            var artists = new List<Artist>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Artists");
                DataTable dt = DAO.GetDataTable(cmd);
                foreach (DataRow row in dt.Rows)
                {
                    var a = new Artist
                    {
                        ArtistID = (int)row["ArtistID"],
                        Name = row["Name"].ToString()
                    };
                    artists.Add(a);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return artists;
        }

        public static Artist GetArtistByID(int artistID)
        {
            Artist artist = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Artists WHERE artistID = @id");
                cmd.Parameters.AddWithValue("@id", artistID);
                DataTable dt = DAO.GetDataTable(cmd);

                DataRow row = dt.Rows[0];
                artist = new Artist
                    {
                        ArtistID = (int)row["ArtistID"],
                        Name = row["Name"].ToString()
                    };
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return artist;
        }




    }
}
