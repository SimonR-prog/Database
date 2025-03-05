using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class LocationRepository(DataContext context) : BaseRepository<LocationEntity>(context), ILocationRepository
{

}
