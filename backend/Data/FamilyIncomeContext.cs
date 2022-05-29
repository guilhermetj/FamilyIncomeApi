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
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("tb_categories");
            builder.Entity<Category>().HasKey(x => x.Id);
            builder.Entity<Category>().Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(x => x.Name).HasColumnName("name").IsRequired();

            builder.Entity<Expenditure>().ToTable("tb_expenditure");
            builder.Entity<Expenditure>().HasKey(x => x.Id);
            builder.Entity<Expenditure>().Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Entity<Expenditure>().Property(x => x.Description).HasColumnName("description").IsRequired();
            builder.Entity<Expenditure>().Property(x => x.CategoryId).HasColumnName("category_id").IsRequired();
            builder.Entity<Expenditure>().Property(x => x.Value).HasColumnName("value").IsRequired();
            builder.Entity<Expenditure>().Property(x => x.Date).HasColumnName("date");
            builder.Entity<Expenditure>().HasOne(x => x.Category).WithMany(e => e.Expenditure).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Revenue>().ToTable("tb_revenue");
            builder.Entity<Revenue>().HasKey(x => x.Id);
            builder.Entity<Revenue>().Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Entity<Revenue>().Property(x => x.Description).HasColumnName("description").IsRequired();
            builder.Entity<Revenue>().Property(x => x.Value).HasColumnName("value").IsRequired();
            builder.Entity<Revenue>().Property(x => x.Date).HasColumnName("date");
  
        }
    }
}
