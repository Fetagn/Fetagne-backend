namespace Fetagne.Domain.Entities
{
    public class User
    {
        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email.ToLower();
            Password = password;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        private string Password { get; set; } = null!;

        public bool VerifyPassword(string password)
        {
            if (password == Password)
            {
                return true;
            }
            return false;
        }
    }
}
