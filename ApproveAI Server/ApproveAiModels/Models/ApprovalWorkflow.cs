using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiModels.Models
{
    /// <summary>
    /// Model for the ApprovalWorkFlow, which is created by users with administration access. ApprovalWorkflows define the steps that must be taken to approve or reject a RegisteredAnswer.
    /// </summary>
    public class ApprovalWorkflow : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? ApprovalTimeLimit { get; set; }
        public ICollection<Group>? ApprovalGroups { get; set; } = new List<Group>();
        public ICollection<ApprovalRequest>? ApprovalRequests { get; set; } = new List<ApprovalRequest>();
        public ICollection<Role>? PrivilegedRoles { get; set; } = new List<Role>();
    }
}
