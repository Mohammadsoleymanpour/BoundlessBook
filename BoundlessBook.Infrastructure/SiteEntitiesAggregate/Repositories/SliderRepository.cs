﻿using BoundlessBook.Domain.SiteEntities;
using BoundlessBook.Domain.SiteEntities.Repositories;
using BoundlessBook.Infrastructure._Utilities;

namespace BoundlessBook.Infrastructure.SiteEntitiesAggregate.Repositories;

public class SliderRepository:BaseRepository<Slider>,ISliderRepository
{
    public SliderRepository(BoundlessBookContext context) : base(context)
    {
    }
}