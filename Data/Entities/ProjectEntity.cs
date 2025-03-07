namespace Data.Entities;

public class ProjectEntity
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Created { get; set; }
    public int? UserId { get; set; }
    public UserEntity? User { get; set; }
    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;


    public ICollection<ProjectUserEntity> ProjectUsers { get; set; } = [];
}
