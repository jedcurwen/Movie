using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebshopLexicon.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Price { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual Movie Movie { get; set; }

    }
}