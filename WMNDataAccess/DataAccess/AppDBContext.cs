﻿using Microsoft.EntityFrameworkCore;
using WMNDataAccess.Models;

namespace WMNDataAccess.DataAccess
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}