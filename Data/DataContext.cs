using Microsoft.EntityFrameworkCore;
using XUnit_NetCore6_WebApi.Models;

namespace XUnit_NetCore6_WebApi.Data
{
    public class DataContext:DbContext,IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {  }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }  
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();   
        }
    }
}
