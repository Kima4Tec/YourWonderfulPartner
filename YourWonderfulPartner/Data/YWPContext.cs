﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using YourWonderfulPartner.Model;

namespace YourWonderfulPartner.Data
{
    public class YWPContext : DbContext
    {
        public YWPContext(DbContextOptions<YWPContext> options)
            : base(options)
        {
        }
        public DbSet<CriteriaData> Criteria { get; set; }

        public DbSet<UserData> User { get; set; }
        public DbSet<MessagesData> Message { get; set; }
        public DbSet<LikesData> Likes { get; set; }
        public DbSet<MatchesData> Matches { get; set; }


        //Configure all decimal properties in EF Core model to have a precision of 10 and a scale of 2.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    {
                        property.SetPrecision(10);
                        property.SetScale(2);
                    }
                }
            }
        }
    }
}
