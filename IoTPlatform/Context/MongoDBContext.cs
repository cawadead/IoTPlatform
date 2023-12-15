using IoTPlatform.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace IoTPlatform.Context
{
    public class MongoDBContext : DbContext
    {
        public DbSet<FabricObject> FabricObjects { get; set; }
        public DbSet<TimeSeries> TimeSeries { get; set; }

    }
}
