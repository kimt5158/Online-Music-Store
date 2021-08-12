using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3_Template.DTL
{
    public class Genre
    {
        private int genreID;
        private string name;
        private string description;

        public int GenreID { get => genreID; set => genreID = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
    }
}
