using AuthSystem.Areas.Identity.Data;
using AuthSystem.Data;
using AuthSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthSystem
{
    public static class SeedData
    {
        public static void Initialize(AuthDbContext context)
        {
            context.Database.EnsureCreated(); // Ensure the database is created

            // Check if there are already users in the database
            if (!context.Users.Any())
            {
                // Add an initial user
                var user = new ApplicationUser
                {
                    UserName = "firstuser@example.com",
                    Email = "firstuser@example.com",
                    NormalizedUserName = "FIRSTUSER@EXAMPLE.COM",
                    NormalizedEmail = "FIRSTUSER@EXAMPLE.COM",
                    FirstName = "Tim",
                    LastName = "Nilsson",
                };

                // Set the password (for development purposes)
                var password = "FirstUser1!"; // Replace with your desired password
                user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, password);

                context.Users.Add(user);

                // Create a LeaveBalance for the user
                var leaveBalance = new LeaveBalance
                {
                    User = user,
                    VacationDays = 25,
                    SickDays = 5,
                    SickKidsDays = 10,
                };
                context.LeaveBalances.Add(leaveBalance);

                // Now, you can seed LeaveRequest for this user
                var leaveRequest = new LeaveRequest
                {
                    User = user,
                    LeaveType = LeaveType.Vacation,
                    LeaveBalance = leaveBalance,
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.Date.AddDays(5),
                    Status = Status.AwaitingApproval,
                };
                context.LeaveRequests.Add(leaveRequest);

                try
                {
                    context.SaveChanges(); // Save changes to the database
                    Console.WriteLine("Seed data successfully added.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while seeding data: {ex}");
                    throw; // Rethrow the exception for further investigation
                }
            }
        }
    }
}
