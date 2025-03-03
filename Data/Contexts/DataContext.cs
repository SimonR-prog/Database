using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    protected DataContext() 
    { 
    }

    public virtual DbSet<ProjectEntity> Projects { get; set; }
    public virtual DbSet<StatusEntity> Statuses { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }

    public virtual DbSet<CityEntity> City { get; set; }
    public virtual DbSet<CustomerEntity> Customer { get; set; }
    public virtual DbSet<LocationEntity> Location { get; set; }
}
