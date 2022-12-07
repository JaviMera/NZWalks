using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IUserRepository
    {
        Task<User?> AuthenticateAsync(string username, string password);
    }

    public sealed class UserRepository : IUserRepository
    {
        private readonly NZWalksDbContext _context;

        public UserRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(
                user => user.Username.ToLower().Equals(username.ToLower())
                && user.Password.Equals(password)
            );

            if (user == null)
                return null;

            var userRoles = await _context.User_Roles
                .Where(userRole => userRole.UserId.Equals(user.Id))
                .Select(userRole => userRole.RoleId)
                .ToListAsync();

            var roles = await _context.Roles.Where(role => userRoles.Contains(role.Id))
                .Select(role => role.Name)
                .ToListAsync();

            user.Roles = roles;;
            return user;
        }
    }
}
