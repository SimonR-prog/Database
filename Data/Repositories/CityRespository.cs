﻿using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class CityRespository(DataContext context) : BaseRepository<CityEntity>(context), ICityRepository
{

}
