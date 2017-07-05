using OnlineShoppingStore.Domain.Entity;

namespace OnlineShoppingStore.Domain.Abstrat
{
    public interface IOrderProcessor
    {
        void ProcessorOrder(Cart cart, ShoppingDetails Shoppingdetail);
    }
}
