namespace Data.Entities;

public class UserEntity
{
    public int UserId { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string SaltKey { get; set; } = null!;

    public int RoleId { get; set; } = null!;
    public RoleEntity Role { get; set; } = null!;
}
