using OnlineShoppingStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Abstrat
{
   public interface IProductRepusetory
    {
       IEnumerable<Product> Products { get; }

       void SaveProduct(Product pro);
       void DeletePro(int ProductID);

    }
}
