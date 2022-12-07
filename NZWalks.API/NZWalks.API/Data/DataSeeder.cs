using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public sealed class DataSeeder
    {
        private readonly NZWalksDbContext _context;

        public DataSeeder(NZWalksDbContext context)
        {
            _context = context; 
        }

        public void Seed()
        {
            if (!_context.Roles.Any())
            {
                _context.Roles.AddRange(new List<Role>() {
                new Models.Domain.Role
                {
                    Id = Guid.NewGuid(),
                    Name = "writer"
                },
                new Models.Domain.Role
                {
                    Id = Guid.NewGuid(),
                    Name = "reader"
                }});
            }

            var readerRole = _context.Roles.FirstOrDefault(x => x.Name.Equals("reader"));
            var writerRole = _context.Roles.FirstOrDefault(x => x.Name.Equals("writer"));

            var readerUserId = Guid.NewGuid();
            var writerUserId = Guid.NewGuid();

            if (!_context.Users.Any())
            {                
                _context.Users.AddRange(new List<User>()
                {
                    new User
                    {
                        Id = readerUserId,
                        FirstName = "Joe",
                        LastName = "Doe",
                        EmailAddress = "joe@doe.com",
                        Username = "joedoe",
                        Password = "sdFD78s.s#*Flfs-ww",
                    },
                    new User
                    {
                        Id = writerUserId,
                        FirstName = "Joe",
                        LastName = "Doe",
                        EmailAddress = "joe@doe.com",
                        Username = "joedoe",
                        Password = "sdFD78s.s#*Flfs-ww",
                    },
                });                
            }

            _context.User_Roles.Add(new User_Role
            {
                Id = Guid.NewGuid(),
                RoleId = readerRole.Id,
                UserId = readerUserId
            });
            _context.User_Roles.Add(new User_Role
            {
                Id = Guid.NewGuid(),
                RoleId = writerRole.Id,
                UserId = writerUserId
            });

            _context.SaveChanges();
        }
    }
}
