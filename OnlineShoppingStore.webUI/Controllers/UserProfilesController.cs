using OnlineShoppingStore.Domain.Abstrat;
using OnlineShoppingStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.webUI.Controllers
{
    public class UserProfilesController : Controller
    {
        protected readonly IUserProfile IuserReapusetory;
        public UserProfilesController(IUserProfile user)
        {
            IuserReapusetory = user;
        }

        public ViewResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Registration(UserProfile users, HttpPostedFileBase files )
        {
            var filename = Path.GetFileName(files.FileName);
            var path =Convert.ToString( Path.Combine(Server.MapPath("~/Images/"), filename));
            files.SaveAs(path);
            users.image = Url.Content(path);
            IuserReapusetory.SaveUserProfile(users);
            return View("UserProfileDetails",users);
        }


	}
}