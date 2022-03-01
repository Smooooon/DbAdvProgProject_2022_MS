﻿using MusterAG.DataAccessLayer.Dao;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DbSet<CustomerDao> Customers { get; set; }
        public DbSet<AddressDao> Addresses { get; set; }
        public DbSet<TownDao> Towns { get; set; }
        public DbSet<CountryDao> Countries { get; set; }
        public DbSet<ArticleDao> Articles { get; set; }
        public DbSet<ArticleGroupDao> ArticleGroups { get; set; }
        public DbSet<OrderDao> Orders { get; set; }
        public DbSet<PositionDao> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Weiterer Code
            modelBuilder.Entity<TownDao>().HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MusterAG;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}