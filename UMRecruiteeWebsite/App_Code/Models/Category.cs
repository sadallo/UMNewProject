using System;
using System.Collections.Generic;

namespace UMRecruiteeWebsite.Models
{
    public class Category
    {
        public Category()
        {
            this.Recruitees = new List<Recruitee>();
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<Recruitee> Recruitees { get; set; }

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
