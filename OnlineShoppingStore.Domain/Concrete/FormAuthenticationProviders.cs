using OnlineShoppingStore.Domain.Abstrat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete
{
  public  class FormAuthenticationProviders :IAuthincation
    {
      private readonly EFDBContext context = new EFDBContext();
        public bool Authenticate(string username, string password)
        {
            var result = context.Users.FirstOrDefault(p => p.UserName == username &&
                p.Password == password);
            if (result == null)
                return false;
            return true;
        }

        public bool Logout()
        {
            return true;
        }
    }
}
