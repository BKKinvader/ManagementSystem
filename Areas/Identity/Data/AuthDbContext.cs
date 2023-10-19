using AuthSystem.Areas.Identity.Data;
using AuthSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AuthSystem.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{

    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveBalance> LeaveBalances { get; set; }

    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }



    public DbSet<AuthSystem.Models.LeaveRequest>? LeaveRequest { get; set; }
}
