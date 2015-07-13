using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMNewJobWebsite.Models;
using System.Runtime.Serialization;

namespace UMNewJobWebsite.DomainDTO
{
    [DataContract]
    public class CategoryDto
    {
        [DataMember]
        public string CategoryId { get; set; }

        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string CategoryDescription { get; set; }

        public static CategoryDto createCategoryDTO(Category obj)
        {
            CategoryDto cat = new CategoryDto();
            cat.CategoryId = obj.CategoryId;
            cat.CategoryName = obj.CategoryName;
            cat.CategoryDescription = obj.CategoryDescription;
            
            return cat;
        }

        public static CategoryDto createCategoryDTO(String CategoryId, String CategoryName, String CategoryDescription)
        {
            CategoryDto cat = new CategoryDto();
            cat.CategoryId = CategoryId;
            cat.CategoryName = CategoryName;
            cat.CategoryDescription = CategoryDescription;
            return cat;
        }
    }
}