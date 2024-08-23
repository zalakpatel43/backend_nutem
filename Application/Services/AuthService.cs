using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
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

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager,  IJwtTokenService jwtTokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

            var response = new LoginResponse();
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                var token = await _jwtTokenService.GenerateTokenAsync(username); // Assume you have a service to generate JWT tokens
                var roles = await _userManager.GetRolesAsync(user);

                // Populate the response
                response.Id = user.Id;
                response.Token = token;
                response.DisplayName = user.UserName; // Adjust as needed
                response.ExpireAt = DateTime.UtcNow.AddHours(1); // Example expiry time
               // response.UserImageFilePath = user.ProfileImagePath; // Adjust if you have this property
                response.IsAdmin = roles.Contains("Admin");
                response.IsSuccess = true;
                response.Message = "Login successful";

                // Convert roles to List<IdentityRole> if you have role objects
                response.Roles = roles.Select(role => new IdentityRole { Name = role }).ToList();

                // Fetch user permissions if applicable
                response.Permissions = await GetUserPermissionsAsync(user); // Implement this method if needed

                // Populate User with full user details
                response.User = new User
                {
                    Id = user.Id,
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

        public async Task<List<string>> GetUserPermissionsAsync(User user)
{
    // Retrieve roles of the user
    var roles = await _userManager.GetRolesAsync(user);
    
    // Fetch permissions for these roles
    var permissions = new List<string>();
    
    foreach (var role in roles)
    {
        // Assuming you have a method to get permissions by role
        var rolePermissions = await GetPermissionsByRoleAsync(role);
        permissions.AddRange(rolePermissions);
    }

    return permissions.Distinct().ToList(); // Return unique permissions
}

private async Task<List<string>> GetPermissionsByRoleAsync(string roleName)
{
    // Fetch permissions from database or any other data source
    // Example using an in-memory list of permissions (replace with actual implementation)
    var allRolePermissions = new Dictionary<string, List<string>>
    {
        { "Admin", new List<string> { "Read", "Write", "Delete", "Update" } },
        { "User", new List<string> { "Read" } },
        { "Manager", new List<string> { "Read", "Update" } }
    };

    // Simulate async database operation
    await Task.Delay(100); // Simulating async operation
    return allRolePermissions.ContainsKey(roleName) ? allRolePermissions[roleName] : new List<string>();
}


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
    }

}
