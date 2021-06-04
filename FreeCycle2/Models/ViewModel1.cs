using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace FreeCycle2.Models
{
    public class ViewModel1
    {
        public int EditIndex { get; set; }


        public Categs Categs { get; set; }
        public ItemsModel ItemsModel { get; set; }
        public Images Images { get; set; }
        public Item Item { get; set; }
    }
}