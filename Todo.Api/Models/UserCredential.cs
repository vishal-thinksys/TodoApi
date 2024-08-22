namespace Todo.Api.Models
{
    public class UserCredential
    {
        public int Id { get; set; }

        public int? UserRoleId { get; set; }

        public string UserName { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public DateTime? CreatedOn { get; set; }

        public virtual UserRole? UserRole { get; set; }
    }
}
