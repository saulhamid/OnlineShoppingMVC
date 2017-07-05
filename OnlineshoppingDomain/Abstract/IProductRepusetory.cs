using OnlineshoppingDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineshoppingDomain.Abstract
{
   public interface IProductRepusetory
    {
       IEnumerable<Product> Product { get; }
    }
}
