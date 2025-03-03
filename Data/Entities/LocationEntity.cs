namespace Data.Entities;

public class LocationEntity
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public CityEntity City { get; set; } = null!;
}
