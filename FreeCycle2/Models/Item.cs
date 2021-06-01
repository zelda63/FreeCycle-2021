using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace FreeCycle2.Models
{
    public class Item
    {
        public int EditIndex2 { get; set; }
        public List<Item> allItems { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
   
        public int item_id { get; set; }
        public bool IsEditable2 { get; set; }

        public DateTime create_date { get; set; }
        public DateTime last_renewed_on { get; set; }

        [Display(Name = "Title")]
        public string item_title { get; set; }

        [Display(Name = "Description")]
        public string item_detail { get; set; }

        [Display(Name = "User")]
        public int user_id { get; set; }

        [Display(Name = "Category")]
        public int category_id { get; set; }

        public char is_active { get; set; }

        public byte[] image { get; set; }

    }
}