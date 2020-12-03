using RazorAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAjax.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<SubCategory> GetSubCategories(int categoryId);
    }
    public class CategoryService : ICategoryService
    {
        public IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { CategoryId = 1, CategoryName="Category 1" },
                new Category { CategoryId = 2, CategoryName="Category 2" },
                new Category { CategoryId = 3, CategoryName="Category 3" }
            };
        }
        public IEnumerable<SubCategory> GetSubCategories(int categoryId)
        {
            var subCategories = new List<SubCategory> {
                new SubCategory { SubCategoryId = 1, CategoryId = 1, SubCategoryName="SubCategory 1" },
                new SubCategory { SubCategoryId = 2, CategoryId = 2, SubCategoryName="SubCategory 2" },
                new SubCategory { SubCategoryId = 3, CategoryId = 3, SubCategoryName="SubCategory 3" },
                new SubCategory { SubCategoryId = 4, CategoryId = 1, SubCategoryName="SubCategory 4" },
                new SubCategory { SubCategoryId = 5, CategoryId = 2, SubCategoryName="SubCategory 5" },
                new SubCategory { SubCategoryId = 6, CategoryId = 3, SubCategoryName="SubCategory 6" },
                new SubCategory { SubCategoryId = 7, CategoryId = 1, SubCategoryName="SubCategory 7" },
                new SubCategory { SubCategoryId = 8, CategoryId = 2, SubCategoryName="SubCategory 8" },
                new SubCategory { SubCategoryId = 9, CategoryId = 3, SubCategoryName="SubCategory 9" }
            };
            return subCategories.Where(s => s.CategoryId == categoryId);
        }
    }
}
