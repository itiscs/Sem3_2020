using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAjax.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
}
