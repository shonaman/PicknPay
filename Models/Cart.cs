using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicknPay.Models
{
    public class Cart
    {
        private List<CartProducts> productCollection = new List<CartProducts>();

        //add items to cart
        public virtual void AddItem(Product product, int quantity)
        {
            CartProducts cartProducts = productCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if(cartProducts == null)
            {
                productCollection.Add(new CartProducts
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                cartProducts.Quantity += quantity;
            }
        }

        //remove items from cart using product ID
        public virtual void RemoveItem(Product product) =>
            productCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);

        //computing total cart price
        public virtual decimal ComputeTotalValue() =>
            productCollection.Sum(e => e.Product.Price * e.Quantity);

        //clearing cart
        public virtual void Clear() => productCollection.Clear();

        //returning items in Cart
        public virtual IEnumerable<CartProducts> CartProduct => productCollection;
    }

   
}
