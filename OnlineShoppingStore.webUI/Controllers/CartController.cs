using OnlineShoppingStore.Domain.Abstrat;
using OnlineShoppingStore.Domain.Entity;
using OnlineShoppingStore.webUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.webUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepusetory repusetory;
        private IOrderProcessor processor;
        public CartController(IProductRepusetory repu,IOrderProcessor proc)
        {
            processor = proc;
            repusetory = repu;
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View (new CartIndexModelView { Cart = cart, ReturnUrl = returnUrl });
        }

        public ViewResult Checkout()
        { 
        return View(new ShoppingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart,ShoppingDetails shoppingdetails)
        {
            if (cart.lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry Your Cart is Empty");
            }
            if (ModelState.IsValid)
            {
                processor.ProcessorOrder(cart, shoppingdetails);
                cart.Clear();
                return View("Complete");
            }
            else {
                return View(shoppingdetails);
            }
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView (cart);
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productid,string returnUrl) 
        {
            Product product = repusetory.Products.Where(p => p.ProductID == productid).FirstOrDefault();
            if (product != null) 
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productid, string returnUrl)
        {
            Product product = repusetory.Products.Where(p => p.ProductID == productid).FirstOrDefault();
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        
     
	}
}