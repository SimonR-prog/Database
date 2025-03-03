namespace Data.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string SaltKey { get; set; } = null!;

    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;
}
