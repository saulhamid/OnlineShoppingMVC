using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace OnlineShoppingStore.webUI.Models
{
    public class UserProfileModel
    {
        [HiddenInput(DisplayValue=false)]
        public int UserID { get; set; }
        [Required(ErrorMessage="Please Input Your UserName")]
        [StringLength(50,MinimumLength=4,ErrorMessage="Please input within 4-50 character")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Input Your Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "Please Input Your Confirm Password")]
        [DataType(DataType.Password)]
        [Display(Name = "PassWord")]
        [System.ComponentModel.DataAnnotations.Compare("UserPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConPassword { get; set; }
        [Required(ErrorMessage = "Please Input Your Email Address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string UserEmail { get; set; }
        [DataType(DataType.Url)]
        public string image { get; set; }
    }
}