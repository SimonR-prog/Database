namespace Data.Entities;

public class ProjectTypeEntity
{
    public int Id { get; set; }
    public string TypeName { get; set; } = null!;
    public int Price { get; set; }
    public string PricingUnit { get; set; } = null!;
}


