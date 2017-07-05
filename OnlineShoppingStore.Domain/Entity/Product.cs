using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OnlineShoppingStore.Domain.Entity
{
  public  class Product
    {
        [HiddenInput(DisplayValue=false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please Enter ProductName")]
        [StringLength(60,ErrorMessage="Product must in 60 aphabet")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        [DataType(DataType.MultilineText)]
        public string Descriptions { get; set; }
        [Required(ErrorMessage = "Please Enter Price")]
        [DataType(DataType.Currency)]
        [Range(0.01,double.MaxValue,ErrorMessage="Please Enter Positive Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please Enter Category")]
        public string Catagory { get; set; }
    }
}
