using IoTPlatform.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace IoTPlatform.Context
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }

    }
}
