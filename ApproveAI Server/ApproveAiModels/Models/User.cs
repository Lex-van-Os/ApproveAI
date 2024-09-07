using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiModels.Models
{
    public class User : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool? HasAdministratorAccess { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; } = new Role();
        public ICollection<Group>? Groups { get; set; } = new List<Group>();
        public ICollection<RegisteredAnswer>? RegisteredAnswers { get; set; } = new List<RegisteredAnswer>();
    }
}
