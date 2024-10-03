using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly RoleManager<Role> _roleManager;

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager,  IJwtTokenService jwtTokenService, RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _roleManager = roleManager;
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

            var response = new LoginResponse();
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                var token = await _jwtTokenService.GenerateTokenAsync(username, user.Id); // Assume you have a service to generate JWT tokens
                var roles = await _userManager.GetRolesAsync(user);

                // Fetch role details
                var roleDetails = await GetRoleDetailsAsync(roles);

                // Convert Role objects to IdentityRole objects
                var identityRoles = roleDetails.Select(role => new IdentityRole<long>
                {
                    Id = role.Id, // Assuming Role.Id is long, convert to string
                    Name = role.Name,
                    NormalizedName = role.NormalizedName,
                    ConcurrencyStamp = role.ConcurrencyStamp
                }).ToList();

                // Populate the response
                response.Id = user.Id;
                response.Token = token;
                response.DisplayName = user.UserName; 
             
                response.ExpireAt = DateTime.UtcNow.AddHours(1);
                response.IsAdmin = roles.Contains("Admin");
                response.IsSuccess = true;
                response.Message = "Login successful";

                response.Role = identityRoles;
                response.Permissions = await GetUserPermissionsAsync(identityRoles); // Implement this method if needed

                // Populate User with full user details
                response.User = new User
                {
                    Id = user.Id,
                    Name=user.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    // Add other necessary properties here
                };
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Invalid username or password";
            }

            return response;
        }


        //public async Task<List<string>> GetUserPermissionsAsync(User user)
        //{
        // // Retrieve roles of the user
        //    var roles = await _userManager.GetRolesAsync(user);
    
        //    // Fetch permissions for these roles
        //    var permissions = new List<string>();
    
        //    foreach (var role in roles)
        //    {
        //        // Assuming you have a method to get permissions by role
        //         var rolePermissions = await GetPermissionsByRoleAsync(role);
        //         permissions.AddRange(rolePermissions);
        //    }

        //        return permissions.Distinct().ToList(); // Return unique permissions
        //}



        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }
        private async Task<List<Role>> GetRoleDetailsAsync(IList<string> roleNames)
        {
            var roleDetails = new List<Role>();

            foreach (var roleName in roleNames)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    roleDetails.Add(role);
                }
            }

            return roleDetails;
        }

        private async Task<List<long>> GetPermissionIdsByRoleIdAsync(long roleId)
        {
            using var httpClient = new HttpClient();
          //  var response = await httpClient.GetAsync($"http://192.168.1.147:8989/api/RolePermission/GetById/{roleId}");

            var response = await httpClient.GetAsync($"https://localhost:7032/api/RolePermission/GetById/{roleId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            // Deserialize the response into the LoginResponse object to use RolePermissions
            var rolePermissionData = JsonConvert.DeserializeObject<LoginResponse>(content);
            return rolePermissionData.RolePermissions.Select(rp => rp.PermissionId).ToList();
        }

        private async Task<List<Permission>> GetAllPermissionsAsync()
        {
            using var httpClient = new HttpClient();
          //  var response = await httpClient.GetAsync("http://192.168.1.147:8989/api/Permission/GetAllPermissions");

            var response = await httpClient.GetAsync("https://localhost:7032/api/Permission/GetAllPermissions");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Permission>>(content);
        }
        public async Task<List<string>> GetUserPermissionsAsync(List<IdentityRole<long>> roles)
        {
            var permissions = new List<string>();

            var permissionTypeMapping = GetPermissionTypeMapping(); // Ensure this method returns Dictionary<long, string>
            var allPermissions = await GetAllPermissionsAsync();

            foreach (var role in roles)
            {
                var roleId = role.Id; // Use the Id from IdentityRole<long>
                var permissionIds = await GetPermissionIdsByRoleIdAsync(roleId);

                foreach (var permissionId in permissionIds)
                {
                    var permission = allPermissions.FirstOrDefault(p => p.Id == permissionId);
                    if (permission != null)
                    {
                        var permissionType = permissionTypeMapping.TryGetValue(permission.PermissionTypeId, out var typeName)
                            ? typeName
                            : "Unknown";
                        permissions.Add($"{permission.Name} ({permission.Code}) - {permissionType}");
                    }
                }
            }

            return permissions.Distinct().ToList();
        }


        private Dictionary<long, string> GetPermissionTypeMapping()
        {
            return new Dictionary<long, string>
            {
                    { 72L, "Add" },
                    { 73L, "Edit" },
                    { 74L, "View" },
                    { 75L, "Delete" },
                    { 76L, "Export" }
            };
        }



    }

}
