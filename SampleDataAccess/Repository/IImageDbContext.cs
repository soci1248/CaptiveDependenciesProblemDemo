using Microsoft.EntityFrameworkCore;
using SampleDataAccess.Entities;

namespace SampleDataAccess.Repository;

internal interface IImageDbContext
{
    DbSet<ApplicationImage> ApplicationImages { get; set; }
}