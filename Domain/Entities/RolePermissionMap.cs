using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RolePermissionMap
    {
        public int Id { get; set; }
        public long RoleId { get; set; }
        public int PermissionId { get; set; }
        public bool HasMasterAccess { get; set; }

        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
