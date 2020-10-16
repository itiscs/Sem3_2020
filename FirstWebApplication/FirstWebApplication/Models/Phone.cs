using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FirstWebApplication.Models
{
    
    public class Phone
    {
        [Key]
        public int IdPhone { get; set; }
        
        [Display(Name ="Производитель")]
        public string Brand { get; set; }
       
        [MaxLength(100)]
        public string Model { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string Image { get; set; }

    }







}
