using ApproveAiModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiModels.Models
{
    public class ApprovalStep : BaseEntity
    {
        public long Id { get; set; }
        public ApprovalStatus? Status { get; set; }
        public int StepIndex { get; set; }
        public long? ApprovedById { get; set; }
        public User? ApprovedBy { get; set; } = new User();
        public long? RejectedById { get; set; }
        public User? RejectedBy { get; set; } = new User();
        public long ApprovalRequestId { get; set; }
        public ApprovalRequest ApprovalRequest { get; set; } = new ApprovalRequest();
    }
}
