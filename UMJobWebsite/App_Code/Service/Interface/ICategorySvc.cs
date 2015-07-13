using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UMJobWebsite.Models;

namespace UMJobWebsite.Service.Interface
{
	public interface ICategorySvc: IService
	{
		List<Category> selectAllCategory();
        Category selectCategoryById(Category obj);
        Boolean insertCategory(Category obj);
        Boolean updateCategory(Category obj);
        Boolean deleteCategory(Category obj);
	}
}