using System.Collections.Generic;

namespace FreeCycle2.Models
{
    public class ItemsModel 
    {
        public int EditIndex { get; set; }

        public List<Item1> Items { get; set; }


        public ItemsModel() { }
    }

    public class Categs 
    {
        public int EditIndex { get; set; }

        public List<Category> Items { get; set; }

        public Categs() { }
    }

    public class Images
    {
        public int EditIndex { get; set; }

        public List<Image> Items { get; set; }

        public Images() { }
    }
}