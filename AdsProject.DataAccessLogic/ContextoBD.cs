﻿using AdsProject.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsProject.DataAccessLogic
{
    public class ContextoBD : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Ad> Ad { get; set; }
        public DbSet<AdImage> AdImage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Data source = WINRAR\SQLEXPRESS;
                                           Initial Catalog = AdsProject;
                                           Integrated Security = true;
                                           Encrypt = false;
                                           TrustServerCertificate = true;");
        }
    }
}
