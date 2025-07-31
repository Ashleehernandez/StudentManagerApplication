using Microsoft.EntityFrameworkCore;
using StudentManagerApplication.Domain.Entity;

namespace StudentManagerApplication.Intraestructura.Data
{
    public class ApplicationDbContextDB : DbContext
    {
        public ApplicationDbContextDB(DbContextOptions<ApplicationDbContextDB> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(s => s.LastName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(s => s.Email).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber).HasMaxLength(15);
            modelBuilder.Entity<Student>().Property(s => s.Address).HasMaxLength(250);
            modelBuilder.Entity<Student>().Property(s => s.City).HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(s => s.State).HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(s => s.ZipCode).HasMaxLength(20);
        }
    }
}
