using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace FreeCycle2.Models
{
    public class Category

    {

        public List<Category> allCategories { get; set; }
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

        public enum CategoryType
        {
            
	    OfficeFurniture = 1,
	    OfficeSupplies = 2,
	    TechEquipment = 3,
	    Other = 4
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

    public class Item
    {
        public int EditIndex2 { get; set; }
        public List<Item> allItems { get; set; }

        public char exchanged { get; set; }
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

        public Item() { }

        public Item(string first_name, string last_name, string email, int item_id, DateTime create_date, DateTime last_renewed_on, string item_title, string item_detail, int user_id, int category_id, char is_active, byte[] image)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.item_id = item_id;
            this.create_date = create_date;
            this.last_renewed_on = last_renewed_on;
            this.item_title = item_title;
            this.item_detail = item_detail;
            this.user_id = user_id;
            this.category_id = category_id;
            this.is_active = is_active;
            this.image = image;
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