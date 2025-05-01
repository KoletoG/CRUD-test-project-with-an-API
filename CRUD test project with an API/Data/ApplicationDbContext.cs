using CRUD_test_project_with_an_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUD_test_project_with_an_API.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Address>().HasOne(x => x.User)
                                 .WithOne(x => x.Address)
                                 .HasForeignKey<Address>(x => x.UserId); // For this project, one person can have only one address and vice versa
    }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<User> Users { get; set; }
}
