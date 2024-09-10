using System;

namespace Domain.ViewModels
{
    public class RolePermissionList
    {
        public int Id { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; } // Assuming you want to include role name
        public int PermissionId { get; set; }
        public string PermissionCode { get; set; } // Assuming you want to include permission code
        public bool HasMasterAccess { get; set; }
    }
}

