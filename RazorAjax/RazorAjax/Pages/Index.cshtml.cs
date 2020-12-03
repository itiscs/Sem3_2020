using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RazorAjax.Models;
using RazorAjax.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAjax.Pages
{
    public class IndexModel : PageModel
    {
        private ICategoryService categoryService;
        public IndexModel(ICategoryService categoryService) => this.categoryService = categoryService;
      
        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public SelectList Categories { get; set; }

        public void OnGet()
        {
            Categories = new SelectList(categoryService.GetCategories(), nameof(Category.CategoryId), nameof(Category.CategoryName));
        }
        public JsonResult OnGetSubCategories()
        {
            return new JsonResult(categoryService.GetSubCategories(CategoryId));
        }
    }
}
