namespace OnlineShoppingStore.Domain.Abstrat
{
    public interface IAuthincation
    {
         bool Authenticate(string username, string password);
         bool Logout();
    }
}
