using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Customer { get; set; }
        public int Discount { get; set; }
        public IEnumerable<OrderLine> Lines { get; set; }
    }
}
