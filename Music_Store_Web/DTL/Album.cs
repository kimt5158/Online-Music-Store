using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3_Template.DTL
{
    public class Album
    {
        private int albumID;

        public int AlbumID
        {
            get { return albumID; }
            set { albumID = value; }
        }

        private int genreID;

        public int GenreID
        {
            get { return genreID; }
            set { genreID = value; }
        }
        private int artistID;

        public int ArtistID
        {
            get { return artistID; }
            set { artistID = value; }
        }

        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string AlbumUrl { get => albumUrl; set => albumUrl = value; }

        string albumUrl;


     }
}
