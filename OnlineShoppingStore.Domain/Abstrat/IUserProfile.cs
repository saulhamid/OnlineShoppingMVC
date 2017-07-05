using OnlineShoppingStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OnlineShoppingStore.Domain.Abstrat
{
   public interface IUserProfile
    {
       void SaveUserProfile(UserProfile userpro);
    }
}
