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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Expenditure>().ToTable("tb_familyIcome");
            builder.Entity<Expenditure>().HasKey(x => x.id);
            builder.Entity<Expenditure>().Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Entity<Expenditure>().Property(x => x.Description).HasColumnName("description").IsRequired();
            builder.Entity<Expenditure>().Property(x => x.Value).HasColumnName("value").IsRequired();
            builder.Entity<Expenditure>().Property(x => x.Date).HasColumnName("date");
        }
    }
}
