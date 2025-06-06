﻿using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
: base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
