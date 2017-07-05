using OnlineShoppingStore.Domain.Abstrat;
using OnlineShoppingStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.webUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepusetory repusetory;
        public AdminController(IProductRepusetory repu)
        {
            repusetory = repu;
        }
        public ActionResult Index()
        {
            return View(repusetory.Products);
        }
        public ViewResult Create( )
        {
            return View();
        }
        [HttpPost]
        public ViewResult Create(Product pro)
        {
            if (ModelState.IsValid)
            {
                repusetory.SaveProduct(pro);
                TempData["msg"] = string.Format("{0} has been saved", pro.ProductName);
                RedirectToAction("index", repusetory.Products);
            }
            return View();
        }
        public ViewResult Edite( int productID)
        {
            Product product = repusetory.Products.FirstOrDefault(p => p.ProductID == productID);
            return View(product);
        }
        [HttpPost]
        public ViewResult Edite(Product pro)
        {
            if (ModelState.IsValid)
            {
                repusetory.SaveProduct(pro);
                TempData["msg"] = string.Format("{0} has been saved", pro.ProductName);
                RedirectToAction("index", repusetory.Products);
            }
            return View();
        }
        public ViewResult Delete(int ProductID)
        {
            repusetory.DeletePro(ProductID);
            return View("Index",repusetory.Products);
        }
       
	}
}