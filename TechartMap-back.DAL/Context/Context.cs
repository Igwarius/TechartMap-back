﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TechartMap_back.DAL.Models;

namespace TechartMap_back.DAL.Context
{
    class Context:DbContext
    {
        public DbSet<User> Users { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TechartMapDB;Username=postgres;Password=zxcqwe1312");
        }
    }
}
