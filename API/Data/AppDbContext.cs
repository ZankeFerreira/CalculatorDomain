using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CalculatorDomain.Domain;
using Microsoft.AspNetCore.Identity;



public class AppDbContext: IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Calculation> Calculation {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Calculation>().HasKey(c => c.Id);

    

    }
}