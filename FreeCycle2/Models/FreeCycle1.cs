namespace FreeCycle2.Models
{
    public class Category

    {
        public int EditIndex { get; set; }

        public int Category_Id { get; set; }

        public string Category_name { get; set; }

        public int max_images_allowed { get; set; }

        public int post_validity_interval_in_days { get; set; }

        public bool IsEditable { get; set; }

        public bool IsDeletable { get; set; }

        public Category() { }

        public Category(int category_Id, string category_name, int max_images_allowed, int post_validity_interval_in_days)
        {
            Category_Id = category_Id;
            Category_name = category_name;
            this.max_images_allowed = max_images_allowed;
            this.post_validity_interval_in_days = post_validity_interval_in_days;
        }

        public Category(int category_Id, string category_name)
        {
            Category_Id = category_Id;
            Category_name = category_name;
        }
    }


    public class Item1

    {
        public int EditIndex { get; set; }

        public int Item_Id { get; set; }

        public int User_Id { get; set; }

        public int Category_Id { get; set; }

        public string Item_Title { get; set; }

        public string Item_Description { get; set; }

        public char Is_Active { get; set; }

        public bool IsEditable { get; set; }

        public bool IsDeletable { get; set; }

        public Item1() { }

        public Item1(int item_Id, int user_Id, int category_Id, string item_Title, string item_Description, char is_Active)
        {

            Item_Id = item_Id;
            User_Id = user_Id;
            Category_Id = category_Id;
            Item_Title = item_Title;
            Item_Description = item_Description;
            Is_Active = is_Active;

        }


    }


    public class Image

    {

        public int EditIndex { get; set; }

        public int Image_Id { get; set; }

        public int Item_Id { get; set; }

        public byte[] Image_Data { get; set; }

        public bool IsEditable { get; set; }

        public bool IsDeletable { get; set; }

        public Image(int v) { }

        public Image(int image_Id, int item_Id, byte[] image_Data)
        {
            Image_Id = image_Id;
            Item_Id = item_Id;
            Image_Data = image_Data;
        }

    }



}