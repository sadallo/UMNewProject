using System;
using System.Collections.Generic;

namespace UMJobWebsite.Models
{
    public class Category
    {
        public Category()
        {
            this.Jobs = new List<Job>();
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        
        public static Category createCategory(String CategoryId, String CategoryName, String CategoryDescription)
        {
            Category obj = new Category();
            obj.CategoryId = CategoryId;
            obj.CategoryName = CategoryName;
            obj.CategoryDescription = CategoryDescription;
            return obj;
        }
    
    }
}