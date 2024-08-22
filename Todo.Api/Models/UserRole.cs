namespace Todo.Api.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public string UserRoleName { get; set; } = null!;

        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<UserCredential> UserCredentials { get; set; } = new List<UserCredential>();
    }
}
