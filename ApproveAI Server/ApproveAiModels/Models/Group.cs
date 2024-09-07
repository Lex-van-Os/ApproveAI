using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApproveAiModels.Models
{
    public class Group : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Index { get; set; }
        public ICollection<User>? Users { get; set; } = new List<User>();
    }
}
