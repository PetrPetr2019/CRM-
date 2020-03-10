using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompanyMailingList
{
    public partial class UserInformDBContext : DbContext
    {
        public UserInformDBContext()
        {
        }

        public UserInformDBContext(DbContextOptions<UserInformDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Informations> Informations { get; set; }
        public virtual DbSet<Documents> Documents { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UserInformDB;Trusted_Connection=true;");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Document>();
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
