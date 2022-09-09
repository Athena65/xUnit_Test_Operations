using Microsoft.EntityFrameworkCore;
using XUnit_NetCore6_WebApi.Models;

namespace XUnit_NetCore6_WebApi.Data
{
    public interface IDataContext
    {
        DbSet<ShoppingItem> ShoppingItems { get; set; }
        Task<int> SaveChanges();
    }
}
