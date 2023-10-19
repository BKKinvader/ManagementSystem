using AuthSystem.Areas.Identity.Data;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSystem.Models
{
    public class LeaveBalance
    {
        public int Id { get; set; }
        [ForeignKey(name: "UserId")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; } 
        public int VacationDays { get; set; } 
        public int SickDays { get; set; }
        public int SickKidsDays { get; set; }

       

        // Additional properties if needed
    }
}
