using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PicknPay.Models;
using PicknPay.Models.ViewModels;

namespace PicknPay.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        public Cart cart;

        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        //viewing orders and marking them as shipped
        public ViewResult List() =>
            View(repository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = repository.Orders
                .FirstOrDefault(o => o.OrderID == orderID);
            if(order != null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }
        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.CartProduct.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your trolley is empty!");
            }
            if (ModelState.IsValid)
            {
                order.CartProduct = cart.CartProduct.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
                
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}