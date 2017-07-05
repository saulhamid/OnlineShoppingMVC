using OnlineShoppingStore.Domain.Abstrat;
using OnlineShoppingStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete
{
   public class UserProfileRepusetory:IUserProfile
    {
       EFDBContext db = new EFDBContext();
       public void SaveUserProfile(UserProfile userpro)
       {
           if (userpro.UserID == 0)
           {
               db.UserProfile.Add(userpro);
           }
           else {
               UserProfile entity = db.UserProfile.Find(userpro.UserID);
               if (entity != null)
               {
                   entity.UserID = userpro.UserID;
                   entity.UserName = userpro.UserName;
                   entity.UserPassword = userpro.UserPassword;
                   entity.UserEmail = userpro.UserEmail;
                   entity.image = userpro.image;
               }
           }
           db.SaveChanges();
       }
       public void DeleteUserProfile(int UserID)
       {
           UserProfile usid = db.UserProfile.FirstOrDefault(u => u.UserID == UserID);
           db.UserProfile.Remove(usid);
       }
    }
}
