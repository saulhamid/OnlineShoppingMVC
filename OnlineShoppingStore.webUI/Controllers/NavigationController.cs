using OnlineShoppingStore.Domain.Abstrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.webUI.Controllers
{
    public class NavigationController : Controller
    {
        private IProductRepusetory repusetory;
         public NavigationController(IProductRepusetory repu)
         {
                repusetory=repu;
         }
         public PartialViewResult Manu(string category =null) 
         {
             ViewBag.SelectCategory = category;
             IEnumerable<string> catagoris = repusetory.Products
                                            .Select(s => s.Catagory)
                                            .Distinct()
                                            .OrderBy(x => x);
                        return PartialView(catagoris);
         }
        
	}
}