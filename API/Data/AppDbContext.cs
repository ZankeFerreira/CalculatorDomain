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
        modelBuilder.Entity<Calculation>().HasData(new Calculation{
            Id = 2,
            Left = 2,
            Right= 5,
            Operation = OperationType.Add,
            Result = 5,
            CreatedAt = DateTime.UtcNow
        }
        );
        //.HasKey(c => c.Id);

    

    }
}