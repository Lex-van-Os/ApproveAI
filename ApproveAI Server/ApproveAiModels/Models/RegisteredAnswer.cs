using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiModels.Models
{
    public class RegisteredAnswer : BaseEntity
    {
        public long Id { get; set; }
        public string Answer { get; set; } = string.Empty;
        public bool? Approved { get; set; }
        public bool? Rejected { get; set; }
        public long ApprovalRequestId { get; set; }
        public ApprovalRequest ApprovalRequest { get; set; }
        public long RegisteredById { get; set; }
        public User RegisteredBy { get; set; }
    }
}
