using Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRolePermissionService
    {
        Task<List<RolePermissionList>> GetAllRolePermissionsAsync();
        Task<RolePermissionAddEdit> GetRolePermissionByIdAsync(int id);
        Task<int> AddRolePermissionAsync(RoleAddEdit model, long userId);
        Task<int> UpdateRolePermissionAsync(RolePermissionAddEdit model, long userId);
        Task DeleteRolePermissionAsync(int id, long userId);
    }
}
