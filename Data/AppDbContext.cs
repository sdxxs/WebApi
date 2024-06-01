
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;


namespace apiweb.Data
{
    public class MyBirdAppDbContext : DbContext
    {
        public MyBirdAppDbContext(DbContextOptions<MyBirdAppDbContext> options) : base(options)
        {
        }
        public DbSet<Model.RegionInfo> RegionsUkraie { get; set; }
        public DbSet<Model.ObservationsInfo> OwnListOfObservationsInfo { get; set; }
    }

}