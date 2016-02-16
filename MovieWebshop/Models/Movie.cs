using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebshopLexicon.Models
{

    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string Price { get; set; }
        public string Director { get; set; }
        public string ReleaseYear { get; set; }
        public string Description { get; set; }
    }
}
