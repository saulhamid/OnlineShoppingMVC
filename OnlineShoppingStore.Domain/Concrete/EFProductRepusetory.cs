using OnlineShoppingStore.Domain.Abstrat;
using OnlineShoppingStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete
{
   public class EFProductRepusetory:IProductRepusetory
    {
       private readonly EFDBContext context=new EFDBContext();
       public IEnumerable<Entity.Product> Products
       {
           get { return context.Products; }
       }
       public void SaveProduct(Product pro)
       {
           if (pro.ProductID == 0)
           {
               context.Products.Add(pro);
           }
           else {
               Product entity = context.Products.Find(pro.ProductID);
               if (entity != null)
               {
                   entity.ProductName = pro.ProductName;
                   entity.Catagory = pro.Catagory;
                   entity.Descriptions = pro.Descriptions;
                   entity.Price = pro.Price;
               }
           }
           context.SaveChanges();
       }
       public void DeletePro(int ProductID)
       {
           Product pro = context.Products.FirstOrDefault(p => p.ProductID == ProductID);
           context.Products.Remove(pro);
           context.SaveChanges();

       }
    }
}
