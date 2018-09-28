
namespace Web.Api.Core.Domain
{
    public class User
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string UserName { get; }

        internal User(string firstName, string lastName, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
        }
    }
}
