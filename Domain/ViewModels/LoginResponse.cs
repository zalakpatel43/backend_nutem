using Domain.Entities;
using Microsoft.AspNetCore.Identity;

public class LoginResponse
{
    public LoginResponse()
    {
        this.Permissions = new List<string>();
        //this.Roles = new List<IdentityRole>();
        this.RolePermissions = new List<RolePermission>();
    }

    public long? Id { get; set; }
    public string Token { get; set; }
    public string DisplayName { get; set; }
    public DateTime ExpireAt { get; set; }
    public string UserImageFilePath { get; set; }
    public bool IsAdmin { get; set; }
    public string SignaturePath { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    //public List<IdentityRole> Roles { get; set; }
    public List<IdentityRole<long>> Role { get; set; }
    public List<string> Permissions { get; set; }
    public List<RolePermission> RolePermissions { get; set; }
    public User User { get; set; }
}

public class RolePermission
{
    public long Id { get; set; }
    public long RoleId { get; set; }
    public long PermissionId { get; set; }
    public bool HasMasterAccess { get; set; }
    public string ActionName { get; set; }
}