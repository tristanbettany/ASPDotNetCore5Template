using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DataLayerContext : DbContext
    {
        public DataLayerContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
