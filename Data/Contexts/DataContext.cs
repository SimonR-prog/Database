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


    //The following code has come from error fixing with chatgpt:
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Creates a composite primary key for the ProjectUserEntity table.
        // Ensures each pair of ids are unique. 
        modelBuilder.Entity<ProjectUserEntity>()
            .HasKey(projectUser => new { projectUser.UserId, projectUser.ProjectId });

        // Not really needed as long as the EF core infers the relationship correctly which it should
        // do automatically. It is best practice to include this explicit way of doing it. 
        modelBuilder.Entity<ProjectUserEntity>()
            .HasOne(projectUser => projectUser.User)
            .WithMany(user => user.ProjectUsers)
            .HasForeignKey(projectUser => projectUser.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectUserEntity>()
            .HasOne(projectUser => projectUser.Project)
            .WithMany(project => project.ProjectUsers)
            .HasForeignKey(projectUser => projectUser.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(project => project.User)
            .WithMany()
            .HasForeignKey(project => project.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }
}
