using AuthSystem.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSystem.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Foreign key to link the LeaveRequest to the user
        public ApplicationUser User { get; set; } // Navigation property for ApplicationUser
        [ForeignKey("LeaveBalanceId")]
        public int LeaveBalanceId { get; set; } // Foreign key to link the LeaveRequest to the LeaveBalance
        public LeaveBalance LeaveBalance { get; set; } // Navigation property for LeaveBalance

        public Status Status { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }

    public enum LeaveType
    {
        Vacation,
        Sick,
        SickKids
    }

    public enum Status
    {
        AwaitingApproval,
        Approved,
        Rejected,
        Canceled
    }
}
