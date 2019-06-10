using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicknPay.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name ="Boschendal 1685 Sauvignon Blanc 750ml", Price = 100M},
            new Product { Name ="Danie de Wet Limestone Hill Chardonnay 750ml", Price = 100M},
            new Product { Name ="De Grendel Rose 750 ml", Price = 70},
            new Product { Name ="KWV Cruxland Gin 750ml", Price = 349M}
        }.AsQueryable<Product>();
    }
}
