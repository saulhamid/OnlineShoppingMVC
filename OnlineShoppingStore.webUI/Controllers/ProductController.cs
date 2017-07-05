using OnlineShoppingStore.Domain.Abstrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.webUI.Models;

namespace OnlineShoppingStore.webUI.Controllers
{
    public class ProductController : Controller
    {
        protected readonly IProductRepusetory repusetory;
        public int Pagesize = 3;
        public ProductController(IProductRepusetory Repu)
        {
            repusetory = Repu;
        }
        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel
            {
                Products = repusetory.Products
                      .Where(p => category == null || p.Catagory == category)
                     .OrderBy(p => p.ProductID)
                     .Skip((page - 1) * Pagesize)
                     .Take(Pagesize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemPerPage = Pagesize,
                    TotalItems = category ==null ? repusetory.Products.Count()
                    : repusetory.Products.Where(p =>p.Catagory ==category).Count()
                },
                CurrentCategory = category
                
            };
            return View(model);
        }
	}
}