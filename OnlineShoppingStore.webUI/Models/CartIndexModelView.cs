using OnlineShoppingStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.webUI.Models
{
    public class CartIndexModelView
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}