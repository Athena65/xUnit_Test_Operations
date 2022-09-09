using Microsoft.EntityFrameworkCore;
using XUnit_NetCore6_WebApi.Data;
using XUnit_NetCore6_WebApi.Models;

namespace XUnit_NetCore6_WebApi.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly DataContext _context;

        public ShoppingService(DataContext context)
        {
            _context = context;
        }
        public async Task<ShoppingItem> Add(ShoppingItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            await _context.ShoppingItems.AddAsync(newItem); 
            await _context.SaveChanges();  
            return newItem;
            
        }

        public async Task<List<ShoppingItem>> GetAllItems()
        {
            return await _context.ShoppingItems.ToListAsync();
        }

        public async Task< ShoppingItem> GetById(Guid id)
        {
            return await _context.ShoppingItems.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Remove(Guid id)
        {
            var item = await _context.ShoppingItems.FirstOrDefaultAsync(x => x.Id == id);
            _context.ShoppingItems.Remove(item);
            await _context.SaveChanges();
        }

        public async Task<ShoppingItem> Update(Guid id, ShoppingItem item)
        {
            var shoppingItem = await _context.ShoppingItems.Where(x => x.Id == id).FirstOrDefaultAsync();
            item.Name = shoppingItem.Name;
            item.Manufacturer = shoppingItem.Manufacturer;
            item.Price=shoppingItem.Price;  
            
            await _context.SaveChanges();
            return shoppingItem;
        }
    }
}
