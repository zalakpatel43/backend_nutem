using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Permission
    {
        public Permission()
        {
            RolePermissions = new List<RolePermissionMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
     //   public int ModuleGroupId { get; set; }
        public int Priority { get; set; }

     //   public virtual ModuleGroup ModuleGroup { get; set; }
        public virtual ICollection<RolePermissionMap> RolePermissions { get; set; }
    }
}
