using Microsoft.EntityFrameworkCore;
using SortDataUsingHeapSort.Models;

namespace SortDataUsingHeapSort.DataAccess.Data
{
    public class HeapSortDbContext : DbContext
    {
        public HeapSortDbContext(DbContextOptions<HeapSortDbContext> options)
            : base(options)
        {
        }

        // public DbSet<TbProduct> TbProducts { get; set; }
        public DbSet<TbSensorDataSample> TbSensorDataSamples { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
