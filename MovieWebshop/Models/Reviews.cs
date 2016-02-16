using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieWebshop.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        public string Name { get; set; }
        public string MovieName { get; set; }
        public string Review { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
