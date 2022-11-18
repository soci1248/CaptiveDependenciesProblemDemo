using Microsoft.EntityFrameworkCore;
using SampleDataAccess.Entities;

namespace SampleDataAccess.Repository;

public class ImageDbContext : DbContext, IImageDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ImageDbDemo;Integrated Security=True;");

    public DbSet<ApplicationImage> ApplicationImages { get; set; }
}