using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PicknPay.Models;
using PicknPay.Models.ViewModels;


namespace PicknPay.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        //pagination
        public int PageSize = 3;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,

                    //creating a category pagination data to avoid showing wrong 
                    //page links
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e =>
                    e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}