using FamilyIncomeApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyIncomeApi.Data
{
    public class FamilyIncomeContext : DbContext
    {
        public FamilyIncomeContext(DbContextOptions<FamilyIncomeContext> options) : base(options)
        {
        }
        public DbSet<Expenditure> expenditures { get; set; }
        public DbSet<Revenue> revenues { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Expenditure>().ToTable("tb_expenditure");
            builder.Entity<Expenditure>().HasKey(x => x.id);
            builder.Entity<Expenditure>().Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Entity<Expenditure>().Property(x => x.Description).HasColumnName("description").IsRequired();
            builder.Entity<Expenditure>().Property(x => x.Value).HasColumnName("value").IsRequired();
            builder.Entity<Expenditure>().Property(x => x.Date).HasColumnName("date");
            builder.Entity<Expenditure>().Property(x => x.Caregory).HasColumnName("category");

            builder.Entity<Revenue>().ToTable("tb_revenue");
            builder.Entity<Revenue>().HasKey(x => x.id);
            builder.Entity<Revenue>().Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Entity<Revenue>().Property(x => x.Description).HasColumnName("description").IsRequired();
            builder.Entity<Revenue>().Property(x => x.Value).HasColumnName("value").IsRequired();
            builder.Entity<Revenue>().Property(x => x.Date).HasColumnName("date");
            builder.Entity<Revenue>().Property(x => x.Caregory).HasColumnName("category");
        }
    }
}
