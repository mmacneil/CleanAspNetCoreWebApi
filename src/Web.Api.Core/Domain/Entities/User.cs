
namespace Web.Api.Core.Domain.Entities
{
    public class User
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string UserName { get; }
        public string PasswordHash { get; }

        internal User(string firstName, string lastName, string email, string userName, string id=null,string passwordHash=null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            PasswordHash = passwordHash;
        }
    }
}
