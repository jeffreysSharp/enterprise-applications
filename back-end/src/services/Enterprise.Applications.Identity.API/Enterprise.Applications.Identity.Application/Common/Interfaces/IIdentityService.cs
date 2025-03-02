namespace Enterprise.Applications.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        // User section
        Task<(string isSucceed, string userId)> CreateUserAsync(string userName, string password, string email, string fullName, List<string> roles);
        Task<string> SigninUserAsync(string userName, string password);
        Task<string> GetUserIdAsync(string userName);
        Task<(string userId, string fullName, string UserName, string email, IList<string> roles)> GetUserDetailsAsync(string userId);
        Task<(string userId, string fullName, string UserName, string email, IList<string> roles)> GetUserDetailsByUserNameAsync(string userName);
        Task<string> GetUserNameAsync(string userId);
        Task<string> DeleteUserAsync(string userId);
        Task<bool> IsUniqueUserName(string userName);
        Task<List<(string id, string fullName, string userName, string email)>> GetAllUsersAsync();
        Task<List<(string id, string userName, string email, IList<string> roles)>> GetAllUsersDetailsAsync();
        Task<string> UpdateUserProfile(string id, string fullName, string email, IList<string> roles);

        // Role Section
        Task<string> CreateRoleAsync(string roleName);
        Task<string> DeleteRoleAsync(string roleId);
        Task<List<(string id, string roleName)>> GetRolesAsync();
        Task<(string id, string roleName)> GetRoleByIdAsync(string id);
        Task<string> UpdateRole(string id, string roleName);

        // User's Role section
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<List<string>> GetUserRolesAsync(string userId);
        Task<string> AssignUserToRole(string userName, IList<string> roles);
        Task<string> UpdateUsersRole(string userName, IList<string> usersRole);
    }
}
