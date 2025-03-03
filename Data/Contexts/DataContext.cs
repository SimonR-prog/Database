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
    public virtual DbSet<EmployeeEntity> Employees { get; set; }
    public virtual DbSet<ClientEntity> Clients { get; set; }
    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<ProjectSchedulesEntity> ProjectSchedules { get; set; }
    public virtual DbSet<ProjectTimeLogEntity> ProjectTimeLogs { get; set; }
    public virtual DbSet<ProjectTypeEntity> ProjectTypes { get; set; }
    public virtual DbSet<RoleEntity> RoleTypes { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }

}
