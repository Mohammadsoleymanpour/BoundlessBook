﻿using BoundlessBook.Domain.UserAggregate;
using BoundlessBook.Domain.UserAggregate.Repository;
using BoundlessBook.Infrastructure._Utilities;

namespace BoundlessBook.Infrastructure.Ef.Persistent.UserAggregate;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(BoundlessBookContext context) : base(context)
    {
    }
}