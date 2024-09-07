using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApproveAiModels.Enums;

namespace ApproveAiModels.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ApprovalRequest : BaseEntity
    {
        public long Id { get; set; }
        public DateTime? ApprovalDeadline { get; set; }
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Open;
        public long ApprovalWorkflowId { get; set; }
        public ApprovalWorkflow ApprovalWorkflow { get; set; } = new ApprovalWorkflow();
        public long RegisteredAnswerId { get; set; }
        public RegisteredAnswer RegisteredAnswer { get; set; } = new RegisteredAnswer();
        public ICollection<ApprovalStep> ApprovalSteps { get; set; } = new List<ApprovalStep>();
    }
}
