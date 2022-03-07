using MusterAG.DataAccessLayer.Dao;
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

            //Beziehungen
            modelBuilder.Entity<CustomerDao>().HasOne<AddressDao>(c => c.Address).WithMany(a => a.Customers).HasForeignKey(c => c.AddressId);
            modelBuilder.Entity<AddressDao>().HasOne<TownDao>(a => a.Town).WithMany(t => t.Addresses).HasForeignKey(a => a.TownId);
            modelBuilder.Entity<TownDao>().HasOne<CountryDao>(t => t.Country).WithMany(c => c.Towns).HasForeignKey(t => t.CountryId);
            modelBuilder.Entity<PositionDao>().HasOne<OrderDao>(p => p.Order).WithMany(o => o.Positions).HasForeignKey(p => p.OrderId);
            modelBuilder.Entity<ArticleDao>().HasOne<ArticleGroupDao>(a => a.ArticleGroup).WithMany(g => g.Articles).HasForeignKey(a => a.ArticleGroupId);
            modelBuilder.Entity<ArticleGroupDao>().HasOne<ArticleGroupDao>();

            //Testdaten
            //Adressen
            modelBuilder.Entity<CountryDao>().HasData(new CountryDao() { Id = 1, Name = "Schweiz" });
            modelBuilder.Entity<CountryDao>().HasData(new CountryDao() { Id = 2, Name = "Deutschland" });
            modelBuilder.Entity<TownDao>().HasData(new TownDao() { Id = 1, Name = "St.Gallen", PLZ = 9000, CountryId = 1 });
            modelBuilder.Entity<TownDao>().HasData(new TownDao() { Id = 2, Name = "Hauptwil", PLZ = 9213, CountryId = 1 });
            modelBuilder.Entity<TownDao>().HasData(new TownDao() { Id = 3, Name = "Konstanz", PLZ = 1111, CountryId = 2 });
            modelBuilder.Entity<AddressDao>().HasData(new AddressDao() { Id = 1, Street = "Teststrasse 1", TownId = 1, });
            modelBuilder.Entity<AddressDao>().HasData(new AddressDao() { Id = 2, Street = "Teststrasse 2", TownId = 1 });
            modelBuilder.Entity<AddressDao>().HasData(new AddressDao() { Id = 3, Street = "Lolastrasse 1", TownId = 2 });
            modelBuilder.Entity<AddressDao>().HasData(new AddressDao() { Id = 4, Street = "Lolastrasse 2", TownId = 2 });

            //Cusomer
            modelBuilder.Entity<CustomerDao>().HasData(new CustomerDao() { Id = 1, Name = "Max Muster", Email = "max.muster@muster.com", Website = "muster.com", Password = "dasPasswort", AddressId = 1 });
            modelBuilder.Entity<CustomerDao>().HasData(new CustomerDao() { Id = 2, Name = "Manuela Sturzi", Email = "manuela.sturzi@sturzi.com", Website = "sturzi.com", Password = "dasPasswort2", AddressId = 2 });

            //Artikel Gruppen
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 1, Name = "Lebensmittel" });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 2, Name = "Getränke", HigherLevelArticleGroupId = 1 });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 3, Name = "Alkohol", HigherLevelArticleGroupId = 2 });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 4, Name = "Non-Alkohol", HigherLevelArticleGroupId = 2 });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 5, Name = "Likör", HigherLevelArticleGroupId = 3 });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 6, Name = "Kreuterschnaps", HigherLevelArticleGroupId = 3 });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 7, Name = "Fleisch", HigherLevelArticleGroupId = 2 });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 8, Name = "Obst", HigherLevelArticleGroupId = 2 });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 9, Name = "Getreide", HigherLevelArticleGroupId = 2 });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 10, Name = "Teigwaren", HigherLevelArticleGroupId = 9 });
            modelBuilder.Entity<ArticleGroupDao>().HasData(new ArticleGroupDao() { Id = 11, Name = "Brot", HigherLevelArticleGroupId = 9 });

            //Artikel
            modelBuilder.Entity<ArticleDao>().HasData(new ArticleDao() { Id = 1, Name = "Vollkornbrot", Price = 4.20M, ArticleGroupId = 9 });
            modelBuilder.Entity<ArticleDao>().HasData(new ArticleDao() { Id = 2, Name = "Zopf", Price = 5.80M, ArticleGroupId = 9 });
            modelBuilder.Entity<ArticleDao>().HasData(new ArticleDao() { Id = 3, Name = "Appenzeller", Price = 34.00M, ArticleGroupId = 3 });
            modelBuilder.Entity<ArticleDao>().HasData(new ArticleDao() { Id = 4, Name = "Eierlikör", Price = 8.70M, ArticleGroupId = 3 });
            modelBuilder.Entity<ArticleDao>().HasData(new ArticleDao() { Id = 5, Name = "Sinalco", Price = 3.40M, ArticleGroupId = 2 });

            //Bestellungen
            modelBuilder.Entity<OrderDao>().HasData(new OrderDao() { Id = 3, Ordered = DateTime.Parse("2022-02-27 08:30:00.000"), CustomerId = 1});
            modelBuilder.Entity<OrderDao>().HasData(new OrderDao() { Id = 2, Ordered = DateTime.Parse("2022-03-01 12:05:00.000"), CustomerId = 2 });
            modelBuilder.Entity<OrderDao>().HasData(new OrderDao() { Id = 1, Ordered = DateTime.Parse("2022-03-02 15:30:00.000"), CustomerId = 1 });

            //Positionen
            modelBuilder.Entity<PositionDao>().HasData(new PositionDao() { Id = 1, Quantity = 2, ArticleId = 1, OrderId =  1});
            modelBuilder.Entity<PositionDao>().HasData(new PositionDao() { Id = 2, Quantity = 1, ArticleId = 4, OrderId =  1});
            modelBuilder.Entity<PositionDao>().HasData(new PositionDao() { Id = 3, Quantity = 2, ArticleId = 3, OrderId =  2});
            modelBuilder.Entity<PositionDao>().HasData(new PositionDao() { Id = 4, Quantity = 6, ArticleId = 5, OrderId =  2});
            modelBuilder.Entity<PositionDao>().HasData(new PositionDao() { Id = 5, Quantity = 1, ArticleId = 2, OrderId =  3});
            modelBuilder.Entity<PositionDao>().HasData(new PositionDao() { Id = 6, Quantity = 6, ArticleId = 5, OrderId =  3});

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MusterAG;Trusted_Connection=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}