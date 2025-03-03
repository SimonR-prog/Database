namespace Data.Entities;

public class CustomerEntity
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = null!;
    public ICollection<UserEntity> Users { get; set; } = [];

    public int LocationId { get; set; }
    public LocationEntity Location { get; set; } = null!;
}
