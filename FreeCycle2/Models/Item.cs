using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeCycle2.Models
{
    public class Item
    {
        public int item_id { get; set; }


        public DateTime create_date { get; set; }
        public DateTime last_renewed_on { get; set; }
        public string item_title { get; set; }

        public string item_detail { get; set; }

        [Display(Name = "User")]
        public int user_id { get; set; }

        //[ForeignKey("user_id")]
        //public virtual User User { get; set; }

        [Display(Name = "Category")]
        public int category_id { get; set; }

        //[ForeignKey("category_id")]
       // public virtual Category Category { get; set; }

        public char is_active { get; set; }
        
        public byte[] image { get; set; }

    }
}