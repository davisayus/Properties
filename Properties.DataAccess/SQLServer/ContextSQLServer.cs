using Microsoft.EntityFrameworkCore;
using Properties.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.DataAccess.SQLServer
{
    public class ContextSQLServer: DbContext
    {

        string _connectionString = "";
        public string ConnectionString { get { return _connectionString; } set { _connectionString = value; } }

        public ContextSQLServer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ContextSQLServer()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString.Length==0)
                _connectionString = @"data source=(local);Integrated Security=True; initial catalog=PropertiesDb";

            optionsBuilder.UseSqlServer(_connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concept>().HasKey(c => new { c.IdConcept });
            modelBuilder.Entity<Feature>().HasKey(f => new { f.IdFeature });
            modelBuilder.Entity<Owner>().HasKey(o => new { o.IdOwner });
            modelBuilder.Entity<Property>().HasKey(p => new { p.IdProperty });
            modelBuilder.Entity<PropertyFeature>().HasKey(pf => new { pf.IdPropertyFeature });
            modelBuilder.Entity<PropertyImage>().HasKey(pi => new { pi.IdPropertyImage });
            modelBuilder.Entity<PropertySale>().HasKey(ps => new { ps.IdPropertySale });
            modelBuilder.Entity<PropertyTrace>().HasKey(pt => new { pt.IdPropertyTrace });
            modelBuilder.Entity<PropertyPost>().HasKey(pp => new { pp.IdPropertyPost });
            modelBuilder.Entity<TypesProperty>().HasKey(tp => new { tp.IdType });

            modelBuilder.Entity<Concept>().Property(c => c.IdConcept).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Feature>().Property(f => f.IdFeature).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Owner>().Property(o => o.IdOwner).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Property>().Property(p => p.IdProperty).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<PropertyFeature>().Property(pf => pf.IdPropertyFeature).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<PropertyImage>().Property(pi => pi.IdPropertyImage).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<PropertyTrace>().Property(pt => pt.IdPropertyTrace).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<PropertyPost>().Property(pp => pp.IdPropertyPost).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<TypesProperty>().Property(tp => tp.IdType).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);


            modelBuilder.Entity<Property>()
                .HasOne(p => p.Owners)
                .WithMany(o => o.Property)
                .HasForeignKey(p => p.IdOwner);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.TypesProperties)
                .WithMany(tp => tp.Property)
                .HasForeignKey(p => p.IdType);

            modelBuilder.Entity<PropertyFeature>()
                .HasOne(pf => pf.Property)
                .WithMany(p => p.PropertyFeatures)
                .HasForeignKey(pf => pf.IdProperty);

            modelBuilder.Entity<PropertyImage>()
                .HasOne(pi => pi.Property)
                .WithMany(p => p.PropertyImages)
                .HasForeignKey(pf => pf.IdProperty);

            modelBuilder.Entity<PropertyPost>()
                .HasOne(pi => pi.Property)
                .WithMany(p => p.PropertyPosts)
                .HasForeignKey(pf => pf.IdProperty);

            modelBuilder.Entity<PropertySale>()
                .HasOne(pi => pi.Property)
                .WithMany(p => p.PropertySales)
                .HasForeignKey(pf => pf.IdProperty);

            modelBuilder.Entity<PropertyTrace>()
                .HasOne(pi => pi.Property)
                .WithMany(p => p.PropertyTraces)
                .HasForeignKey(pf => pf.IdProperty);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<TypesProperty> TypesProperties { get; set; }
        public DbSet<PropertyFeature> PropertyFeatures { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }
        public DbSet<PropertyPost> PropertyPosts { get; set; }


    }
}
