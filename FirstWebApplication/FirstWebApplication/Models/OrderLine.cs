using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int PhoneID { get; set; }
        public int Count { get; set; }
        public int Amount { get; set; }
        public Order Order { get; set; }
        public Phone Phone { get; set; }
    }
}
