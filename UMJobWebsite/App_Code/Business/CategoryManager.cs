using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UMJobWebsite.Models;
using UMJobWebsite.Service.Interface;
using UMJobWebsite.Exceptions.Service;

namespace UMJobWebsite.Business
{
    public class CategoryManager : BusinessManager
    {

        public List<Category> selectAllCategory()
        {
            try
            {
                ICategorySvc svc = (ICategorySvc)this.getService(typeof(ICategorySvc).Name);
                return svc.selectAllCategory();
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Category selectCategoryById(Category obj)
        {
            try
            {
                ICategorySvc svc = (ICategorySvc)this.getService(typeof(ICategorySvc).Name);
                return svc.selectCategoryById(obj);
            }
            catch (ServiceLoadException ex)
            {
                return null;
            }
        }

        public Boolean insertCategory(Category obj)
        {
            try
            {
                ICategorySvc svc = (ICategorySvc)this.getService(typeof(ICategorySvc).Name);
                return svc.insertCategory(obj);
                    
              
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean updateCategory(Category obj)
        {
            try
            {
                ICategorySvc svc = (ICategorySvc)this.getService(typeof(ICategorySvc).Name);
                return svc.updateCategory(obj);
               
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }

        public Boolean deleteCategory(Category obj)
        {
            try
            {
                ICategorySvc svc = (ICategorySvc)this.getService(typeof(ICategorySvc).Name);
                return svc.deleteCategory(obj);
            }
            catch (ServiceLoadException ex)
            {
                return false;
            }
        }
    }
}
