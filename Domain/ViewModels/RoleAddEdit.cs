using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class RoleAddEdit
    {
        public RoleAddEdit()
        {
            Permissions = new List<PermissionAddEdit>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public List<PermissionAddEdit> Permissions { get; set; }
    }
}
