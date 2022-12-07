namespace NZWalks.API.Models.Domain
{
    public sealed class Role 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<User_Role> UserRoles { get; set; }
    }
}
