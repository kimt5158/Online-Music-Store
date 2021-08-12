using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab3_Template.DTL;
using System.Data.SqlClient;
using System.Data;

namespace Lab3_Template.DAL
{
    public class GenreDAO
    {
        public static DataTable GetDataTable()
        {
            return DAO.GetDataTable("SELECT * FROM Genres");
        }
        public static IEnumerable<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Genres");
                DataTable dt = DAO.GetDataTable(cmd);
                foreach (DataRow row in dt.Rows)
                {
                    var genre = new Genre
                    {
                        GenreID = int.Parse(row["GenreID"].ToString()),
                        Name = row["Name"].ToString(),
                        Description = row["Description"].ToString()
                    };
                    genres.Add(genre);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return genres;
        }

        public static Genre GetGenreByID(int genreID)
        {
            Genre genre = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Genres WHERE genreID = @id");
                cmd.Parameters.AddWithValue("@id", genreID);
                DataTable dt = DAO.GetDataTable(cmd);
                DataRow row = dt.Rows[0];
                genre = new Genre
                    {
                        GenreID = int.Parse(row["GenreID"].ToString()),
                        Name = row["Name"].ToString(),
                        Description = row["Description"].ToString()
                    };
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return genre;
        }

    }
}
