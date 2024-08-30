using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace last.Db
{
    public class Tabel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PurchasingPrice { get; set; }
        public string? SellingPrice { get; set; }
        public string? Profit { get; set; }
        public string? Quantity { get; set; }
    }
}
