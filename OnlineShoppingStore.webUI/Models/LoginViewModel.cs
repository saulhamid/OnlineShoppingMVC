using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace OnlineShoppingStore.webUI.Models
{
    public class LoginViewModel
    {  
        [Required(ErrorMessage="UserName is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage="Password is Required")]
        [StringLength(20,MinimumLength=6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [Display(Name="Remeber Me?")]
        public bool RememberMe { get; set; }

    }
}