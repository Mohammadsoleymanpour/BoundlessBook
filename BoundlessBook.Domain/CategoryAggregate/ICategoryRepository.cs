﻿using BoundlessBook.Common.Common.Domain.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundlessBook.Domain.CategoryAggregate
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<bool> IsExistProduct(Guid categoryId);

    }
}
