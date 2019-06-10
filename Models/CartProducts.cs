using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicknPay.Models
{
    public class CartProducts
    {
        public int CartProductsID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
