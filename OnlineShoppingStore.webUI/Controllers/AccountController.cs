using OnlineShoppingStore.Domain.Abstrat;
using OnlineShoppingStore.webUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace OnlineShoppingStore.webUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IAuthincation authincation;
        public AccountController(IAuthincation authencation)
        {
            this.authincation = authencation;
        }
       [AllowAnonymous]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authincation.Authenticate(model.UserName, model.Password))
                {
                    DateTime expires = DateTime.Now.AddDays(30);
                    FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: model.RememberMe);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                    if (model.RememberMe)
                    {
                       
                        Response.Cookies.Clear();
                        DateTime expiryDate = DateTime.Now.AddDays(30);

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2,model.UserName, DateTime.Now, expiryDate, true, String.Empty);
                        string encryptedTicket = FormsAuthentication.Encrypt(ticket);                    
                        HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        authenticationCookie.Expires = ticket.Expiration;
                        Response.Cookies.Add(authenticationCookie);
                        return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                    }
                   
                }
                else {
                    ModelState.AddModelError("", "Inccorect UserName or Password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }
       
	}
}