using XUnit_NetCore6_WebApi.Models;

namespace XUnit_NetCore6_WebApi.Services
{
    public interface IShoppingService
    {
        public Task<List<ShoppingItem>> GetAllItems();
        public Task<ShoppingItem> Add(ShoppingItem newItem);
        public Task<ShoppingItem> GetById(Guid id);
        public Task Remove(Guid id);   
        public Task<ShoppingItem> Update(Guid id , ShoppingItem item);
    }
}
